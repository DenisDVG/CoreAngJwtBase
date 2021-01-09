import { Component, OnInit } from '@angular/core';
import { BookstoreService } from 'src/app/services/bookstore.service';
import { Book } from '../models/book';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.scss']
})
export class OrdersComponent implements OnInit {


  books: Book[] = [];
  columns = ['id', 'author', 'title', 'price']

  constructor(private bs: BookstoreService) { }

  ngOnInit(): void {
    this.bs.getOrders()
      .subscribe(res => {
        this.books = res;
      });
  }


}
