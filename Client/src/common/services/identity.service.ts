import { Subject        } from 'rxjs'
import { HttpClient     } from '@angular/common/http'
import { Injectable     } from '@angular/core'
import { Account        } from '@models/account.model'
import { Identity       } from '@models/identity.model'
import { MessageService } from '@services/message.service'
import { MessageType    } from '@enums/message.enum'
import { Router         } from '@angular/router'

@Injectable({ providedIn: 'root' })
export class IdentityService {
  private readonly baseUrl: string = 'http://localhost:5000/api';
  // ======================================= //
  public authState: boolean = false;
  public identity: Identity;
  public identity$: Subject<Identity> = new Subject<Identity>();
  // ======================================= //
  constructor(private message: MessageService, private http: HttpClient, private router: Router) {
    this.identity$.subscribe({
      next: result => {
        this.identity = result;
        this.router.navigate(['search']);
        console.log('AuthState Changed =>', result);
      }
    });

    const storage: Identity = JSON.parse(localStorage.getItem('identity')) as Identity;
    this.authState = storage != null;
    if (storage && !this.identity) {
      this.identity$.next(storage);
    }
  }
  // ======================================= //
  public userLogin(account: Account): Promise<Object> {
    return this.http
      .post(`${this.baseUrl}/auth`, account)
      .toPromise()
      .then((result) => {
        this.identity.userName = account.userName;
        this.message.show('Success!', `Welcome ${account.userName}`, MessageType.Success);
        return result;
      });
  }
  public userRegister(account: Account): Promise<Object> {
    return this.http
      .put(`${this.baseUrl}/auth`, account)
      .toPromise()
      .then((result) => {
        this.message.show('Success!', `Account successfully created`, MessageType.Success)
        return result;
      });
  }
  public userLogout(): Promise<void> {
    return this.http
      .post(`${this.baseUrl}/auth/logout`, null)
      .toPromise()
      .then(() => this.message.show('Signing Out', '', MessageType.Info))
      .then(() => this.setIdentity());
  }
  public setIdentity(identity?: Identity) {
    identity
      ? localStorage.setItem('identity', JSON.stringify(identity))
      : localStorage.removeItem('identity');
    this.authState = identity != null;
    this.identity$.next(identity);
  }
}
