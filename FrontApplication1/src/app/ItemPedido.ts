import { Produto } from './Produto';
export class ItemPedido {
  descricao: string = '';
  quantidade: number = 0;
  produtoId: number = 0;
  produto: Produto | undefined;
  }
