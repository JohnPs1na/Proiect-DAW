import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthRegisterService {
  public url = 'https://localhost:5001/api/authentication';

  constructor(
    public http : HttpClient,
  ) { }

  public signup(user:any) : Observable<any>{
    return this.http.post(`${this.url}/sign-up/basic`,user);
  }
}
