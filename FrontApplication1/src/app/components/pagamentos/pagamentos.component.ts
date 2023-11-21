import { PagamentoService } from './../../pagamentos.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Pagamento } from 'src/app/Pagamento';
@Component({
  selector: 'app-pagamento',
  templateUrl: './pagamentos.component.html',
  styleUrls: ['./pagamentos.component.css']
})
export class PagamentosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  pagamentos: Array<any> | undefined;
  constructor(private pagamentoService : PagamentoService) { }

  ngOnInit(): void {
    this.listarPagamento();
    this.tituloFormulario = 'Novo Pagamento';
    this.formulario = new FormGroup({
      numerocartao: new FormControl(null),
      validade: new FormControl(null),
      nometitular: new FormControl(null),
      pedido: new FormControl(null)
    })
  }

  listarPagamento(): void {
    this.pagamentoService.listar().subscribe(pagamentos => {
       this.pagamentos = pagamentos;
    });
   }
  enviarFormulario(): void {
    const pagamento : Pagamento = this.formulario.value;
    this.pagamentoService.cadastrar(pagamento).subscribe(result => {
      alert('Pagamento inserido com sucesso.');
    })
  }
}
