import { Icart } from './icart';

export class Cart implements Icart
{
    constructor(public productId : number,
        public productName : string,
        public listPrice : number,
        public cardHolderPrice : number,
        public customerId : number,
        public point : number,
        public imageURL: string,
        public quantity : number)
    {

    }
}
