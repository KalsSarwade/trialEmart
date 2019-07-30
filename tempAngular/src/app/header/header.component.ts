import { Component, OnInit } from '@angular/core';
import { GetProductsService } from '../get-products.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  

  constructor(private prodservice: GetProductsService, private activatedRoute : ActivatedRoute) { }

  ngOnInit() 
  {
    
  }

}
