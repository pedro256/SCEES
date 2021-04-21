import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import {Router}from '@angular/router';
import { Product } from '../product.model';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {

  product : Product = {
    name:'',
    qtd:12,
    categoryId:'08d8fb82-714e-446d-81bb-06f412602aec',
    price:0
  }
  constructor(private productService:ProductService, private route:Router) { }

  ngOnInit(): void {
    
  }

  createProduct(): void {
    //this.productService.showMessage("Produto criado com sucesso !!");
    this.productService.create(this.product).subscribe(item=>{
      //console.log(item)
      this.productService.showMessage("Produto criado com sucesso !!");
      this.route.navigate(['/stock'])
    })
    
  }
  cancel():void{
    this.route.navigate(['/stock'])
  }

}
