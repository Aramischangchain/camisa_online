import { ItemPedido } from './../../ItemPedido';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ItemPedidoService } from 'src/app/itens-pedido.service';
import { Produto } from 'src/app/Produto';
import { ProdutoService } from './../../produtos.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './itens-pedido.component.html',
  styleUrls: ['./itens-pedido.component.css']
})
export class ItensPedidoComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  itenspedido: Array<any> | undefined;
  produtos: Array<any> | undefined;

  constructor(private itempedidoService : ItemPedidoService,
     private produtosService: ProdutoService) { }

  ngOnInit(): void {
    this.listarItemPedido();
    this.tituloFormulario = 'Novo Item';
    this.produtosService.listar().subscribe(produtos =>{
      this.produtos = produtos;
      if(this.produtos && this.produtos.length > 0){
        this.formulario.get('produtoId')?.setValue(this.produtos[0].id)
      }
    });
    this.formulario = new FormGroup({
      descricao: new FormControl(null),
      quantidade: new FormControl(null),
      produtoId: new FormControl(null),
    })
  }

  listarItemPedido(): void {
    this.itempedidoService.listar().subscribe(itenspedido => {
       this.itenspedido = itenspedido;
    });
   }

  enviarFormulario(): void {
    const itempedido : ItemPedido = this.formulario.value;
    this.itempedidoService.cadastrar(itempedido).subscribe(result => {
      alert('Item inserido com sucesso.');
    })
  }
}
