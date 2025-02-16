import {Component} from '@angular/core';
import {TableModule} from 'primeng/table';
import {Apollo, QueryRef} from 'apollo-angular';
import {
  GET_ACCOUNT_AND_TRANSACTIONS,
  GetTransactionsByAccountIDResult,
  GetTransactionsByAccountIDVariables,
  Transaction
} from '../../graphql/transactions.graphql';
import {map} from 'rxjs/operators';
import {Observable} from 'rxjs';
import {Chip} from 'primeng/chip';
import {NgIf} from '@angular/common';
import {Select} from 'primeng/select';
import {FormsModule} from '@angular/forms';

@Component({
  selector: 'app-transactions',
  imports: [
    TableModule,
    Chip,
    NgIf,
    FormsModule
  ],
  templateUrl: './transactions.component.html',
})
export class TransactionsComponent {
  data$: Observable<any>;
  transactions: Transaction[] = [];


  constructor(private apollo: Apollo) {
    const queryRef: QueryRef<GetTransactionsByAccountIDResult, GetTransactionsByAccountIDVariables> = this.apollo.watchQuery({
      query: GET_ACCOUNT_AND_TRANSACTIONS,
      variables: {
        accountId: 1,
        accountIdForTransactions: 1,
        accountIdForCategories: 1
      }
    })

      this.data$ = queryRef.valueChanges.pipe(
        map(result => result.data.transactions)
      );

    this.data$.subscribe(result => this.transactions = result);
  }
}
