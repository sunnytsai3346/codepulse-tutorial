import { Component, OnInit } from '@angular/core';
import { Category } from '../models/category.model';
import { Router } from '@angular/router';
import { CategoryService } from '../services/category.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.css'
})
export class CategoryListComponent implements OnInit {
  categories : Category[] =[];
  getCategoryListSubscription? : Subscription;
  
  constructor(private categoryService :CategoryService, private router:Router){

  }

  ngOnInit():void
  {
    this.getCategoryListSubscription= this.categoryService.getCategoryList()
    .subscribe({
      next: (categories) => {
        this.categories = categories
      },
      error: (response) =>{
        console.log(response)
      },
    })

  }
}
