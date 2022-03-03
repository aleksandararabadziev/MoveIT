import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { GetOfferComponent } from './offers/get-offer.component';
import { OffersComponent } from './offers/offers.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatInputModule } from '@angular/material/input';
import { MatTabsModule } from '@angular/material/tabs';
import { MatListModule } from '@angular/material/list';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatButtonModule } from '@angular/material/button';
import { BrowserAnimationsModule, NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { OffersModule } from './offers/offers.module';
import { CommonModule } from '@angular/common';

const ROUTES: Routes = [
  { path: '', redirectTo: 'offers', pathMatch: 'full' },
  { path: 'offer-details/:id', loadChildren: () => import('./offers/offer-details/offer-details.module').then(m => m.OfferDetailsModule) },
  { path: 'offers', loadChildren: () => import('./offers/offers.module').then(m => m.OffersModule) },
  { path: '**', redirectTo: 'offers', pathMatch: 'full' },
]

@NgModule({
  declarations: [
    AppComponent,
    GetOfferComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatDialogModule,
    MatFormFieldModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatInputModule,
    MatTabsModule,
    MatListModule,
    NoopAnimationsModule,
    MatCheckboxModule,
    FormsModule,
    RouterModule.forRoot(ROUTES, { useHash: true })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
