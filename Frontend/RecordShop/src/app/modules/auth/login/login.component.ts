import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginResult } from 'src/app/interfaces/login-result';
import { AuthService } from 'src/app/services/auth.service';
import jwt_decode from "jwt-decode";
import { Subscription } from 'rxjs';
import { SharedDataService } from 'src/app/services/shared-data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})

export class LoginComponent implements OnInit, OnDestroy {
  public subscription: Subscription | undefined;
  public sharedEmail: string = '';

  public error : string | boolean = false;

  public loginForm: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(
    private router: Router,
    private authService: AuthService,
    private sharedDataService: SharedDataService,
  ) { }

  get email(): AbstractControl | null {
    return this.loginForm.get('email');
  }
  get password() : AbstractControl | null {
    return this.loginForm.get('password');
  }

  ngOnInit(){
    this.subscription = this.sharedDataService.currentEmailUser.subscribe((sharedEmail) => this.sharedEmail = sharedEmail);
  }
  
  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  public login(): void {
    this.error = false;
    
    if(this.validateEmail(this.loginForm.value.email)){
      
       this.authService.createLogin(this.loginForm.value).subscribe((response :LoginResult)=>{
        
        if(response.success == true)
       {
          this.sharedDataService.changeUserData(this.loginForm.value.email);
          
          console.log(jwt_decode(response.accessToken));

          localStorage.setItem('accessToken', response.accessToken);
          localStorage.setItem('refreshToken', response.refreshToken);
        

          var RolePart = response.accessToken.split('.')[1];
          var decodedJwtJsonData = window.atob(RolePart);
          let decodedJwtData = JSON.parse(decodedJwtJsonData);

          var isAdmin = decodedJwtData.role;
          localStorage.setItem('Role', isAdmin);
          console.log(isAdmin);
          
          this.error = "Login with succes!";
       }
         else
            this.error = "Invalid Password";
            this.router.navigate(['/songs']);

        });
    }
    else{
      this.error = "Invalid Email!";
    }

  }

  validateEmail(email: string) {
    console.log("validator");
    const re =
      /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    console.log(re.test(String(email).toLowerCase()));
    
      return re.test(String(email).toLowerCase());
  }

}
