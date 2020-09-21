import { IHall } from "../hall/hall";
import { ISpectacle } from "../spectacle/spectacle";

export interface ISchedule {
    id: string;
    Name: string;
    enabled: boolean;
    hall: IHall;
    hallId: string;
    spectacle: ISpectacle;
    spectacleId: string;
    startTime: Date;
    endTime: Date;
    description: string;
    lastUpdated: Date;
    lastUserId: string;
}