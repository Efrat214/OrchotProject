import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PasswordModule } from 'primeng/password';
import { ImageModule } from 'primeng/image';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { MessagesModule } from 'primeng/messages';
import { DbService } from './db.service';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ToastModule } from 'primeng/toast';
import { MessageModule } from 'primeng/message';
import { RippleModule } from 'primeng/ripple';
import { AnimateModule } from 'primeng/animate';
import { BrowserAnimationsModule } from'@angular/platform-browser/animations';
import { PanelMenuModule } from 'primeng/panelmenu';
import { AccordionModule } from 'primeng/accordion';     
import { MenubarModule } from 'primeng/menubar';
import { PanelModule } from 'primeng/panel';
import { FileUploadModule } from "primeng/fileupload";
import {DropdownModule} from 'primeng/dropdown';
import {InputSwitchModule} from 'primeng/inputswitch';
import {InputNumberModule} from 'primeng/inputnumber';
import { LoginComponent } from './login/login.component';
import { MenuComponent } from './menu/menu.component';
import { FileUploadComponent } from './file-upload/file-upload.component';
import {TableModule} from 'primeng/table';
import {CheckboxModule} from 'primeng/checkbox';
import {DialogModule} from 'primeng/dialog';
import {CalendarModule} from 'primeng/calendar';
import {SliderModule} from 'primeng/slider';
import {MultiSelectModule} from 'primeng/multiselect';
import {ContextMenuModule} from 'primeng/contextmenu';
import {ProgressBarModule} from 'primeng/progressbar';
import { UsersEditingComponent } from './users-editing/users-editing.component';
import { pathArr } from './Path';
import { RouterModule } from '@angular/router';
import { FilterComponent } from './filter/filter.component';
import {ConfirmPopupModule} from 'primeng/confirmpopup';
 //import {ConfirmationService} from 'primeng/api';
import {MenuModule} from 'primeng/menu';
import { MessageService } from 'primeng/api';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MenuComponent,
    FileUploadComponent,
    UsersEditingComponent,
    FilterComponent
  ],
  imports: [
    BrowserModule,PasswordModule,ImageModule,InputTextModule,ButtonModule,MessagesModule,FormsModule,
    HttpClientModule,ToastModule,MessageModule,RippleModule,AnimateModule,BrowserAnimationsModule,
    PanelMenuModule,AccordionModule,MenubarModule,PanelModule,FileUploadModule,DropdownModule,
    InputSwitchModule,InputNumberModule,TableModule,CheckboxModule,DialogModule,CalendarModule,SliderModule,
    MultiSelectModule,ContextMenuModule,ProgressBarModule,RouterModule.forRoot(pathArr),ConfirmPopupModule,
    MenuModule,
    AppRoutingModule
  ],
  providers: [DbService,MessageService],
  bootstrap: [AppComponent]
})
export class AppModule {
  
 }
