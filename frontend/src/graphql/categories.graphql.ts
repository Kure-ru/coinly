import {gql} from '@apollo/client/core';

export interface Category {
  id: number;
  name: string;
  available: number;
  activity: number;
  assigned: number;
}

export interface GetCategoriesByAccount {
  categories: Category[];
}

export interface GetCategoriesByAccountVariables {
  accountId: number;
}

export const GET_CATEGORIES_BY_ACCOUNT = gql`
  query GetCategoriesByAccount($accountId: Int!) {
    categoriesByAccount(accountId: $accountId) {
      id
      name
      available
      activity
      assigned
    }
  }
`;
