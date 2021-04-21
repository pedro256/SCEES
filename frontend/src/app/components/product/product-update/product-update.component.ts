import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../product.model';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  styleUrls: ['./product-update.component.css']
})
export class ProductUpdateComponent implements OnInit {

  product: Product = {
    name:'',
    price:0,
    qtd:0

  }

  constructor(private productService:ProductService, private router:Router,private route:ActivatedRoute) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id')
    this.productService.findById(id).subscribe((product)=>{
      this.product = product
    })
  }
  updateProduct():void{
    this.productService.update(this.product).subscribe(()=>{
      this.productService.showMessage("Produto Atualizado com sucesso !!");
      this.router.navigate(['/stock'])
    })
  }
  cancel():void{
    this.router.navigate(['/stock'])
  }

}
