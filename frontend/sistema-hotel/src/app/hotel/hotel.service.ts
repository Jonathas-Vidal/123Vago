import { inject, Injectable } from '@angular/core';
import { Hotel } from './hotel.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HotelService {
  private http = inject(HttpClient);
  private readonly API = 'https://localhost:5432/api/Hotel';

  listar(): Observable<Hotel[]> {
    return this.http.get<Hotel[]>(this.API);
  }

  adicionar(hotel: Omit<Hotel, 'id'>): Observable<Hotel> {
    return this.http.post<Hotel>(this.API, hotel);
  }

buscarPorId(id: number): Observable<Hotel> {
  return this.http.get<Hotel>(`${this.API}/${id}`);
}

atualizar(hotel: Hotel): Observable<void> {
  return this.http.put<void>(`${this.API}/${hotel.id}`, hotel);
}

  remover(id: number): Observable<void> {
    return this.http.delete<void>(`${this.API}/${id}`);
  }
}

