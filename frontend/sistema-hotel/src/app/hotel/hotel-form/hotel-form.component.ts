import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { HotelService } from '../hotel.service';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-hotel-form',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    CommonModule,
  ],
  templateUrl: './hotel-form.component.html',
  styleUrls: ['./hotel-form.component.css'],
})
export class HotelFormComponent implements OnInit {
  form: FormGroup;
  hotelId?: number;
  isEditMode = false;

  constructor(
    private fb: FormBuilder,
    private service: HotelService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.form = this.fb.group({
      nome: ['', Validators.required],
      descricao: ['', Validators.required],
      localizacao: ['', Validators.required],
      quarto: [null, [Validators.required, Validators.min(0)]],
    });
  }

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');

    if (id) {
      this.hotelId = +id;
      this.isEditMode = true;
      this.service.buscarPorId(this.hotelId).subscribe({
        next: (hotel) => this.form.patchValue(hotel),
        error: () => alert('Erro ao carregar hotel para edição.'),
      });
    }
  }

  salvar() {
    if (this.form.valid) {
      if (this.isEditMode && this.hotelId) {
        const hotelAtualizado = { id: this.hotelId, ...this.form.value };
        this.service.atualizar(hotelAtualizado).subscribe({
          next: () => this.router.navigate(['/']),
          error: () => alert('Erro ao atualizar hotel.'),
        });
      } else {
        this.service.adicionar(this.form.value).subscribe({
          next: () => this.router.navigate(['/']),
          error: () => alert('Erro ao salvar hotel.'),
        });
      }
    }
  }
}