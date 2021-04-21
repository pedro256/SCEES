import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http'; 
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EMPTY, Observable } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import {Product} from './product.model'

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseUrl = "http://localhost:4001/products"
  httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};

  constructor(private snackBar: MatSnackBar,private http:HttpClient) { }

  showMessage(msg:string,isError:boolean=false): void {
    this.snackBar.open(msg,"",{
      duration:3000,
      horizontalPosition:"right",
      verticalPosition:"top",
      panelClass: isError? ['msg-error'] : ['msg-success']
    })
  }
  errorHandle(e:any): Observable<any>{
    this.showMessage('Error no sistema !! ações não efetuadas!!',true)
    return EMPTY
  }
  create(product : Product ): Observable<any>{
    return this.http.post<Product>(this.baseUrl,product, this.httpOptions).pipe(
      map(obj=>obj),
      catchError(e => this.errorHandle(e))
    );
  }
  
  findAll(): Observable<Product[]>{
    return this.http.get<Product[]>(this.baseUrl).pipe(
      map(obj=>obj),
      catchError(e => this.errorHandle(e))
    );
  }
  findById(id:string): Observable<Product>{
    const url = `${this.baseUrl}/${id}`;
    return this.http.get<Product>(url).pipe(
      map(obj=>obj),
      catchError(e => this.errorHandle(e))
    );
  } 
  update(pproduct:Product): Observable<Product>{
    const url = `${this.baseUrl}/${pproduct.id}`;
    return this.http.put<Product>(url,pproduct).pipe(
      map(obj=>obj),
      catchError(e => this.errorHandle(e))
    );
  }
  delete(id:string):Observable<Product> {
    const url = `${this.baseUrl}/${id}`;
    return this.http.delete<Product>(url).pipe(
      map(obj=>obj),
      catchError(e => this.errorHandle(e))
    );
  }
}
