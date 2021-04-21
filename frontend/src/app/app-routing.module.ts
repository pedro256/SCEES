import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from './views/home/home.component';
import {StockCrudComponent} from './views/stock-crud/stock-crud.component';

import {ProductCreateComponent} from './components/product/product-create/product-create.component';
import {ProductUpdateComponent} from './components/product/product-update/product-update.component';
import {ProductDeleteComponent} from './components/product/product-delete/product-delete.component';

const routes: Routes = [
  {
  path:"",
  component: HomeComponent
},
{
  path:"stock",
  component: StockCrudComponent
},
{
  path:"stock/create",
  component: ProductCreateComponent
},
{
  path:"stock/update/:id",
  component: ProductUpdateComponent
},
{
  path:"stock/delete/:id",
  component: ProductDeleteComponent
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
