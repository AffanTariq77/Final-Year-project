import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { UserService } from "../../services/User.service";
import { HttpClient, HttpClientModule } from "@angular/common/http";

@Component({
  selector: "login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
  form: FormGroup;
  submitted:boolean;
  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private http: HttpClient,
    private UserService: UserService,
    
  ) {
    this.form = this.formBuilder.group({
      Email: ["", [Validators.email, Validators.required]],
      Password: ["", Validators.required],
    });
  }

  get f() {
		return this.form.controls;
	}
  ngOnInit(){

  }

  onLoginSubmit(){
    debugger
    this.submitted = true;
  }
  
}
