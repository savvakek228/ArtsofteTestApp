import {Component, OnInit} from "@angular/core";
import {employeeService} from "./employee.service";
import {Employee} from "./employee";
import {Department} from "../departments/department";
import {Language} from "../languages/language";
import {BehaviorSubject, Observable} from "rxjs";
import {tap} from "rxjs/operators";
import {departmentsService} from "../departments/departments.service";
import {languagesService} from "../languages/languages.service";
import {FormBuilder, FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
  selector: 'emps',
  templateUrl: 'emps.component.html',
  providers: [employeeService, departmentsService, languagesService]

})

export class empsComponent implements OnInit{
  employeeForm: FormGroup;
  employee: Employee = new Employee();
  employees$: Observable<Object>;
  empDepartments$: BehaviorSubject<Department[]> = new BehaviorSubject<Department[]>(null);
  empLanguages$: BehaviorSubject<Language[]> = new BehaviorSubject<Language[]>(null);
  tableMode: boolean = true;
  genders: string[] =  ["Мужчина", "Женщина"];

  constructor(private employeeService: employeeService,
              private languagesService: languagesService,
              private departmentsService: departmentsService,
              private formBuilder: FormBuilder) {
    this.initializeForm();
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

  initializeForm(){
    this.employeeForm =
      this.formBuilder.group({
      name:['',Validators.required],
      surname:['', Validators.required],
      age:['', Validators.required],
      gender:['',Validators.required],
      department:['',Validators.required],
      language:['',Validators.required]
    });
  }

  isControlInvalid(controlName: string) : boolean{
    const control = this.employeeForm.controls[controlName];
    return control.invalid && control.touched;
  }

  revert(){
    this.employeeForm.reset();
  }

  submit(){
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

  onSubmit(){
    const controls = this.employeeForm.controls;
    if (this.employeeForm.invalid){
      Object.keys(controls).forEach(controlName => controls[controlName].markAsTouched())
      return;
    }
    this.employee = this.employeeForm.value
    this.employee.gender = this.employeeForm.value.gender== "Мужчина";
    console.log(this.employee);
    this.submit();
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
