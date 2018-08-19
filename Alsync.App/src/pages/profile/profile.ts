import { Component } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';
import { NavController, NavParams } from 'ionic-angular';

// import { Item } from '../../models/item';
import { Users } from '../../providers/providers';

import { TranslateService } from '@ngx-translate/core';

@Component({
    templateUrl: 'profile.html'
})

export class ProfilePage {
    form: FormGroup;
    currentUser: any;

    subProfile: any = ProfilePage;

    constructor(
        public navCtrl: NavController,
        public items: Users,
        public formBuilder: FormBuilder,
        public navParams: NavParams,
        private translate: TranslateService
    ) {

        this.currentUser = this.items.current;

        // let group: any = JSON.stringify(this.currentUser);
        // console.log(group)
        // this.form = this.formBuilder.group(group);
    }
}