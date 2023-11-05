import { Injectable } from '@angular/core';
import {HttpClient , HttpHeaders} from '@angular/common/http'

@Injectable({
  providedIn: 'root'
})
export class UrlServiceService {

  constructor(private http:HttpClient ) { }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };
  baseUrl:any="https://localhost:7008/Go";
  SendLongUrl(data: any){
    return this.http.post(this.baseUrl,JSON.stringify(data),this.httpOptions);
  }

  

}
