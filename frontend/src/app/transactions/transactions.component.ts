import { Component } from '@angular/core';
import {TableModule} from 'primeng/table';
import {Apollo} from 'apollo-angular';
import {GET_ACCOUNT_AND_TRANSACTIONS} from '../../graphql/transactions.graphql';
import {map} from 'rxjs/operators';
import {Observable} from 'rxjs';
import {Chip} from 'primeng/chip';
import {NgIf} from '@angular/common';

@Component({
  selector: 'app-transactions',
  imports: [
    TableModule,
    Chip,
    NgIf
  ],
  templateUrl: './transactions.component.html',
})
export class TransactionsComponent {
  data$: Observable<any>;
  transactions: any;

  constructor(private apollo: Apollo) {
    this.data$ = this.apollo.watchQuery({
      query: GET_ACCOUNT_AND_TRANSACTIONS,
      variables: {
        id: 1,
        accountId: 1
      }
    })
      .valueChanges
      .pipe(
        map(result => result.data.transactions)
      );
    this.data$.subscribe(result => this.transactions = result);
  }
}
