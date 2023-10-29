import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ClienteService } from 'src/app/cliente.service';
import { Cliente } from 'src/app/Cliente';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private clienteService : ClienteService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Cliente';
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      email: new FormControl(null),
      endereco: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const cliente : Cliente = this.formulario.value;
    this.clienteService.cadastrar(cliente).subscribe(result => {
      alert('Cliente inserido com sucesso.');
    })
  }
}
