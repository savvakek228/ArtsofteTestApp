import {Component, OnInit, Optional, ChangeDetectorRef} from "@angular/core";
import {languagesService} from "./languages.service";
import {Language} from "./language";

@Component({
  selector: "lang",
  templateUrl: "langs.component.html",
  providers: [languagesService]
})
export class langsComponent implements OnInit{
  language: Language = new Language();
  languages: Language[];
  tableMode: boolean = true;

  constructor(private languagesService: languagesService) {
  }

  ngOnInit(): void {
    this.loadLanguages();
  }

  loadLanguages(){
    this.languagesService.getLanguages().subscribe((data: Language[])=>this.languages=data);
  }

  submit(){
    if(this.language.languageID == null) {
      this.languagesService.createLanguage(this.language).subscribe(()=>this.loadLanguages());
    }
    else {
      this.languagesService.updateLanguage(this.language).subscribe(()=>this.loadLanguages());
    }
    this.cancel();
  }

  delete(l: Language){
    this.languagesService.deleteLanguage(l.languageID).subscribe(()=>this.loadLanguages());
  }

  add(){
    this.cancel();
    this.tableMode = false;
  }

  editLanguage(l: Language){
    this.language = l;
  }

  cancel(){
    this.language = new Language();
    this.tableMode = true;
  }

  trackByLangID(index:number,lang?: any): number{
    if (lang.languageID != null) {
      return lang.languageID;
    }
  }
}
