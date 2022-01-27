import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TicketsService {

  public url = 'https://localhost:5001/api/ticket';

  constructor(
    public http:HttpClient,
  ) { }

  public getTickets():Observable<any>{
    return this.http.get(`${this.url}/read`)
  }

  public getTicketsByArtist(data:any) : Observable<any>{

    if(data == ""){
      return this.getTickets();
    }
    else{
      return this.http.get(`${this.url}/get/` + data)
    }
  }
}
