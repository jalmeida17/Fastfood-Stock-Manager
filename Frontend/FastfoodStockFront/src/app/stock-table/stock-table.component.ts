import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TableModule } from 'primeng/table';
import { IconFieldModule } from 'primeng/iconfield';
import { FastfoodStock } from '../../../Models/FastfoodStock';
import { ButtonModule } from 'primeng/button';
import { FastfoodStockService } from '../../../Services/FastfoodStock.service';
import { ConfirmationService, MessageService } from 'primeng/api';
import { Inject } from '@angular/core';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { ToastModule } from 'primeng/toast';
import { ConfirmPopupModule } from 'primeng/confirmpopup';
import { FormsModule } from '@angular/forms';
import { CardModule } from 'primeng/card';

@Component({
  selector: 'app-stock-table',
  standalone: true,
  imports: [TableModule, IconFieldModule, ButtonModule, CommonModule, DialogModule, InputTextModule, ToastModule, ConfirmPopupModule, FormsModule, CardModule],
  templateUrl: './stock-table.component.html',
  styleUrl: './stock-table.component.scss',
})
export class StockTableComponent  {

  
  creatorVisible: boolean = false;
  visible: boolean = false;
  restaurants: FastfoodStock[] = [];
  selectedStock: FastfoodStock | null = null;

  creatorName!: string;
  creatorLocation!: string;

  editedName!: string;
  editedLocation!: string;

  constructor(
    private fastfoodstockService: FastfoodStockService, 
    @Inject(MessageService) private messageService: MessageService, 
    @Inject(ConfirmationService) private confirmationService: ConfirmationService

  ) {}


    ngOnInit() {
  
      this.fastfoodstockService.getAll()
        .subscribe(response => {
          this.restaurants = response;
          console.log(response)
        });
      } 

    openEditDialog(rowIndex: number) {
      this.visible = true;
      try{
        this.selectedStock = { ...this.restaurants[rowIndex] };
        this.editedLocation = this.selectedStock?.location ?? '';
        this.editedName = this.selectedStock?.name ?? '';
      }catch(error){
        console.error("[ERROR] Error when retreiving this row's data (", error, ").")
      }

     }

    saveEdit() {
      if (this.selectedStock) {
        this.selectedStock.name = this.editedName;
        this.selectedStock.location = this.editedLocation;

        this.fastfoodstockService.update(this.selectedStock)
          .subscribe(() => {
            const index = this.restaurants.findIndex(stock => stock.id === this.selectedStock!.id);
            if (index !== -1) {
              this.restaurants[index] = this.selectedStock!;
            }
            this.visible = false;
          });
      }
    }

    create() {
      const newStock: FastfoodStock = {
        id: 0,
        name: this.creatorName,
        location: this.creatorLocation,
        bread: 0,
        cheese: 0,
        meat: 0,
        lettuce: 0,
        tomato: 0,
        onion: 0,
        pickle: 0,
        ketchup: 0,
        mustard: 0,
        mayonnaise: 0,
        potato: 0,
        water: 0,
        coke: 0,
        lastRestock: new Date(),
      };
  
      this.fastfoodstockService.add(newStock)
          .subscribe(() => {
            console.log(`Created ${newStock.name}`);
            this.creatorVisible = false;
            window.location.reload()
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
        FastfoodStock.name = "New Name";
        FastfoodStock.location = "New Location";

        this.fastfoodstockService.update(FastfoodStock)
          .subscribe(() => {
            console.log(`Edited ${FastfoodStock.name}`);
          });
      }

      delete(FastfoodStock: FastfoodStock){
        this.fastfoodstockService.remove(FastfoodStock.id)
          .subscribe(() => {
            this.restaurants = this.restaurants.filter(stock => stock.id !== FastfoodStock.id);
            console.log(`Deleted stock with id ${FastfoodStock.id}`);
          });
      }

      confirmAction(event: Event, action: string, stock: FastfoodStock) {
        this.confirmationService.confirm({
          target: event.target as EventTarget,
          message: `Are you sure you want to ${action} this restaurant?`,
          icon: 'pi pi-exclamation-triangle',
          accept: () => {
            if (action === 'restock') {
              this.restock(stock);
              this.messageService.add({ severity: 'success', summary: 'Restocked', detail: 'Restaurant restocked successfully' });
            }
              else if (action === 'delete') {
              this.delete(stock);
              this.messageService.add({ severity: 'error', summary: 'Deleted', detail: 'Restaurant deleted successfully' });
            }
            }
          },
        );
      }

      confirmActionEdit(event: Event){
        this.confirmationService.confirm({
          target: event.target as EventTarget,
          message: `Are you sure you want to update this restaurant?`,
          icon: 'pi pi-exclamation-triangle',
          accept: () => {
            this.saveEdit()
            this.messageService.add({ severity: 'info', summary: 'Updated', detail: 'Restaurant updated successfully' });
            
            }
        })
      }

      confirmActionCreate(event: Event){
        this.confirmationService.confirm({
          target: event.target as EventTarget,
          message: `Are you sure you want to create this restaurant?`,
          icon: 'pi pi-exclamation-triangle',
          accept: () => {
            if(this.creatorName === "" || this.creatorLocation === ""){
              this.messageService.add({ severity: 'error', summary: 'Error', detail: 'Please fill in all fields' });
            } else {
              this.create()
              this.messageService.add({ severity: 'success', summary: 'Created', detail: 'Restaurant created successfully' });
              this.creatorLocation = "";
              this.creatorName = "";
            }
            }
        })
      }
  
}
