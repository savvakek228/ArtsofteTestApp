import {Department} from "../departments/department";
import {Language} from "../languages/language";

export class Employee{
  constructor(
    public employeeID?: number,
    public name?: string,
    public surname?: string,
    public age?: number,
    public gender?: boolean,
    public department?: Department,
    public language?: Language
  ) {
  }
}
