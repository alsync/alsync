import { Component } from "@angular/core";
import { ItemSliding, Item } from "ionic-angular";

import { Users } from '../../providers/providers';

import { TranslateService } from '@ngx-translate/core';

@Component({
    templateUrl: 'phones.html'
})

export class PhonesPage {
    currentUser: any;
    isReadyToSave: boolean;

    constructor(
        public items: Users,
        public translate: TranslateService
    ) {
        this.currentUser = this.items.current;
    }

    change(oldValue: string, value: string) {
        this.isReadyToSave = oldValue != value;
    }

    slideItem(slidingItem: ItemSliding, item: Item) {
        slidingItem.setElementClass("active-sliding", true);
        slidingItem.setElementClass("active-slide", true);
        slidingItem.setElementClass("active-options-right", true);
        item.setElementStyle("transform", "translate3d(-70px, 0px, 0px)");
    }

    addItem() {
        this.currentUser.phones.push({ phone: '' })
    }

    deleteItem(item) {
        this.currentUser.phones.splice(this.currentUser.phones.indexOf(item), 1);
        // this.items.delete(item);
    }
}