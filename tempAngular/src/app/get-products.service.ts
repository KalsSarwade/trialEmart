import { Injectable } from '@angular/core';
import { Iproducts } from './iproducts';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Products } from './products';
import { ProductDescription } from './product-description';
import { ProductParameters } from './product-parameters';
import { Cart } from './cart';
import { Category } from './category';
import { Customer } from './customer';



@Injectable({
  providedIn: 'root'
})
export class GetProductsService {

  constructor(private http : HttpClient) { }

  public getProductListByWCF() : Observable<Iproducts[]>
  {
    return this.http.get<Iproducts[]>("http://localhost:51932/GetProducts.svc/GetProducts");
  }

  public getProductById(productId : number) :  Observable<Products>
  {
    return this.http.get<Products>("http://localhost:51932/GetProducts.svc/GetProduct/"+productId);
  }

   getProductDescriptionByWCF(productId : number) : Observable<ProductDescription>
  {
    return this.http.get<ProductDescription>("http://localhost:58219/Service1.svc/GetProduct/"+productId);
  }

  getProductParametersByWCF(productId : number) : Observable<ProductParameters>
  {
    return this.http.get<ProductParameters>("http://localhost:50008/GetProductParamsService.svc/GetProduct/"+productId);
  }

  getCategoryFromWCF(): Observable<Category[]>
  {
    return this.http.get<Category[]>("http://localhost:52003/GetCategory.svc/GetCategory");
  }

  getSubCategoryFromWCF(category : string) :Observable<Category[]>
  {
    return this.http.get<Category[]>("http://localhost:52003/GetCategory.svc/GetCategory/"+category);
  }
  getProductByWCF(subcategory : string) : Observable<Category[]>
  {
    return this.http.get<Category[]>("http://localhost:52003/GetCategory.svc/GetSubCategory/"+subcategory);
  }
  getProductByCategory(category : string) : Observable<Products[]>
  {
    return this.http.get<Products[]>("http://localhost:51932/GetProducts.svc/GetProductByCategory/"+category);
  }
  addProductToCart(cart : Cart) : Observable<Cart>
  {
  
      return this.http.post<Cart>("http://localhost:57274/AddtoCartService.svc/AddtoCart",cart);
  }

  getCart() : Observable<Cart[]>
  {
    return this.http.get<Cart[]>("http://localhost:57274/AddtoCartService.svc/GetCart");
  }
  private baseUrl = 'http://localhost:59053/LoginService.svc/Login';
  saveCustomer(customer:Customer): Observable<Object>
  {  console.log(customer);
     return this.http.post(this.baseUrl,customer);
  }

}
