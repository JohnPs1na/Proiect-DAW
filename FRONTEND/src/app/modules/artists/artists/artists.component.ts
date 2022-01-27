import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { ArtistsService } from 'src/app/services/artists.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-artists',
  templateUrl: './artists.component.html',
  styleUrls: ['./artists.component.scss']
})
export class ArtistsComponent implements OnInit , OnDestroy {

  public subscription:Subscription | any;
  public loggedUser : any;
  public artists = [];
  public displayedColumns = ['FirstName','LastName','Genre','Profile']

  constructor(
    private router:Router,
    private dataService:DataService,
    private artistsService:ArtistsService,
  ) { }

  ngOnInit(): void {
    this.subscription = this.dataService.currentUser.subscribe(user => this.loggedUser = user);
    this.artistsService.getArtists().subscribe(
      (result) => {
        console.log(result);
        this.artists = result;
      },
      (error) => {
        console.error(error);
        
      }
    );
  }

  ngOnDestroy(): void {
      this.subscription.unsubscribe();
  }

  public logout():void{
    localStorage.setItem('Role','Anonymous');
    this.router.navigate(['/login']);
  }

  public goToArtist(id:any) : void {
    this.router.navigate(['/artist',id]);
  }
}
