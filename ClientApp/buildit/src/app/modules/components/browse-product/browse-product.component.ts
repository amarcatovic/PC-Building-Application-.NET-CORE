import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-browse-product',
  templateUrl: './browse-product.component.html',
  styleUrls: ['./browse-product.component.scss'],
})
export class BrowseProductComponent implements OnInit {
  img = 'Master';

  constructor() {}

  ngOnInit(): void {
    console.log('init');
  }
}
