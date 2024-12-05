import { Component } from '@angular/core';
import { StockTableComponent } from './stock-table/stock-table.component';
import { FastfoodStockService } from '../../Services/FastfoodStock.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [StockTableComponent,
    CommonModule
           ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'FastfoodStockFront';
}
