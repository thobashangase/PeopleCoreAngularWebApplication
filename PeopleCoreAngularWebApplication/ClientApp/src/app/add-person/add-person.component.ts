import { Component } from '@angular/core';
import { Person } from '../models/person';
import { Router } from '@angular/router';
import { PeopleService } from '../services/people.service';

@Component({
  selector: 'app-add-person',
  templateUrl: './add-person.component.html',
  styleUrls: ['./add-person.component.css']
})

export class AddPersonComponent {
  model = new Person('', '', '', '');

  constructor(private peopleService: PeopleService, private router: Router) { }

  submitted = false;

  onSubmit() { this.submitted = true; }

  addPerson(person: Person) {
    delete person.id;

    this.peopleService.addPerson(person).subscribe(() => {
      this.router.navigate(['/people']);
    }, error => console.error(error));
  }
}
