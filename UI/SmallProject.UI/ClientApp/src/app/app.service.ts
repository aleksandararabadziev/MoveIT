import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { AppSettingsModel } from "./shared/models/appSettings.model";
import { OfferModel } from "./shared/models/offer.model";
import { Repository } from "./shared/repository.service";

@Injectable({
    providedIn: 'root'
})
export class AppService {
    constructor(private _repository: Repository) { }

    getPing(): Observable<any> {
        return this._repository.ajaxGet("Test/Ping", null);
    }

    postPing(data: string): Observable<any> {
        return this._repository.ajaxPost("Test/Ping", data);
    }

    getAppSettings(successcb: any) {
        this._repository.ajaxGetSync("Home/GetAppSettings", null, function (result: any) {
            successcb(result);
        }, "GET");
    }
}