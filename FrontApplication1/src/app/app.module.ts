import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule} from 'ngx-bootstrap/modal';

import { ClienteService } from './cliente.service';
import { ClienteComponent } from './components/cliente/cliente.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';

const routes: Routes = [
  { path: 'cliente', component: ClienteComponent},
  { },
  // Outras rotas...
];
@NgModule({
  declarations: [
    AppComponent,
    ClienteComponent,
    NavBarComponent,
  ],

  imports: [
    [RouterModule.forRoot(routes)],
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  exports: [RouterModule],

  providers: [HttpClientModule, ClienteService],
  bootstrap: [AppComponent]
})
export class AppModule { }

