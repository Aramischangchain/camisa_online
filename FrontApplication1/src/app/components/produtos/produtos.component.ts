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
  produtos: Array<any> | undefined;
  constructor(private produtoService : ProdutoService) { }

  ngOnInit(): void {
    this.listarProduto();
    this.tituloFormulario = 'Novo Produto';
    this.formulario = new FormGroup({
      descricao: new FormControl(null),
      cor: new FormControl(null),
      preco: new FormControl(null),
      tamanho: new FormControl(null)
    })
  }

  listarProduto(): void {
    this.produtoService.listar().subscribe(produtos => {
       produtos = produtos;
    });
   }
  enviarFormulario(): void {
    const produto : Produto = this.formulario.value;
    this.produtoService.cadastrar(produto).subscribe(result => {
      alert('Produto inserido com sucesso.');
    })
  }
}
