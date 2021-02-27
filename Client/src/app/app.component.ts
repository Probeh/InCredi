import { Component             } from '@angular/core'
import { NavigationEnd, Router } from '@angular/router'
import { PrimeNGConfig         } from 'primeng/api'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public route: string;
  constructor(private primengConfig: PrimeNGConfig, private router: Router) {
    this.router.events.subscribe({
      next: event =>
        this.route = !(event instanceof NavigationEnd) ? this.route :
          event.urlAfterRedirects.slice(1).replace('/', ' ')
    });
    this.primengConfig.ripple = true;
  }
}

