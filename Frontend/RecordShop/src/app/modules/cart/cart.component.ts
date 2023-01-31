import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SongCart } from 'src/app/interfaces/song-cart';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss']
})
export class CartComponent implements OnInit {

  public message: string  = "";
  public email: string = '';
  public totalPrice: string = '';
  public songcart: SongCart[];

  constructor(
    private activatedRoute: ActivatedRoute,
    private cartService: CartService,
    private route: Router,
    ) {}

  ngOnInit(): void {
    this.activatedRoute.params.subscribe((params: any) => {
      console.log('param', params);
      this.email = params['email'];
    });
  
    console.log(this.email);
    this.cartService.GetSongCartForUser(this.email).subscribe(
      (response)=>{
        this.songcart = response;
        this.condition();
      },
      (error)=>{
        console.error(error);
      });

  }

  public condition(): void{
    console.log('here', this.songcart);
    if(!this.songcart.length)
    {
      console.log("works");
      this.message = "Nothing to see here, move along!";
      this.totalPrice = '';
    }
    else
      this.getPrice();
  }

  public add(songcart: any): void{
    this.cartService.IncreaseNoCopies(songcart).subscribe(
      (response)=>{
        this.songcart=response;
        this.getPrice();
      },
      (error)=>{
        console.error(error);
      });
  }

  public minus(songcart: any): void{
    this.cartService.DecreaseNoCopies(songcart).subscribe(
      (response)=>{
        this.songcart=response;
        this.condition();
      },
      (error)=>{
        console.error(error);
      });
  }

  public discard(): void{
    this.cartService.DeleteAllSongCartByEmail(this.email).subscribe(
      (response)=>{
        this.songcart=[];
        this.condition();
      },
      (error)=>{
        console.error(error);
      });
  }

  public getPrice(): void{
    console.log(this.songcart);

    this.cartService.CartPrice(this.songcart[0].cartId).subscribe(  
      (response)=>{
        this.totalPrice = response.price;
      },
      (error)=>{
        console.error(error);
      }
    );
  }

  public placeOrder(): void{
    this.cartService.UpdateSentCart(this.email).subscribe(
      (response)=>{
        console.log("Order palced");
        this.songcart = [];
        this.condition();  
      },
      (error)=>{
        console.error(error);
      })

  }

  public goBack(): void{
    this.route.navigate(['/songs']);
  }

}
