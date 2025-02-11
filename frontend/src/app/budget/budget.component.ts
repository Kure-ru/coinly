import { Component } from '@angular/core';
import { NgIf } from '@angular/common';
import { PrimeTemplate } from 'primeng/api';
import { TableModule } from 'primeng/table';
import { Observable } from 'rxjs';
import { Apollo, QueryRef } from 'apollo-angular';
import { map } from 'rxjs/operators';
import {
  Category,
  GET_CATEGORIES_BY_ACCOUNT,
  GetCategoriesByAccount,
  GetCategoriesByAccountVariables
} from '../../graphql/categories.graphql';
import { Card } from 'primeng/card';
import { Button } from 'primeng/button';
import { CategoriesService } from '../categories.service';
import { MutationResult } from '@apollo/client';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faPlus, faTrash } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-budget',
  imports: [
    NgIf,
    PrimeTemplate,
    TableModule,
    Card,
    Button,
    FontAwesomeModule
  ],
  templateUrl: './budget.component.html',
})
export class BudgetComponent {
  data$: Observable<any>;
  categories: Category[] = [];
  faPlus = faPlus;
  faTrash = faTrash;
  selectedCategories: number[] = [];

  constructor(private apollo: Apollo, private categoriesService: CategoriesService) {
    const queryRef: QueryRef<GetCategoriesByAccount, GetCategoriesByAccountVariables> = this.apollo.watchQuery({
      query: GET_CATEGORIES_BY_ACCOUNT,
      variables: {
        accountId: 1
      }
    });

    this.data$ = queryRef.valueChanges.pipe(
        map(result => result.data)
    );

    this.data$.subscribe(result => this.categories = result.categoriesByAccount);
  }

  addCategory() {
    (this.categoriesService.addCategory('new category', 1) as Observable<MutationResult<{addCategory: Category}>>).subscribe({
      next: (response) => {
        if (response.data) {
          this.categories = [...this.categories, response.data.addCategory];
        }
      },
      error: (error) => {
        console.error('Error adding category', error);
      }
    });
  }

  deleteCategories(){
    if (this.selectedCategories.length === 0) {
      return;
    }
   this.categoriesService.deleteCategory(this.selectedCategories).subscribe({
     next: (response) => {
       this.categories = this.categories.filter(category => !this.selectedCategories.includes(category.id));
       this.selectedCategories = [];
     },
     error: (error) => {
       console.error('Error deleting categories', error);
     }
   });
  }
}
