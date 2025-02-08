import { Component } from '@angular/core';
import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { TimelineModule } from 'primeng/timeline';
import { ChipModule } from 'primeng/chip';
import {RouterOutlet} from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [ButtonModule, CardModule, TimelineModule, ChipModule, RouterOutlet],
  templateUrl: './app.component.html',
})
export class AppComponent {

}


