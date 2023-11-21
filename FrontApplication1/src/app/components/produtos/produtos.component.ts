import { Produto } from './../../Produto';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ProdutoService } from 'src/app/produtos.service';

@Component({
  selector: 'app-produto',
  templateUrl: './produtos.component.html',
  styleUrls: ['./produtos.component.css']
})
export class ProdutosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  clientes: Array<any> | undefined;
  constructor(private produtoService : ProdutoService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Produto';
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      email: new FormControl(null),
      endereco: new FormControl(null)
    })
  }

  listarClientes(): void {
    this.produtoService.listar().subscribe(clientes => {
       this.clientes = clientes;
    });
   }
  enviarFormulario(): void {
    const produto : Produto = this.formulario.value;
    this.produtoService.cadastrar(produto).subscribe(result => {
      alert('Produto inserido com sucesso.');
    })
  }
}
