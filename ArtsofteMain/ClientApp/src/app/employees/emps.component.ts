import {Component} from "@angular/core";
import {employeeService} from "./employee.service";


@Component({
  selector: 'emps',
  templateUrl: 'emps.component.html',
  providers: [employeeService]

})
export class empsComponent {

}
