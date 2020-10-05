import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DepartmentsComponent } from './departments/departments.component';
import { LanguagesComponent } from "./languages/languages.component";
import { EmployeesComponent } from "./employees/employees.component";
import {rootComponent} from "./root/main.component";
import {AppRoutingModule} from "./app.routing";
import {AutocompleteLibModule} from "angular-ng-autocomplete";

@NgModule({
  imports: [BrowserModule, FormsModule, ReactiveFormsModule, HttpClientModule, AppRoutingModule, AutocompleteLibModule],
  declarations: [DepartmentsComponent,LanguagesComponent, EmployeesComponent,rootComponent],
  bootstrap: [rootComponent]
})
export class AppModule { }
