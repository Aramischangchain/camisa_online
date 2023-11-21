import { Cliente } from './../../Cliente';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ClienteService } from 'src/app/cliente.service';
@Component({
  selector: 'app-cliente',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  clientes: Array<any> | undefined;
  constructor(private clienteService : ClienteService) { }

  ngOnInit(): void {
    this.listarClientes();
    this.tituloFormulario = 'Novo Cliente';
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      email: new FormControl(null),
      endereco: new FormControl(null)
    })

    }
  listarClientes(): void {
    this.clienteService.listar().subscribe(clientes => {
       this.clientes = clientes;
    });
   }
  enviarFormulario(): void {
    const cliente : Cliente = this.formulario.value;
    this.clienteService.cadastrar(cliente).subscribe(result => {
      alert('Cliente inserido com sucesso.');
    })
  }
}


