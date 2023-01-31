import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';
import { CartComponent } from './modules/cart/cart.component';
import { OrderComponent } from './modules/order/order.component';

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'auth',
  },
  {
    path: 'auth',
    loadChildren: () => import('src/app/modules/auth/auth.module').then(m => m.AuthModule),
  },
  {
    path: 'songs',
    loadChildren: () => import('src/app/modules/songs/songs.module').then(m => m.SongsModule),
  },
  {
    path: 'cart/:email',
    canActivate: [AuthGuard],
    component: CartComponent
  },
  {
    path: 'orders/:email',
    canActivate: [AuthGuard],
    component: OrderComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }