import { ForncedorService } from 'src/app/fornecedores.service';
import { Fornecedor } from './../../Fornecedor';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
@Component({
  selector: 'app-forncedor',
  templateUrl: './fornecedores.component.html',
  styleUrls: ['./fornecedores.component.css']
})
export class FornecedoresComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  fornecedores: Array<any> | undefined;
  constructor(private fornecedorService : ForncedorService) { }

  ngOnInit(): void {
    this.listarFornecedor();
    this.tituloFormulario = 'Novo Fornecedor';
    this.formulario = new FormGroup({
      nome: new FormControl(null),
      contato: new FormControl(null),
      endereco: new FormControl(null)

    })
  }

  listarFornecedor(): void {
    this.fornecedorService.listar().subscribe(fornecedores => {
       this.fornecedores = fornecedores;
    });
   }
  enviarFormulario(): void {
    const fornecedor : Fornecedor = this.formulario.value;
    this.fornecedorService.cadastrar(fornecedor).subscribe(result => {
      alert('Forncedor inserido com sucesso.');
    })
  }
}
