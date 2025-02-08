import {gql, TypedDocumentNode} from '@apollo/client/core';
import {Account} from './accounts.graphql';

interface Transaction {
  id: number;
  accountId: number;
  amount: number;
  category: string;
  merchant: string;
}

interface GetTransactionsByAccountIdResult {
  accountById: Account;
  transactions: Transaction[];
}

interface GetTransactionsByAccountIdVariables {
  id: number;
}

export const GET_ACCOUNT_AND_TRANSACTIONS: TypedDocumentNode<GetTransactionsByAccountIdResult, GetTransactionsByAccountIdVariables> =
  gql`query GetAccountAndTransactions($accountId: Int!) {
    accountById(id: $accountId) {
    id
    income
    expense
    balance
    }

    transactions(accountId: $accountId) {
      id
      amount
      category
      merchant
    }
}`
