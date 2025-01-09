import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";

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
  isSignUp: boolean = false; // Track if user is on the sign-up form or login form

  constructor(private fb: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      email: ["", [Validators.required, Validators.email]],
      password: ["", [Validators.required, Validators.minLength(6)]],
    });

    this.signUpForm = this.fb.group({
      email: ["", [Validators.required, Validators.email]],
      password: ["", [Validators.required, Validators.minLength(6)]],
    });
  }

  onLoginSubmit(): void {
    if (this.loginForm.valid) {
      const { email, password } = this.loginForm.value;
      const storedEmail = localStorage.getItem("email");
      const storedPassword = localStorage.getItem("password");

      if (email === storedEmail && password === storedPassword) {
        alert("Login successful!");
        this.router.navigate(["/home"]); // Redirect to the dashboard
      } else {
        this.errorMessage = "Invalid email or password";
      }
    } else {
      this.errorMessage = "Please fill out the form correctly.";
    }
  }

  onSignUpSubmit(): void {
    if (this.signUpForm.valid) {
      const { email, password } = this.signUpForm.value;

      // Store the credentials in localStorage
      localStorage.setItem("email", email);
      localStorage.setItem("password", password);

      alert("Sign up successful! You can now log in.");
      this.isSignUp = false; // Switch back to login form
    } else {
      this.errorMessage = "Please fill out the form correctly.";
    }
  }

  toggleForm(): void {
    this.isSignUp = !this.isSignUp;
    this.errorMessage = ""; // Clear error message when toggling forms
  }
}
