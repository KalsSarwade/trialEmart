import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DisplayProductsComponent } from './display-products/display-products.component';
import { SingleProductComponent } from './single-product/single-product.component';

const routes: Routes = [{path :'getProducts', component: DisplayProductsComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
