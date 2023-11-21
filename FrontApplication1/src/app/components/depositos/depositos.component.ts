import { Deposito } from './../../Deposito';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DepositoService } from 'src/app/depositos.service';

@Component({
  selector: 'app-deposito',
  templateUrl: './depositos.component.html',
  styleUrls: ['./depositos.component.css']
})
export class DepositosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  depositos: Array<any> | undefined;
  constructor(private depositoService : DepositoService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Deposito';
    this.formulario = new FormGroup({
      quantidade: new FormControl(null),
      estoqueId: new FormControl(null),
    })
  }

  listarDepositos(): void {
    this.depositoService.listar().subscribe(depositos => {
       this.depositos = depositos;
    });
   }
  enviarFormulario(): void {
    const deposito : Deposito = this.formulario.value;
    this.depositoService.cadastrar(deposito).subscribe(result => {
      alert('Deposito inserido com sucesso.');
    })
  }
}
