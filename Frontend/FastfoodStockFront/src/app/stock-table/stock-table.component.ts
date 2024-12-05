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
  
}
