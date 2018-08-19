import { Item } from '../../models/item';

export class Users {
    items: any[] = [];

    constructor() {
        let items = [
            {
                name: '周晓彤',
                avatar: 'assets/img/speakers/bear.jpg',
                gender: Gender.Male,
                company: 'IBM',
                address: '天府大道199号天府五街23号',
                phones: [
                    { label: 'call', phone: '13000000000' },
                    { label: 'home', phone: '13888888888' }
                ]
            },
            {
                name: '付歆',
                avatar: 'assets/img/speakers/cheetah.jpg',
                gender: Gender.Female,
                company: 'IBM',
                address: '天府大道199号天府五街23号',
                phones: [
                    { label: 'mobile', phone: '13000000000' },
                    { label: 'home', phone: '13888888888' },
                    { label: 'work', phone: '13888888888' },
                    { label: 'text', phone: '13888888888' }
                ]
            },
            {
                name: "Burt",
                alias: 'Burt Bear',
                avatar: "assets/img/speakers/bear.jpg",
                gender: '1',
                vocation: 'Saler',
                company: 'Microsoft',
                address: '天府大道二段199号',
                about: "Burt is a Bear.",
                phones: [                    
                    { label: 'mobile', phone: '13000000000' },
                    { label: 'home', phone: '13888888888' },
                    { label: 'work', phone: '13888888888' },
                    { label: 'text', phone: '13888888888' }
                ]
            },
            {
                name: 'Charlie',
                alias: "Charlie Cheetah",
                avatar: "assets/img/speakers/cheetah.jpg",
                gender: '0',
                vocation: 'Computer Soft',
                company: 'IBM',
                address: '一环路西三段',
                about: "Charlie is a Cheetah.",
                phones: [
                    { label: 'mobile', phone: '13000000000' },
                    { label: 'home', phone: '13888888888' },
                    { label: 'work', phone: '13888888888' },
                    { label: 'text', phone: '13888888888' }
                ]
            },
            {
                name: 'Donald',
                alias: "Donald Duck",
                avatar: "assets/img/speakers/duck.jpg",
                gender: '0',
                vocation: 'Teacher',
                company: 'HP',
                address: '',
                about: "Donald is a Duck."
            },
            {
                name: '阿信',
                alias: "倪淳珂",
                avatar: "assets/img/speakers/duck.jpg",
                gender: '1',
                vocation: '计算机软件',
                region: '四川, 成都',
                company: '成都瑞特科技有限公司',
                address: '四川省成都市三环路东五段299号锦悦西路东二段',
                phones: [
                    { label: 'mobile', phone: '13000000000' },
                    { label: 'home', phone: '13888888888' },
                    { label: 'work', phone: '13888888888' },
                    { label: 'text', phone: '13888888888' }
                ]
            },
            {
                name: 'Eva',
                alias: "Eva Eagle",
                avatar: "assets/img/speakers/eagle.jpg"
            },
            {
                "name": "Ellie Elephant",
                "avatar": "assets/img/speakers/elephant.jpg",
                "about": "Ellie is an Elephant."
            },
            {
                "name": "Molly Mouse",
                "avatar": "assets/img/speakers/mouse.jpg",
                "about": "Molly is a Mouse."
            },
            {
                "name": "Paul Puppy",
                "avatar": "assets/img/speakers/puppy.jpg",
                "about": "Paul is a Puppy."
            }
        ];

        for (let item of items) {
            this.items.push(new Item(item));
        }


    }

    get current() {
        return this.items[1];
    }

    query(params?: any) {
        if (!params)
            return this.items;

        return this.items.filter(item => {
            for (let key in params) {
                let field = item[key];
                if (typeof field == 'string'
                    && field.toLowerCase().indexOf(params[key].toLowerCase()) > -1)
                    return true;
            }
            return false;
        });
    }

    add(item: Item) {
        this.items.push(item);
    }

    delete(item: Item) {
        this.items.splice(this.items.indexOf(item), 1);
    }
}

export const Gender = {
    Female: 0,
    Male: 1
}