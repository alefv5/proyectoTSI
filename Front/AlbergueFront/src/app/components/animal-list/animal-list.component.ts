import { Component, OnInit,Input } from '@angular/core';
import {Dog} from '../../models/Dog'

@Component({
  selector: 'app-animal-list',
  templateUrl: './animal-list.component.html',
  styleUrls: ['./animal-list.component.css']
})
export class AnimalListComponent implements OnInit {
  @Input() dog!: Dog;
  ngOnInit(): void {
  }

}
