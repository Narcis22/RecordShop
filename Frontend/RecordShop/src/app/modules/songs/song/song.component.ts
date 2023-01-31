import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Artist } from 'src/app/interfaces/artist';
import { Song } from 'src/app/interfaces/song';
import { NumberSongsWithGenre } from 'src/app/interfaces/number-songs-with-genre';
import { SongService } from 'src/app/services/song.service';
import { SharedDataService } from 'src/app/services/shared-data.service';
import { ModifySongComponent } from '../../popup/modify-song/modify-song.component';

@Component({
  selector: 'app-song',
  templateUrl: './song.component.html',
  styleUrls: ['./song.component.scss']
})

export class SongComponent implements OnInit, OnDestroy {

  public subscription: Subscription;
  public sharedEmail: string = ''; 
  public songs: Song[];
  public role: string = localStorage.getItem('Role');

  public parentMessage: NumberSongsWithGenre[]; 
  
  public givenFromArtistComponent: Artist = {id: 0, firstName: 'default', lastName: 'default'};
  public givenNameFromGenreComponent: string = 'default';
                        
  constructor(
    private router: Router,
    private sharedDataService: SharedDataService,
    private songService: SongService,
    public dialog: MatDialog,
  ) { }

  ngOnInit(): void {

    this.subscription = this.sharedDataService.currentEmailUser.subscribe((sharedEmail) => this.sharedEmail = sharedEmail);
    this.songService.getAllSongs().subscribe(
      (result: Song[]) => {
        console.log(result);
        this.songs = result;
      },
      (error) => {
        console.error(error);
      });

    this.songService.noSongsWithGenre().subscribe(
      (response) => 
      {
        this.parentMessage = response;
        console.log("List was refreshed", this.parentMessage);
      },
      (error)=>{
        console.error(error);
      });
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  public auth(): void{
    this.router.navigate(['/auth']);
  }

  
  public receiveMessageFromArtist(event: Artist): void{
    console.log(event);
    this.givenFromArtistComponent = event;
  }
  public receiveMessageFromGenre(event: string): void{
    console.log(event);
    this.givenNameFromGenreComponent = event;
  }

  public logout(): void{
    this.sharedDataService.changeUserData('default email');
    
    this.role = localStorage.getItem('Role');

    localStorage.setItem('Role', 'User');
    localStorage.setItem('accessToken', '');
    localStorage.setItem('refreshToken', '');
  }

  public delete(song: Song): void{
    console.log(song);
    this.songService.deleteSong(song).subscribe(
      (response)=>{
        this.songs = response;
      },
      (error) =>{
          console.error(error);
      }
    );
  }

  public edit(song: Song): void{
    this.openModal(song);

  }

  public add(): void{
    this.openModal();
  }

  public openModal(song?: Song): void {
    const data = {
      song
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '700px';
    dialogConfig.data = data;
    
    const dialogRef = this.dialog.open(ModifySongComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      console.log(result);
      if (result) {
        this.songs = result;
      }
    });
  }
  
  public addToCart(song: Song): void{

    console.log(this.sharedEmail);
    if(this.sharedEmail == 'default email')
        this.router.navigate(['/auth']);
    else
    {
      this.songService.addCartToUser(this.sharedEmail).subscribe(
        (response)=>{
            this.songService.addToSongCart(song.id, this.sharedEmail).subscribe(
              (response) => {
                console.log("Adaugat");
              },
              (error)=>{
                console.error(error);
              });
        },
        (error)=>{
          console.error(error);
        });
    }
  }

  public saveEdits(): void{
    console.log(this.givenFromArtistComponent);
    console.log(this.givenNameFromGenreComponent);
    
    if(this.givenFromArtistComponent.id != 0)
    {
      console.log(this.givenFromArtistComponent);
      
      this.songService.getSongsWithArtist(this.givenFromArtistComponent.id).subscribe(
        (response)=>{
          this.songs = response;
          this.givenFromArtistComponent.id = 0; 
          if(this.givenNameFromGenreComponent != 'default'){

            this.songService.getSongWithGenre(this.givenNameFromGenreComponent).subscribe(
              (response)=>{
                this.songs = response;
                this.givenNameFromGenreComponent = 'default';
              },
              (error)=>{
                console.error(error);
              });
          }
        },
        (error)=>{
          console.error(error);
        });
    }
    else
      if(this.givenNameFromGenreComponent != 'default')
      {
        this.songService.getSongWithGenre(this.givenNameFromGenreComponent).subscribe(
          (response)=>{
            this.songs = response;
            this.givenNameFromGenreComponent = 'default';
          },
          (error)=>{
            console.error(error);
          });     
      }
      else{
        this.songService.getAllSongs().subscribe(
          (result: Song[]) => {
            this.songs = result;
          },
          (error) => {
            console.error(error);
          });
      }
    }  
    
  public goToUserCart(): void{
    this.router.navigate(['cart/', this.sharedEmail]);
  }

  public goToOrders (): void{
    this.router.navigate(['orders/', this.sharedEmail]);
  }
  
}


