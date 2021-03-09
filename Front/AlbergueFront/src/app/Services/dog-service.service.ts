import { Injectable } from '@angular/core';
import {HttpClient,HttpHeaders} from '@angular/common/http'
import { Observable } from 'rxjs';
import { Dog } from '../models/Dog';

const httpOptions ={
  headers: new HttpHeaders({
    'content-Type':'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class DogService {

  dogsUrl:string="http://localhost:51359/api/Albergue";
  constructor(private http:HttpClient) { }
  getDogs():Observable<Dog[]>{
    return this.http.get<Dog[]>(this.dogsUrl);
  }
}
