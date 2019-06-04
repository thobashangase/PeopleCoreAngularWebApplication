import { Component, Inject } from '@angular/core';
import { Person } from '../models/person';
import { HttpClient } from '@angular/common/http';
import {
  CanActivate, Router,
  ActivatedRouteSnapshot,
  RouterStateSnapshot, ActivatedRoute
} from '@angular/router';

@Component({
  selector: 'app-edit-person',
  templateUrl: './edit-person.component.html'//,
  //styleUrls: ['./edit-person.component.css']
})

export class EditPersonComponent {
  model: Person;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router, private _avRoute: ActivatedRoute) {
    if (this._avRoute.snapshot.params["id"]) {
      this.http.get<Person>(this.baseUrl + 'api/People/' + this._avRoute.snapshot.params["id"]).subscribe(result => {
        this.model = result;
      }, error => console.error(error));
    }
  }

  submitted = false;

  onSubmit() { this.submitted = true; }

  updatePerson(person: Person) {
    this.http.put(this.baseUrl + 'api/People', person).subscribe(result => {
      this.router.navigate(['/people']);
    }, error => console.error(error));
  }
}
