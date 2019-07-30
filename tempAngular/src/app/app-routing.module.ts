import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DisplayProductsComponent } from './display-products/display-products.component';
import { SingleProductComponent } from './single-product/single-product.component';
import { SubCategoryComponent } from './sub-category/sub-category.component';
import { DisplayAllProductsOfCategoryComponent } from './display-all-products-of-category/display-all-products-of-category.component';
import { DisplayCategoryTableComponent } from './display-category-table/display-category-table.component';
import { ProductsByCategoryComponent } from './products-by-category/products-by-category.component';
import { CartComponent } from './cart/cart.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [{path :'getProducts', component: DisplayProductsComponent},
{path :'product/:productId', component : SingleProductComponent},
{path: 'category/:category', component : SubCategoryComponent},
{path: 'subcategory/:products',component : DisplayAllProductsOfCategoryComponent},
{path: 'getCategories', component:DisplayCategoryTableComponent},
{path: 'productOfCategory/:categoryId',component: ProductsByCategoryComponent },
{path: 'mycart', component: CartComponent},
{path :'login', component:LoginComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
