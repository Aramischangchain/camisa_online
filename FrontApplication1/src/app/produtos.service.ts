import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Produto } from './Produto';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ProdutoService {
  apiUrl = 'http://localhost:5000/Produto';
  constructor(private http: HttpClient) { }
  listar(): Observable<Produto[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Produto[]>(url);
  }
  buscar(id: number): Observable<Produto> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Produto>(url);
  }
  cadastrar(produto: Produto): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Produto>(url, produto, httpOptions);
  }
  atualizar(produto: Produto): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Produto>(url, produto, httpOptions);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }

}
