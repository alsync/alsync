import { Component } from '@angular/core';
import { NavController, ModalController } from 'ionic-angular';

import { TranslateService } from '@ngx-translate/core';

@Component({
    templateUrl: 'settings.html'
})

export class SettingsPage {
    constructor(
        private translate: TranslateService
    ) { }
}