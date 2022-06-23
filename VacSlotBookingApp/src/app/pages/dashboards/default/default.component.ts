import { Component, Input, OnInit } from '@angular/core';
import { AuthService } from 'src/app/auth/auth.service';
import { PatientRecord } from 'src/app/model/patient-record.model';
import { SlotService } from 'src/app/services/slot.service';
import Swal from 'sweetalert2';
import * as $ from 'jquery';
import { Router } from '@angular/router';
import { HospitalDetails } from 'src/app/model/hospital-details.model';
@Component({
  selector: 'app-default',
  templateUrl: './default.component.html',
  styleUrls: ['./default.component.scss']
})
export class DefaultComponent implements OnInit {
  hospitalList: HospitalDetails[] = [];
  hospitalSlotList: HospitalDetails[] = [];
  slotList: HospitalDetails[] = [];
  noRecordsFound: boolean = false;
  userId: number;
  hospitalId: number = 0;
  slotId: number = 0;
  slotDate: Date;
  curDate: Date;
  constructor(private router: Router, private slotService: SlotService, private authservice: AuthService) { }

  ngOnInit(): void {
    this.userId = Number(this.authservice.getUserId());
    this.getHospitals();
    this.getSlots();
    this.curDate = new Date();
  }
  getHospitals() {
    this.slotService.getAllHospitals().subscribe(results => {
      this.hospitalList = results;
      if (this.hospitalList.length <= 0) {
        this.noRecordsFound = true;
      }
      Swal.close();
    },
      (error) => {
        //this.loader.hide();
        Swal.close();
      });
  }
  getSlots() {
    this.slotService.getAllSlots().subscribe(results => {
      this.slotList = results;
      if (this.hospitalList.length <= 0) {
        this.noRecordsFound = true;
      }
      Swal.close();
    },
      (error) => {
        //this.loader.hide();
        Swal.close();
      });
  }
  getSlotList() {
    if (this.slotDate != undefined) {
      this.slotService.getDashboardDetails(this.hospitalId, this.slotId, this.slotDate).subscribe(results => {
        this.hospitalSlotList = results;
        if (this.hospitalSlotList.length <= 0) {
          this.noRecordsFound = true;
        }
        Swal.close();
      },
        (error) => {
          //this.loader.hide();
          Swal.close();
        });
    }
    else{
      Swal.fire('Please select a valid date.');
    }
  }
  next() {
    if ($('input[name="package"]:checked').val() != undefined) {
      var index = $('input[name="package"]:checked').val();
      if (this.hospitalSlotList[index].perSlotCount == this.hospitalSlotList[index].filledCount) {
        Swal.fire('Slot is full.');
      }
      else {
        this.router.navigate(['/add-patient', this.hospitalSlotList[index].id,this.slotDate]);
      }
    }
    else {
      Swal.fire('Please select any slot to proceed.');
    }
  }
}
