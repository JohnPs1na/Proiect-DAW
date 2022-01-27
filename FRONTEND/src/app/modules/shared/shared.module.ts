import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddEditEventComponent } from './add-edit-event/add-edit-event.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AddEditEventComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  entryComponents:[
    AddEditEventComponent
  ]
})
export class SharedModule { }
