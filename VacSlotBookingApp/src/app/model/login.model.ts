import { Log } from './log.model';

export class Login extends Log{
    id:number;
    userName:string;
    password:string;
    userId:number;
    displayName:string;
    isBlocked:boolean;
}