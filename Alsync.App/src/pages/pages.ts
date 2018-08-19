import { TabsPage } from './tabs/tabs';
import { HomePage } from './home/home';
import { FavoritesPage } from './favorites/favorites';
import { ContactsPage } from '../pages/contacts/contacts';
import { FollowsPage } from '../pages/follows/follows';
import { PersonalPage } from './personal/personal';

export const FirstRunPage = TabsPage;

export const MainPage = TabsPage;

export const Tabs = {
    Tab1: {
        TabRoot: FavoritesPage,
        TabTitle: "FAVORITES_TAB_TITLE",
        TabIcon: "star"
    },
    Tab2: {
        TabRoot: HomePage,
        TabTitle: "MESSAGE_TAB_TITLE",
        TabIcon: "text"
    },
    Tab3: {
        TabRoot: FollowsPage,
        TabTitle: "FOLLOWS_TAB_TITLE",
        TabIcon: "contacts"
    },
    Tab4: {
        TabRoot: PersonalPage,
        TabTitle: "ME_TAB_TITLE",
        TabIcon: "person"
    }
};