import { Component } from '@angular/core';
import {RouterLink, RouterOutlet} from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { TimelineModule } from 'primeng/timeline';
import { ChipModule } from 'primeng/chip';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import { Apollo } from 'apollo-angular';
import { NgIf} from '@angular/common';
import {GET_ACCOUNT_AND_TRANSACTIONS} from "../../graphql/transactions.graphql";


@Component({
  selector: 'app-home',
  imports: [ButtonModule, CardModule, NgIf, TimelineModule, ChipModule, RouterLink],
  templateUrl: './home.component.html',
})
export class HomeComponent {
  data$: Observable<any>;
  data: any;

  constructor(private apollo: Apollo) {
    this.data$ = this.apollo.watchQuery({
      query: GET_ACCOUNT_AND_TRANSACTIONS,
      variables: {
        id: 1,
        accountId: 1
      }
    })
      .valueChanges
      .pipe(
        map(result => result.data)
      );
    this.data$.subscribe(result => this.data = result);
  }
}

