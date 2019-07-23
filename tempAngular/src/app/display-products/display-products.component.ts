import { Component, OnInit } from '@angular/core';
import { Iproducts } from '../iproducts';
import { GetProductsService } from '../get-products.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-display-products',
  templateUrl: './display-products.component.html',
  styleUrls: ['./display-products.component.css']
})
export class DisplayProductsComponent implements OnInit {

  prodWcf : Iproducts[];
  constructor(private prodservice : GetProductsService) { }

  
  ngOnInit() 
  {
      this.prodservice.getProductListByWCF().subscribe((data)=>this.prodWcf=data);
  }

}
