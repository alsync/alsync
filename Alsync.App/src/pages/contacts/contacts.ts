import { Component } from '@angular/core';
import { NavController, ModalController } from 'ionic-angular';

// import { ItemCreatePage } from '../item-create/item-create';
// import { ItemDetailPage } from '../item-detail/item-detail';
import { UserProfilePage } from '../user-profile/user-profile'

import { Item } from '../../models/item';
import { Users } from '../../providers/providers';

@Component({
    templateUrl: 'contacts.html'
})

export class ContactsPage {
    currentGroups: any[] = [];

    constructor(
        public navCtrl: NavController,
        public items: Users,
        public modalCtrl: ModalController
    ) {
        let currentItems = this.items.query()
        this.currentGroups = this.group(currentItems);
    }

    addItem() {
        // let addModal = this.modalCtrl.create(ItemCreatePage);
        // addModal.onDidDismiss(item => {
        //     if (item) {
        //         this.items.add(item);
        //     }
        // })
        // addModal.present();
    }

    getItems(value) {
        var params = {
            name: value,
            alias: value
        };
        let currentItems = this.items.query(params);
        this.currentGroups = this.group(currentItems);
    }

    openItem(item: Item) {
        this.navCtrl.push(UserProfilePage, {
            item: item
        });
    }

    group(items) {
        let groups: any[] = [];
        let json = {};
        for (let p of items) {
            var key = p.name.charAt(0);
            if (json[key])
                json[key].push(p);
            else
                json[key] = [p];
        }
        for (let p in json) {
            groups.push({ key: p, items: json[p] });
        }

        return groups;
    }
}