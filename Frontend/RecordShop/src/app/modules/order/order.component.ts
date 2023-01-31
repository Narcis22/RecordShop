import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {

  public index : number = 0;
  public email: string = '';
  public orders: string[];
  constructor(
    private activatedRoute: ActivatedRoute,
    private cartService: CartService,
    private route: Router
  ) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe((params: any) => {
      console.log('param', params);
      this.email = params['email'];
    });

    console.log(this.email);
    this.cartService.GetStringSongCart(this.email).subscribe(
      (response) => {
        console.log(response);
        this.orders =  response;
        this.index += 1;
      },
      (error)=>{
        console.error(error);
      });
  }

  public goBack(): void{
    this.route.navigate(['/songs']);
  }
}
