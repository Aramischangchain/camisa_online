import { ItemPedido } from './ItemPedido';
export class Pedido {
  status: string = '';
  preco: number = 0;
  itempedidoId: number = 0;
  itempedido: ItemPedido | undefined;

  }
