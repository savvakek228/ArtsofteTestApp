import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DepartmentsComponent } from './departments/departments.component';
import { langsComponent } from "./languages/langs.component";
import { EmployeesComponent } from "./employees/employees.component";
import {rootComponent} from "./root/main.component";
import {AppRoutingModule} from "./app.routing";

@NgModule({
  imports: [BrowserModule,FormsModule, ReactiveFormsModule, HttpClientModule,AppRoutingModule],
  declarations: [DepartmentsComponent,langsComponent, EmployeesComponent,rootComponent],
  bootstrap: [rootComponent]
})
export class AppModule { }
