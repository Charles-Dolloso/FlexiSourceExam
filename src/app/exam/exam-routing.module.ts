import { Routes, RouterModule } from '@angular/router';
import { ExamFormComponent } from './exam-form/exam-form.component';

export const examRoutesList: Routes = [
    {
        path: '', // default route
        component: ExamFormComponent,
    }
];

export const examRoutes = RouterModule.forChild(examRoutesList);
