import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { DisplayProductsComponent } from './display-products/display-products.component';
import { SingleProductComponent } from './single-product/single-product.component';
import { HttpClientModule } from '@angular/common/http';
import { CartComponent } from './cart/cart.component';
import { SubCategoryComponent } from './sub-category/sub-category.component';
import { DisplayCategoryTableComponent } from './display-category-table/display-category-table.component';
import { DisplayAllProductsOfCategoryComponent } from './display-all-products-of-category/display-all-products-of-category.component';
import { ProductsByCategoryComponent } from './products-by-category/products-by-category.component';
import { LoginComponent } from './login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    DisplayProductsComponent,
    SingleProductComponent,
    CartComponent,
    SubCategoryComponent,
    DisplayCategoryTableComponent,
    DisplayAllProductsOfCategoryComponent,
    ProductsByCategoryComponent,
    LoginComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
