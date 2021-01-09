import { Component, OnInit } from '@angular/core';
import { BookstoreService } from 'src/app/services/bookstore.service';
import { Book } from '../models/book';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  books: Book[] = [];
  columns = ['id', 'author', 'title', 'price']

  constructor(private bs: BookstoreService) { }

  ngOnInit(): void {
    this.bs.getCatalog()
      .subscribe(res => {
        this.books = res;
      });
  }

}
