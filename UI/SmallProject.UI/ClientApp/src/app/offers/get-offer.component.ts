import { Component } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { GetOfferModel } from '../shared/models/offer.model';
import { OfferService } from './offers.service';


@Component({
    selector: 'get-offer',
    templateUrl: './get-offer.component.html'
})
export class GetOfferComponent {

    model: GetOfferModel;

    constructor(public dialogRef: MatDialogRef<GetOfferComponent>, private _offerService: OfferService) {
        this.model = new GetOfferModel();
    }

    submitProposal() {
        this._offerService.createOffer(this.model).subscribe(result => {
            this.dialogRef.close(true);
        })
    }

    cancel() {
        this.dialogRef.close(false);
    }
}