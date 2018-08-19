import { Component } from "@angular/core";
import { Validators, FormBuilder, FormGroup } from '@angular/forms';

import { Item } from '../../models/item';
import { Users } from '../../providers/providers';

@Component({
    templateUrl: 'profile-edit.html'
})

export class ProfileEditPage {
    form: FormGroup;
    currentUser: Item;

    constructor(public items: Users,
        public formBuilder: FormBuilder) {

        this.currentUser = this.items.current;

        let group: any = {
            name: 'heiheihei',
            gender: '',
            company: 'come on',
            phones: []
        };
        this.form = this.formBuilder.group(group);
    }
}