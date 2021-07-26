import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { BasketService } from './basket/basket.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Skinet';
  // products: IProduct[];

  constructor(private basketService: BasketService, private accountService: AccountService) {}

  ngOnInit(): void {
    // this.http.get('https://localhost:44328/api/products?pageSize=50').subscribe((response: IPagination) => {
    //   // console.log(response);
    //   this.products = response.data; /*tozihat safe 3 mored 11 */
    // }, error => {
    //   console.log(error);
    // });
    this.loadBasket();
    this.loadCurrentUser(); /*tozihat safe 14 mored 5 */
  }

  loadBasket() {
    const basketId = localStorage.getItem('basket_id');
    if (basketId) {
      this.basketService.getBasket(basketId).subscribe(() => {
        console.log('initialized basket');
      }, error => {
        console.log(error);
      }); /*tozihat safe 9 mored 5 */
    }
  }

  loadCurrentUser() {
    const token = localStorage.getItem('token');
    /*if (token) { */ /*tozihat safe 15 mored 4 */
    this.accountService.loadCurrentUser(token).subscribe(() => {
      console.log('loaded user');
    }, error => {
      console.log(error);
    });
    /*}*/
  }
}
