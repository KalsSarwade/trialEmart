import { Component, OnInit } from '@angular/core';
import { GetProductsService } from '../get-products.service';
import { Cart } from '../cart';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  cart: Cart[];
  check1 : number =0;
  check2 : number = 0;
  //islogged =false;
  constructor(private prodservice: GetProductsService) { }

  ngOnInit() 
  {
    this.prodservice.getCart().subscribe((data)=>this.cart=data);
  }
  setchkval1()
  {
    this.check1 = 1;
  }
  setchkval2()
  {
    this.check2 = 1;
  }
  isValid()
  {
    if((this.check1==1) && (this.check2 ==1))
    {
      alert("true true");
    }

  }

}
