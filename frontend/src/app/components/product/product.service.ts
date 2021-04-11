import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http'; 
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import {Product} from './product.model'

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = "https://localhost:5001/api/Product"
  httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};

  constructor(private snackBar: MatSnackBar,private http:HttpClient) { }

  showMessage(msg:string): void {
    this.snackBar.open(msg,"",{
      duration:3000,
      horizontalPosition:"right",
      verticalPosition:"top"
    })
  }
  create(product : Product ): Observable<any>{
    return this.http.post<Product>(this.baseUrl,product, this.httpOptions);
  }
  /*
  findAll(): Observable<Product[]>{
    return this.http.get<Product[]>(this.baseUrl);
  }
  */
}
