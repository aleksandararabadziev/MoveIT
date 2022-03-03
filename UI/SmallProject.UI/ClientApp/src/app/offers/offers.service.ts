import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Repository } from "../shared/repository.service";

@Injectable({
    providedIn: 'root'
})
export class OfferService {
    constructor(private _repository: Repository) { }

    getAllOffers(): Observable<any> {
        return this._repository.ajaxGet("Offer/GetAllOffersByUser", null);
    }

    createOffer(data: any): Observable<any>{
        return this._repository.ajaxPost("Offer/CreateOffer", data);
    }

    getOfferById(data: any):Observable<any>{
        return this._repository.ajaxGet("Offer/GetOfferById", data);
    }
}