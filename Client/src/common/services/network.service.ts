import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'

@Injectable({ providedIn: 'root' })
export class NetworkService {
  constructor(private http: HttpClient) { }
  public getData<T>(endpoint: string, args: { [key: string]: string } = null): Promise<T> {
    return this.http
      .get<T>(`${endpoint}`, args ? { params: args } : {})
      .toPromise();
  }
}
