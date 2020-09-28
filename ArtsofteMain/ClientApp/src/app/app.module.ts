import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { deptsComponent } from './departments/depts.component';
import { langsComponent } from "./languages/langs.component";
import { empsComponent } from "./employees/emps.component";
import {RouterModule, Routes} from "@angular/router";
import {rootComponent} from "./root/main.component";
import {main} from "@angular/compiler-cli/src/main";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSelectModule} from "@angular/material/select";

const appRoutes: Routes = [
  {path: '', component: empsComponent},
  {path: 'depts', component: deptsComponent},
  {path: 'langs', component: langsComponent}
]

@NgModule({
    imports: [BrowserModule, FormsModule, HttpClientModule, RouterModule.forRoot(appRoutes), BrowserAnimationsModule, MatSelectModule],
  declarations: [deptsComponent,langsComponent, empsComponent,rootComponent],
  bootstrap: [rootComponent]
})
export class AppModule { }
