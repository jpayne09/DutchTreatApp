import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from "@angular/common/http"
import { AppComponent } from './app.component';
import { ProductListView } from './views/ProductListView.component';

import { CartView } from './views/cartView.component';
import router from './router';
import ShopPage from './pages/shopPage.component';
import { Checkout } from './pages/checkout.component';
import Store from './store';
import LoginPage from './pages/loginPage.component';
import AuthActivator from './services/authActivator.service';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
        AppComponent,
        ProductListView,
        CartView,
        ShopPage,
        Checkout,
        LoginPage
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      router,
      FormsModule
  ],
    providers: [
        Store,
        AuthActivator
    ],
  bootstrap: [AppComponent]
})
export class AppModule { }
