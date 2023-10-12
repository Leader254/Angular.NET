import { Injectable } from '@angular/core';
import { Product } from '../models/products.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseApiUrl: string = "https://localhost:7131";

  constructor(private http : HttpClient) { }
  getAllProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.baseApiUrl + '/api/Product');
  }
  addProduct(newProduct : Product) : Observable<Product>{
    newProduct.id = "";
    return this.http.post<Product>(this.baseApiUrl + "/api/Product", newProduct);
  }
  // editProduct(newProduct : Product)
  getProductById(id : string) : Observable<Product>{
    return this.http.get<Product>(this.baseApiUrl + "/api/Product/" + id);
  }
  editProduct(id : string, editProductRequest : Product) : Observable<Product> {
    return this.http.put<Product>(this.baseApiUrl + "/api/Product/" + id, editProductRequest);
  }
  deleteProduct(id : string) : Observable<Product>{
    return this.http.delete<Product>(this.baseApiUrl + "/api/Product/" + id);
  }
}
