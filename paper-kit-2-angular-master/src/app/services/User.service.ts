import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Observable } from 'rxjs';

@Injectable({
	providedIn: 'root',
})
export class UserService {
	private readonly baseUrl: string;

	constructor(private httpClient: HttpClient) {
		this.baseUrl = `${environment.apiUrl}user/`;
	}

	signUp(signupRequest: any): Observable<any> {
		return this.httpClient.post<any>(`${this.baseUrl}signup`, signupRequest);
	}

	login(loginRequest: any): Observable<any> {
		return this.httpClient.post<any>(`${this.baseUrl}login`, loginRequest);
	}

}
