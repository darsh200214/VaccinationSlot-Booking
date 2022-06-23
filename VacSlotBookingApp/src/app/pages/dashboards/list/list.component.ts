import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/auth/auth.service';
import { HospitalDetails } from 'src/app/model/hospital-details.model';
import { PatientRecord } from 'src/app/model/patient-record.model';
import { SlotService } from 'src/app/services/slot.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  hospitalList: HospitalDetails[] = [];
  slotList: HospitalDetails[] = [];
  patientList: PatientRecord[] = [];
  noRecordsFound: boolean = false;
  userId: number;
  hospitalId: number = 0;
  slotId: number = 0;
  slotDate: Date;
  curDate: Date;
  constructor(private slotService: SlotService, private authservice: AuthService, private router: Router) { }

  ngOnInit(): void {
    this.userId = Number(this.authservice.getUserId());
    this.curDate = new Date();
    this.getHospitals();
    this.getSlots();
    this.getAllPatientRecords();
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
  getAllPatientRecords() {
    if (this.userId == 1) {
      if (this.slotDate != undefined) {
        this.slotService.getPatientRecordsByFilter(this.hospitalId, this.slotId, this.slotDate).subscribe(results => {
          this.patientList = results.filter(x => x.isActive === true);
          if (this.patientList.length <= 0) {
            this.noRecordsFound = true;
          }
          Swal.close();
        },
          (error) => {
            //this.loader.hide();
            Swal.close();
          });
      } else {
        this.slotService.getAllPatientRecords().subscribe(results => {
          this.patientList = results.filter(x => x.isActive === true);;
          if (this.patientList.length <= 0) {
            this.noRecordsFound = true;
          }
          Swal.close();
        },
          (error) => {
            //this.loader.hide();
            Swal.close();
          });
      }
    } else {
      this.slotService.getSlotBookingsById(this.userId).subscribe(results => {
        this.patientList = results.filter(x => x.isActive === true);;
        if (this.patientList.length <= 0) {
          this.noRecordsFound = true;
        }
        Swal.close();
      },
        (error) => {
          //this.loader.hide();
          Swal.close();
        });
    }
  }
  onDischarge(id) {
    Swal.fire({
      title: 'Please confirm!',
      confirmButtonText: 'Ok'
    }).then(result => {
      if (result.value) {
        Swal.fire({
          title: 'Processing!',
          allowOutsideClick: false
        });
        Swal.showLoading();
        var patientRecordObj = new PatientRecord();
        patientRecordObj.id = id;
        patientRecordObj.createdBy = Number(this.authservice.getUserId());
        this.slotService.addPatientRecord(patientRecordObj).subscribe(success => {
          Swal.close();
          if (success > 0) {
            Swal.fire("Vaccinated successfully").then(data => { this.getAllPatientRecords(); });
          }
          else {
            Swal.fire("Patient discharge failed").then(data => { this.getAllPatientRecords(); });
          }
        },
          error => {
            Swal.close();
            Swal.fire(
              'Error',
              error,
              'error'
            );
          });
      }
    });

  }
}
