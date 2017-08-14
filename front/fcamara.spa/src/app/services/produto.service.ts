import { Injectable, Inject } from '@angular/core';
import { Http, Headers, RequestOptions, Response } from '@angular/http';


@Injectable()
export class ProdutoService {
    constructor(private http: Http, @Inject('baseApiUrl') private baseUrl: string) { }

    getAll() {
        return this.http.get(`${this.baseUrl}v1/produtos`, this.jwt()).map((response: Response) => response.json(),  localStorage.removeItem('usuarioLogado'));
    }

    // private helper methods
    private jwt() {
        // create authorization header with jwt token
        let currentUser = JSON.parse(localStorage.getItem('usuarioLogado'));

        if (currentUser && currentUser.Token) {

            let headers = new Headers({ 'Authorization': 'Bearer ' + currentUser.Token, 'Content-Type': 'application/json; charset=utf-8' });
            return new RequestOptions({ headers: headers, withCredentials: true });
        }
    }
}