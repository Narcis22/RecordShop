import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { SongsRoutingModule } from './songs-routing.module';
import { GenreComponent } from './genre/genre.component';
import { ArtistComponent } from './artist/artist.component';
import { MaterialModule } from '../material/material.module';
import { SongComponent } from './song/song.component';
import { PopupModule } from '../popup/popup.module';
import { HoverButtonDirective } from 'src/app/hover-button.directive';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';


@NgModule({
  declarations: [
    GenreComponent,
    ArtistComponent,
    SongComponent,
    HoverButtonDirective,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    SongsRoutingModule,
    MaterialModule,
    PopupModule
  ],
  exports:[
    MaterialModule,
    HoverButtonDirective
  ]
 
})

export class SongsModule { }
