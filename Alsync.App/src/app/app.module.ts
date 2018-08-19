import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { IonicApp, IonicErrorHandler, IonicModule } from 'ionic-angular';
import { SplashScreen } from '@ionic-native/splash-screen';
import { StatusBar } from '@ionic-native/status-bar';
import { Camera } from '@ionic-native/camera';
import { QRScanner, QRScannerStatus } from '@ionic-native/qr-scanner';

import { AppComponent } from './app.component';
import { HomePage } from '../pages/home/home';
import { TabsPage } from '../pages/tabs/tabs';
import { FavoritesPage } from '../pages/favorites/favorites';
import { ContactsPage } from '../pages/contacts/contacts';
import { FollowsPage } from '../pages/follows/follows';
import { SearchPage } from '../pages/search/search'
import { UserProfilePage } from '../pages/user-profile/user-profile';
import { PersonalPage } from '../pages/personal/personal';
import { ProfilePage } from '../pages/profile/profile';
import { PhonesPage } from '../pages/phones/phones';
import { ProfileEditPage } from '../pages/profile-edit/profile-edit';
import { SettingsPage } from '../pages/settings/settings';

import { Users } from '../mocks/providers/users';

import { HttpModule, Http } from '@angular/http';
import { HttpClientModule, HttpClient } from '@angular/common/http';
import { TranslateModule, TranslateLoader } from '@ngx-translate/core';
import { TranslateHttpLoader } from '@ngx-translate/http-loader';

export function HttpLoaderFactory(http: Http) {
  return new TranslateHttpLoader(http, './assets/i18n/', '.json');
}

@NgModule({
  declarations: [
    AppComponent,
    HomePage,
    TabsPage,
    FavoritesPage,
    FollowsPage,
    SearchPage,
    ContactsPage,
    UserProfilePage,
    PersonalPage,
    ProfilePage,
    PhonesPage,
    ProfileEditPage,
    SettingsPage
  ],
  imports: [
    BrowserModule,
    // HttpClientModule,
    // TranslateModule.forRoot({
    //   loader: {
    //     provide: TranslateLoader,
    //     useFactory: HttpLoaderFactory,
    //     deps: [HttpClient]
    //   }
    // }),
    HttpModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useFactory: HttpLoaderFactory,
        deps: [Http]
      }
    }),
    IonicModule.forRoot(AppComponent, {
      tabsHideOnSubPages: true
    })
  ],
  bootstrap: [IonicApp],
  entryComponents: [
    AppComponent,
    HomePage,
    TabsPage,
    FavoritesPage,
    FollowsPage,
    SearchPage,
    ContactsPage,
    UserProfilePage,
    PersonalPage,
    ProfilePage,
    PhonesPage,
    ProfileEditPage,
    SettingsPage
  ],
  providers: [
    Users,
    StatusBar,
    SplashScreen,
    Camera,
    QRScanner,
    { provide: ErrorHandler, useClass: IonicErrorHandler }
  ]
})
export class AppModule { }
