import { Component } from '@angular/core';
import { User } from '../Users';
import { SelectItem } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { DbService } from '../db.service';
import { Observable } from 'rxjs';
import { TblAssistValue } from '../TblAssistValue';
import { ThisReceiver } from '@angular/compiler';
import {Validators,FormControl,FormGroup,FormBuilder} from '@angular/forms';
@Component({
  selector: 'app-users-editing',
  templateUrl: './users-editing.component.html',
  providers:[MessageService],
  styleUrls: ['./users-editing.component.css'],
  styles: [`
  :host ::ng-deep .p-row-editing {
      padding-top: 0 !important;
      padding-bottom: 0 !important;
  }
`]
})
export class UsersEditingComponent {
  userform: FormGroup= new FormGroup({
    title: new FormControl('')})
  arrU:User[]=[];
  departments1:TblAssistValue[] = [];
  departments:SelectItem[] = [];
  value:boolean=true;
  u1:User=new User(0, "", "", "", "", "", "", true, true)
  value1:Boolean=true;
  u:User=new User(0, "", "", "", "", "", "", true, true)
  clonedUsers: { [s: string]: User; } = {};
  constructor(private db:DbService,private messageService: MessageService){
    this.db.getTblAssistValueById(12).subscribe(x => {
      this.departments1 = <TblAssistValue[]>x;
      this.departments1.forEach(y => 
        this.departments.push({label:y.value1, value:y.code})
        );
    });
  }
  ngOnInit() {
    this.db.GetAllUsers() .subscribe(x=>{
       
      this.arrU=<User[]>x;
    });
  }
  addUser(){
    this.arrU.unshift(new User(0, "", "", "", "", "", "", false, false))
    this.messageService.add({key: 'myKey1',severity:'info', detail:'יש להכניס את פרטי המשתמש החדש בשורה הראשונה של הטבלה'})
    this.arrU[this.arrU.length];
  }
  onRowEditInit(user: User) {
    this.clonedUsers[user.id] = {...user};
  }
onRowEditSave(user: User,index:number){
 console.log(user);
 if(user.fullName===""||user.password===""||user.userName==="")
 {
  this.messageService.add({key: 'myKey1',severity:'error', summary: 'Error', detail:'יש להכניס את כל שדות החובה'});
 }
 else{
  this.db.getByUserName(user.userName).subscribe(x=>{
    this.u1=<User>x;
    console.log(this.u1);
    if(user.id==0){
      if(this.u1==null){
        //add new user
        console.log(user);
        this.departments1.forEach(element => {
          if(element.value1.includes(user.department)){
            user.department=element.code; 
          }
        })
        this.db.addUser(user).subscribe(x=>{
          this.u=<User>x;
        })
          // this.departments1.forEach(element => {
          //   if(element.code.includes(this.u.department))
          //       this.u.department=element.value1;
          // });
        console.log(this.u);
        
        console.log(user);
        
        this.messageService.add({key: 'myKey1',severity:'success', summary: 'Success', detail:'המשתמש נוסף בהצלחה'});
        this.departments1.forEach(element => {
          if(element.code.includes(user.department)){
            user.department=element.value1; 
          }
        });
      }
      else{
        console.log('enter');
        
        this.messageService.add({key: 'myKey1',severity:'error', summary: 'Error', detail:'אין אפשרות להכניס משתמש כפול '});
        //this.arrU
      }
  }
  //user.id!=0
  else{
    if(this.u1.id==user.id){
      // this.departments1.forEach(element => {
      //   if(element.code.includes(user.department)){
      //     user.department=element.value1; 
      //   }
      // });
      console.log(user);
      console.log(this.u);
      this.departments1.forEach(element => {
        if(element.value1.includes(user.department)){
          user.department=element.code; 
        }
      });
      this.db.updateUser(user.id,user).subscribe(x=>{
        this.u=<User>x;
        // this.departments1.forEach(element => {
        //   if(element.value1.includes(user.department)){
        //     user.department=element.code; 
        //   }
        // });
        this.messageService.add({key: 'myKey1',severity:'success', summary: 'Success', detail:' המשתמש עודכן בהצלחה'});
        this.departments1.forEach(element => {
          if(element.code.includes(user.department)){
            user.department=element.value1; 
          }
        });
    })
    }
    else{
      this.messageService.add({key: 'myKey1',severity:'error', summary: 'Error', detail:'אין אפשרות להכניס משתמש כפול '});
      this.arrU[index] = this.clonedUsers[user.id];
    }
  }
  })}
  }
  onRowEditCancel(user: User, index: number) {
    if(user.id==0){
      this.arrU.pop();

    }
    else{
      this.arrU[index] = this.clonedUsers[user.id];
      delete this.clonedUsers[user.id];
    }
  }
    delete(user:User,index:number){
    user.active= false;
    this.db.updateUser(user.id, user).subscribe(x=>{
      this.u=<User>x;
      this.messageService.add({key: 'myKey1',severity:'success', summary: 'Success', detail:'המשתמש נמחק בהצלחה'});
    })
    }}


// import { Component } from '@angular/core';
// import { User } from '../Users';
// import { SelectItem } from 'primeng/api';
// import { MessageService } from 'primeng/api';
// import { DbService } from '../db.service';
// import { Observable } from 'rxjs';
// import { TblAssistValue } from '../TblAssistValue';
// import { ThisReceiver } from '@angular/compiler';
// import {Validators,FormControl,FormGroup,FormBuilder} from '@angular/forms';
// @Component({
//   selector: 'app-users-editing',
//   templateUrl: './users-editing.component.html',
//   providers:[MessageService],
//   styleUrls: ['./users-editing.component.css'],
//   styles: [`
//   :host ::ng-deep .p-row-editing {
//       padding-top: 0 !important;
//       padding-bottom: 0 !important;
//   }
// `]
// })
// export class UsersEditingComponent {
//   userform: FormGroup= new FormGroup({
//     title: new FormControl('')})
//   arrU:User[]=[];
//   departments1:TblAssistValue[] = [];
//   departments:SelectItem[] = [];
//   value:boolean=true;
//   u1:User=new User(0, "", "", "", "", "", "", true, true)
//   value1:Boolean=true;
//   u:User=new User(0, "", "", "", "", "", "", true, true)
//   clonedUsers: { [s: string]: User; } = {};
//   constructor(private db:DbService,private messageService: MessageService){
//     this.db.getTblAssistValueById(12).subscribe(x => {
//       this.departments1 = <TblAssistValue[]>x;
//       this.departments1.forEach(y => 
//         this.departments.push({label:y.value1, value:y.code})
//         );
//     });
//   }
//   ngOnInit() {
//     this.db.GetAllUsers() .subscribe(x=>{
       
//       this.arrU=<User[]>x;
//     });
//   }
//   addUser(){
//     this.arrU.push(new User(0, "", "", "", "", "", "", true, true))
//     this.arrU[this.arrU.length];
//   }
//   onRowEditInit(user: User) {
//     this.clonedUsers[user.id] = {...user};
//   }
//   onRowEditSave(user: User,index:number){
//  console.log(user);
//  if(user.fullName===""||user.password===""||user.userName==="")
//  {
//   this.messageService.add({key: 'myKey1',severity:'error', summary: 'Error', detail:'יש להכניס את כל שדות חובה'});
//  }
//  else{
//   this.db.getByUserName(user.userName).subscribe(x=>{
//     this.u1=<User>x;
//     console.log(this.u1);
//     if(user.id==0){
//       if(this.u1==null){
//         this.db.addUser(user).subscribe(x=>{
//           this.u=<User>x;})
//           // this.departments1.forEach(element => {
//           //   if(element.code.includes(this.u.department))
//           //       this.u.department=element.value1;
//           // });
//           console.log(this.u);
          
//           console.log(user);
          
//           this.messageService.add({key: 'myKey1',severity:'success', summary: 'Success', detail:'User added'});
//       }
//       else{
//         console.log('enter');
        
//         this.messageService.add({key: 'myKey1',severity:'error', summary: 'Error', detail:'אין אפשרות להכניס משתמש כפול '});
//         this.arrU.pop();
//       }
//   }
//   else{
//   if(this.u1.id==user.id){
//     // this.departments1.forEach(element => {
//     //   if(element.code.includes(user.department)){
//     //     user.department=element.value1; 
//     //   }
//     // });
//     console.log(user);
//     console.log(this.u);
//     this.db.updateUser(user.id,user).subscribe(x=>{
//       this.u=<User>x;
//       this.messageService.add({key: 'myKey1',severity:'success', summary: 'Success', detail:'משתמש עודכן'});
//   })
//   }
//   else{
//     this.messageService.add({key: 'myKey1',severity:'error', summary: 'Error', detail:'אין אפשרות להכניס משתמש כפול '});
//     this.arrU[index] = this.clonedUsers[user.id];
//   }}
//   })}
//   }
//   onRowEditCancel(user: User, index: number) {
//     if(user.id==0){
//       this.arrU.pop();

//     }
//     else{
//       this.arrU[index] = this.clonedUsers[user.id];
//       delete this.clonedUsers[user.id];
//     }
//   }
//     delete(user:User,index:number){
//     user.active= false;
//     this.db.updateUser(user.id,user).subscribe(x=>{
//       this.u=<User>x;
//   })
//   //this.arrU[index] = this.clonedUsers[user.id];
//   this.messageService.add({key: 'myKey1',severity:'success', summary: 'Success', detail:'user was deleted'});
//   }

// }

// // import { Component } from '@angular/core';
// // import { User } from '../Users';
// // import { SelectItem } from 'primeng/api';
// // import { MessageService } from 'primeng/api';
// // import { DbService } from '../db.service';
// // import { Observable } from 'rxjs';
// // import { TblAssistValue } from '../TblAssistValue';
// // import { ThisReceiver } from '@angular/compiler';
// // import {Validators,FormControl,FormGroup,FormBuilder} from '@angular/forms';
// // @Component({
// //   selector: 'app-users-editing',
// //   templateUrl: './users-editing.component.html',
// //   providers:[MessageService],

// //   styles: [`
// //       :host ::ng-deep .p-cell-editing {
// //           padding-top: 0 !important;
// //           padding-bottom: 0 !important;
// //       }
// //   `]
// // })
// // export class UsersEditingComponent {
// //   userform: FormGroup= new FormGroup({
// //   title: new FormControl('')})
// //   arrU:User[]=[];
// //   departments1:TblAssistValue[] = [];
// //   departments:SelectItem[] = [];
// //   value:boolean=true;
// //   u1:User=new User(0, "", "", "", "", "", "", true, true)
// //   value1:Boolean=true;
// //   u:User=new User(0, "", "", "", "", "", "", true, true)
// //   clonedUsers: { [s: string]: User; } = {};
// //   constructor(private db:DbService,private messageService: MessageService){
// //     this.db.getTblAssistValueById(12).subscribe(x => {
// //       this.departments1 = <TblAssistValue[]>x;
// //       this.departments1.forEach(y => 
// //         this.departments.push({label:y.value1, value:y.code})
// //         );
// //     });
// //   }
// //   ngOnInit() {
// //     this.db.GetAllUsers() .subscribe(x=>{
       
// //       this.arrU=<User[]>x;
// //     });
// //   }
// //   addUser(){
// //     this.arrU.push(new User(0, "", "", "", "", "", "", true, true))
// //   }
// //   onRowEditInit(user: User) {
// //     this.clonedUsers[user.id] = {...user};
// //   }
// //   onRowEditSave(user: User,index:number){
// //  console.log(user);
// //  if(user.fullName===""||user.password===""||user.userName==="")
// //  {
// //   this.messageService.add({key: 'myKey1',severity:'error', summary: 'Error', detail:'יש להכניס את כל שדות חובה'});
// //  }
// //  else{
// //   this.db.getByUserName(user.userName).subscribe(x=>{
// //     this.u1=<User>x;
// //     console.log(this.u1);
// //     if(user.id==0){
// //       if(this.u1==null){
// //         this.db.addUser(user).subscribe(x=>{
// //           this.u=<User>x;
// //           this.db.GetAllUsers() .subscribe(x=>{
       
// //             this.arrU=<User[]>x;
// //           });
// //         })
// //           // this.departments1.forEach(element => {
// //           //   if(element.code.includes(this.u.department))
// //           //       this.u.department=element.value1;
// //           // });
          
// //           this.messageService.add({key: 'myKey1',severity:'success', summary: 'Success', detail:'User added'});
           
// //       }
// //       else{
// //         console.log('enter');
        
// //         this.messageService.add({key: 'myKey1',severity:'error', summary: 'Error', detail:'אין אפשרות להכניס משתמש כפול '});
// //         this.arrU.pop();
// //       }
// //   }
// //   else{
// //   if(this.u1.id==user.id){
// //     this.departments1.forEach(element => {
// //       if(element.code.includes(user.department)){
// //         user.department=element.value1; 
// //       }
// //     });
// //     this.db.updateUser(user.id,user).subscribe(x=>{
// //       this.u=<User>x;
// //       this.messageService.add({key: 'myKey1',severity:'success', summary: 'Success', detail:'משתמש עודכן'});
// //   })
// //   }
// //   else{
// //     this.messageService.add({key: 'myKey1',severity:'error', summary: 'Error', detail:'אין אפשרות להכניס משתמש כפול '});
// //     this.arrU[index] = this.clonedUsers[user.id];
// //   }}
// //   })}
// //   }
// //   onRowEditCancel(user: User, index: number) {
// //     if(user.id==0){
// //       this.arrU.pop();

// //     }
// //     else{
// //       this.arrU[index] = this.clonedUsers[user.id];
// //       delete this.clonedUsers[user.id];
// //     }
// //   }
// //     delete(user:User,index:number){
// //     user.active= false;
// //     this.db.updateUser(user.id,user).subscribe(x=>{
// //       this.u=<User>x;
// //   })
// //   //this.arrU[index] = this.clonedUsers[user.id];
// //   this.messageService.add({key: 'myKey1',severity:'success', summary: 'Success', detail:'user was deleted'});
// //   }

// // }
