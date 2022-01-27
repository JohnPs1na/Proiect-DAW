import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EventsService {

  public url = 'https://localhost:5001/api/events';

  constructor(
    public http : HttpClient,
  ) { }

  public getEvents() : Observable<any>{
    return this.http.get(`${this.url}/events`);
  }

  public deleteEvent(event : any) : Observable<any>{
    const options = {
      headers:new HttpHeaders(),
      body: event
    }
    return this.http.delete(`${this.url}`,options);
  }

  public addEvent(event:any) :Observable<any>{
    const headers = new HttpHeaders().set('Authorization','Bearer ' + localStorage.getItem('Role'));
    console.log(headers);
    
    return this.http.post(`${this.url}/create`,event,{headers});
  }

  public editEvent(event:any):Observable<any>{

    return this.http.put(`${this.url}/update`,event);

  }
}
