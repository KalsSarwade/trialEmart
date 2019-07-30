import { IproductParameters } from './iproduct-parameters';

export class ProductParameters implements IproductParameters
{
    constructor(public productId : number,
        public parameterId : number,
        public value : string,
        public parameterName : string)
        {

        }
}
