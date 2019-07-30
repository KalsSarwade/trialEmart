import { Component, OnInit } from '@angular/core';
import { GetProductsService } from '../get-products.service';
import { ActivatedRoute } from '@angular/router';
import { Products } from '../products';

@Component({
  selector: 'app-products-by-category',
  templateUrl: './products-by-category.component.html',
  styleUrls: ['./products-by-category.component.css']
})
export class ProductsByCategoryComponent implements OnInit {
product : Products[];
  constructor(private prodservice: GetProductsService, private acRoute: ActivatedRoute) { }

  ngOnInit() 
  {
    let catId :string = this.acRoute.snapshot.params['categoryId'];
    this.prodservice.getProductByCategory(catId).subscribe((data)=>this.product=data);
  }

}
