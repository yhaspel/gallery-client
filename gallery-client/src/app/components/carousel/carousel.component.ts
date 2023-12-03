import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { Image } from '../../models/image';
import { CommonModule } from '@angular/common';
import { CarouselModule } from 'primeng/carousel';


@Component({
  selector: 'app-carousel',
  standalone: true,
  templateUrl: './carousel.component.html',
  styleUrls: ['./carousel.component.scss'],
  imports: [CommonModule, CarouselModule]
})
export class CarouselComponent implements OnInit {
  @Input() images: Image[] | null = [];
  @Output() imageSelected = new EventEmitter<number>();

  ngOnInit(): void {
    console.log('Images:', this.images);
  }
  
  handleImageSelection(imageId: number) {
    this.imageSelected.emit(imageId);
  }
}