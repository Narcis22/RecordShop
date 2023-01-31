import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Genre } from 'src/app/interfaces/genre';
import { GenreService } from 'src/app/services/genre.service';

@Component({
  selector: 'app-modify-genre',
  templateUrl: './modify-genre.component.html',
  styleUrls: ['./modify-genre.component.scss']
})
export class ModifyGenreComponent implements OnInit {
  
  public genreForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    name: new FormControl(''),
  });

  public title;
  
  constructor(
    @Inject(MAT_DIALOG_DATA) public data : any,
    private genreService: GenreService,
    public dialogRef: MatDialogRef<ModifyGenreComponent>,
  ) {
    console.log(this.data);
    if (data.genre) {
      this.title = 'Edit genre name';
      this.genreForm.patchValue(this.data.genre);
    } 
    else {
      this.title = 'Add genre';
    }
  }

  ngOnInit() {

  }

  public add(): void{
    this.genreService.addGenre(this.genreForm.value).subscribe(
      (response)=>{
        console.log(response);
        this.dialogRef.close(response);
      },
      (error)=>{
        console.error(error);
      });
  }

  public edit(): void{
    this.genreService.UpdateGenre(this.genreForm.value).subscribe(
      (response)=>{
        console.log(response);
        this.dialogRef.close(response);
      },
      (error)=>{
        console.error(error);
      });
  }

}
