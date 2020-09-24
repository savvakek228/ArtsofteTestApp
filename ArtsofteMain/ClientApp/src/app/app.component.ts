import {Component, OnInit} from '@angular/core';
import {Department} from "./test/department";
import {DepartmentsService} from "./test/departments.service";

@Component({
  selector: 'app',
  templateUrl: './app.component.html',
  providers: [DepartmentsService]
})
export class AppComponent implements OnInit{
  department: Department = new Department();
  departments: Department[];
  tableMode: boolean = true;

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
    }
    else {
      this.departmentService.updateDepartment(this.department).subscribe(data => this.loadDepartments());
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
    this.departmentService.deleteDepartment(d.id).subscribe(data=>this.loadDepartments());
  }
  add(){
    this.cancel();
    this.tableMode = false;
  }
}
