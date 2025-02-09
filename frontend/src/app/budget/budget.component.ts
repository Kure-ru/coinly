import { Component } from '@angular/core';
import {NgIf} from '@angular/common';
import {PrimeTemplate} from 'primeng/api';
import {TableModule} from 'primeng/table';
import {Observable} from 'rxjs';
import {Apollo, QueryRef} from 'apollo-angular';
import {map} from 'rxjs/operators';
import {
  Category,
  GET_CATEGORIES_BY_ACCOUNT,
  GetCategoriesByAccount,
  GetCategoriesByAccountVariables
} from '../../graphql/categories.graphql';

@Component({
  selector: 'app-budget',
  imports: [
    NgIf,
    PrimeTemplate,
    TableModule
  ],
  templateUrl: './budget.component.html',
})

export class BudgetComponent {
  data$: Observable<any>;
  categories: Category[] = [];


  constructor(private apollo: Apollo) {

    const queryRef: QueryRef<GetCategoriesByAccount, GetCategoriesByAccountVariables> = this.apollo.watchQuery({
      query: GET_CATEGORIES_BY_ACCOUNT,
      variables: {
        accountId: 1
      }
    })

    this.data$ = queryRef.valueChanges.pipe(
      map(result => result.data)
    );

    this.data$.subscribe(result => this.categories = result.categoriesByAccount);
  }
}
