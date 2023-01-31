import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ArtistInfo } from 'src/app/interfaces/artist-info';
import { ArtistService } from 'src/app/services/artist.service';

@Component({
  selector: 'app-artist-details',
  templateUrl: './artist-details.component.html',
  styleUrls: ['./artist-details.component.scss']
})
export class ArtistDetailsComponent implements OnInit {

  public title: string = "Details"
  public artistInfo: ArtistInfo ={
    nationality: 'unknown',
    birthYear: 0,
    deathYear: 0,
  };

  constructor(
    @Inject(MAT_DIALOG_DATA) public data : any,
    private artistService: ArtistService,
    public dialogRef: MatDialogRef<ArtistDetailsComponent>,
  ) { }
 

  ngOnInit() {

    this.artistService.GetArtistInfo(this.data.id).subscribe(
      (response) =>{
          this.artistInfo = response;
        console.log(this.artistInfo);
        if(this.artistInfo.nationality === null && this.artistInfo.birthYear === null && this.artistInfo.deathYear === null)
        {
          this.title = 'There are no details!';
        }
      },  
      (error)=>{
        console.error(error);
      });
  }
  
}  
