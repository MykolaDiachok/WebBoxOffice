import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ISchedule } from '../Data/schedule/schedule';
import { Iresponse } from '../Data/response/response';
import { IHall } from '../Data/hall/hall';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public schedules: ISchedule[];
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Iresponse>(baseUrl + 'api/GL/Schedule').subscribe(result => {
      this.schedules = result.data;
      this.schedules.forEach(element => {
        http.get<Iresponse>(baseUrl + 'api/GL/hall/' + element.hallId).subscribe(
          resultHall => {
            element.hall = resultHall.data;
          }, error => console.error(error));

        http.get<Iresponse>(baseUrl + 'api/GL/Spectacle/' + element.spectacleId).subscribe(
          resultSpectacle => {
            element.spectacle = resultSpectacle.data;
          }, error => console.error(error));
      }
      );


    }, error => console.error(error));
  }
}





