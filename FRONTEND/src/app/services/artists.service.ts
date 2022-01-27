import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ArtistsService {

  public url = 'https://localhost:5001/api/artists';
  

  constructor(
    public http:HttpClient,
  ) { }


  public getArtists():Observable<any>{
    return this.http.get(`${this.url}`);
  }

  public getArtistById(id:any) :Observable<any>{
    return this.http.get(`${this.url}/${id}`);
  }
}
