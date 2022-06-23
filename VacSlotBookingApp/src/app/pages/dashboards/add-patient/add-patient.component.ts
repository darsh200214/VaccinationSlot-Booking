import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/auth/auth.service';
import { HospitalDetails } from 'src/app/model/hospital-details.model';
import { PatientRecord } from 'src/app/model/patient-record.model';
import { SlotService } from 'src/app/services/slot.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-add-patient',
  templateUrl: './add-patient.component.html',
  styleUrls: ['./add-patient.component.scss']
})
export class AddPatientComponent implements OnInit {
  hospitalSlotMappingId: number;
  patientAdmitForm: FormGroup;
  hospitalList: HospitalDetails[] = [];
  submitted = false;
  bedType: string;
  hospitalName: string;
  slotdate: string;
  constructor(private formBuilder: FormBuilder, private route: ActivatedRoute,private router:Router,
    private authservice: AuthService, private slotService:SlotService) { }

  ngOnInit() {
    this.hospitalSlotMappingId = Number(this.route.snapshot.paramMap.get('id'));
    this.slotdate=this.route.snapshot.paramMap.get('slotdate');
    this.patientAdmitForm = this.formBuilder.group({
      hospitalSlotMappingId: [this.hospitalSlotMappingId, Validators.required],
      slotDate:[this.slotdate, Validators.required],
      patientName: ['', [Validators.required, Validators.maxLength(100), Validators.minLength(3)]],
      gender: ['', Validators.required],
      age: ['', Validators.required],
      address: ['', Validators.required],
      description: [''],
      contactNo: ['', [Validators.required, Validators.pattern('[0-9]+'), Validators.minLength(10), Validators.maxLength(10)]],
    });
  }
  get f() { return this.patientAdmitForm.controls; }
  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.patientAdmitForm.invalid) {
      return;
    } else {
      Swal.fire({
        title: 'Processing!',
        allowOutsideClick: false
      });
      Swal.showLoading();
      let patientRecordObj: PatientRecord = Object.assign({}, this.patientAdmitForm.value);
      patientRecordObj.createdBy= Number(this.authservice.getUserId());
      this.slotService.addPatientRecord(patientRecordObj).subscribe(success => {
        Swal.close();
        if (success > 0) {
          this.patientAdmitForm.reset();
          this.submitted = false;
          Swal.fire("Slot booked successfully").then(data => { this.router.navigate(['/dashboard/patient-list']); });
        }
        else {
          Swal.fire("Slot booking failed").then(data => { this.router.navigate(['/dashboard/patient-list']); });
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
  }
  goBack() {
    window.history.back();
  }
}
