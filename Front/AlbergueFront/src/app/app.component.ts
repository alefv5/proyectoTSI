import { Component } from '@angular/core';
import {Dog} from './models/Dog';
import {DogService} from './Services/dog-service.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
    title: string= "San roque";
}
