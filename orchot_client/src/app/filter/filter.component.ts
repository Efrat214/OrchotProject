import { Component } from '@angular/core';
import { Document } from '../Document';
import { MessageService } from 'primeng/api';
import {MenuItem} from 'primeng/api';
import { DocReferance} from '../doc-reference'
import { DbService } from '../db.service';

@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.css'],
  providers:[MessageService]
})
export class FilterComponent {
  calendarVal?:Date;
  title = 'project';
  document=new Document(0,"","","","","",new Date(),new Date(),false,new Date(),"",new Date(),0,"",false,"");
  docRef:DocReferance=new DocReferance(0,0,"","");
  arrD:Document[]=[];
  arrDocRef:DocReferance[]=[];

  constructor(private db:DbService,private messageService: MessageService){
    
  }
  ngOnInit() {
    this.refreshDocs();
  }
  refreshDocs(){
    this.db.getAllDocument().subscribe(x=>{
      this.arrD=<Document[]>x;
    });
  }
  // delete(doc:Document){
  //   this.db.deleteDocReferances(doc.id).subscribe();
  //   this.db.deleteDoc(doc.id).subscribe();
  //   console.log(this.arrD);
  //   this.messageService.add({key: 'myKey1',severity:'success', summary: 'Success', detail:'document was deleted'});
  //   this.refreshDocs();
  // }
  delete(doc:Document){
    this.db.getDocumentByDocId(doc.id).subscribe(x=>{
      console.log(x);
      this.db.deleteFileFromAzure(doc.docLink).subscribe(result=>{console.log(result);});
      this.arrDocRef=<DocReferance[]>x;  
      this.arrDocRef.forEach(x=>this.db.deleteDocReferances(x.id).subscribe(x=>console.log('success')));
      
      //this.db.deleteDocReferances(this.docRef.id).subscribe();
      this.db.deleteDoc(doc.id).subscribe(x=>
      this.messageService.add({key: 'myKey1',severity:'success', summary: 'Success', detail:'המסמך נמחק בהצלחה'}));
     this.arrD=this.arrD.filter(x=>x.id!=doc.id)
      // this.refreshDocs();
     
    });
      
    // thisthis.db.getDocumentByDocId(doc.id).subscribe(x=>{
    //   this.docRef= <DocReferance>x;
    //   console.log(this.docRef);
    // })
   }
    onReject(){
      this.messageService.clear('confirm');
    }
    onConfirm(d:Document){
      this.messageService.clear('confirm');
      this.delete(d);
    }
    showConfirm(){
      this.messageService.add({key:'confirm' ,severity: 'warn', summary: '  warning', detail: '?למחוק את המסמך', sticky: true });
    }
 }
