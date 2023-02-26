import { Component, Input, OnInit } from '@angular/core';
import { IncidentDto } from 'src/app/dtos/incident.dto';
import { IncidentService } from 'src/app/services/incident.service';

@Component({
  selector: 'app-incident-card',
  templateUrl: './incident-card.component.html',
  styleUrls: ['./incident-card.component.scss']
})
export class IncidentCardComponent implements OnInit{
  isFetching: boolean = false;
  @Input() searchInput: string;
  incidents:IncidentDto[] = []
  constructor(private incidentService: IncidentService) {

  }

  ngOnInit(): void {
    this.getIncidents();
  }
  
  getIncidents(){
    this.isFetching = true;
    const service = this.searchInput ? this.incidentService.getMany(this.searchInput) : this.incidentService.getAll();
    service.subscribe((data) => {
      this.incidents = data;
    }, (error: any) => {
      console.log(error);
    }, () => {
      this.isFetching = false;
    });
  }
}
