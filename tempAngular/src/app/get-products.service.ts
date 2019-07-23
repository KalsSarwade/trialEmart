import { Injectable } from '@angular/core';
import { Iproducts } from './iproducts';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GetProductsService {

  constructor(private http : HttpClient) { }

  public getProductListByWCF() : Observable<Iproducts[]>
  {
    return this.http.get<Iproducts[]>("http://localhost:51932/GetProducts.svc/GetProducts");
  }
}
