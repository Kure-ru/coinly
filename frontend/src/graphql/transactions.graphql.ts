import {gql} from '@apollo/client/core';
import {Account} from './accounts.graphql';
import {Category} from './categories.graphql';

export interface Transaction {
  id: number;
  accountId: number;
  amount: number;
  category: Category;
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
  categoriesByAccount: Category[];
}

export interface GetTransactionsByAccountIDVariables {
  accountId: number;
  accountIdForTransactions: number;
  accountIdForCategories: number;
}

export const GET_ACCOUNT_AND_TRANSACTIONS = gql`
  query GetAccountDetails($accountId: Int!, $accountIdForTransactions: Int!, $accountIdForCategories: Int!) {
    accountById(id: $accountId) {
      id
      income
      expense
      balance
    }
    transactions(accountId: $accountIdForTransactions) {
      id
      accountId
      amount
      category {
        id
        name
      }
      payee
      type
      date
    }
    categoriesByAccount(accountId: $accountIdForCategories) {
      id
      name
      activity
      assigned
    }
  }`;

export const ADD_TRANSACTION = gql`
  mutation AddTransaction($input: AddTransactionInput!) {
    addTransaction(input: $input) {
      id
      amount
      categoryId
      payee
      date
      type
    }
  }`;

