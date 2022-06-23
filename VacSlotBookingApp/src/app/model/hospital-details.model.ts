import { Log } from "./log.model";

export class HospitalDetails extends Log {
    id:number;
    hospitalName:string;
    address :string;
    contactNo:string;
    slotTime:string;
    perSlotCount :number;
    filledCount :number;
}