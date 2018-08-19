import { Component } from '@angular/core';
import { NavController, ModalController } from 'ionic-angular';

import { ProfilePage } from '../profile/profile';
import { PhonesPage } from '../phones/phones';
import { SettingsPage } from '../settings/settings';

import { Item } from '../../models/item';
import { Users } from '../../providers/providers';

import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'page-personal',
    templateUrl: 'personal.html'
})

export class PersonalPage {
    currentUser: Item;
    pageGroups: any[] = [
        {
            pages: [
                { title: 'PHONES', icon: 'list', component: PhonesPage },
                { title: 'FANS', icon: 'people', component: PhonesPage }
            ]
        }, {
            pages: [
                { title: 'SETTINGS', icon: 'settings', component: SettingsPage }
            ]
        }
    ];

    constructor(
        public navCtrl: NavController,
        public items: Users,
        public translate: TranslateService
    ) {
        this.currentUser = this.items.current;
    }

    openProfile() {
        this.navCtrl.push(ProfilePage);
    }

    openPage(page) {
        this.navCtrl.push(page.component)
    }
}