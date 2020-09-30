import {Component, OnInit} from "@angular/core";
import {employeeService} from "./employee.service";
import {Employee} from "./employee";
import {Department} from "../departments/department";
import {Language} from "../languages/language";
import {BehaviorSubject, Observable} from "rxjs";
import {map, tap} from "rxjs/operators";
import {departmentsService} from "../departments/departments.service";
import {languagesService} from "../languages/languages.service";

interface Gender {
  name: string,
  value: boolean
}

@Component({
  selector: 'emps',
  templateUrl: 'emps.component.html',
  providers: [employeeService, departmentsService, languagesService]

})

export class empsComponent implements OnInit{
  employee: Employee = new Employee();
  employees$: Observable<Object>;
  empDepartments$: BehaviorSubject<Department[]> = new BehaviorSubject<Department[]>(null);
  empLanguages$: BehaviorSubject<Language[]> = new BehaviorSubject<Language[]>(null);
  tableMode: boolean = true;
  genders: Gender[] = [{name: "Муж", value: true}, {name: "Жен",value:false}];

  constructor(private employeeService: employeeService,
              private languagesService: languagesService,
              private departmentsService: departmentsService) {

  }

  ngOnInit(): void {
    console.log(this.genders);
    this.loadAllData();
  }

  loadAllData(){
    this.employees$ = this.employeeService.getEmployees()
      .pipe(tap(()=>
      {
        this.departmentsService.getDepartments().subscribe((data:Department[])=>this.empDepartments$.next(data));
        console.log(this.empDepartments$);
        this.languagesService.getLanguages().subscribe((data:Language[])=>this.empLanguages$.next(data));
        console.log(this.empLanguages$);
      }))
  }

  submit(){
    debugger;
    if(this.employee.employeeID == null) {
      this.employeeService.createEmployee(this.employee).subscribe(()=>this.loadAllData());
    }
    else {
      this.employeeService.updateEmployee(this.employee).subscribe(()=>this.loadAllData());
    }
    this.cancel();
  }

  delete(e: Employee){
    this.employeeService.deleteEmployee(e.employeeID).subscribe(()=>this.loadAllData());
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
