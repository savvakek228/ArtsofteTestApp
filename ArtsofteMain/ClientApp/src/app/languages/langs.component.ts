import {Component} from "@angular/core";
import {languagesService} from "./languages.service";
import {Language} from "./language";

@Component({
  selector: "lang",
  templateUrl: "/langs.component.html",
  providers: [languagesService]
})
export class LangsComponent {

}
