import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminAddPostComponent } from './Admin/admin-add-post/admin-add-post.component';
import { AdminPostsComponent } from './Admin/admin-posts/admin-posts.component';
import { AdminViewPostComponent } from './Admin/admin-view-post/admin-view-post.component';

const routes: Routes = [
  {
    path: '',
    component: AdminPostsComponent
  },
  {
    path: 'admin/posts/add',
    component :AdminAddPostComponent
  },
  {
    path: 'admin/posts/:id',
    component : AdminViewPostComponent
  }
 

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
