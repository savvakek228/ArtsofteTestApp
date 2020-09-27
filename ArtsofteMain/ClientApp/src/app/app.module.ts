import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DeptsComponent } from './departments/depts.component';
import {LangsComponent} from "./languages/langs.component";

@NgModule({
  imports: [BrowserModule, FormsModule, HttpClientModule],
  declarations: [DeptsComponent,LangsComponent],
  bootstrap: [DeptsComponent]
})
export class AppModule { }
