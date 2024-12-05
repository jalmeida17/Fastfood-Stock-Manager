import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FastfoodStock } from '../Models/FastfoodStock';
  
@Injectable({
  providedIn: 'root'
})
export class FastfoodStockService {
  private url = 'https://localhost:7213/FastfoodStock';
   
  constructor(private httpClient: HttpClient) { }
  
  getAll(){
    return this.httpClient.get<FastfoodStock[]>(this.url);
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

  update(post: any) {
    return this.httpClient.put(`${this.url}/${post.id}`, post);
  }
  
}