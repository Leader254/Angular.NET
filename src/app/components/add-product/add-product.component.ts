import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Product } from 'src/app/models/products.model';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {
  newProduct: Product = {
    id : '',
    name: '',
    type: '',
    price: 0,
    color: '',
    imgUrl: ''
  }
  constructor(private productService : ProductsService, private router : Router) {}
  addProduct(){
    this.productService.addProduct(this.newProduct)
    .subscribe({
      next: (product) => {
        this.router.navigate(["products"]);
        console.log(product);
      },
      error: (response) => {
        console.log(response)
      }
    })
  }
}
