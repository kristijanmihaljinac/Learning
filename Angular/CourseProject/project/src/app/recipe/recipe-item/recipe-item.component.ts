import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Recipe } from '../models/recipe.model';

@Component({
  selector: 'app-recipe-item',
  templateUrl: './recipe-item.component.html',
  styleUrls: ['./recipe-item.component.css'],
})
export class RecipeItemComponent implements OnInit {
  @Input()
  recipeModel!: Recipe;

  @Output()
  onRecipeSelect: EventEmitter<Recipe> = new EventEmitter();
  constructor() {}

  ngOnInit(): void {}

  onRecipeClick() {
    this.onRecipeSelect.emit(this.recipeModel);
  }
}
