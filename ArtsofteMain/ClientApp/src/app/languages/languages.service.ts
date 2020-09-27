import {Language} from "./language";
import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";

@Injectable()
export class languagesService{
  private url = 'languages';

  constructor(private http: HttpClient) {
  }

  createLanguage(language: Language){
    return this.http.post(this.url,language);
  }

  getLanguages(){
    return this.http.get(this.url);
  }

  getLanguage(id: number){
    return this.http.get(this.url+"/"+id);
  }

  updateLanguage(language: Language){
    return this.http.put(this.url,language);
  }

  deleteLanguage(id: number){
    return this.http.delete(this.url+"/"+id);
  }
}
