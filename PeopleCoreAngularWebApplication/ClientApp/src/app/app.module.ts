import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { GetPeopleComponent } from './get-people/get-people.component';
import { AddPersonComponent } from './add-person/add-person.component';
import { EditPersonComponent } from './edit-person/edit-person.component';
import { PeopleService } from './services/people.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    GetPeopleComponent,
    AddPersonComponent,
    EditPersonComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: GetPeopleComponent, pathMatch: 'full' },
      { path: 'people', component: GetPeopleComponent },
      { path: 'add-person', component: AddPersonComponent },
      { path: 'people/edit/:id', component: EditPersonComponent }
    ])
  ],
  providers: [PeopleService],
  bootstrap: [AppComponent]
})
export class AppModule { }
