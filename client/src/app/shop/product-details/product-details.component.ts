import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product: IProduct;

  constructor(private shopService: ShopService, private activatedRoute: ActivatedRoute, private bcService: BreadcrumbService) {
    this.bcService.set('@productDetails', ' '); /*tozihat safe 7 mored 4 */
  }

  ngOnInit() {
    this.loadProduct();
  }

  loadProduct() {
    this.shopService.getProduct(+this.activatedRoute.snapshot.paramMap.get('id')).subscribe(product => { /*tozihat safe 5 mored 4 */
      this.product = product;
      this.bcService.set('@productDetails', product.name); /*tozihat safe 6 mored 6 */
    }, error => {
      console.log(error);
    });
  }

}
