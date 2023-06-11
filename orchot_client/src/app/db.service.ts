import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import{Document}from './Document'
import { User } from './Users';
import { identifierName } from '@angular/compiler';
import DocReferance from './doc-reference';


@Injectable({
  providedIn: 'root'
})
export class DbService {
  baseUrl="https://localhost:7116";
  currentUserId:number = 0;
  userName:string = "";
  passward: string = "";

  constructor(private http: HttpClient) { }
  GetAllUsers(){
    return this.http.get(this.baseUrl + "/api/User");
  }
  getUserById(id: number){
    return this.http.get(this.baseUrl + "/api/User/"+id);
  }
  // getUserByName(name: string){
  //   return this.http.get(this.baseUrl + "/api/User/"+name);
  // }
  updateUser(id:number,u:User){
    return this.http.put(this.baseUrl + "/api/User/"+id,u);
  }
  addUser(u:User){
    return this.http.post(this.baseUrl + "/api/User",u);
  }
  getDocuments(){
    return this.http.get(this.baseUrl + "/api/Document")
  }
  getDocRefById(id:number){
    return this.http.get(this.baseUrl + "/api/DocReferance"+id);
  }
  getTblAssistValueById(id:number){
    return this.http.get(this.baseUrl + "/api/TblAssistValue/"+id);
  }
  addDocument(d:Document){
    return this.http.post(this.baseUrl + "/api/Document",d);
  }
  getAllDocument(){
    return this.http.get(this.baseUrl + "/api/Document");
  }
  getAllDocumentRef(){
    return this.http.get(this.baseUrl + "/api/DocReferance");
  }
  addDocRef(dr:DocReferance){
    return this.http.post(this.baseUrl + "/api/DocReferance",dr);
  }
  getByUserName(xx: string){
    return this.http.get(this.baseUrl +"/api/Ext/"+xx);
  }

  deleteDoc(id:number){
    return this.http.delete(this.baseUrl +"/api/Document/"+id);
  }
  deleteDocReferances(id:number){
    return this.http.delete(this.baseUrl +"/api/DocReferance/"+id);
  }
  getDocumentByDocId(id:number){
    return this.http.get(this.baseUrl + "/api/Extra/"+id);
  }

  uploadFile(doc: Document, fileToUpload: File){
    const url = this.baseUrl +"/api/Azure/";
    const formData = new FormData();
    formData.append('formFile', fileToUpload, fileToUpload.name);
  
    const headers = new HttpHeaders();
    headers.set('Content-Type', 'multipart/form-data');

    formData.append('Id', doc.id.toString());
    formData.append('DocumentName', doc.documentName);
    formData.append('Organization', doc.organization);
    formData.append('BusinessUnit', doc.businessUnit);
    formData.append('Department', doc.department);
    formData.append('CreateBy', doc.createBy);
    formData.append('DocType', doc.docType);
    
    //!לא למחוק!
    //כאן מקבלים את הלינק למסמך
    console.log(formData);
    
    return this.http.post(url, formData, {headers});
  }

  deleteFileFromAzure(url: string){
    return this.http.delete(url);
  }

}
