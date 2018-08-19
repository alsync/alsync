import { Component } from "@angular/core";
import { NavParams, Platform, ActionSheetController } from 'ionic-angular';

import { Users } from '../../providers/providers';

import { TranslateService } from '@ngx-translate/core';

@Component({
    templateUrl: 'user-profile.html'
})

export class UserProfilePage {
    item: any;

    constructor(
        public navParams: NavParams,
        public items: Users,
        public platform: Platform,
        public actionSheetCtrl: ActionSheetController,
        public translate: TranslateService
    ) {
        let item = this.navParams.get("item");

        if (item.alias || item.vocation) {
            if ((item.alias && !item.vocation)
                || (!item.alias && item.vocation))
                item.about = item.name || item.vocation
            else
                item.about = `${item.name} | ${item.vocation}`;
        }
        this.item = item;
    }

    option() {
        let actionSheet = this.actionSheetCtrl.create({
            title: 'Options',
            // cssClass: 'action-sheets-basic-page',
            buttons: [
                {
                    text: 'Delete',
                    role: 'destructive',
                    icon: !this.platform.is('ios') ? 'trash' : null,
                    handler: () => {
                        console.log('Delete clicked');
                        let sheet = this.actionSheetCtrl.create({
                            title: 'Delete contact',
                            buttons: [
                                {
                                    text: 'Delete',
                                    role: 'destructive',
                                    icon: !this.platform.is('ios') ? 'heart-outline' : null,
                                    handler: () => {
                                        console.log('Delete clicked');
                                    }
                                },
                                {
                                    text: 'Cancel',
                                    role: 'cancel', // will always sort to be on the bottom
                                    icon: !this.platform.is('ios') ? 'close' : null,
                                    handler: () => {
                                        console.log('Cancel clicked');
                                    }
                                }
                            ]
                        });
                        sheet.present();
                    }
                },
                {
                    text: 'Flag',
                    icon: !this.platform.is('ios') ? 'flag' : null,
                    handler: () => {
                        console.log('Flag clicked');
                    }
                },
                {
                    text: 'Unfollow',
                    icon: !this.platform.is('ios') ? 'flag' : null,
                    handler: () => {
                        console.log('Unfollow clicked');
                    }
                },
                {
                    text: 'Favorite',
                    icon: !this.platform.is('ios') ? 'heart-outline' : null,
                    handler: () => {
                        console.log('Favorite clicked');
                    }
                },
                {
                    text: 'Cancel',
                    role: 'cancel', // will always sort to be on the bottom
                    icon: !this.platform.is('ios') ? 'close' : null,
                    handler: () => {
                        console.log('Cancel clicked');
                    }
                }
            ]
        });
        actionSheet.present();
    }
}