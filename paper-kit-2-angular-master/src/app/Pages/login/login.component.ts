import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { UserService } from "app/services/User.service";

@Component({
  selector: "login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})
export class LoginComponent implements OnInit {
  test: Date = new Date();
  focus;
  focus1;
  loginForm!: FormGroup;
  signUpForm!: FormGroup;
  errorMessage: string = "";
  isSignUp: boolean = false; 

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private UserService: UserService
  ) {}

  ngOnInit(): void {
    debugger
    this.loginForm = this.fb.group({
      email: ["", [Validators.required, Validators.email]],
      password: ["", [Validators.required, Validators.minLength(6)]],
    });

    this.signUpForm = this.fb.group({
      Name: "",
      email: ["", [Validators.required, Validators.email]],
      password: ["", [Validators.required, Validators.minLength(6)]],
    });
  }

  onLoginSubmit(){
    debugger
    if (this.loginForm.valid) {
      const form = this.loginForm.value;
      this.UserService.createform(form).subscribe(
        (data: any) => {
          console.log("Login successful:", data);
          // Navigate or handle success response
        },
        (error: any) => {
          console.log("Login failed:", error);
          this.errorMessage = "Login failed. Please try again.";
        }
      );
    } else {
      this.errorMessage = "Please fill out the form correctly.";
    }
  }
  

  onSignUpSubmit(): void {
    if (this.signUpForm.valid) {
      const { Name, email, password } = this.signUpForm.value;

      // Store the credentials in localStorage
      localStorage.setItem("name", Name);
      localStorage.setItem("email", email);
      localStorage.setItem("password", password);

      localStorage.setItem("user_firsttimelogin", "true");

      alert("Sign up successful! Complete your profile please.");
      // this.isSignUp = false; // Switch back to login form
      this.router.navigate(["/profdetials-component"]);
    } else {
      this.errorMessage = "Please fill out the form correctly.";
    }
  }

  toggleForm(): void {
    this.isSignUp = !this.isSignUp;
    this.errorMessage = ""; // Clear error message
  }
}
