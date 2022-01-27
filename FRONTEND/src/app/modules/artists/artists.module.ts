import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ArtistsRoutingModule } from './artists-routing.module';
import { ArtistsComponent } from './artists/artists.component';
import { MaterialModule } from '../material/material.module';
import { ArtistComponent } from './artist/artist.component';


@NgModule({
  declarations: [
    ArtistsComponent,
    ArtistComponent
  ],
  imports: [
    CommonModule,
    ArtistsRoutingModule,
    MaterialModule
  ]
})
export class ArtistsModule { }
