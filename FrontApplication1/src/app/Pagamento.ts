import { Pedido } from './Pedido';
export class ItemPedido {
  numerocartao: string = '';
  validade: string = '';
  nometitular: string = '';
  pedidoId: number = 0;
  pedido: Pedido | undefined;
  }
