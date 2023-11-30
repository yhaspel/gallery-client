import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Image } from '../models/image';
import { Observable } from 'rxjs';

/**
 * Temporary - need to connect to backend application to complete requirements of task.
 */
const imagesUrl = 'https://picsum.photos/v2/list?page=1&limit=100';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) { }

  getImages(): Observable<Image[]> {
    return this.http.get(imagesUrl) as Observable<Image[]>;
  }
}
