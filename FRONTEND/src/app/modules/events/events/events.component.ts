import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { DataService } from 'src/app/services/data.service';
import { EventsService } from 'src/app/services/events.service';
import { AddEditEventComponent } from '../../shared/add-edit-event/add-edit-event.component';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.scss']
})
export class EventsComponent implements OnInit, OnDestroy {

  public subscription:Subscription | any;
  public loggedUser:any;
  public events = [];
  public displayedColumns = ['Genre', 'Title', 'ticketNum','startTime','edit','delete']

  constructor(
    private router:Router,
    private dataService:DataService,
    private eventsService : EventsService,
    public dialog:MatDialog,
  ) { }

  ngOnInit(): void {
    this.subscription = this.dataService.currentUser.subscribe(user => this.loggedUser = user);
    this.eventsService.getEvents().subscribe(
      (result) => {
        console.log(result);
        this.events = result;
      },
      (error) => {
        console.log(error);
        
      }
    )
  }

  ngOnDestroy(){
    this.subscription.unsubscribe();
  }

  public logout():void{
    localStorage.setItem('Role','Anonymous');
    this.router.navigate(['/login']);
  }

  public deleteEvent(event:any):void{
    this.eventsService.deleteEvent(event).subscribe(
      (result) => {
        console.log(result);
        this.events = result;
      },
      (error) =>{
        console.error(error);
        
      }
    );
  }


  public openModal(event?:any,opt?:any) : void {
    const data = {
      event,
      opt
    };

    
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '700px';
    dialogConfig.data = data;

    const dialogRef = this.dialog.open(AddEditEventComponent,dialogConfig);

    dialogRef.afterClosed().subscribe(
      (result) => {
        console.log(result);
        if(result){
          this.events = result;
        }     
      }
    );
  }
  public addEvent(opt:any) : void { 
    
    this.openModal(opt);
  }

  public editEvent(event:any,opt:any): void{
    
    this.openModal(event,opt);
  }
}



