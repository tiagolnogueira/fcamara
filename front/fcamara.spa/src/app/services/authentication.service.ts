import { Injectable, Inject } from '@angular/core';
import { Http, Headers, Response, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map'

@Injectable()
export class AuthenticationService {
    constructor(private http: Http, @Inject('baseApiUrl') private baseUrl: string) { }

    login(username: string, password: string) {
        let customHeaders = new Headers({
            'Content-Type': 'application/json; charset=utf-8'
        });

        let options = new RequestOptions({
            headers: customHeaders,
            withCredentials: true
        });

        return this.http.post(`${this.baseUrl}v1/usuario/login`, JSON.stringify({ login: username, senha: password }), options)
            .map((response: Response) => {
                // login successful if there's a jwt token in the response
                let user = response.json();
                
                if (user && user.Token) {
                    
                    // store user details and jwt token in local storage to keep user logged in between page refreshes
                    localStorage.setItem('usuarioLogado', JSON.stringify(user));
                }

                return user;
            });
    }

    logout() {
        // remove user from local storage to log user out
        localStorage.removeItem('usuarioLogado');
    }
}