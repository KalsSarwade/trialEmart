import { Icategory } from './icategory';

export class Category implements Icategory
{
    constructor(public categoryId :number,
        public category : string,
        public subCategory :string,
        public imageURL :string,
        public flag :number)
    {}
}
