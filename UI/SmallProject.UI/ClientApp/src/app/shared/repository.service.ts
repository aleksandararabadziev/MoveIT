import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Inject, Injectable } from "@angular/core";
import { SESSION_STORAGE } from "ngx-webstorage-service";
import { StorageService } from "ngx-webstorage-service/src/storage.service";
import { Observable } from "rxjs";
import { catchError, tap } from 'rxjs/operators';

import * as $ from 'jquery';
import { Utils } from "./utils.service";

@Injectable({
    providedIn: 'root'
})
export class Repository {
    constructor(private _http: HttpClient, @Inject(SESSION_STORAGE) private _storage: StorageService, private _utils: Utils) { }

    getHeader() {
        var headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'user' : 'username1'
        });

        return headers;
    }

    getApiUrl() {
        var settings = this._storage.get("app_settings");
        return settings.webApiUrl;
    }

    ajaxGet(url: string, data: any): Observable<any> {
        var result = this.getHeader();
        var headers = result;

        url = this.getApiUrl() + url;

        return this._http.get<any>(url, { headers: headers, params: data }).pipe(
            tap(data => {
                return data;
            }),
            catchError(err => {
                return this._utils.handleError(err.error);
            })
        );
    }

    ajaxPost(url: string, data: any): Observable<any> {
        var result = this.getHeader();
        var headers = result;

        url = this.getApiUrl() + url;

        return this._http.post<any>(url, data, { headers: headers }).pipe(
            tap(data => {
                return data;
            }),
            catchError(err => {
                return this._utils.handleError(err.error);
            })
        );
    }

    ajaxGetSync(url: string, data: any, success: any, method: any){
        if (method == undefined)
            method = "POST";
    
        if (method == "GET")
            data = data;
        else
            data = JSON.stringify(data);
    
        var ajaxSettings = {
            mode: "queue",
            url: url,
            async: false,
            cache: false,
            contentType: "application/json; charset=utf-8",
            type: method,
            data: data,
            dataType: "json",
            success: function (d: any, s: any, x: any) {
                if (d == null) {
                    response = d;
                }
                else if (d.hasOwnProperty("d")) {
                    var response = JSON.parse(d.d);
                } else {
                    response = d;
                }
                success(response);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                console.log(thrownError);
            }
        };
    
        $.ajax(ajaxSettings);
    }
}