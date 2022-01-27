import { Component, Inject, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EventsService } from 'src/app/services/events.service';

@Component({
  selector: 'app-add-edit-event',
  templateUrl: './add-edit-event.component.html',
  styleUrls: ['./add-edit-event.component.scss']
})
export class AddEditEventComponent implements OnInit {

  public eventForm : FormGroup = new FormGroup({
    title : new FormControl(''),
    genre : new FormControl(''),
    startTime : new FormControl(''),
    ticketNum : new FormControl(0),
    Status : new FormControl(''),
  });

  public titlu;
  public option : number;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data : any,
    private eventService : EventsService,
    public dialogRef:MatDialogRef<AddEditEventComponent>,
  ) { 
    if(data.event){
      this.titlu = 'Edit Event'
      this.eventForm.patchValue(this.data.event);
      console.log(this.data.event);
    } else {
      this.titlu = 'Add Event'
    }

    this.option = 1;
    
  }


  //getters

  get title():AbstractControl{
    return this.eventForm.get('title')!;
  }
  get genre():AbstractControl{
    return this.eventForm.get('genre')!;
  }
  get startTime():AbstractControl{
    return this.eventForm.get('startTime')!;
  }
  get ticketNum():AbstractControl{
    return this.eventForm.get('ticketNum')!;
  }
  get Status():AbstractControl{
    return this.eventForm.get('Status')!;
  }
  ngOnInit(): void {
  }

  public addEvent():void{
    this.option = this.data.opt;
    this.eventService.addEvent(this.eventForm.value).subscribe(
      (result) =>{
        console.log(result);  
        this.dialogRef.close(result);  
      },
      (error) => {
        console.error(error);      
      }
    );

  }

  public editEvent() :void{
    this.data.event.title = this.eventForm.value.title;
    this.data.event.genre = this.eventForm.value.genre;
    this.data.event.ticketNum = this.eventForm.value.ticketNum;
    this.data.event.startTime = this.eventForm.value.startTime;
    this.data.event.status = this.eventForm.value.status;

    this.eventService.editEvent(this.data.event).subscribe(
      (result) =>{
        this.dialogRef.close(result);  
      },
      (error) => {
        console.error(error);      
      }
    );
  }
}
