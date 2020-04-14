import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Prestamo } from '../prestamo/models/prestamo';
import { tap, catchError } from 'rxjs/operators';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';

@Injectable({
  providedIn: 'root'
})
export class PrestamoService {
  urlBase: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') urlBase: string,
    private handleErrorService: HandleHttpErrorService) {
    this.urlBase = urlBase;
  }
  get(): Observable<Prestamo[]> {
    return this.http.get<Prestamo[]>(this.urlBase + 'api/Prestamo')
      .pipe(
        tap(_ => this.handleErrorService.log('Datos traídos')),
        catchError(this.handleErrorService.handleError<Prestamo[]>('Consultar Prestamo', null))
      );
  }
  post(prestamo: Prestamo): Observable<Prestamo> {
    return this.http.post<Prestamo>(this.urlBase + 'api/Prestamo', prestamo)
      .pipe(
        tap(_ => this.handleErrorService.log('Datos enviados')),
        catchError(this.handleErrorService.handleError<Prestamo>('Registrar Prestamo', null))
      );
  }
}
