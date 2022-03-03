import { Component, Inject, OnInit } from '@angular/core';
import { SESSION_STORAGE, StorageService } from 'ngx-webstorage-service';
import { AppService } from './app.service';
import { AppSettingsModel } from './shared/models/appSettings.model';
import { OfferModel } from './shared/models/offer.model';

@Component({
  selector: 'move-it',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  title: string = "MoveIT";
  appSettings: AppSettingsModel = null;

  constructor(private _appService: AppService,
    @Inject(SESSION_STORAGE) private _storage: StorageService) {

  }

  ngOnInit(): void {
    this.getAppSettings();
  }

  getAppSettings() {
    var self = this;

    var appSettings = this._storage.get('app_settings');
    if (!!!appSettings) {
      this._appService.getAppSettings(function (
        result: AppSettingsModel
      ) {
        self._storage.set('app_settings', result);
      });
    }
  }
}