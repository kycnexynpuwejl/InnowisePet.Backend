import { Component, OnInit } from '@angular/core';
import { ProductService } from '../product.service';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  public products: Array<string> = []
  constructor(private productService: ProductService) { }
  
  ngOnInit() {
    this.productService.getProducts().subscribe(x => console.log(x))
  }

}
