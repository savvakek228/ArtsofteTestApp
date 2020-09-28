import {Component, OnInit} from '@angular/core';
import {department} from './department';
import {departmentsService} from "./departments.service";
import {Language} from "../languages/language";

@Component({
  selector: 'depts',
  templateUrl: 'depts.component.html',
  providers: [departmentsService]
})
export class deptsComponent implements OnInit{
  department: department = new department();
  departments: department[];
  tableMode: boolean = true;

  constructor(private departmentService: departmentsService) {
  }

  ngOnInit(): void {
    this.loadDepartments();
  }

  loadDepartments(){
    this.departmentService.getDepartments().subscribe((data: department[])=> this.departments = data);
  }

  submit(){
    if (this.department.departmentID == null) {
      this.departmentService.createDepartment(this.department).subscribe(()=>this.loadDepartments());
    }
    else {
      this.departmentService.updateDepartment(this.department).subscribe(() => this.loadDepartments());
    }
    this.cancel();
  }

  editDepartment(d: department){
    d.editable = !d.editable;
    this.department = d;
  }

  cancel(){
    this.department = new department();
    this.tableMode = true;
  }
  delete(d: department){
    this.departmentService.deleteDepartment(d.departmentID).subscribe(()=>this.loadDepartments());
  }
  add(){
    this.cancel();
    this.tableMode = false;
  }

  trackByDeptID(index: number, department: any): number{
    return department.departmentID;
  }
}
