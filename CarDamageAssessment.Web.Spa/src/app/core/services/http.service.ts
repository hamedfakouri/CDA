import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import {  Response } from '@angular/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators';



@Injectable()
export class HttpService <T> {
 
  public endpoint:string="";
  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    })
  };
  constructor(private http:HttpClient)
  {
  
  }
 
  private extractData(res: Response):T {
    let body = res;
    return ;
  }

  getAll(): Observable<Array<T>> {
  

    
   
    return this.http.get<Array<T>>(this.endpoint);
  }
  
  get(id): Observable<T> {
    return this.http.get<T>(this.endpoint +  id).pipe(
      map(this.extractData));
  }
  
  add (T): Observable<T> {
    console.log(T);
    return this.http.post<T>(this.endpoint , JSON.stringify(T), this.httpOptions).pipe(
      tap((T) => console.log(`added  w/ `)),
      catchError( this.handleError<any>('add'))
    );
  }
  
  update(id, T): Observable<T> {
    return this.http.put(this.endpoint  + id, JSON.stringify(T), this.httpOptions).pipe(
      tap(_ => console.log(`updated  id=${id}`)),
      catchError(this.handleError<any>('updateCar'))
    );
  }
  
  delete (id): Observable<T> {
    return this.http.delete<any>(this.endpoint  + id, this.httpOptions).pipe(
      tap(_ => console.log(`deleted  id=${id}`)),
      catchError(this.handleError<any>('deleteCar'))
    );
  }
 
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
  
      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead
  
      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);
  
      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}