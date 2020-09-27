import {Component, OnInit} from '@angular/core';
import {Department} from './department';
import {DepartmentsService} from "./departments.service";

@Component({
  selector: 'depts',
  templateUrl: './depts.component.html',
  providers: [DepartmentsService]
})
export class DeptsComponent implements OnInit{
  department: Department = new Department();
  departments: Department[];
  tableMode: boolean = true;
  enableEdit: boolean = false;

  constructor(private departmentService: DepartmentsService) {
  }

  ngOnInit(): void {
    this.loadDepartments();
  }

  loadDepartments(){
    this.departmentService.getDepartments().subscribe((data: Department[])=> this.departments = data);
  }

  submit(){
    if (this.department.id == null) {
      this.departmentService.createDepartment(this.department).subscribe((data:Department) => this.departments.push(data));
      this.loadDepartments();
    }
    else {
      this.departmentService.updateDepartment(this.department).subscribe(data => this.loadDepartments());
      this.loadDepartments();
    }
    this.cancel();
  }

  editDepartment(d: Department){
    d.editable = !d.editable;
    this.department = d;
  }

  cancel(){
    this.department = new Department();
    this.tableMode = true;
  }
  delete(d: Department){
    this.departmentService.deleteDepartment(d.departmentID).subscribe(data=>this.loadDepartments());
  }
  add(){
    this.cancel();
    this.tableMode = false;
  }
}
