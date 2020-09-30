import {Component, OnInit} from '@angular/core';
import {Department} from './department';
import {departmentsService} from "./departments.service";
import {Language} from "../languages/language";

@Component({
  selector: 'depts',
  templateUrl: 'depts.component.html',
  providers: [departmentsService]
})
export class deptsComponent implements OnInit{
  department: Department = new Department();
  departments: Department[];
  tableMode: boolean = true;

  constructor(private departmentService: departmentsService) {
  }

  ngOnInit(): void {
    this.loadDepartments();
  }

  loadDepartments(){
    this.departmentService.getDepartments().subscribe((data: Department[])=> this.departments = data);
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

  editDepartment(d: Department){
    this.department = d;
  }

  cancel(){
    this.department = new Department();
    this.tableMode = true;
  }
  delete(d: Department){
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
