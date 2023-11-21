import { ItemPedido } from './../../ItemPedido';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ItemPedidoService } from 'src/app/itens-pedido.service';
@Component({
  selector: 'app-cliente',
  templateUrl: './itens-pedido.component.html',
  styleUrls: ['./itens-pedido.component.css']
})
export class ItensPedidoComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  itenspedido: Array<any> | undefined;
  constructor(private itempedidoService : ItemPedidoService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Item';
    this.formulario = new FormGroup({
      descricao: new FormControl(null),
      quantidade: new FormControl(null),
      produto: new FormControl(null)
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
