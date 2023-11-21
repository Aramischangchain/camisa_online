import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule} from 'ngx-bootstrap/modal';

import { ClienteService } from './cliente.service';
import { ClientesComponent } from './components/clientes/clientes.component';
import { ProdutosComponent } from './components/produtos/produtos.component';
import { FornecedoresComponent } from './components/fornecedores/fornecedores.component';
import { DepositosComponent } from './components/depositos/depositos.component';
import { PedidosComponent } from './components/pedidos/pedidos.component';
import { ItensPedidoComponent } from './components/itens-pedido/itens-pedido.component';
import { PagamentosComponent } from './components/pagamentos/pagamentos.component';

@NgModule({
  declarations: [
    AppComponent,
    ClientesComponent,
    ProdutosComponent,
    FornecedoresComponent,
    PedidosComponent,
    ItensPedidoComponent,
    PagamentosComponent,
    DepositosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  providers: [HttpClientModule, ClienteService],
  bootstrap: [AppComponent]
})
export class AppModule { }
