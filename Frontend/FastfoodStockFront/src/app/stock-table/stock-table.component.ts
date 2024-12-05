import { Component, OnInit } from '@angular/core';
import { TableModule } from 'primeng/table';
import { IconFieldModule } from 'primeng/iconfield';
import { FastfoodStock } from '../../../Models/FastfoodStock';
import { ButtonModule } from 'primeng/button';
import { FastfoodStockService } from '../../../Services/FastfoodStock.service';

@Component({
  selector: 'app-stock-table',
  standalone: true,
  imports: [TableModule, IconFieldModule, ButtonModule],
  templateUrl: './stock-table.component.html',
  styleUrl: './stock-table.component.scss'
})
export class StockTableComponent  {

  restaurants: FastfoodStock[] = [
    {
      id: 1,
      name: 'Burger King',
      location: '1234 Main St',
      lastRestock: new Date(),
      bread: 100,
      cheese: 100,
      meat: 100,
      lettuce: 100,
      tomato: 100,
      onion: 100,
      pickle: 100,
      ketchup: 100,
      mustard: 100,
      mayonnaise: 100,
      potato: 100,
      water: 100,
      coke: 100
    },
    {
      id: 2,
      name: 'McDonalds',
      location: '4321 Elm St',
      lastRestock: new Date(),
      bread: 100,
      cheese: 100,
      meat: 100,
      lettuce: 100,
      tomato: 100,
      onion: 100,
      pickle: 100,
      ketchup: 100,
      mustard: 100,
      mayonnaise: 100,
      potato: 100,
      water: 100,
      coke: 100
    }
  ];

  fastfoods:any;
  
    constructor(private fastfoodstockService:FastfoodStockService) {}
  
    ngOnInit() {
  
      this.fastfoodstockService.getAll()
        .subscribe(response => {
          this.fastfoods = response;
          console.log(response)
        });
      }
  
}
