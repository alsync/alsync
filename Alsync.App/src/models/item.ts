export class Item {
    constructor(private fields: any) {
        for (var f in fields) {
            this[f] = fields[f];
        }
    }
}