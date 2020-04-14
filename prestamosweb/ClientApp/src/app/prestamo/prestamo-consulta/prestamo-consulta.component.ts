import { Component, OnInit } from '@angular/core';
import { Prestamo } from '../models/prestamo';
import { PrestamoService } from 'src/app/servicios/prestamo.service';

@Component({
  selector: 'app-prestamo-consulta',
  templateUrl: './prestamo-consulta.component.html',
  styleUrls: ['./prestamo-consulta.component.css']
})
export class PrestamoConsultaComponent implements OnInit {
  prestamos: Prestamo[];
  constructor(private prestamoService: PrestamoService) { }
  ngOnInit() {
    this.prestamoService.get().subscribe(result => {
      this.prestamos = result;
    });
  }
}

