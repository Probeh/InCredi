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
  private readonly baseUrl: string = 'auth';
  // ======================================= //
  public authState: boolean = false;
  public identity: Identity;
  public identity$: Subject<Identity> = new Subject<Identity>();
  // ======================================= //
  constructor(private message: MessageService, private http: HttpClient, private router: Router) {
    this.identity$.subscribe({
      next: result => {
        this.identity = result;
        this.router.navigate([result ? 'search' : 'account']);
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
      .post(`${this.baseUrl}/login`, account)
      .toPromise()
      .then((result) => {
        this.identity.username = account.username;
        this.message.show('Success!', `Welcome ${account.username}`, MessageType.Success);
        return result;
      })
      .catch(error => {
        this.message.show('Login failure!', 'Invalid credentials', MessageType.Error);
        return error;
      })
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
  public userLogout(): Promise<Object> {
    var result = this.http
      .post(`${this.baseUrl}/logout`, null)
      .toPromise();
    this.setIdentity();
    this.message.show('Signed out!', '', MessageType.Warning);
    return result;
  }
  public setIdentity(identity?: Identity) {
    identity
      ? localStorage.setItem('identity', JSON.stringify(identity))
      : localStorage.removeItem('identity');
    this.authState = identity != null;
    this.identity$.next(identity);
  }
}
