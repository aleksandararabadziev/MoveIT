import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { OfferModel } from '../shared/models/offer.model';
import { GetOfferComponent } from './get-offer.component';
import { OfferService } from './offers.service';


@Component({
    selector: 'offers',
    templateUrl: './offers.component.html'
})
export class OffersComponent implements OnInit {

    offers: OfferModel[];

    constructor(private _offerService: OfferService, public dialog: MatDialog, private _router: Router) { }

    ngOnInit(): void {
        this.getAllOffers();
    }

    getAllOffers() {
        this._offerService.getAllOffers().subscribe(result => {
            this.offers = result;
        })
    }

    openGetOfferModal(): void {
        const dialogRef = this.dialog.open(GetOfferComponent, {
            width: '450px',
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result) {
                this.getAllOffers();
            }
        });
    }

    openOfferDetails(id: any) {
        let newRelativeUrl = this._router.createUrlTree(['offer-details', id]);
        let baseUrl = window.location.href.replace(this._router.url, '');
    
        window.open(baseUrl + newRelativeUrl, '_blank');
    }
}