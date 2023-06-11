import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'project';
  text:string=""
  @Input()
  exist:boolean=false;
  ngOnInit(): void {
  }
  catchExist(e:any){
  this.exist=e;
  
}
  // Check(){
  //   while(!this.exist){
  //     console.log(false);
  //   }
  //   alert('true')
  // }
  
}
