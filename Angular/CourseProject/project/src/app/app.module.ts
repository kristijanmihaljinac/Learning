import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { RecipeItemComponent } from './recipe/recipe-item/recipe-item.component';
import { RecipeDetailComponent } from './recipe/recipe-detail/recipe-detail.component';
import { ShoppingListComponent } from './shopping/shopping-list/shopping-list.component';
import { ShoppingListEditComponent } from './shopping/shopping-list-edit/shopping-list-edit.component';
import { HeaderComponent } from './header/header.component';
import { RecipeListComponent } from './recipe/recipe-list/recipe-list.component';
import { RecepiesComponent } from './recipe/recepies/recepies.component';
import { FormsModule } from '@angular/forms';
import { DropdownDirective } from './shared/directives/dropdown.directive';

@NgModule({
  declarations: [
    AppComponent,
    RecipeItemComponent,
    RecipeDetailComponent,
    RecipeListComponent,
    RecepiesComponent,
    ShoppingListComponent,
    ShoppingListEditComponent,
    HeaderComponent,
    RecepiesComponent,
    DropdownDirective
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
