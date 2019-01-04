import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from 'src/_models/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiAddress = 'http://localhost:5000/api/';

constructor(private httpClient: HttpClient) { }

getUsers() {
  return this.httpClient.get<User[]>(this.apiAddress + 'values');
}

}


