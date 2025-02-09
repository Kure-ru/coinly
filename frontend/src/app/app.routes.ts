import { Routes } from '@angular/router';
import {TransactionsComponent} from './transactions/transactions.component';
import {HomeComponent} from './home/home.component';
import {BudgetComponent} from './budget/budget.component';

export const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'transactions', component: TransactionsComponent },
  { path: 'budget', component: BudgetComponent },
];
