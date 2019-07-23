import { Iproducts } from './iproducts';

export class Products implements Iproducts
{
    constructor(public productId :number, public categoryId : number,public productName : string,public imageURL : string,public listPrice : number,
       public cardHolderPrice : number,public point : number)
        {

        }
}
