import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ModifySongComponent } from './modify-song/modify-song.component';
import { ModifyGenreComponent } from './modify-genre/modify-genre.component';
import { ModifyArtistComponent } from './modify-artist/modify-artist.component';
import { ArtistDetailsComponent } from './artist-details/artist-details.component';
import { MarksPipe } from 'src/app/marks.pipe';


@NgModule({
  declarations: [
    ModifySongComponent,
    ModifyGenreComponent,
    ModifyArtistComponent,
    ArtistDetailsComponent,
    MarksPipe,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  entryComponents: [
    ModifySongComponent,
    ModifyArtistComponent,
    ModifyGenreComponent,
    ArtistDetailsComponent,
  ],
  exports:[
    MarksPipe,
  ],
})

export class PopupModule { }
