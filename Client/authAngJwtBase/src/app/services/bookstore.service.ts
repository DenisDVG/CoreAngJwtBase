import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { STORE_API_URL } from '../app-injection-tokens';
import { Book } from '../components/models/book';

@Injectable({
  providedIn: 'root'
})
export class BookstoreService {

  private baseApiUrl = `${this.apiUrl}api/`;

  constructor(
    private http: HttpClient,
    @Inject(STORE_API_URL) private apiUrl: string
  ) { }

  // Мы не добавляем вручную токен к запросам это деллается
  // автоматически перехватчиком запросов который мы добавили как
  // библиотеку работы с токенами

  getCatalog(): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.baseApiUrl}book`);
  }

  getOrders(): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.baseApiUrl}orders`);
  }
}
