import {Component, OnDestroy, OnInit} from '@angular/core';
import {Department} from './department';
import {Subscription} from "rxjs";
import {MainAPIService} from "../root/MainAPIService";

@Component({
  selector: 'depts',
  templateUrl: 'departments.component.html',
  providers: [MainAPIService]
})
export class DepartmentsComponent implements OnInit, OnDestroy{
  department: Department = new Department();
  departments: Department[];
  subscriptions: Subscription[] = [];
  tableMode: boolean = true;

  constructor(private apiService: MainAPIService) {
  }

  ngOnInit(): void {
    this.loadDepartments();
  }

  ngOnDestroy() {
    this.subscriptions.forEach((sub)=>sub.unsubscribe());
  }

  //region Working with View

  loadDepartments(){
    this.subscriptions.push(this.apiService.getDepartments().subscribe((data: Department[]) => this.departments = data));
  }

  submit(){
    if (this.department.departmentID == null) {
      this.subscriptions.push(this.apiService.createDepartment(this.department).subscribe(()=>this.loadDepartments()));
    }
    else {
      this.subscriptions.push(this.apiService.updateDepartment(this.department).subscribe());
    }
    this.cancel();
  }

  editDepartment(d: Department){
    this.department = d;
  }

  cancel(){
    this.department = new Department();
    this.tableMode = true;
  }
  delete(d: Department){
    this.subscriptions.push(this.apiService.deleteDepartment(d.departmentID)
      .subscribe(()=>this.departments.splice(this.departments.indexOf(d),1)));
  }
  add(){
    this.department = new Department();
    this.tableMode = false;
  }

  trackByDeptID(index: number, department: any): number{
    if (department.departmentID != null) {
      return department.departmentID;
    }
  }

  //endregion
}
