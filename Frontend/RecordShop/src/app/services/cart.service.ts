import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CartService {

  httpOptions = {
    headers: new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken'))
  };

  public urlSongCart = "https://localhost:5001/api/songcart";
  public urlCart = "https://localhost:5001/api/cart";

  constructor(
    private http: HttpClient,
  ) { }

  public CartPrice(id: number): Observable<any>{
    console.log("in service", id);
    return this.http.get<any>(`${this.urlCart}/CartPrice/${id}`);
  }

  public getCartId(email: string): Observable<any>{
    console.log("in service", email);
    return this.http.get<any>(`${this.urlCart}/getCartId/${email}`);
  }

  public UpdateSentCart(email: string): Observable<any>{
    return this.http.put<any>(`${this.urlCart}/UpdateSentCart/${email}`, null);
  }

  public GetSongCartForUser(email: string): Observable<any>{
    return this.http.get<any>(`${this.urlSongCart}/GetSongCartForUser/${email}`);
  }
  
  public DeleteAllSongCartByEmail(email: string): Observable<any>{
    return this.http.delete<any>(`${this.urlSongCart}/DeleteAllSongCartByEmail/${email}`);
  }

  public IncreaseNoCopies(songCart: any): Observable<any>{
    return this.http.put<any>(`${this.urlSongCart}/IncreaseNoCopies`, songCart);
  }

  public DecreaseNoCopies(songCart: any): Observable<any>{
    return this.http.put<any>(`${this.urlSongCart}/DecreaseNoCopies`, songCart);
  }

  public GetStringSongCart(email: string): Observable<any>{
    return this.http.get<any>(`${this.urlCart}/GetStringSongCart/${email}`);
  }
}

        