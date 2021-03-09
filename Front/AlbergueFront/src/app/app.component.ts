import { Component } from '@angular/core';
import {Dog} from './models/Dog';
import {DogService} from './Services/dog-service.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  // dogs: Dog[] = [
  //   new Dog("Ch1", "Cachuchin", 48),
  //   new Dog("R1", "Rover", 3),
  //   new Dog("B1", "Blanco", 18)
  // ];
  dogs!:Dog[];
  constructor(private dogService:DogService){}

  ngOnInit(): void {
    if(this.dogService.getDogs().subscribe(dog=>{
      this.dogs=dog;
      console.log(dog);
    })==null)
    {
      alert("No se encontro");
    }
  }
  onSkill()
  {

  }
  onFame()
  {
  }
}
