import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { DetailsOfferModel } from 'src/app/shared/models/offer.model';
import { OfferService } from '../offers.service';


@Component({
    selector: 'offer-details',
    templateUrl: './offer-details.component.html'
})
export class OfferDetailsComponent implements OnInit {

    offerId: string;
    model: DetailsOfferModel;

    constructor(private _offerService: OfferService, private _route: ActivatedRoute) {
        this.offerId = this._route.snapshot.paramMap.get("id");
        this.model = new DetailsOfferModel();
    }

    ngOnInit() {
        this.getOfferById();
    }

    getOfferById() {

        var data = {
            offerId: this.offerId
        }

        this._offerService.getOfferById(data).subscribe(result => {
            this.model = result;
        })
    }
}