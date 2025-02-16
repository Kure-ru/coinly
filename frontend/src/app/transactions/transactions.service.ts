import { Injectable } from '@angular/core';
import { Apollo } from 'apollo-angular';
import {ADD_TRANSACTION} from '../../graphql/transactions.graphql';
import {TransactionType} from '../home/home.component';


@Injectable({
  providedIn: 'root'
})
export class TransactionsService {
  constructor(private apollo: Apollo) {}

  addTransaction(amount: number, categoryId: number, payee: string, accountId: number, date: Date, type: TransactionType) {
    return this.apollo.mutate({
      mutation: ADD_TRANSACTION,
      variables: {
        input: {
          amount,
          categoryId,
          payee,
          accountId,
          date,
          type
        }
      }
    });
  }
}
