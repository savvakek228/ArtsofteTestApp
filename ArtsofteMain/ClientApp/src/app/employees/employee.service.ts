import {Employee} from "./employee";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";

@Injectable()
export class employeeService{

  private url = "/employees"

  constructor(private http: HttpClient) {
  }

  createEmployee(emp: Employee){
    return this.http.post(this.url,emp);
  }

  getEmployees(){
    return this.http.get(this.url);
  }

  getEmployee(id: number){
    return this.http.get(this.url+"/"+id);
  }

  updateEmployee(emp: Employee){
    return this.http.put(this.url,emp);
  }

  deleteEmployee(id: number){
    return this.http.delete(this.url+"/"+id);
  }
}
