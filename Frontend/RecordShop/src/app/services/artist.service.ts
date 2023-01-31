import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Artist } from '../interfaces/artist';
import { ArtistInfo } from '../interfaces/artist-info';

@Injectable({
  providedIn: 'root'
})
export class ArtistService {

  httpOptions = {
    headers: new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken'))
  };

  public url = "https://localhost:5001/api/artist";

  constructor(
    private http: HttpClient
  ) { }

  public AddArtist(artist: Artist) :Observable<Artist[]>{
    return this.http.post<Artist[]>(`${this.url}/AddArtist`, artist, this.httpOptions);
  }

  public UpdateArtist(artist: Artist) :Observable<Artist[]>{
    return this.http.put<Artist[]>(`${this.url}/UpdateArtist`, artist, this.httpOptions);
  }

  public DeleteArtist(artist: Artist) :Observable<any>{
    const options = {
          headers: new HttpHeaders()
              .set('Content-Type', 'application/json')
              .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken')),
          body: artist,
        };
    return this.http.delete<any>(`${this.url}/DeleteArtist`, options);  
  }

  public GetArtists(): Observable<Artist[]>{
    return this.http.get<Artist[]>(`${this.url}/GetArtists`);
  }

  public GetArtistInfo(id : number): Observable<ArtistInfo>{
    const options = {
      headers: new HttpHeaders()
          .set('Content-Type', 'application/json')
    };
    return this.http.get<ArtistInfo>(`${this.url}/GetArtistInfo/${id}`, options);
  }



}
