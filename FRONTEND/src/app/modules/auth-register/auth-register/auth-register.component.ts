import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthRegisterService } from 'src/app/services/auth-register.service';

@Component({
  selector: 'app-auth-register',
  templateUrl: './auth-register.component.html',
  styleUrls: ['./auth-register.component.scss']
})
export class AuthRegisterComponent implements OnInit {

  public registerForm : FormGroup = new FormGroup({
    email:new FormControl(''),
    username:new FormControl(''),
    password:new FormControl('')
  })
  constructor(
    private router:Router,
    private authRegisterService:AuthRegisterService
  ) { }

  //getters
  get email() :AbstractControl{
    return this.registerForm.get('email')!;
  }

  get username() :AbstractControl{
    return this.registerForm.get('username')!;
  }

  get password() :AbstractControl{
    return this.registerForm.get('password')!;
  }

  ngOnInit(): void {
  }

  public signup():void{
    console.log(this.registerForm.value);
    this.authRegisterService.signup(this.registerForm.value).subscribe(
      (result) => {
        console.log(result);
        this.router.navigate(['/login'])
      },
      (error) => {
        console.error(error);
        console.error('Userul nu a fost creat');
        
      }
    )
  }

}
