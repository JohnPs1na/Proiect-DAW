import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TicketsRoutingModule } from './tickets-routing.module';
import { TicketsComponent } from './tickets/tickets.component';
import { MaterialModule } from '../material/material.module';
import { BncPipe } from 'src/app/bnc.pipe';


@NgModule({
  declarations: [
    TicketsComponent,
    BncPipe,
  ],
  imports: [
    CommonModule,
    TicketsRoutingModule,
    MaterialModule,
  ],
  exports:[
    BncPipe,
  ]
})
export class TicketsModule { }
