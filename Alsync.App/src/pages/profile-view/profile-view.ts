import { Component } from '@angular/core';
import { ViewController } from 'ionic-angular';

import { Item } from '../../models/item';
import { Users } from '../../providers/providers';

import { ProfileEditPage } from '../profile-edit/profile-edit';

@Component({
    templateUrl: 'profile-view.html'
})

export class ProfileViewPage {
    currentUser: Item;
    ProfileEditPage = ProfileEditPage;

    constructor(public viewCtrl: ViewController,
        public items: Users) {

        this.currentUser = this.items.current;
    }

    ionViewDidLoad() {
        this.viewCtrl.setBackButtonText('Me');
    }
}