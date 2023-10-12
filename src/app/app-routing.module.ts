import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductsComponent } from './products/products.component';
import { AddProductComponent } from './components/add-product/add-product.component';
import { EditProductComponent } from './components/edit-product/edit-product.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AuthGuard } from './shared/AuthGuard';
import { TermsAndServiceComponent } from './components/terms-and-service/terms-and-service.component';

const routes: Routes = [
  {
    path : "products",
    component : ProductsComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "products/add",
    component: AddProductComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "products/edit/:id",
    component : EditProductComponent,
    canActivate: [AuthGuard]
  },
  {
    path: "login",
    component : LoginComponent
  },
  {
    path: "register",
    component : RegisterComponent
  },
  {
    path: "",
    redirectTo: "products",
    pathMatch: "full"
  },
  {
    path: "terms-and-service",
    component : TermsAndServiceComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
