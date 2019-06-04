import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../models/person';

@Injectable({
  providedIn: 'root',
})
export class PeopleService {
    myAppUrl: string = "";
  
    constructor(private _http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.myAppUrl = baseUrl;
    }

    getPeople(): Observable<Person[]> {  
      return this._http.get<Person[]>(this.myAppUrl + 'api/People');  
    }  
  
    getPersonById(id: string): Observable<Person> {  
      return this._http.get<Person>(this.myAppUrl + "api/People/" + id);
    }  

    addPerson(person) {  
      return this._http.post(this.myAppUrl + 'api/People', person);
    }  
  
    updatePerson(person) {  
      return this._http.put(this.myAppUrl + 'api/People', person);
    }  
  
    deletePerson(id: string) {  
      return this._http.delete(this.myAppUrl + "api/People/" + id);
    }
}  
