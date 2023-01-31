import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Genre } from '../interfaces/genre';

@Injectable({
  providedIn: 'root'
})
export class GenreService {

  public url= "https://localhost:5001/api/genre";

  constructor(
    private http: HttpClient
  ) { }


  public addGenre(genre: any): Observable<Genre[]>{
    const options = {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json')
        .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken')),
    };
    return this.http.post<Genre[]>(`${this.url}/AddGenre`,genre, options);
  }
  
  public UpdateGenre(genre: any): Observable<Genre[]>{
    const options = {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json')
        .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken')),
    };
    console.log(genre);
    return this.http.put<Genre[]>(`${this.url}/UpdateGenre`, genre, options);
  }

  public DeleteGenres(): Observable<Genre[]>{
    const options = {
      headers: new HttpHeaders()
        .set('Content-Type', 'application/json')
        .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken'))
    };
    return this.http.delete<Genre[]>(`${this.url}/DeleteGenres`, options);
  }

  public getGenres(): Observable<Genre[]> {
    return this.http.get<Genre[]>(`${this.url}/GetGenres`);
  }
}
