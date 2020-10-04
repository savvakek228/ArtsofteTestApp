import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {Department} from "../departments/department";
import {Employee} from "../employees/employee";
import {Language} from "../languages/language";


@Injectable()
export class MainAPIService {
  private departmentsURL: string = "/departments";
  private employeesURL: string = "/employees";
  private languagesURL: string = "/languages";

  constructor(private http: HttpClient) {
  }

  //region Departments

  createDepartment(department: Department){
    return this.http.post(this.departmentsURL,department);
  }

  getDepartments(){
    return this.http.get(this.departmentsURL);
  }

  updateDepartment(department: Department){
    return this.http.put(this.departmentsURL,department);
  }

  deleteDepartment(id: number){
    return this.http.delete(this.departmentsURL+"/"+id);
  }

  //endregion

  //region Employees

  createEmployee(emp: Employee){
    return this.http.post(this.employeesURL,emp);
  }

  getEmployees(){
    return this.http.get(this.employeesURL);
  }

  updateEmployee(emp: Employee){
    return this.http.put(this.employeesURL,emp);
  }

  deleteEmployee(id: number){
    return this.http.delete(this.employeesURL+"/"+id);
  }

  //endregion

  //region Languages

  createLanguage(language: Language){
    return this.http.post(this.languagesURL,language);
  }

  getLanguages(){
    return this.http.get(this.languagesURL);
  }

  updateLanguage(language: Language){
    return this.http.put(this.languagesURL,language);
  }

  deleteLanguage(id: number){
    return this.http.delete(this.languagesURL+"/"+id);
  }

  //endregion

}
