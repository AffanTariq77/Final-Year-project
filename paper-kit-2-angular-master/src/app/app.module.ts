import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { FormsModule } from "@angular/forms";
import { NgbModule } from "@ng-bootstrap/ng-bootstrap";
import { RouterModule } from "@angular/router";
import { AppRoutingModule } from "./app.routing";

import { AppComponent } from "./app.component";
import { NavbarComponent } from "./shared/navbar/navbar.component";
import { FooterComponent } from "./shared/footer/footer.component";

import { ComponentsModule } from "./components/components.module";
import { ExamplesModule } from "./examples/examples.module";
import { ReactiveFormsModule } from "@angular/forms";
import { LoginComponent } from "./Pages/login/login.component";
import { ProfdetailsComponent } from "./Pages/profdetails/profdetails.component";
import { TripSearchComponent } from "./Trip/trip-search/trip-search.component";
import { HttpClient, HttpClientModule } from "@angular/common/http";
import { SignupComponent } from "./Pages/signup/signup.component";
import { ProfilePageComponent } from './Pages/profile-page/profile-page.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    FooterComponent,
    LoginComponent,
    ProfdetailsComponent,
    TripSearchComponent,
    SignupComponent,
    ProfilePageComponent
  ],
  imports: [
    BrowserModule,
    NgbModule,
    FormsModule,
    RouterModule,
    ComponentsModule,
    ExamplesModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
