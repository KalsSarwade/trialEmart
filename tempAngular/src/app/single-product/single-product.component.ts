import { Component, OnInit } from '@angular/core';
import { Iproducts } from '../iproducts';
import { GetProductsService } from '../get-products.service';
import { ActivatedRoute } from '@angular/router';
import { Products } from '../products';
import { ProductDescription } from '../product-description';
import { ProductParameters } from '../product-parameters';
import { Cart } from '../cart';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-single-product',
  templateUrl: './single-product.component.html',
  styleUrls: ['./single-product.component.css']
})
export class SingleProductComponent implements OnInit {

  /*
  * variable declarations
  */
  prod : Iproducts[];    
  singleprod : Products;
  prodDesc : ProductDescription;
  prodParams : ProductParameters;
  tocart : Cart;
  
  /*
  * constructor injection
  */
  constructor(private prodservice : GetProductsService, 
    private _activatedroute : ActivatedRoute) 
    {
      
    }

  ngOnInit() 
  {
    //let subcat : number = this._activatedroute.snapshot.params['categoryId'];
    this.prodservice.getProductListByWCF().subscribe((data)=>this.prod=data);
    let productId : number = this._activatedroute.snapshot.params['productId'];
    this.prodservice.getProductById(productId).subscribe((dataa)=>this.singleprod=dataa);
    this.prodservice.getProductDescriptionByWCF(productId).subscribe((data)=>this.prodDesc=data);
    this.prodservice.getProductParametersByWCF(productId).subscribe((dataaaa)=>this.prodParams=dataaaa);
  }

  public submitToCart()
  {
    this.tocart=new Cart
    (this.singleprod.productId,
      this.singleprod.productName,
      this.singleprod.listPrice,
      this.singleprod.cardHolderPrice,0,
      this.singleprod.point,
      this.singleprod.imageURL,1);
      console.log(this.tocart.imageURL);
    console.log("helooo");
    console.log(this.tocart.productId);
    console.log(this.tocart);
    alert("Item added to cart");
    return this.prodservice.addProductToCart(this.tocart).subscribe();
  }


}
