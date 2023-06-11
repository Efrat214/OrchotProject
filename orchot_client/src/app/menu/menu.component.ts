import { Component } from '@angular/core';
import { Route, Router, RouterLink } from '@angular/router';
import { MenuItem } from 'primeng/api';
import { DbService } from '../db.service';
import { User } from '../Users';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent {
    user:User = new User(0, "", "", "", "", "", "", true, true);
    arrU:User[] = [];
    items: MenuItem[] = [];
    admin:boolean = false;

constructor(private db:DbService,private rout:Router){
    this.admin = localStorage.getItem('isAdmin') === 'true';
}
  ngOnInit() {

   this.items = [
       {
           label: ' מסמכים ',
           icon: 'pi pi-pw pi-file',command:e=>{
            this.rout.navigate(['menu'])
           },
           items: [{
                   label: ' מסמך חדש ', 
                   icon: 'pi pi-fw pi-plus',
                   routerLink:['upLoadFile']                  
               },
               {label: ' שאילתת מסמכים ', 
               icon: 'pi pi-fw pi-external-link', 
               routerLink:['filter'],
               command:e=>{
                this.admin=false;
                const foundItem = this.items.find(x => x.label === ' מסמכים ');
                if (foundItem && foundItem.items) {
                    console.log(foundItem.items);
                    foundItem.items = [];
                    console.log(foundItem.items);
                  }                  
                // this.rout.navigate(['menu/filter'])
               }
               }
           ],
       },
       {
           label: ' ניהול ',
           disabled:!this.admin,
           icon: 'pi pi-fw pi-pencil',
           command:e=>{
            this.rout.navigate(['menu'])
           },
           items: [
               {label: ' עדכון משתמשים ', icon: 'pi pi-fw pi-refresh',routerLink:'UserEdit'},
            //    {label: 'ארכיון צפיה במסמכים	', icon: 'pi pi-pi pi-bars'}
           ]
       },
       ];
    }
    isAdmin(){
        this.db.getUserById(this.db.currentUserId).subscribe(x=>{
            this.user=<User>x;
            this.admin=false;
        })
        // if(this.user.admin==true)
        //     this.admin=false;
    }
}
