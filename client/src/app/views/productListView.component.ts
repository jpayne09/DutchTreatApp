﻿import { Component, OnInit } from "@angular/core";
import { Store } from '../services/store.service';

@Component({
  selector: "product-list",
  templateUrl: "productListView.component.html"
})
export class ProductListView implements OnInit {
    public products = [];

    constructor(public store: Store) {
        this.products = store.products;
    }
    ngOnInit(): void {
        this.store.loadProducts()
            .subscribe();
    }


}