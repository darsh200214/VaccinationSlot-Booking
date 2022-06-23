import { Injectable, APP_BOOTSTRAP_LISTENER } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, mapTo, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Tokens } from './tokens';
import { AppCookieService } from './app-cookie.service';
import { UserService } from '../services/user.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  loggedUser: string;
  constructor(private http: HttpClient, private router: Router, private appCookieService: AppCookieService, private userServices: UserService) { }

  signin(user: { email: string, password: string}): Observable<boolean> {
    
    // var headers = new HttpHeaders().set(environment.CompanyID, this.getCompanyId());
    // return this.http.post<any>(environment.apiBaseUrl + 'login', user, { headers })
    return this.http.post<any>(environment.apiBaseUrl + 'login', user)
      .pipe(
        tap(tokens => {
          this.doLoginUser(user.email, tokens)
        }),
        mapTo(true),
        catchError(error => {
          return of(false);
        }));
  }
  isLoggedIn() {
    return !!this.getJwtToken();
  }

  refreshToken() {
    return this.http.post<any>(environment.apiBaseUrl + 'refresh', {
      'token': this.getJwtToken(),
      'refreshToken': this.getRefreshToken()
    }).pipe(tap((tokens: Tokens) => {
      this.storeTokens(tokens);
    }),
      catchError(error => {
        alert("Session Timeout, Please login again");
        this.logout();
        return of(false);
      }));
  }
  getLoginUserDetails() {
    this.userServices.getUserDetailsById(this.getUserId()).subscribe(results => {
      this.setUserName(results.email);  
      Swal.close(); 
      this.router.navigate(['/dashboard']);
    });
  }
  getJwtToken() {
    return localStorage.getItem(environment.JWT_TOKEN);
  }

  doLoginUser(username: string, tokens: Tokens) {
    this.loggedUser = username;
    this.storeTokens(tokens);
    this.setUserId(tokens.userId);    
  }

  logout() {
    this.loggedUser = null;
    localStorage.clear();
    localStorage.clear();
    this.router.navigate(['/signin']);
    return true;
  }

  private getRefreshToken() {
    return localStorage.getItem(environment.REFRESH_TOKEN);
  }

  private storeTokens(tokens: Tokens) {
    localStorage.setItem(environment.JWT_TOKEN, tokens.token);
    localStorage.setItem(environment.REFRESH_TOKEN, tokens.refreshToken);
  } 

  getUserName() {
    return localStorage.getItem(environment.UserName);
  }
  setUserName(UserName) {
    return localStorage.setItem(environment.UserName, UserName);
  }
  getUserCode() {
    return localStorage.getItem(environment.UserCode);
  }
  setUserCode(UserCode) {
    return localStorage.setItem(environment.UserCode, UserCode);
  }
  getUserProfilePic() {
    return localStorage.getItem(environment.ProfilePic);
  }
  setUserProfilePic(ProfilePic) {
    return localStorage.setItem(environment.ProfilePic, ProfilePic);
  }
  getUserId() {
    return localStorage.getItem(environment.UserId);
  }
  setUserId(UserId) {
    localStorage.setItem(environment.UserId, UserId);
    return localStorage.setItem(environment.UserId, UserId);
  }
  getRoleName() {    
    return localStorage.getItem(environment.RoleName);
  }
  setRoleName(RoleName) {
    return localStorage.setItem(environment.RoleName, RoleName);
  }
  getLanguage() {
    return localStorage.getItem(environment.Language);
  }
  setLanguage(lang) {
    return localStorage.setItem(environment.Language, lang);
  }

  roleMatch(allowedRoles): boolean {
    var isMatch = false;
    var userRoles = this.getRoleName();
    allowedRoles.forEach(element => {
      if (userRoles.indexOf(element) > -1) {
        isMatch = true;
      }
      if (element.toUpperCase()=="ALL") {
        isMatch = true;
      }
    });
    return isMatch;
  }
}