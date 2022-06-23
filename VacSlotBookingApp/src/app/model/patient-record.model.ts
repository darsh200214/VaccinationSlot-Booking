import { Log } from "./log.model";

export class PatientRecord extends Log {
    id:number;
    hospitalSlotMappingId:number;
    patientName :string;
    gender :string;
    age :number;
    address :string;
    contactNo:string;
    description:string;

    hospitalName :string;
    slotTime :string;
    slotDate:Date;

}