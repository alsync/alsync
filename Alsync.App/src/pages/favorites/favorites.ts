import { Component } from '@angular/core';

@Component({
    templateUrl: 'favorites.html'
})

export class FavoritesPage {
    addItem() {
        console.log('trigger addItem event')
    }
}