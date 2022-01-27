import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRegisterRoutingModule } from './auth-register-routing.module';
import { AuthRegisterComponent } from './auth-register/auth-register.component';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AuthRegisterComponent
  ],
  imports: [
    CommonModule,
    AuthRegisterRoutingModule,
    MatButtonModule,
    ReactiveFormsModule,
  ]
})
export class AuthRegisterModule { }
