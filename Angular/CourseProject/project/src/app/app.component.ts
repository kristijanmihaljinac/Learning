import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'project';
  activeState = 'recepies';
  

  onNavigateChange(stateName: string){

    this.activeState = stateName;

    

      
  }
}
