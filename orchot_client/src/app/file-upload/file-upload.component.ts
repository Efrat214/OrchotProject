import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import { SelectItem } from 'primeng/api';
import { FileUpload } from 'primeng/fileupload';
import { DbService } from '../db.service';

// import { DocReference } from '../doc-reference';
import{DocReferance} from '../doc-reference'
import { Document } from '../Document';
import { TblAssistValue } from '../TblAssistValue';
import { Router } from '@angular/router';

@Component({
  selector: 'app-file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.css'],
  providers:[MessageService]
})

export class FileUploadComponent{
  isDisabled:boolean=false;
  file:any;
  d: Document = new Document(0,"","","","","",new Date(), new Date(), false,new Date(),"",new Date(), 0,"",false,"");
  d1: Document = new Document(0,"","","","","",new Date(), new Date(), false,new Date(),"",new Date(), 0,"",false,"");
  dr: DocReferance = new DocReferance(0, 0, "", "");
  currentDate:string = "";
  userName:string = "";
  numDaysExp: number = 0;
  uploadFile:boolean=false;
  uploadAzure:boolean=false;
  todayDate:string = new Date().toISOString().split('T')[0];;
  upload:number=0;
  date1:boolean=false;
  date2:boolean=false;

  organizations:SelectItem[] = [];
  organization:string = "";

  businessUnits:SelectItem[] = [];
  businessUnit:string = "";

  departments:SelectItem[] = [];
  department:string = "";

  documentTypes:SelectItem[] = [];
  documentType:string = "";

  refTypes:SelectItem[] = [];
  refType:string = "";

  alertActive: boolean = false;
  
  organizations1:TblAssistValue[] = [];
  businessUnits1:TblAssistValue[] = [];
  departments1:TblAssistValue[] = [];
  documentsType1:TblAssistValue[] = [];
  refTypes1:TblAssistValue[] = [];

  constructor(private db:DbService, private messageService: MessageService, private rout:Router){
    //this.todayDate.setHours(0, 0, 0, 0);
    this.d.createBy = localStorage.getItem('userName')?.toString() || '';
    this.currentDate = new Date().toISOString().substring(0, 10);
  }
  
  ngOnInit(){
    //this.messageService.add({key: 'myKey1',severity:'info', summary: 'Info', detail:'יש להכניס את כל הפרטים המסומנים ב *'});
    this.db.getTblAssistValueById(10).subscribe(x => {
      this.organizations1 = <TblAssistValue[]>x;
      this.organizations1.forEach(y => 
        this.organizations.push({label:y.value1, value:y.code})
        );    
    });

    this.db.getTblAssistValueById(11).subscribe(x => {
      this.businessUnits1 = <TblAssistValue[]>x;
      this.businessUnits1.forEach(y => 
        this.businessUnits.push({label:y.value1, value:y.code})
        );
    });

    this.db.getTblAssistValueById(12).subscribe(x => {
      this.departments1 = <TblAssistValue[]>x;
      this.departments1.forEach(y => 
        this.departments.push({label:y.value1, value:y.code})
        );
    });

    this.db.getTblAssistValueById(13).subscribe(x => {
      this.documentsType1 = <TblAssistValue[]>x;
      this.documentsType1.forEach(y => 
        this.documentTypes.push({label:y.value1, value:y.code})
        );
    });

    this.db.getTblAssistValueById(20).subscribe(x => {
      this.refTypes1 = <TblAssistValue[]>x;
      this.refTypes1.forEach(y => 
        this.refTypes.push({label:y.value1, value:y.code})
        );
    });

  }

  onChange1(){
    this.date1=true;
    this.onChange();
  }
  onChange2(){
    this.date2=true;
    this.onChange();
  }
  onChange() {
    console.log("-----------------on Change---------------");
    console.log(this.uploadFile);
    console.log(this.d);
  if(this.date1 && this.date2){
    const expDate = new Date(this.d.expirationDate);
    const effDate = new Date(this.d.effectiveDate);
    const diffInMs = expDate.getTime() - effDate.getTime();
    const diffInDays = diffInMs / (1000 * 60 * 60 * 24);
    console.log(diffInDays);
    if (diffInDays < 0) {
      this.messageService.add({key: 'myKey1', severity: 'error', summary: 'Error', detail: ' נא לבחור תאריכים תקינים'});
    }
  }
    if(this.d.documentName!==""&&this.d.docType!==""&&this.d.department!==""&&this.d.businessUnit!==""&&this.d.organization!==""&&this.dr.refType!=="")
      this.uploadFile = true;
    else
      this.uploadFile = false;
  }

  addDocument(){
    console.log("------------add Document-----------");
    console.log(this.d);
    
    this.departments1.forEach(element => {
      if(element.code.includes(this.d.department)){
        this.d.department=element.code; 
      }
    })
    this.businessUnits1.forEach(element => {
      if(element.code.includes(this.d.businessUnit)){
        this.d.businessUnit=element.code; 
      }
    }) 
    this.organizations1.forEach(element => {
      if(element.code.includes(this.d.organization)){
        this.d.organization=element.code; 
      }
    })
    this.documentsType1.forEach(element => {
      if(element.code.includes(this.d.docType)){
        this.d.docType=element.code; 
      }
    })
    this.refTypes1.forEach(element => {
      if(element.code.includes(this.dr.refType)){
        this.dr.refType=element.code; 
      }
    })
    console.log(this.d);
    //////////////////////////////////////
    this.db.addDocument(this.d).subscribe(x=>{
      this.dr.docId=<number>x;
      console.log(this.dr.docId)
      console.log(this.dr)
      if(this.dr.docId!=0){
        this.db.addDocRef(this.dr).subscribe(x=>{
        this.upload=<number>x; 
        if(this.upload){
          this.messageService.add({key: 'myKey1', severity: 'success', summary: 'Success', detail: 'המסמך נשמר בהצלחה'});
          setTimeout(() => {
            this.rout.navigate(['menu'])
          }, 1000);
          
        }
        else{
          this.messageService.add({key: 'myKey1',severity:'error', summary: 'Error', detail:'העלאת המסמך נכשלה'});
        } 
      })
    }
    
    })

    // console.log(this.dr.docId)
    //  console.log(this.dr)
    // if(this.dr.docId!=0){
    //   this.db.addDocRef(this.dr).subscribe(x=>{
    //   this.dr=<DocReferance>x; 
    //   this.messageService.add({key: 'myKey1',severity:'success', summary: 'Success', detail:'המסמך נשמר בהצלחה!'});

    //   })
    // }
    // else{
    //   this.messageService.add({key: 'myKey1',severity:'error', summary: 'Error', detail:'העלאת המסמך נכשלה'});
    // } 
    /////////////////////////////////////////// 
    //     
  }

  clearInputs() {
    this.d = new Document(0,"","","","","",new Date(), new Date(), false,new Date(),"",new Date(), 0,"",false,"");
    this.d1 = new Document(0,"","","","","",new Date(), new Date(), false,new Date(),"",new Date(), 0,"",false,"");
    this.dr = new DocReferance(0, 0, "", "");
    this.currentDate = new Date().toISOString().substring(0, 10);
    this.userName = "";
    this.numDaysExp = 0;
    this.organization = "";
    this.businessUnit = "";
    this.department = "";
    this.documentType = "";
    this.refType = "";
  }

  onUpload(event: any) {
    this.uploadAzure=true;
    console.log("-----------upload-Document----------");
    if (event === undefined)
      return;
    console.log(event);
    this.file = <File>event.files[0];
    console.log(this.d);

    //copy document//
    this.d1.id = this.d.id;
    this.d1.createBy = this.d.createBy;
    this.d1.documentName = this.d.documentName;
    this.d1.docType = this.d.docType;
    /////////////////////////////
    this.departments1.forEach(element => {
      if(element.code.includes(this.d.department)){
        this.d1.department = element.value1; 
      }
    })
    this.businessUnits1.forEach(element => {
      if(element.code.includes(this.d.businessUnit)){
        this.d1.businessUnit = element.value1; 
      }
    }) 
    this.organizations1.forEach(element => {
      if(element.code.includes(this.d.organization)){
        this.d1.organization = element.value1; 
      }
    })
    ///////////////////////////////////

    this.db.uploadFile(this.d1, this.file).subscribe((result) => {
      console.log(Object.values(result)[0]);     
      this.d.docLink = Object.values(result)[0];
      this.isDisabled = true;
      this.uploadAzure=false;
    },
     error => {
     this.messageService.add({key: 'myKey1',severity:'error', summary: 'Error', detail:'העלאת המסמך נכשלה' });
     this.uploadAzure = false;
     }
    )
  }

  clearIcon(event: any){
    this.uploadAzure = false;
  }
    // addDocument(){
  //   console.log("------------add Document-----------");
  //   this.documentsType1.forEach(element => {
  //     if(element.code.includes(this.d.docType)){
  //       this.d.docType = element.code; 
  //     }
  //   })
  //   this.departments1.forEach(element => {
  //     if(element.code.includes(this.d.department)){
  //       this.d.department=element.code; 
  //     }
  //   })
  //   this.businessUnits1.forEach(element => {
  //     if(element.code.includes(this.d.businessUnit)){
  //       this.d.businessUnit=element.code; 
  //     }
  //   }) 
  //   this.organizations1.forEach(element => {
  //     if(element.code.includes(this.d.organization)){
  //       this.d.organization=element.code; 
  //     }
  //   })
  //   //////////////////////////////////////
  //   this.db.addDocument(this.d).subscribe(x=>{
  //     this.dr.docId=<number>x;
  //   })
  //   if(this.dr.docId!=0){
  //     this.db.addDocRef(this.dr).subscribe(x=>{
  //     this.dr=<DocReferance>x; 
  //     this.messageService.add({key: 'myKey1',severity:'success', summary: 'Success', detail:'המסמך נשמר בהצלחה!'});

  //     })
  //   }
  //   else{
  //     this.messageService.add({key: 'myKey1',severity:'error', summary: 'Error', detail:'העלאת המסמך נכשלה'});
  //   } 
  //   ///////////////////////////////////////////     
  // }
}