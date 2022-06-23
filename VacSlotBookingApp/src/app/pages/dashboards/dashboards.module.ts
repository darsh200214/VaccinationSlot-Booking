import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { DashboardsRoutingModule } from './dashboards-routing.module';
import { UIModule } from '../../shared/ui/ui.module';

import { NgbDropdownModule, NgbTooltipModule, NgbNavModule, NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';
import { PerfectScrollbarModule } from 'ngx-perfect-scrollbar';

import { DefaultComponent } from './default/default.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ListComponent } from './list/list.component';
import { AddPatientComponent } from './add-patient/add-patient.component';
import { VaccinatedComponent } from './vaccinated/vaccinated.component';
@NgModule({
  declarations: [DefaultComponent, ListComponent, AddPatientComponent, VaccinatedComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    DashboardsRoutingModule,
    UIModule,
    NgbDropdownModule,
    NgbTooltipModule,
    NgbNavModule,
    NgbAlertModule,
    PerfectScrollbarModule,
    SharedModule
  ]
})
export class DashboardsModule { }
