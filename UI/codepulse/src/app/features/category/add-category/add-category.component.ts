import { Component } from '@angular/core';
import { AddCategoryRequest } from '../models/add-category-request.model';
import { Subscription } from 'rxjs';
import { CategoryService } from '../services/category.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrl: './add-category.component.css'
})
export class AddCategoryComponent {
  model : AddCategoryRequest ;
  private addCategorySubscription? : Subscription;
  constructor(private categoryService:CategoryService){
    this.model ={
      name:"",
      urlHandle:""
    };

  }
  
  onFormSubmit(){
    this.addCategorySubscription= this.categoryService.addCategory(this.model)
    .subscribe({
      next:(response)=>{
        console.log('successful');
      },
      error:(error)=>{
        console.log(error);
      }
    })


  }

}
