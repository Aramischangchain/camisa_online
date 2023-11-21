import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Deposito } from './Deposito';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class DepositoService {
  apiUrl = 'http://localhost:5000/Deposito';
  constructor(private http: HttpClient) { }
  listar(): Observable<Deposito[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Deposito[]>(url);
  }
  buscar(id: number): Observable<Deposito> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Deposito>(url);
  }
  cadastrar(deposito: Deposito): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Deposito>(url, deposito, httpOptions);
  }
  atualizar(deposito: Deposito): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Deposito>(url, deposito, httpOptions);
  }
  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.delete<string>(url, httpOptions);
  }

}
