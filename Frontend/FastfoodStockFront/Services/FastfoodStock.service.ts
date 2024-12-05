import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
  
@Injectable({
  providedIn: 'root'
})
export class FastfoodStockService {
  private url = 'https://localhost:7213/FastfoodStock';
   
  constructor(private httpClient: HttpClient) { }
  
  getAll(){
    return this.httpClient.get(this.url);
  }

  getById(id: number) {
    return this.httpClient.get(`${this.url}/${id}`);
  }

  add(post: any) {
    return this.httpClient.post(this.url, post);
  }

  remove(id: number) {
    return this.httpClient.delete(`${this.url}/${id}`);
  }
  
}