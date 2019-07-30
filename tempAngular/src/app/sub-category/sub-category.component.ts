import { Component, OnInit, OnChanges } from '@angular/core';
import { GetProductsService } from '../get-products.service';
import { ActivatedRoute } from '@angular/router';
import { Category } from '../category';

@Component({
  selector: 'app-sub-category',
  templateUrl: './sub-category.component.html',
  styleUrls: ['./sub-category.component.css']
})
export class SubCategoryComponent implements OnInit {

  subcat : Category[];
  cat : Category[];
  constructor(private prodservice: GetProductsService, private activatedRoute : ActivatedRoute ){ }

  ngOnInit() {
    this.prodservice.getCategoryFromWCF().subscribe((data)=>this.cat=data);
    let sub : string = this.activatedRoute.snapshot.params['category'];
    this.prodservice.getSubCategoryFromWCF(sub).subscribe((data)=>this.subcat=data);
  }

  
// ngOnChanges()
// {
//   debugger;
//   let sub : string = this.activatedRoute.snapshot.params['category'];
//     this.prodservice.getSubCategoryFromWCF(sub).subscribe((data)=>this.subcat=data);
// }
}
