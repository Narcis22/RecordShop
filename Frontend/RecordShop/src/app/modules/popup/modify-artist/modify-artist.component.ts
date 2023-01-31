import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ArtistService } from 'src/app/services/artist.service';

@Component({
  selector: 'app-modify-artist',
  templateUrl: './modify-artist.component.html',
  styleUrls: ['./modify-artist.component.scss']
})
export class ModifyArtistComponent implements OnInit {

  public artistForm: FormGroup = new FormGroup({
    id: new FormControl(0),
    firstName: new FormControl(''),
    lastName: new FormControl(''),
  });

  public title;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data : any,
    private artistService: ArtistService,
    public dialogRef: MatDialogRef<ModifyArtistComponent>,
  ) {
    
    if (data.artist) {
      this.title = 'Edit artist';
      this.artistForm.patchValue(this.data.artist);
    } 
    else {
      this.title = 'Add artist';
    }
  }

  ngOnInit() {
  }

  public add(): void{

    this.artistService.AddArtist(this.artistForm.value).subscribe(
      (response)=>{
        console.log(response);
        this.dialogRef.close(response);
      },
      (error)=>{
        console.error(error);
      });
  }

  public edit(): void{

    this.artistService.UpdateArtist(this.artistForm.value).subscribe(
      (response)=>{
        console.log(response);
        this.dialogRef.close(response);
      },
      (error)=>{
        console.error(error);
      });
  }
}

