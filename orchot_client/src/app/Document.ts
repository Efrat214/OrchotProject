
export class Document{
    constructor
    (
        public id: number,
        public documentName: string,  
        public organization: string,  
        public businessUnit: string,  
        public department: string,  
        public createBy: string,  
        public createDate: Date,
        public effectiveDate: Date,  
        public alertActive:boolean,
        public lastAlert :Date,
        public mailAddress: string,
        public expirationDate :Date, 
        public numDaysExp: number,
        public docType: string,
        public deleted: boolean,
        public docLink: string
    ){}  
}
