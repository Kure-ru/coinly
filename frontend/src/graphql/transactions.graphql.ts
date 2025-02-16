import {gql} from '@apollo/client/core';
import {Account} from './accounts.graphql';

export interface Transaction {
  id: number;
  accountId: number;
  amount: number;
  category: string;
  payee: string;
  date: Date;
  type: TransactionType
}

enum TransactionType {
  inflow,
  outflow
}

export interface GetTransactionsByAccountIDResult {
  accountById: Account;
  transactions: Transaction[];
}

export interface GetTransactionsByAccountIDVariables {
  id: number;
  accountId: number;
}

export const GET_ACCOUNT_AND_TRANSACTIONS = gql`
  query GetAccountAndTransactions($id: Int!, $accountId: Int!) {
    accountById(id: $id) {
      id
      income
      expense
      balance
    }
    transactions(accountId: $accountId) {
      id
      amount
      category
      payee
      type
      date
    }
  }
`;

export const ADD_TRANSACTION = gql`
  mutation AddTransaction($input: AddTransactionInput!) {
    addTransaction(input: $input) {
      id
      amount
      category
      payee
      date
      type
    }
  }`;

