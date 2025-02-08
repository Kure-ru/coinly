import {gql, TypedDocumentNode} from '@apollo/client/core';

export interface Account {
  id: number;
  income: number;
  expense: number;
  balance: number;
}

interface GetAccountByIdResult {
  accountById: Account;
}

interface GetAccountByIdVariables {
  id: number;
}

export const GET_ACCOUNT_BY_ID: TypedDocumentNode<GetAccountByIdResult, GetAccountByIdVariables> = gql`
  query GetAccountById($id: Int!) {
    accountById(id: $id) {
      id
      income
      expense
      balance
    }
  }
`;
