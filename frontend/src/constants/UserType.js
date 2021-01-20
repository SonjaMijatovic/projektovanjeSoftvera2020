import strings from "../localization";

const UserType = {
    ADMIN: 'ADMIN',
    DOCTOR: 'DOCTOR',
    PATIENT: 'PATIENT',
    PHARMACYST:'PHARMACYST'
};

export function getUserTypesList() {
    return [
        {
            value: UserType.ADMIN,
            name: 'Admin'
        },
        {
            value: UserType.DOCTOR,
            name: 'Doctor'
        },
        {
            value: UserType.PATIENT,
            name: 'Patient'
        },
        {
            value: UserType.PHARMACYST,
            name: 'Pharmacyst'
        }
    ]
}

export default UserType;