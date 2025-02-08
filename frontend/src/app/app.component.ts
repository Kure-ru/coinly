import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import {GET_ACCOUNT_BY_ID} from '../graphql/accounts.graphql';
import {Observable} from 'rxjs';
import { map } from 'rxjs/operators';
import { Apollo } from 'apollo-angular';
import {AsyncPipe, NgIf} from '@angular/common';


@Component({
  selector: 'app-root',
  imports: [ButtonModule, CardModule, AsyncPipe, NgIf],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'frontend';
  account$: Observable<any>;

constructor(private apollo: Apollo) {
  this.account$ = this.apollo.watchQuery({
    query: GET_ACCOUNT_BY_ID,
    variables: {
      id: 1
    }
  })
    .valueChanges
    .pipe(
      map(result => result.data.accountById)
    );


}
}


