import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { DataService } from 'src/app/services/data.service';
import { TicketsService } from 'src/app/services/tickets.service';

@Component({
  selector: 'app-tickets',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.scss']
})
export class TicketsComponent implements OnInit , OnDestroy {

  public subscription:Subscription | any;
  public loggedUser : any;
  public tickets = [];
  public displayedColumns = ['Event Title', 'Price', 'Status','startTime','endTime']


  constructor(
    private router:Router,
    private dataService:DataService,
    private ticketsService:TicketsService
  ) { }


  data: string = "";

  blurEvent(event: any){
    this.data = event.target.value;
  }

  
  ngOnInit(): void {
    this.subscription = this.dataService.currentUser.subscribe(user => this.loggedUser = user);
    this.ticketsService.getTickets().subscribe(
      (result) =>{
        console.log(result);
        this.tickets = result;
      },
      (error) =>
      {
        console.error(error);
        
      }
    )
  }

  ngOnDestroy(): void {
      this.subscription.unsubscribe();
  }

  public logout():void{
    localStorage.setItem('Role','Anonymous');
    this.router.navigate(['/login']);
  }

  public getTickets():void{
    console.log(this.data);
    
    this.ticketsService.getTicketsByArtist(this.data).subscribe(
      (result) =>{
        console.log(result);
        this.tickets = result;
        
      }
    )
  }
}
