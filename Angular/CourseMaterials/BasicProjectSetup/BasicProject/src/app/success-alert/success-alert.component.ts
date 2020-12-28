import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-success-alert',
  templateUrl: './success-alert.component.html',
  styleUrls: ['./success-alert.component.css']
})
export class SuccessAlertComponent implements OnInit {

  @Input() 
  message: string | undefined;

  constructor() { }

  ngOnInit(): void {
    
  }

}
