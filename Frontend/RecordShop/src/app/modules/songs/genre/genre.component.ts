import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Genre } from 'src/app/interfaces/genre';
import { GenreService } from 'src/app/services/genre.service';
import { ModifyGenreComponent } from '../../popup/modify-genre/modify-genre.component';

@Component({
  selector: 'app-genre',
  templateUrl: './genre.component.html',
  styleUrls: ['./genre.component.scss']
})
export class GenreComponent implements OnInit {
  
  public displayedColumns = [ 'Genre', 'edit',  'select'];
  public genres: Genre[]; 
  constructor(
    protected genreService: GenreService,
    public dialog: MatDialog,
  ) {}

  @Input() messageFromSongs: any;
  @Output() givenGenre = new EventEmitter<string>();

  ngOnInit(): void {
    this.genreService.getGenres().subscribe(
      (response)=>{
        this.genres = response;
        console.log(this.genres);
      },
      (error)=>{
        console.log(error);
      });    
  }

  public isAdmin(): boolean{

    if(localStorage.getItem('Role') === 'User'){
        return false;
    }
    else{
        return true;
    }
  }

  public select(genre: Genre): void{
    this.givenGenre.emit(genre.name);
  }

  public delete(genre?: Genre): void{
      this.genreService.DeleteGenres().subscribe(
        (response) => {
          this.genres = response;
        },
        (error)=>{
          console.error(error);
        });

  }

  public edit(genre: Genre): void{
    console.log("in edit");
    this.openModal(genre);
  }

  public add(): void{
    this.openModal();
  }

  public openModal(genre?: Genre): void {
    const data = {
      genre
    }

    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '300px';
    dialogConfig.height = '250px';
    dialogConfig.data = data;

    console.log("in openModal");
    
    const dialogRef = this.dialog.open(ModifyGenreComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      console.log(result);
      if (result) {
        this.genres = result;
      }
    });
  }

}
