import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { fromEvent, Subscription } from 'rxjs';
import { Observable } from 'rxjs';
import Swal from 'sweetalert2';
import { AuthService } from './auth/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  onlineEvent: Observable<Event>;
  offlineEvent: Observable<Event>;
  subscriptions: Subscription[] = [];

  connectionStatusMessage: string;
  connectionStatus: string;

  constructor(private translate: TranslateService, private authService: AuthService) {

  }
  ngOnInit() {
    this.translate.setDefaultLang('en');
    if (this.authService.getLanguage() == "kn")
      this.translate.setDefaultLang('kn');
    else if (this.authService.getLanguage() == "en")
      this.translate.setDefaultLang('en');
    else
      this.translate.setDefaultLang('en');

      this.onlineEvent = fromEvent(window, 'online');
    this.offlineEvent = fromEvent(window, 'offline');

    this.subscriptions.push(this.onlineEvent.subscribe(e => {
      this.connectionStatusMessage = 'Back to online!';
      this.connectionStatus = 'online';
      Swal.fire('online!',  this.connectionStatusMessage, 'success');
 
          console.log('Online...');
    }));

    this.subscriptions.push(this.offlineEvent.subscribe(e => {
      this.connectionStatusMessage = 'Connection lost! You are not connected to internet';
      this.connectionStatus = 'offline';
      Swal.fire('offline!',  this.connectionStatusMessage, 'warning');

      console.log('Offline...');
    }));
  }
  ngOnDestroy(): void {
    /**
    * Unsubscribe all subscriptions to avoid memory leak
    */
    this.subscriptions.forEach(subscription => subscription.unsubscribe());
  }
}
