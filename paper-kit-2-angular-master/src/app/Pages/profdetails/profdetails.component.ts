import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";

@Component({
  selector: "profdetails",
  templateUrl: "./profdetails.component.html",
  styleUrls: ["./profdetails.component.scss"],
})
export class ProfdetailsComponent implements OnInit {
  profileform: FormGroup;
  profilepicture: string | ArrayBuffer | null = null;

  constructor(private fb: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.profileform = this.fb.group({
      age: [""],
      gender: [""],
      profile_pic: ["null"],
    });
  }
  onfileselected(event: Event) {
    const file = (event.target as HTMLInputElement).files?.[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = () => {
        this.profilepicture = reader.result;
      };
      reader.readAsDataURL(file);
    }
  }

  onsubmit() {
    if (this.profileform.valid) {
      const profiledetails = this.profileform.value;
      profiledetails.profile_pic = this.profilepicture;

      //save them into tha localstorage for the testing and temparory
      localStorage.setItem("userProfile", JSON.stringify(profiledetails));
      localStorage.setItem("user_firsttimelogin", "false"); //it will false when user is first time
      alert("Profile is completer successfully");
      this.router.navigate(["/user-profile"]);
    } else {
      alert("Please fill the details first");
    }
  }
}
