import { Component, EventEmitter, Output} from '@angular/core';
import { MessageService } from 'primeng/api';
import { DbService } from '../db.service';
import { User } from '../Users';
import { PrimeNGConfig } from 'primeng/api';
import { Route, Router } from '@angular/router';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
  providers: [MessageService]
})
export class LoginComponent {

  constructor(
    private messageService: MessageService,
    private db:DbService,
    private primengConfig: PrimeNGConfig,
    private route:Router
  ){}

  
  id:number = 1;
  checkUser:User = new User(0, "", "", "", "", "", "", true, true);
  userName:string = "";
  password:string = "";
  check: Boolean= false;
  clickLogin:boolean=false;
  // numDaysExp: number = 0;
  
  exist:boolean = false;
  @Output()
  throwEvent:EventEmitter<boolean> = new EventEmitter<boolean>();

  ngOnInit(): void {
    this.primengConfig.ripple = true;
    console.log(this.exist);
  }

  ClickLogin(){
    this.clickLogin=true;
  }

  clearLogin(){
    this.userName="";
    this.password="";
    this.clickLogin=false;
  }

  showMessage(){
    //this.db.userName = this.userName;
    //this.db.passward = this.password;
    localStorage.setItem('userName', this.userName); // set the isAdmin key to true
    this.exist = true;
  
    this.db.getByUserName(this.userName).subscribe(x=>{
      this.checkUser= <User>x;
      console.log(this.checkUser);
      
      if(this.checkUser == null){
        console.log("userName: "+ this.userName);
        // console.log("checkUser  "+this.checkUser.userName);
        this.exist=false;
        this.messageService.add({key: 'myKey1', severity: 'error', summary: 'Error', detail: 'משתמש לא קיים'});
      }
      else{ 
        if(this.checkUser.password!= this.password||!this.checkUser.active){
          this.exist=false;
          this.messageService.add({key: 'myKey1', severity: 'error', summary: 'Error', detail: 'משתמש לא קיים'});
        }
        else{
        console.log(this.exist);
        localStorage.setItem('isAdmin', String(this.checkUser.admin)); // set the isAdmin key to true
        this.route.navigate(["/menu"]);
        this.throwEvent.emit(this.exist)
        }
      }
  });
  }



  // if(!this.exist){
  //   this.messageService.add({key: 'myKey1', severity: 'error', summary: 'Error', detail: 'משתמש לא קיים'});
  // }
  //   console.log(this.exist);
  //   this.throwEvent.emit(this.exist)
  
  // showMessage(){

  //   for (let i = 0; i < this.userArr.length; i++) {

  //   }

  //   this.db.getUserById(this.id).subscribe(x => {
  //     this.checkUser = <User>x;
  //   })
  //   // this.checkUser = this.db.getUserById(this.id);
  //   if(this.checkUser && this.checkUser.Active == true){
  //     this.MessageService.add({severity:'success', summary:'Service Message', detail:'Via MessageService'});
  //   }
  //   else{
  //     this.MessageService.add({severity:'error', summary:'Service Message', detail:'Via MessageService'});
  //   }

  // }

}
