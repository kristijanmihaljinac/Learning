import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-warning-alert',
  templateUrl: './warning-alert.component.html',
  styleUrls: ['./warning-alert.component.css']
})
export class WarningAlertComponent implements OnInit {

  //#region Inputs
  @Input()
  message: string | undefined;
  //#endregion
  
  constructor() { }

  ngOnInit(): void {
  }

}
