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
        console.log(`Restocking ${FastfoodStock.name}`)
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
