import { Route } from "@angular/router";
import { UsersEditingComponent } from "./users-editing/users-editing.component";
import { FileUploadComponent } from "./file-upload/file-upload.component";
import { MenuComponent } from "./menu/menu.component";
import { FilterComponent } from "./filter/filter.component";
import { LoginComponent } from "./login/login.component";

export const pathArr:Route[]=[
    {path:"",component:LoginComponent},
   
    {path:"menu", component:MenuComponent
    , children:[{
        path:"filter",component:FilterComponent},
        {path:"upLoadFile",component:FileUploadComponent},
        {path:"UserEdit",component:UsersEditingComponent}
       
    ]
    }
    // {path:"menu/filter", component:FilterComponent} ,
    // {path:"menu/upLoadFile",component:FileUploadComponent},
    // {path:"menu/UserEdit",component:UsersEditingComponent}
]