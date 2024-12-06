import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { IconFieldModule } from 'primeng/iconfield';
import { FastfoodStock } from '../../../Models/FastfoodStock';
import { ButtonModule } from 'primeng/button';
import { FastfoodStockService } from '../../../Services/FastfoodStock.service';

@Component({
  selector: 'app-stock-table',
  standalone: true,
  imports: [TableModule, IconFieldModule, ButtonModule, CommonModule],
  templateUrl: './stock-table.component.html',
  styleUrl: './stock-table.component.scss'
})
export class StockTableComponent  {

  restaurants: FastfoodStock[] = [];
  
    constructor(private fastfoodstockService:FastfoodStockService) {}
  
    ngOnInit() {
  
      this.fastfoodstockService.getAll()
        .subscribe(response => {
          this.restaurants = response;
          console.log(response)
        });
      } 

      restock(FastfoodStock: FastfoodStock){
        FastfoodStock.bread += 20; 
        FastfoodStock.cheese += 15; 
        FastfoodStock.meat += 30; 
        FastfoodStock.lettuce += 10; 
        FastfoodStock.tomato += 10; 
        FastfoodStock.onion += 8; 
        FastfoodStock.pickle += 5; 
        FastfoodStock.ketchup += 20; 
        FastfoodStock.mustard += 15; 
        FastfoodStock.mayonnaise += 15; 
        FastfoodStock.potato += 50;
        FastfoodStock.water += 100; 
        FastfoodStock.coke += 80;  
        FastfoodStock.lastRestock = new Date();

        this.fastfoodstockService.update(FastfoodStock)
          .subscribe(() => {
            console.log(`Restocked ${FastfoodStock.name}`);
          });
    }

      edit(FastfoodStock: FastfoodStock){
        console.log(`Editing ${FastfoodStock.name}`)
      }

      delete(FastfoodStock: FastfoodStock){
        this.fastfoodstockService.remove(FastfoodStock.id)
          .subscribe(() => {
            this.restaurants = this.restaurants.filter(stock => stock.id !== FastfoodStock.id);
            console.log(`Deleted stock with id ${FastfoodStock.id}`);
          });
      }
  
}
