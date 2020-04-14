import { Component, OnInit } from '@angular/core';
import { Prestamo } from '../models/prestamo';
import { PrestamoService } from 'src/app/servicios/prestamo.service';

@Component({
  selector: 'app-prestamo-registro',
  templateUrl: './prestamo-registro.component.html',
  styleUrls: ['./prestamo-registro.component.css']
})
export class PrestamoRegistroComponent implements OnInit {
  prestamo: Prestamo;
  constructor(private personaService: PrestamoService) { }
  ngOnInit() {
    this.prestamo = new Prestamo();
  }
  registrar() {
    this.personaService.post(this.prestamo).subscribe(p => {
      if (p != null) {
        alert('Prestamo registrado con éxito');
        this.prestamo = p;
      }
    });
  }
}