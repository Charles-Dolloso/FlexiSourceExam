import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
  {
    path: 'exam',
    loadChildren: () => import('./exam/exam.module').then(m => m.ExamModule)
  },
  {
    path: '**',
    redirectTo: 'exam'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
