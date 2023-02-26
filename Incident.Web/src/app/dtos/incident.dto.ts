export class IncidentDto {
    constructor(systemId: number, id: string, color: string, name: string, description: string, updatedBy: string) {
        this.systemId = systemId;
        this.id = id;
        this.color = color;
        this.name = name;
        this.description = description;
        this.updatedBy = updatedBy;
    }
    public systemId: number;
    public id: string;
    public color: string;
    public name: string;
    public description: string;
    public updatedBy: string;
}
