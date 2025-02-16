import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { TimelineModule } from 'primeng/timeline';
import { ChipModule } from 'primeng/chip';
import { SpeedDial } from 'primeng/speeddial';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { Apollo, QueryRef } from 'apollo-angular';
import { formatDate, NgIf } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SelectItem } from 'primeng/api';
import { AddTransactionComponent } from '../add-transaction/add-transaction.component';
import { TransactionsService } from '../transactions/transactions.service';
import { GET_ACCOUNT_AND_TRANSACTIONS } from '../../graphql/transactions.graphql';
import { Category } from '../../graphql/categories.graphql';

export enum TransactionType {
  inflow = 'INFLOW',
  outflow = 'OUTFLOW'
}

@Component({
  selector: 'app-home',
  imports: [ButtonModule, CardModule, NgIf, TimelineModule, ChipModule, RouterLink, SpeedDial, FormsModule, AddTransactionComponent],
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  data$ =  new Observable();
  data: any;
  visible: boolean = false;
  amount: number = 0.0;
  category: {label: string, value: number} = {label: '', value: 0};
  payee: string = '';
  date: Date = new Date();
  transactionTypes: SelectItem[] = [
    { label: 'inflow', value: TransactionType.inflow },
    { label: 'outflow', value: TransactionType.outflow },
  ];
  type: SelectItem = this.transactionTypes[1];
  queryRef!: QueryRef<any, { accountId: number; accountIdForTransactions: number; accountIdForCategories: number }>;
  categoryLabels: SelectItem[] = [];


  constructor(private apollo: Apollo, private transactionService: TransactionsService) {}

  ngOnInit() {
    this.fetchTransactions();
  }

  onSave() {
    if (this.data.accountById.id) {
      this.transactionService.addTransaction(
        parseFloat(this.amount.toString()),
        this.category.value,
        this.payee,
        parseInt(this.data.accountById.id),
        this.date,
        this.type.value
      ).subscribe({
        next: response => {
          this.visible = false;
          this.queryRef.refetch();
        },
        error: error => {
          console.error('Error adding transaction', error);
        }});
    }
  }

  fetchTransactions() {
    this.queryRef = this.apollo.watchQuery({
    query: GET_ACCOUNT_AND_TRANSACTIONS,
    variables: {
      accountId: 1,
      accountIdForTransactions: 1,
      accountIdForCategories: 1
    }
  })

    this.data$ = this.queryRef.valueChanges.pipe(
      map(result => result.data),
      catchError((error) => {
        console.error('Error fetching data:', error);
        return [];
      })
    );

    this.data$.subscribe({
      next: result => {
        this.data = result;
        if (this.data && this.data.categoriesByAccount){
          this.categoryLabels = this.data.categoriesByAccount.map((category: Category) => ({ label: category.name, value: category.id }));
        }
      },
      error: error => {
        console.error('Subscription error:', error);
      }
    });
  }

  protected readonly formatDate = formatDate;
}
