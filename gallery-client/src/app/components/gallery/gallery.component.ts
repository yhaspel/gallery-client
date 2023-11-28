import { Component, OnDestroy, OnInit } from '@angular/core';
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
export class GalleryComponent implements OnInit, OnDestroy {
  images$: Observable<Image[]> = of([]);
  selectedImage: Image | undefined;
  sub: Subscription | undefined;

  constructor(private api: ApiService) {}

  ngOnInit(): void {
    this.images$ = this.api.getImages().pipe(tap((images: Image[]) => {
      this.selectedImage = images[2];
    }));
  }

  ngOnDestroy(): void {
    this.sub?.unsubscribe();
  }

  handleImageSelection(imageId: number) {
    console.warn('selected image id >>>', imageId);
    this.sub = this.images$.pipe(
      map(res => res.find(image => image.id === imageId)),
      tap((image: Image | undefined) => {
        console.warn('image', image);
        this.selectedImage = image;
      })
    ).subscribe();
  }
}
