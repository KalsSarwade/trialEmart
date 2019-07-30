import { IproductDescription } from './iproduct-description';

export class ProductDescription implements IproductDescription
{
    constructor(public pdId:number, public productId : number, public longDescription : string, public shortDescription : string)
        {
            
        }
}
