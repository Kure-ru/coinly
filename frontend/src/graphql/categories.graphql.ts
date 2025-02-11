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

export const ADD_CATEGORY = gql`
  mutation AddCategory($name: String!, $accountId: Int!) {
    addCategory(name: $name, accountId: $accountId) {
      id
      name
      available
      activity
      assigned
    }
  }
`;

export const DELETE_CATEGORY = gql`
  mutation DeleteCategories($categoryIds: [Int!]!) {
    deleteCategories(categoryIds: $categoryIds)
  }
`;
