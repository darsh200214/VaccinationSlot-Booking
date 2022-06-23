import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HospitalDetails } from '../model/hospital-details.model';
import { PatientRecord } from '../model/patient-record.model';

@Injectable({
  providedIn: 'root'
})
export class SlotService {

  constructor(private http: HttpClient) { }
  addPatientRecord(patientRecord:PatientRecord) {
    return this.http.post<number>(environment.apiBaseUrl + "Slot/AddPatientRecord",patientRecord);
  }
  getAllPatientRecords() {
    return this.http.get<PatientRecord[]>(environment.apiBaseUrl + "Slot/GetAllPatientRecords");
  } 
  getDashboardDetails(HospitalId:number,SlotId:number,SlotDate:Date) {
    return this.http.get<HospitalDetails[]>(environment.apiBaseUrl + "Slot/GetDashboardDetails/"+HospitalId+"/"+SlotId+"/"+SlotDate);
  } 
  getPatientRecordsByFilter(HospitalId:number,SlotId:number,SlotDate:Date) {
    return this.http.get<PatientRecord[]>(environment.apiBaseUrl + "Slot/GetPatientRecordsByFilter/"+HospitalId+"/"+SlotId+"/"+SlotDate);
  } 
  getAllHospitals() {
    return this.http.get<HospitalDetails[]>(environment.apiBaseUrl + "Slot/GetAllHospitals");
  } 
  getAllSlots() {
    return this.http.get<HospitalDetails[]>(environment.apiBaseUrl + "Slot/GetAllSlots");
  } 
  getSlotBookingsById(CreatedBy:number) {
    return this.http.get<PatientRecord[]>(environment.apiBaseUrl + "Slot/GetSlotBookingsById/"+CreatedBy);
  } 
}
