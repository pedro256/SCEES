import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';
import {Router}from '@angular/router';

@Component({
  selector: 'app-product-create',
  templateUrl: './product-create.component.html',
  styleUrls: ['./product-create.component.css']
})
export class ProductCreateComponent implements OnInit {

  constructor(private productService:ProductService, private route:Router) { }

  ngOnInit(): void {
    
  }

  createProduct(): void {
    this.productService.showMessage("Produto criado com sucesso !!");
  }
  cancel():void{
    this.route.navigate(['/stock'])
  }

}
