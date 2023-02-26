import { Component, Input, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { IncidentDto } from 'src/app/dtos/incident.dto';
import { IncidentService } from 'src/app/services/incident.service';

@Component({
  selector: 'app-incident-management',
  templateUrl: './incident-management.component.html',
  styleUrls: ['./incident-management.component.scss']
})
export class IncidentManagementComponent implements OnInit {
  isSaving: boolean = false;
  method: number = 0; //0 create, 1 update
  @Input() injectedIncidentData : IncidentDto;
  public incidentDto : IncidentDto = new IncidentDto(0, '', '#e1e1e1', '', '', '');

  constructor(private incidentService: IncidentService, public activeModal: NgbActiveModal) {
    
  }

  ngOnInit(): void {
    if(this.injectedIncidentData) {
      this.method = 1;
      this.incidentDto = this.injectedIncidentData;
    }
  }

  save(){
    this.isSaving = true;
    const service = this.method === 1 ? this.incidentService.update(this.incidentDto.systemId, this.incidentDto) : this.incidentService.create(this.incidentDto);
    service.subscribe((response) => {
      this.activeModal.close(1); //@TODO : create ENUM
    }, (error: any) => {
      console.log(error);
      this.activeModal.close(0); //@TODO : create ENUM
    }, () => {
      this.isSaving = false;
    });
    
  }
}
