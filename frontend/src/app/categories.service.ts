import {Injectable} from '@angular/core';
import {Apollo} from 'apollo-angular';

import {ADD_CATEGORY, DELETE_CATEGORY, UPDATE_CATEGORY, UpdateCategoryInput} from '../graphql/categories.graphql';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  constructor(private apollo: Apollo) {}

  addCategory(name: string, accountId: number) {
    return this.apollo.mutate({
      mutation: ADD_CATEGORY,
      variables: {
          name,
          accountId
      }
    });
  }

  deleteCategory(categoryIds: number[]) {
    return this.apollo.mutate({
      mutation: DELETE_CATEGORY,
      variables: {
          categoryIds
      }
    });
  }

  updateCategory(input: UpdateCategoryInput) {
    return this.apollo.mutate({
      mutation: UPDATE_CATEGORY,
      variables: {
        input
      }
    })
  }
}

