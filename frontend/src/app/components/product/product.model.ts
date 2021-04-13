export interface Product{
    id?:string,
    name:string,
    qtd:number,
    categoryId?:string,
    price:number,
    salePrice?:number,
    dataValid?:Date
}