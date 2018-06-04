import { Injectable, Inject } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/toPromise';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';
import { MFPModel } from '../components/models/mfp.model';

@Injectable()
export class MFPService {
    myAppUrl: string = "";
    private tokeyKey = "token";
    private token: any;
    headers: Headers | undefined;
    options: RequestOptions | undefined;
    constructor(private _http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getMyFriendsPositions() {
        let headers = this.initAuthHeaders();
        return this._http.get(this.myAppUrl + "/api/mfp/ListMyFriendsPositions", { headers: headers })
            .map((response: Response) => {
                return response.json()
            })
            .catch(this.handleError);
    }

    getTop3FriendsNearByVisitedFriend(visitedFriendPositionID: number) {
        //this.headers = new Headers({ 'content-type': 'application/json' });
        //this.options = new RequestOptions({ headers: this.headers });
        //, this.options)
        let headers = this.initAuthHeaders();
        return this._http.get(this.myAppUrl + "/api/mfp/GetTop3FriendsNearByVisitedFriend/" + visitedFriendPositionID, { headers: headers })
            .map((response: Response) => {
              
                return response.json()
            })
            .catch(this.handleError);
    }

    private getLocalToken(): string {
        if (!this.token) {
            this.token = sessionStorage.getItem(this.tokeyKey);
        }
        return this.token;
    }

    private initAuthHeaders(): Headers {
        let token = this.getLocalToken();
        if (token == null) throw "No token";

        var headers = new Headers();
        headers.append("Authorization", "Bearer " + token);

        return headers;
    }
    private handleError(error: Response) {
        return Observable.throw(error.json().error || 'Opps!! Server error');
    }  
}