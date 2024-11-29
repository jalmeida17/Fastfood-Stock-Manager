export class FastfoodStock {
    id: number;
    name: string;
    location: string;
    lastRestock: Date;
    bread: number;
    cheese: number;
    meat: number;
    lettuce: number;
    tomato: number;
    onion: number;
    pickle: number;
    ketchup: number;
    mustard: number;
    mayonnaise: number;
    potato: number;
    water: number;
    coke: number;
  
    constructor(
      id: number,
      name: string,
      location: string,
      lastRestock: Date,
      bread: number,
      cheese: number,
      meat: number,
      lettuce: number,
      tomato: number,
      onion: number,
      pickle: number,
      ketchup: number,
      mustard: number,
      mayonnaise: number,
      potato: number,
      water: number,
      coke: number
    ) {
      this.id = id;
      this.name = name;
      this.location = location;
      this.lastRestock = lastRestock;
      this.bread = bread;
      this.cheese = cheese;
      this.meat = meat;
      this.lettuce = lettuce;
      this.tomato = tomato;
      this.onion = onion;
      this.pickle = pickle;
      this.ketchup = ketchup;
      this.mustard = mustard;
      this.mayonnaise = mayonnaise;
      this.potato = potato;
      this.water = water;
      this.coke = coke;
    }
  }
  