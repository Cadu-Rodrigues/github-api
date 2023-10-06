import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from'../environments/environment';
import { Language } from './APIResponse';

@Injectable({
  providedIn: 'root'
})
export class RepositoriesService {

  constructor(private http: HttpClient) { }

  getRepositories(){
    return this.http.get<Array<Language>>(`${environment.apiUrl}/Repositories`);
  }
}
