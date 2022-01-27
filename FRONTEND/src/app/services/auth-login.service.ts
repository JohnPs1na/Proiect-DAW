import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthLoginService {

  public url = 'https://localhost:5001/api/authentication';

  constructor(
    public http : HttpClient,
  ) { }

  public login(user:any) : Observable<any>{
    const token = this.http.post(`${this.url}/login`,user);
    return token;
  }
}
