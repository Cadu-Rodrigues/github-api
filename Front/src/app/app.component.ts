import { Component, OnInit } from '@angular/core';
import { RepositoriesService } from './repositories.service';
import { Language } from './APIResponse';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'GithubFront';
  response: Array<Language> | null = null;
  constructor(private service: RepositoriesService) { }
  ngOnInit(): void {
    this.service.getRepositories().subscribe(response => {
      this.response = response;
    })

  }
}
