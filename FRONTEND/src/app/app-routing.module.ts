import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  {
    path:'',
    canActivate:[AuthGuard],
    children:[
      {
        path:'',
        loadChildren:() => import('src/app/modules/events/events.module').then(m => m.EventsModule),
      },
      {
        path:'',
        loadChildren:() => import('src/app/modules/artists/artists.module').then(m => m.ArtistsModule),
      },
      {
        path:'',
        loadChildren:() => import('src/app/modules/tickets/tickets.module').then(m => m.TicketsModule),
      }
    ]
  },
  {
    path:'login',
    loadChildren: () => import('src/app/modules/auth/auth.module').then(m => m.AuthModule),
  },
  {
    path:'register',
    loadChildren:() => import('src/app/modules/auth-register/auth-register.module').then(m=>m.AuthRegisterModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
