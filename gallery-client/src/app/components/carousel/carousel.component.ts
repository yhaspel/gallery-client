import { Component, Input, ViewChild, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Image } from '../../models/image';

@Component({
  selector: 'app-carousel',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './carousel.component.html',
  styleUrl: './carousel.component.scss'
})
export class CarouselComponent {
  @Input() images: Image[] | null = [];
  @Output() imageSelected = new EventEmitter<number>();
  @ViewChild('imagesContainer') imageContainer: any;

  width = 120;
  height = 100;

  constructor() {

  }

  handlePrevious() {
    this.imageContainer.nativeElement.scrollBy(-300, 0)
  }

  handleNext() {
    this.imageContainer.nativeElement.scrollBy(300, 0)
  }

  handleSelect(imageId: number) {
    this.imageSelected.emit(imageId);
  }
}
