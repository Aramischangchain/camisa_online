import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ClientesComponent } from './components/clientes/clientes.component';
import {DepositosComponent } from './components/depositos/depositos.component';
import { FornecedoresComponent } from './components/fornecedores/fornecedores.component';
import { ProdutosComponent } from './components/produtos/produtos.component';

const routes: Routes = [{
  path: 'clientes', component:ClientesComponent
  },
  { path: 'depositos', component:DepositosComponent
},
{path: 'fornecedores', component:FornecedoresComponent},
{path: 'produtos', component:ProdutosComponent},
{path: 'pedidos', component:ProdutosComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
