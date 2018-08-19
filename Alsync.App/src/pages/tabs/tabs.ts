import { Component } from '@angular/core';
// import { NavController } from 'ionic-angular';

import { Tabs } from '../pages';

import { TranslateService } from '@ngx-translate/core';

@Component({
    selector: 'page-tabs',
    templateUrl: 'tabs.html'
})
export class TabsPage {
    tab1Root: any = Tabs.Tab1.TabRoot;
    tab2Root: any = Tabs.Tab2.TabRoot;
    tab3Root: any = Tabs.Tab3.TabRoot;
    tab4Root: any = Tabs.Tab4.TabRoot;

    tab1Title = " ";
    tab2Title = " ";
    tab3Title = " ";
    tab4Title = " ";

    tab1Icon: string = Tabs.Tab1.TabIcon;
    tab2Icon: string = Tabs.Tab2.TabIcon;
    tab3Icon: string = Tabs.Tab3.TabIcon;
    tab4Icon: string = Tabs.Tab4.TabIcon;

    constructor(public translate: TranslateService) {
        translate.get([Tabs.Tab1.TabTitle, Tabs.Tab2.TabTitle, Tabs.Tab3.TabTitle, Tabs.Tab4.TabTitle])
            .subscribe(values => {
                this.tab1Title = values[Tabs.Tab1.TabTitle];
                this.tab2Title = values[Tabs.Tab2.TabTitle];
                this.tab3Title = values[Tabs.Tab3.TabTitle];
                this.tab4Title = values[Tabs.Tab4.TabTitle];
            });
    }
}
