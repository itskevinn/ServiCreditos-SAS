import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { PrestamoConsultaComponent } from './prestamo/prestamo-consulta/prestamo-consulta.component';
import { PrestamoRegistroComponent } from './prestamo/prestamo-registro/prestamo-registro.component';

const rutas: Routes = [
  {
    path: 'ConsultaPestamos',
    component: PrestamoConsultaComponent
  },
  {
    path: 'RegistroPrestamos',
    component: PrestamoRegistroComponent
  }

];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(rutas),
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
