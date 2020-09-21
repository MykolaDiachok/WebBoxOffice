import { ISpectacle } from "./spectacle";

export interface ISpectacleLinks{
    id:string;
    name:string;
    spectacle:ISpectacle;
    url:string;
    contentUrl:string;
    lastUpdated:Date;
    lastUserId:string;
}