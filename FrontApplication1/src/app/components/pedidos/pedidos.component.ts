import { Pedido } from './../../Pedido';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { PedidoService } from 'src/app/pedidos.service';

@Component({
  selector: 'app-pedido',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidoComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  pedidos: Array<any> | undefined;
  constructor(private pedidoService : PedidoService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Pedido';
    this.formulario = new FormGroup({
      status: new FormControl(null),
      preco: new FormControl(null),
      itempedidoId: new FormControl(null)
    })
  }

  listarPedidos(): void {
    this.pedidoService.listar().subscribe(pedidos => {
       this.pedidos = pedidos;
    });
   }
  enviarFormulario(): void {
    const pedido : Pedido = this.formulario.value;
    this.pedidoService.cadastrar(pedido).subscribe(result => {
      alert('Pedido inserido com sucesso.');
    })
  }
}
