import { ItemPedido } from './ItemPedido';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ItemPedidoService {
  apiUrl = 'http://localhost:5000/ItemPedido';
  constructor(private http: HttpClient) { }
  listar(): Observable<ItemPedido[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<ItemPedido[]>(url);
  }
  buscar(id: number): Observable<ItemPedido> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<ItemPedido>(url);
  }
  cadastrar(itempedido: ItemPedido): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<ItemPedido>(url, itempedido, httpOptions);
  }
  atualizar(itemPedido: ItemPedido): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<ItemPedido>(url, itemPedido, httpOptions);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }

}
