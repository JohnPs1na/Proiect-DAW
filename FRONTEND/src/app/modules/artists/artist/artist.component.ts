import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { ArtistsService } from 'src/app/services/artists.service';

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html',
  styleUrls: ['./artist.component.scss']
})
export class ArtistComponent implements OnInit {

  public subscription : Subscription | any;
  public id : any;
  public artist = {
    FirstName : 'Default',
    LastName : "default",
    Genre : "default"
  };

  constructor(
    private route:ActivatedRoute,
    private artistsService:ArtistsService,
  ) { }

  ngOnInit(): void {
    this.subscription = this.route.params.subscribe(params => {
      this.id = params;
      this.id = this.id.id
      console.log(this.id);
      
      if(this.id){
        this.getArtist();
      }
    })
  }

  public getArtist():void {
    this.artistsService.getArtistById(this.id).subscribe(
      (result) => {
        console.log(result);
        
        this.artist.FirstName = result.firstName;
        this.artist.LastName = result.lastName;
        this.artist.Genre = result.genre;
        console.log(this.artist);
        
      },
      (error) => {
        console.error(error);
        
      }
    );
  }

}
