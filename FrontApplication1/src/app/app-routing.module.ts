import { PedidoComponent } from './components/pedidos/pedidos.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientesComponent } from './components/clientes/clientes.component';
import {DepositosComponent } from './components/depositos/depositos.component';
import { FornecedoresComponent } from './components/fornecedores/fornecedores.component';
import { ProdutosComponent } from './components/produtos/produtos.component';
import { PagamentosComponent } from './components/pagamentos/pagamentos.component';
import { ItensPedidoComponent } from './components/itens-pedido/itens-pedido.component';

const routes: Routes = [{
path: 'clientes', component:ClientesComponent},
{path: 'depositos', component:DepositosComponent},
{path: 'produtos', component:ProdutosComponent},
{path: 'pedidos', component:PedidoComponent},
{path: 'pagamentos', component: PagamentosComponent},
{path: 'itenspedido', component: ItensPedidoComponent},
{path: 'fornecedores', component: FornecedoresComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
