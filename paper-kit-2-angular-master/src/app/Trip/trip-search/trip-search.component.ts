import { Component, OnInit } from "@angular/core";
import { tripdata, gettrips } from "./tripdata";

interface Trip {
  id: number;
  place: string;
  location: string;
  date: string; // ("05/15/2024")
  price: number;
  weather: string;
  saftystatus: string;
}

@Component({
  selector: "trip-search",
  templateUrl: "./trip-search.component.html",
  styleUrls: ["./trip-search.component.scss"],
})
export class TripSearchComponent implements OnInit {
  trips: Trip[] = [];
  filteredTrips: Trip[] = [];

  searchdata = {
    location: "",
    date: "",
    price: 0,
  };

  ngOnInit(): void {
    tripdata(); // Ensure trips are added to localStorage
    this.trips = gettrips() as Trip[]; // Load trips from localStorage
  }

  onsearch(): void {
    this.filteredTrips = this.trips.filter((trip) => {
      return (
        trip.location
          .toLowerCase()
          .includes(this.searchdata.location.toLowerCase()) &&
        trip.date >= this.searchdata.date &&
        trip.price <= this.searchdata.price
      );
    });
  }
}
