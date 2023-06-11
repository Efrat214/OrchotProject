export class User{
    constructor(
        public id: number,
        public fullName: string,
        public userName: string,
        public password: string,
        public mailAddress: string,
        public department: string,
        public mobile: string,
        public admin: boolean,
        public active: boolean 
    ){}
}