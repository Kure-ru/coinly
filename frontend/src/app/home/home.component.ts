import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { TimelineModule } from 'primeng/timeline';
import { ChipModule } from 'primeng/chip';
import { SpeedDial } from 'primeng/speeddial';
import { DatePicker } from 'primeng/datepicker';
import { Observable } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import {Apollo, QueryRef} from 'apollo-angular';
import {formatDate, NgIf} from '@angular/common';
import { GET_ACCOUNT_AND_TRANSACTIONS } from '../../graphql/transactions.graphql';
import { Dialog } from 'primeng/dialog';
import { InputText } from 'primeng/inputtext';
import { TransactionsService } from '../transactions/transactions.service';
import { FormsModule } from '@angular/forms';
import { Select } from 'primeng/select';
import {SelectItem} from 'primeng/api';

export enum TransactionType {
  inflow = 'INFLOW',
  outflow = 'OUTFLOW'
}

@Component({
  selector: 'app-home',
  imports: [ButtonModule, CardModule, NgIf, TimelineModule, ChipModule, DatePicker, RouterLink, SpeedDial, Dialog, InputText, FormsModule, Select],
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  data$ =  new Observable();
  data: any;
  visible: boolean = false;
  amount: number = 0.0;
  category: string = '';
  payee: string = '';
  date: Date = new Date();
  transactionTypes: SelectItem[] = [
    { label: 'inflow', value: TransactionType.inflow },
    { label: 'outflow', value: TransactionType.outflow },
  ];
  type: SelectItem = this.transactionTypes[1];
  queryRef!: QueryRef<any, { id: number; accountId: number }>;


  constructor(private apollo: Apollo, private transactionService: TransactionsService) {}

  ngOnInit() {
    this.fetchTransactions();
  }

  onSave() {
    if (this.data.accountById.id) {
      this.transactionService.addTransaction(
        parseFloat(this.amount.toString()),
        this.category,
        this.payee,
        parseInt(this.data.accountById.id),
        this.date,
        this.type.value
      ).subscribe({
        next: response => {
          console.log('Transaction added', response);
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
      id: 1,
      accountId: 1
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
        console.log('Data fetched successfully:', result);
      },
      error: error => {
        console.error('Subscription error:', error);
      }
    });
  }

  protected readonly formatDate = formatDate;
}
