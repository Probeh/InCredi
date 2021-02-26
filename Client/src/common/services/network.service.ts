import { HttpClient } from '@angular/common/http'
import { Injectable } from '@angular/core'

@Injectable({ providedIn: 'root' })
export class NetworkService {
  private baseUrl: string = 'http://localhost:5000/api';
  constructor(private http: HttpClient) { }
  public getData<T>(endpoint: string, args: { [key: string]: string } = null): Promise<T> {
    return this.http
      .get<T>(`${this.baseUrl}/${endpoint}`, args ? { params: args } : {})
      .toPromise();
  }
}
