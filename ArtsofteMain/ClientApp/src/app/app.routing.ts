import {NgModule} from "@angular/core";
import {Routes,RouterModule} from "@angular/router";
import {EmployeesComponent} from "./employees/employees.component";
import {DepartmentsComponent} from "./departments/departments.component";
import {LanguagesComponent} from "./languages/languages.component";

const appRoutes: Routes = [
  {path: '', component: EmployeesComponent},
  {path: 'departments', component: DepartmentsComponent},
  {path: 'languages', component: LanguagesComponent}
]

@NgModule({
  imports:[RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})

export class AppRoutingModule{

}
