import { Component, OnInit } from '@angular/core';
import { Category } from '../category';
import { GetProductsService } from '../get-products.service';

@Component({
  selector: 'app-display-category-table',
  templateUrl: './display-category-table.component.html',
  styleUrls: ['./display-category-table.component.css']
})
export class DisplayCategoryTableComponent implements OnInit {

  cat : Category[];
  constructor(private prodservice : GetProductsService) { }

  ngOnInit() {
    this.prodservice.getCategoryFromWCF().subscribe((data)=>this.cat=data);
  }

}
