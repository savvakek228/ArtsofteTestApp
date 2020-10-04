import {Component, OnDestroy, OnInit} from "@angular/core";
import {Language} from "./language";
import {MainAPIService} from "../root/MainAPIService";
import {Subscription} from "rxjs";

@Component({
  selector: "lang",
  templateUrl: "langs.component.html",
  providers: [MainAPIService]
})
export class langsComponent implements OnInit, OnDestroy{
  language: Language = new Language();
  languages: Language[];
  subscriptions: Subscription[] = [];
  tableMode: boolean = true;

  constructor(private apiService: MainAPIService) {
  }

  ngOnInit(): void {
    this.loadLanguages();
  }

  ngOnDestroy(): void {
    this.subscriptions.forEach((sub)=>sub.unsubscribe);
  }

  //region Working with View

  loadLanguages(): void{
    this.subscriptions.push(this.apiService.getLanguages().subscribe((data: Language[])=>this.languages=data));
  }

  submit(): void{
    if(this.language.languageID == null) {
      this.subscriptions.push(this.apiService.createLanguage(this.language).subscribe(()=>this.loadLanguages()));
    }
    else {
      this.subscriptions.push(this.apiService.updateLanguage(this.language).subscribe());
    }
    this.cancel();
  }

  delete(l: Language): void{
    this.subscriptions.push(this.apiService.deleteLanguage(l.languageID).subscribe(()=>this.languages.splice(this.languages.indexOf(l),1)));
  }

  add(): void{
    this.language = new Language();
    this.tableMode = false;
  }

  editLanguage(l: Language): void{
    this.language = l;
  }

  cancel(): void{
    this.language = new Language();
    this.tableMode = true;
  }

  trackByLangID(index:number,lang?: any): number{
    if (lang.languageID != null) {
      return lang.languageID;
    }
  }

  //endregion
}
