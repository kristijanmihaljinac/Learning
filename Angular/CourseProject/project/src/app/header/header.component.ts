import { Component, EventEmitter, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {


  @Output()
  navigateChange: EventEmitter<string> = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
    
  }

  changeNavigation(state: string){
    this.navigateChange.emit(state);
  }

}
