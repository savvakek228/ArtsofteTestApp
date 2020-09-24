import {Department} from "./department";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";

@Injectable()
export class DepartmentsService {
  private url = "/departments";

  constructor(private http: HttpClient) {
  }

  createDepartment(department: Department){
    return this.http.post(this.url,department);
  }

  getDepartments(){
    return this.http.get(this.url);
  }

  getDepartment(id: number){
    return this.http.get(this.url+"/"+id);
  }

  updateDepartment(department: Department){
    return this.http.put(this.url,department);
  }

  deleteDepartment(id: number){
    return this.http.delete(this.url+"/"+id);
  }
}
