import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddPatientComponent } from './add-patient/add-patient.component';

import { DefaultComponent } from './default/default.component';
import { ListComponent } from './list/list.component';
import { VaccinatedComponent } from './vaccinated/vaccinated.component';

const routes: Routes = [
    {
        path: '',
        component: DefaultComponent,        
    },
    {
        path: 'patient-list',
        component: ListComponent,        
    },
    {
        path: 'done-list',
        component: VaccinatedComponent,        
    },
    {
        path: 'add-patient/:id/:slotdate',
        component: AddPatientComponent,        
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class DashboardsRoutingModule {}
