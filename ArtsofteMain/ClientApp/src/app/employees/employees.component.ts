import {Component, OnDestroy, OnInit} from "@angular/core";
import {Employee} from "./employee";
import {Department} from "../departments/department";
import {Language} from "../languages/language";
import {BehaviorSubject, Observable, Subscription} from "rxjs";
import {map, tap} from "rxjs/operators";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {MainAPIService} from "../root/MainAPIService";

@Component({
  selector: 'emps',
  templateUrl: 'employees.component.html',
  providers: [MainAPIService]

})

export class EmployeesComponent implements OnInit, OnDestroy{

  //region Fields

  employeeForm: FormGroup;
  editing: boolean = false;
  employee: Employee = new Employee();
  subscriptions: Subscription[] = []
  employees$: Observable<Object>;
  empDepartments$: BehaviorSubject<Department[]> = new BehaviorSubject<Department[]>(null);
  empLanguages$: BehaviorSubject<Language[]> = new BehaviorSubject<Language[]>(null);
  tableMode: boolean = true;
  genders: string[] =  ["Мужчина", "Женщина"];

  //endregion

  //region Constructor and Angular event handlers

  constructor(private apiService: MainAPIService,
              private formBuilder: FormBuilder) {
    this.initializeForm();
  }

  ngOnInit(): void {
    this.loadAllData();
  }

  ngOnDestroy() {
    this.subscriptions.forEach((sub)=>sub.unsubscribe());
  }

  //endregion

  //region Employees Reactive Form

    initializeForm(){
      this.employeeForm =
        this.formBuilder.group({
          employeeID: this.employee.employeeID,
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

    onSubmit(){
      const controls = this.employeeForm.controls;
      if (this.employeeForm.invalid){
        Object.keys(controls).forEach(controlName => controls[controlName].markAsTouched())
        return;
      }
      this.employee = this.employeeForm.value
      this.employee.gender = this.employeeForm.value.gender == this.genders[0];
      this.submit();
    }

    //endregion

  //region Working with View

  loadAllData(){
    this.employees$ = this.apiService.getEmployees()
      .pipe(tap(()=>
      {
        this.subscriptions.push(this.apiService.getDepartments().subscribe((data:Department[])=>this.empDepartments$.next(data)));
        this.subscriptions.push(this.apiService.getLanguages().subscribe((data:Language[])=>this.empLanguages$.next(data)));
      }))
  }

  submit(){
    if(this.employee.employeeID == null) {
      this.subscriptions.push(this.apiService.createEmployee(this.employee).subscribe(()=>this.loadAllData()));
    }
    else {
      this.subscriptions.push(this.apiService.updateEmployee(this.employee).subscribe(()=>this.loadAllData()));
    }
    this.cancel();
  }

  delete(e: Employee){
    this.subscriptions.push(this.apiService.deleteEmployee(e.employeeID).subscribe(()=>this.loadAllData()));
  }

  add(){
    this.employee = new Employee();
    this.tableMode = false;
    this.editing = false;
    this.employeeForm.patchValue({
      employeeID: this.employee.employeeID,
      name: '',
      surname: '',
      age: '',
      gender: '',
      department:'',
      language:''
    })
  }

  editEmployee(e: Employee){
    this.editing = true;
    this.tableMode = false;
    this.employee = e;
    this.employeeForm.patchValue({
      employeeID: this.employee.employeeID,
      name: this.employee.name,
      surname: this.employee.surname,
      age: this.employee.age,
      gender: this.employee.gender ? this.genders[0] : this.genders[1],
      department: this.employee.department.name,
      language: this.employee.language.name
    })
  }

  cancel(){
    this.employee = new Employee();
    this.tableMode = true;
    this.editing = false;
  }

  trackByEmpID(index:number,emp?: any): number {
    if (emp.employeeID != null) {
      return emp.employeeID;
    }
  }

  //endregion
}
