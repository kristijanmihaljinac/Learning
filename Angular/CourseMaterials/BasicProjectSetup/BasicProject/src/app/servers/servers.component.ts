import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-servers',
  templateUrl: './servers.component.html',
  styleUrls: ['./servers.component.css']
})
export class ServersComponent implements OnInit {

  allowNewServer = false;
  serverCreationStatus = "No server creation!!";
  serverName = "Test";
  userName = "";
  disableButtonUserName = this.userName === ""
  serverCreated = false;
  servers = ['Test server', 'New server'];

  constructor() { 
    setTimeout(() => {
      this.allowNewServer = true;
    }, 5000);
  }

  ngOnInit(): void {
    
  }

  onCreateServer(){
    this.serverCreationStatus = "Server was created!!! Name is " + this.serverName;
    this.serverCreated = true;
    this.servers.push(this.serverName);
  }

  onUpdateServerName(event: Event){
    this.serverName = (<HTMLInputElement>event.target).value ;
  }

  onUserNameChange(event: Event){
    this.disableButtonUserName = this.userName === ""
  }

  onUserNameButtonClick(){
    this.userName = "";
    this.disableButtonUserName = this.userName === ""
  }
  
}
