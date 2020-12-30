import {
  Component,
  Input,
  OnChanges,
  OnInit,
  SimpleChanges,
} from '@angular/core';

@Component({
  selector: 'app-server-element',
  templateUrl: './server-element.component.html',
  styleUrls: ['./server-element.component.css'],
})
export class ServerElementComponent implements OnInit, OnChanges {
  @Input('srvElement')
  public element: {
    type: string;
    name: string;
    content: string;
  };

  constructor() {
    console.log('constructor');
  }

  ngOnInit(): void {
    console.log('ngOnInit');
  }

  ngOnChanges(changes: SimpleChanges) {
    console.log('on changes');
  }
}
