import { Component, OnInit } from '@angular/core';
import { AbstractControl,FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public unauthorised : boolean = this.Unauthorised();
  public error : string | boolean = false;

  public registerForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
    role: new FormControl('User', [Validators.required])
  });
  
  constructor(
    private authService: AuthService,
  ) { }

  get email(): AbstractControl | null {
    return this.registerForm.get('email');
  }
  get password() : AbstractControl | null {
    return this.registerForm.get('password');
  }

  ngOnInit(){
  }
  
  public Unauthorised(){
     if(localStorage.getItem('Role') == 'User'){ 
        return true; 
      }
    return false;
  }

  public register(){
    this.error =  false;
    
    console.log("Register requested");
    this.authService.createRegister(this.registerForm.value).subscribe(
      (response) =>{
      console.log(response);
      this.error = "Registration Succeded!";
    },
    (error) =>{
      this.error = "Error on register!"; 
      console.error(error);
    }
    );
  }

}
