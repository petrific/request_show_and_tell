import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public things: Thing[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Thing[]>(baseUrl + 'thing').subscribe(result => {
      this.things = result;
    }, error => console.error(error));
  }
}

interface Thing {
  id: string;
  active: boolean;
}
