import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiService } from '../../services/api.service';
import { Image } from '../../models/image';
import { Observable, Subscription, map, of, tap } from 'rxjs';
import { CarouselComponent } from '../carousel/carousel.component';

@Component({
    selector: 'app-gallery',
    standalone: true,
    templateUrl: './gallery.component.html',
    styleUrl: './gallery.component.scss',
    providers: [ApiService],
    imports: [CommonModule, CarouselComponent]
})
export class GalleryComponent implements OnInit {
  images$: Observable<Image[]> = of([]);
  selectedImage: Image | undefined;
  sub: Subscription | undefined;

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.images$ = this.api.getImages();
  }

  handleImageSelection(imageId: number) {
    this.sub = this.images$.pipe(
      map(res => res.find(image => image.id === imageId)),
      tap((image: Image | undefined) => {
        this.selectedImage = image;
      })
    ).subscribe();
  }
}
