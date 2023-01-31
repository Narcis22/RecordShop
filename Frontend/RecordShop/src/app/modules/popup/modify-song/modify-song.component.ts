import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { SongService } from 'src/app/services/song.service';

@Component({
  selector: 'app-modify-song',
  templateUrl: './modify-song.component.html',
  styleUrls: ['./modify-song.component.scss']
})

export class ModifySongComponent implements OnInit {

  public title;

  public songForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    name: new FormControl(''),
    price: new FormControl(0),
    duration: new FormControl(0),
    releaseYear: new FormControl(0),
    remix: new FormControl(0),
    album: new FormControl(''),
  });

  constructor(
    @Inject(MAT_DIALOG_DATA) public data : any,
    private songService: SongService,
    public dialogRef: MatDialogRef<ModifySongComponent>,
  ) {
    console.log(this.data);
    if (data.song) {
      this.title = 'Edit song';
      this.songForm.patchValue(this.data.song);
    } else {
      this.title = 'Add song';
    }
  }


  ngOnInit() {
  }

  public add(): void {
    console.log(this.songForm.value);

    this.songService.addSong(this.songForm.value).subscribe(
      (result) => {
        console.log(result);
        this.dialogRef.close(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  public edit(): void {
    this.songService.updateSong(this.songForm.value).subscribe(
      (result) => {
        console.log(result);
        this.dialogRef.close(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

}