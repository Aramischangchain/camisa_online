import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Fornecedor } from './Fornecedor';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ForncedorService {
  apiUrl = 'http://localhost:5000/Fornecedor';
  constructor(private http: HttpClient) { }
  listar(): Observable<Fornecedor[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Fornecedor[]>(url);
  }
  buscar(id: number): Observable<Fornecedor> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Fornecedor>(url);
  }
  cadastrar(fornecedor: Fornecedor): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Fornecedor>(url, fornecedor, httpOptions);
  }
  atualizar(fornecedor: Fornecedor): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Fornecedor>(url, fornecedor, httpOptions);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }

}
