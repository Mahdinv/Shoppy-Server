import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotFoundComponent } from './core/not-found/not-found.component';
import { ServerErrorComponent } from './core/server-error/server-error.component';
import { TestErrorComponent } from './core/test-error/test-error.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  {path: '', component: HomeComponent, data: {breadcrumb: 'Home'}}, /*tozihat safe 6 mored 5 */
  {path: 'test-error', component: TestErrorComponent, data: {breadcrumb: 'Test Errors'}},
  {path: 'server-error', component: ServerErrorComponent, data: {breadcrumb: 'Server Error'}},
  {path: 'not-found', component: NotFoundComponent, data: {breadcrumb: 'Not Found'}},
  // {path: 'shop', component: ShopComponent},
  // {path: 'shop/:id', component: ProductDetailsComponent},
  {path: 'shop', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule), /*tozihat safe 5 mored 6 */
  data: {breadcrumb: 'Shop'}},
  {path: '**', redirectTo: 'not-found', pathMatch: 'full'} /*bere be home component */
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
