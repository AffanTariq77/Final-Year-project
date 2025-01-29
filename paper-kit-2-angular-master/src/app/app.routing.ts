import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { BrowserModule } from "@angular/platform-browser";
import { Routes, RouterModule } from "@angular/router";

import { ComponentsComponent } from "./components/components.component";
import { ProfileComponent } from "./examples/profile/profile.component";
// import { SignupComponent } from "./examples/signup/signup.component";
import { LandingComponent } from "./examples/landing/landing.component";
import { NucleoiconsComponent } from "./components/nucleoicons/nucleoicons.component";
import { LoginComponent } from "./Pages/login/login.component";
import { LayoutComponent } from "./Pages/layout/layout.component";
import { DashboardComponent } from "./Pages/dashboard/dashboard.component";
import { AboutUsComponent } from "./Pages/about-us/about-us.component";
import { ProfdetailsComponent } from "./Pages/profdetails/profdetails.component";
import { SignupComponent } from "./Pages/signup/signup.component";

const routes: Routes = [
  { path: "", redirectTo: "login", pathMatch: "full" },
  { path: "login", component: LoginComponent },
  {
    path: "",
    component: LayoutComponent,
    children: [
      { path: "dashboard", component: DashboardComponent },
      { path: "about-us", component: AboutUsComponent },
    ],
  },
  { path: "profdetials", component: ProfdetailsComponent },
  { path: "home", component: ComponentsComponent },
  { path: "user-profile", component: ProfileComponent },
  { path: "signup", component: SignupComponent },
  { path: "landing", component: LandingComponent },
  { path: "nucleoicons", component: NucleoiconsComponent },
];

@NgModule({
  imports: [
    CommonModule,
    BrowserModule,
    RouterModule.forRoot(routes, {
      useHash: true,
    }),
  ],
  exports: [],
})
export class AppRoutingModule {}
