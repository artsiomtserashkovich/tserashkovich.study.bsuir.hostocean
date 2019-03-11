import { string } from "prop-types";


export class LaboratoryWork {
    public id: string | undefined;
    public title: string | undefined;
    public date: Date = new Date();
    public description: string | undefined;
    public subGroup: LaboratoryWorkSubGroup = LaboratoryWorkSubGroup.Common;
    public groupId: number | undefined;
}

export enum LaboratoryWorkSubGroup {
    "Common" = 0,
    "First" = 1,
    "Second" = 2,
}