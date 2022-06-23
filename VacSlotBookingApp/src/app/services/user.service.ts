import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { SubscriberFilter, User, UserFilter, UserModelById, ZMIdModel } from '../model/user.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  getUserDetailsById(Id) {
    return this.http.get<User>(environment.apiBaseUrl + "users/GetUsersDetailsById/"+Id);
  }
}
