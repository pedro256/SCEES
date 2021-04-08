import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router'

@Component({
  selector: 'app-stock-crud',
  templateUrl: './stock-crud.component.html',
  styleUrls: ['./stock-crud.component.css']
})
export class StockCrudComponent implements OnInit {

  constructor(private router:Router) { }

  ngOnInit(): void {
  }
  navigateToProductCreate():void{
    this.router.navigate(['/stock/create'])
  }

}
