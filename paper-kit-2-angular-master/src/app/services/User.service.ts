import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
	providedIn: 'root',
})
export class UserService {
	private readonly baseUrl: string;
    private urlPath = '';
	constructor(private httpClient: HttpClient) {
		this.baseUrl = `${environment.apiUrl}user`;
	}

    getBenefit(id: any): Observable<any> {
		return this.httpClient.get<any>(`${this.urlPath}/${id}`).pipe();
	}
	createform(form: any): Observable<any> {
		debugger
		return this.httpClient.post<any>(`${this.baseUrl}`, form).pipe();
	}
}
