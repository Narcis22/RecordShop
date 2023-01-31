import { EventEmitter ,Component, Input, OnInit, Output } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Artist } from 'src/app/interfaces/artist';
import { ArtistService } from 'src/app/services/artist.service';
import { ArtistDetailsComponent } from '../../popup/artist-details/artist-details.component';
import { ModifyArtistComponent } from '../../popup/modify-artist/modify-artist.component';

@Component({
  selector: 'app-artist',
  templateUrl: './artist.component.html',
  styleUrls: ['./artist.component.scss']
})
export class ArtistComponent implements OnInit {

  public artists: Artist[];
  public artistInfo: any;
  public displayedColumns = [ 'First Name', 'Last Name', 'About', 'edit', 'delete', 'select'];

  @Output() givenArtist = new EventEmitter<any>();
  constructor(
    private artistService: ArtistService,
    public dialog: MatDialog,
  ) { }

  ngOnInit(): void {
    this.artistService.GetArtists().subscribe(
      (response)=>{
        console.log(response);
        this.artists = response;
      },
      (error)=>{
        console.error(error);
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

  public edit(artist: Artist): void{
    this.openModal(artist);

  }

  public add(): void{
    this.openModal();
  }

  public openModal(artist?: Artist): void {
    const data = {
      artist
    };
    
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '500px';
    dialogConfig.height = '350px';
    dialogConfig.data = data;
    
    const dialogRef = this.dialog.open(ModifyArtistComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      console.log(result);
      if (result) {
        this.artists = result;
      }
    });
  }

  public delete(artist: Artist): void{
    console.log(artist);
    
    this.artistService.DeleteArtist(artist).subscribe(
      (response)=>{
        this.artists=response;
      },
      (error)=>{
        console.error(error);
      });
  }

  public info(artist: Artist): void{
      console.log(artist);

      const dialogConfig = new MatDialogConfig();
      dialogConfig.width = '400px';
      dialogConfig.height = '500px';
      dialogConfig.data = artist;
      
      const dialogRef = this.dialog.open(ArtistDetailsComponent, dialogConfig);
      dialogRef.afterClosed().subscribe((result) => {
        console.log(result);
      });
  }

  public select(artist: any)
  {
    this.givenArtist.emit(artist);
  }

}
