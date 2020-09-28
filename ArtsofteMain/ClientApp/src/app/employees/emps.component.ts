import {Component, OnInit} from "@angular/core";
import {employeeService} from "./employee.service";
import {Employee} from "./employee";


@Component({
  selector: 'emps',
  templateUrl: 'emps.component.html',
  providers: [employeeService]

})
export class empsComponent implements OnInit{
  employee: Employee = new Employee();
  employees: Employee[];
  tableMode: boolean = true;
  genders: ["Мужчина", "Женщина"];

  constructor(private employeeService: employeeService) {

  }


  ngOnInit(): void {
  }

  loadEmployees(){
    this.employeeService.getEmployees().subscribe((data: Employee[])=>this.employees=data);
  }

  submit(){
    if(this.employee.employeeID == null) {
      this.employeeService.createEmployee(this.employee).subscribe(()=>this.loadEmployees());
    }
    else {
      this.employeeService.updateEmployee(this.employee).subscribe(()=>this.loadEmployees());
    }
    this.cancel();
  }

  delete(e: Employee){
    this.employeeService.deleteEmployee(e.employeeID).subscribe(()=>this.loadEmployees());
  }

  add(){
    this.cancel();
    this.tableMode = false;
  }

  editEmployee(e: Employee){
    this.employee = e;
  }

  cancel(){
    this.employee = new Employee();
    this.tableMode = true;
  }

  trackByEmpID(index:number,emp?: any): number {
    if (emp.employeeID != null) {
      return emp.employeeID;
    }


  }
}
