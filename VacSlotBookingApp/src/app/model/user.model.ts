import { Log } from './log.model';

export class User extends Log {
    id: number;
    userCode: string;
    roleId: number;
    name: string;
    addressLine1: string;
    addressLine2: string;
    landmark: string;
    city: string;
    talukId: number;
    districtId: number;
    stateId: number;
    pincode: string;
    email: string;
    mobileNumber: string;
    telephoneNumber: string;
    role: string;
    state: string;
    district: string;
    taluk: string;
    departmentName: string;
    roleName: string;
    profilePic: string;
    departmentId: number;
    balanceAmount: number;


}

export class UserFilter {
    pageIndex: number;
    pageSize: number;
    search: string;
    sortBy: string;
    sortOrder: string;
    status: boolean;
}
export class SubscriberFilter {
    pageIndex: number;
    pageSize: number;
    stateId: number;
    districtId: number;
    talukId: number
    search: string;
    sortBy: string;
    sortOrder: string;
    status: boolean;
    createdBy: number;
}
export class UserPageInfo {
    pageIndex: number;
    pageItems: User[]
}

export class UserModelById extends UserFilter {
    roleID?: number;
}

export class ZMIdModel extends UserFilter {
    ZMId?: number;
}
export class DMIdModel extends UserFilter {
    DMId?: number;
}
export class EXCIdModel extends UserFilter {
    EXCId?: number;
}