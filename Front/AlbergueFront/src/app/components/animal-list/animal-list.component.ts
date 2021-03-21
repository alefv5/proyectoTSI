import { Component, OnInit,Input } from '@angular/core';
import {Dog} from '../../models/Dog'
import {DogService} from '../../Services/dog-service.service'

@Component({
  selector: 'app-animal-list',
  templateUrl: './animal-list.component.html',
  styleUrls: ['./animal-list.component.css']
})
export class AnimalListComponent implements OnInit {
  dogs!:Dog[];
  constructor(private dogService:DogService){}
  ngOnInit(): void {
    if(this.dogService.getDogs().subscribe(dog=>{
      debugger;
      this.dogs=dog;
      console.log(dog);
    })==null)
    {
      alert("No se encontro");
    }
  }  
}
