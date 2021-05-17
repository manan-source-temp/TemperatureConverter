import { Injectable } from '@angular/core';
import {Observable, throwError} from 'rxjs';
import {HttpClient,HttpHeaders,HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TemperatureService {

  constructor(private http:HttpClient) { 
  }

  public GetTemperature(temperatureValue:number,oldTemperatureType:string,currenTemperatureType:string):Observable<any>
  {
    
     return this.http.get<number>(`http://localhost:64206/api/temperature/${temperatureValue}/${oldTemperatureType}/${currenTemperatureType}`);         
  }

 
}
