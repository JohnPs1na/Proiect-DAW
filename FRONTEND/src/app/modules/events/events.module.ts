import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EventsRoutingModule } from './events-routing.module';
import { EventsComponent } from './events/events.component';
import { MaterialModule } from '../material/material.module';
import { EventComponent } from './event/event.component';


@NgModule({
  declarations: [
    EventsComponent,
    EventComponent,
  ],
  imports: [
    CommonModule,
    EventsRoutingModule,
    MaterialModule,
  ],
  exports:[
  ]
})
export class EventsModule { }
