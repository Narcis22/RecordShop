import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Song } from '../interfaces/song';

@Injectable({
  providedIn: 'root'
})

export class SongService {

  httpOptions = {
    headers: new HttpHeaders()
      .set('Content-Type', 'application/json')
      .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken'))
  };

  public urlSong = "https://localhost:5001/api/song";
  public urlSongCart = "https://localhost:5001/api/songcart";
  public urlCart = "https://localhost:5001/api/cart";

  constructor(
    private http: HttpClient
    ) { }


  public addSong(song: Song): Observable<Song> {
    return this.http.post<Song>(`${this.urlSong}/AddSong`, song, this.httpOptions);
  }

  public updateSong(song:Song):Observable<Song> {
    return this.http.put<Song>(`${this.urlSong}/UpdateSong`, song, this.httpOptions);
  }
  
  public deleteSong(song: any): Observable<any> {
    const options = {
      headers: new HttpHeaders()
          .set('Content-Type', 'application/json')
          .set('Authorization', 'Bearer ' + localStorage.getItem('accessToken')),
      body: song,
    };
    return this.http.delete<any>(`${this.urlSong}/DeleteSong`, options);
  }

  public getAllSongs(): Observable<Song[]>{
    return this.http.get<Song[]>(`${this.urlSong}/GetAllSongs`);
  }

  public getSongWithGenre(genre: string): Observable<Song[]>{
    return this.http.get<Song[]>(`${this.urlSong}/GetSongsWithGenre/${genre}`);
  }

  public getSongsWithArtist(idArtist: number): Observable<Song[]>{
    return this.http.get<Song[]>(`${this.urlSong}/GetSongsWithArtist/${idArtist}`);
  }
  
  public noSongsWithGenre(): Observable<any> {
    return this.http.get<any>(`${this.urlSong}/NoSongsWithGenre`);
  }

  public addToSongCart(id: number, email: string): Observable<any> {
    return this.http.post<any>(`${this.urlSongCart}/AddSongCart/${id}/${email}`, null);
  }

  public addCartToUser(email: string): Observable<any> {
    return this.http.post<any>(`${this.urlCart}/AddCartToUser/${email}`, null);
  }

}
