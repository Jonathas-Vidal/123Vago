import { Routes } from '@angular/router';
import { HotelFormComponent } from './hotel/hotel-form/hotel-form.component';
import { HotelListComponent } from './hotel/hotel-list/hotel-list.component';

export const routes: Routes = [
  { path: '', component: HotelListComponent },
  { path: 'novo', component: HotelFormComponent },
  { path: 'editar/:id', component: HotelFormComponent },
];
