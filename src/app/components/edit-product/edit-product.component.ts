import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from 'src/app/models/products.model';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-edit-product',
  templateUrl: './edit-product.component.html',
  styleUrls: ['./edit-product.component.css']
})
export class EditProductComponent implements OnInit {
  editProductRequest : Product = {
    id : '',
    name: '',
    type: '',
    price: 0,
    color: '',
    imgUrl: ''
  };

  constructor(
    private router : Router,
    private productService : ProductsService,
    private route : ActivatedRoute
    ) {}
  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get("id");

        if(id){
          this.productService.getProductById(id)
           .subscribe({
            next : (response) => {
              this.editProductRequest = response;
            }
           })
        }
      }
    })
  }
  editProduct() {
    this.productService.editProduct(this.editProductRequest.id, this.editProductRequest)
    .subscribe({
      next: (response) => {
        this.router.navigate(["products"])
        console.log(this.editProductRequest);
      },
      error: (err) => {
        console.log(err)
      }
    })
  }
}
