import { Component, OnInit } from '@angular/core';
import { GetProductsService } from '../get-products.service';
import { ActivatedRoute } from '@angular/router';
import { Category } from '../category';

@Component({
  selector: 'app-display-all-products-of-category',
  templateUrl: './display-all-products-of-category.component.html',
  styleUrls: ['./display-all-products-of-category.component.css']
})
export class DisplayAllProductsOfCategoryComponent implements OnInit {

  subcat : Category[];
  constructor(private prodservice: GetProductsService, private activatedRoute: ActivatedRoute) 
  {

  }

  ngOnInit() 
  {
    let subb = this.activatedRoute.snapshot.params['products'];
    this.prodservice.getProductByWCF(subb).subscribe((data)=>this.subcat=data);
  }

}
