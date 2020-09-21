import { IDataBoxOffice } from "../dataBoxOffice/dataBoxOffice";

export interface IHall{
    id:string;
    name:string;
    description:string;
    freePlaces:number;
    dataBoxOffice:IDataBoxOffice;
    lastUpdated:Date;
    lastUserId:string;
}