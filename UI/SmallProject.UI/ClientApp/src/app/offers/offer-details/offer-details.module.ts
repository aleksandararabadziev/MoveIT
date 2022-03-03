import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { OfferDetailsComponent } from './offer-details.component';

@NgModule({
  declarations: [OfferDetailsComponent],
  imports: [
    RouterModule.forChild([
      {
        path: '', component: OfferDetailsComponent,
      },
    ]),
  ],
})
export class OfferDetailsModule { }