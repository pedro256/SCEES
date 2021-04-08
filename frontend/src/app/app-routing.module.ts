import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from './views/home/home.component';
import {StockCrudComponent} from './views/stock-crud/stock-crud.component';

import {ProductCreateComponent} from './components/product/product-create/product-create.component';

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
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
