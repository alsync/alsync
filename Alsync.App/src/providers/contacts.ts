import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

import { Item } from '../models/item';

@Injectable()
export class Contacts {

    constructor(public http: Http) {
    }

    query(params?: any) {

    }
}