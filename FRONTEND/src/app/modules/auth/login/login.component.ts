import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthLoginService } from 'src/app/services/auth-login.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForm :FormGroup = new FormGroup({
    username : new FormControl(''),
    password : new FormControl(''),
  });

  public token : any;

  constructor(
    private router:Router,
    private dataService:DataService,
    private authLoginService:AuthLoginService
  ) {
   }

    //getters 
  
    get username() : AbstractControl{
      return this.loginForm.get('username')!;
    }

    get password() : AbstractControl{
      return this.loginForm.get('password')!;
    }

  ngOnInit(): void {
  }

  public login(): void{
    console.log(this.loginForm.value);
    this.dataService.changeUserData(this.loginForm.value);
    this.authLoginService.login(this.loginForm.value).subscribe(
      (result) =>{
        console.log(result);      
        this.token = result;
        localStorage.setItem('Role',this.token.accesToken); 
        this.router.navigate(['/events']);

      },
      (error) => {
        console.error(error);
        this.token = null;
      }
    );      
    
    
  }

}
