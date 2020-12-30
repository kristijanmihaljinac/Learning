import { Component, OnInit } from '@angular/core';
import { Recipe } from '../models/recipe.model';

@Component({
  selector: 'app-recepies',
  templateUrl: './recepies.component.html',
  styleUrls: ['./recepies.component.css']
})
export class RecepiesComponent implements OnInit {

  selectedRecipe: Recipe | null = null;
  constructor() { }

  ngOnInit(): void {
  }
  onSelectRecipe(recipe: Recipe){
    this.selectedRecipe = recipe;
    console.log(recipe);
  }
}
