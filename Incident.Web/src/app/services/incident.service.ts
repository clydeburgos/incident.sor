import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { environment } from "src/environments/environment";
import { INCIDENT_ALL_URL, INCIDENT_CREATE_URL, INCIDENT_DELETE_URL, INCIDENT_GET_URL, INCIDENT_UPDATE_URL } from "../constants/incident.endpoints";
import { IncidentDto } from "../dtos/incident.dto";

@Injectable({
  providedIn: 'root'
})
export class IncidentService {

  constructor(private http: HttpClient){
      
  }

  getAll(){
    return this.http.get<any>(`${ environment.apiUrl }${ INCIDENT_ALL_URL }`);
  }

  getMany(filter: string){
    return this.http.get<any>(`${ environment.apiUrl }${ INCIDENT_ALL_URL }?search=${filter}`);
  }

  get(id: string): Observable<IncidentDto> {
    return this.http.get<IncidentDto>(`${ environment.apiUrl }${ INCIDENT_GET_URL }/${ id }`);
  }

  create(payload: IncidentDto) {
    return this.http.post<any>(`${ environment.apiUrl }${ INCIDENT_CREATE_URL }`, payload);
  }

  update(id : number, payload: IncidentDto){
    return this.http.put<any>(`${ environment.apiUrl }${ INCIDENT_UPDATE_URL }/${id}`, payload);
  }

  delete(id: string){
    return this.http.delete<any>(`${ environment.apiUrl }${ INCIDENT_DELETE_URL }/${ id }`, {});
  }
}
