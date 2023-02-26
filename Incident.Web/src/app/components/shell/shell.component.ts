import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IncidentListComponent } from '../incidents/incident-list/incident-list.component';
import { IncidentManagementComponent } from '../incidents/incident-management/incident-management.component';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss']
})
export class ShellComponent implements OnInit {
  @ViewChild('incidentList') incidentList: IncidentListComponent;
  constructor(private modalService: NgbModal) {

  }
  ngOnInit() {
  }

  open(data?: any) {
		
    const modalRef = this.modalService.open(IncidentManagementComponent);
    modalRef.componentInstance.injectedIncidentData = data;
    modalRef.closed.subscribe((type) => {
      if(type === 1) {
        this.incidentList.ngOnInit();
      }
    })
	}

  showDetailIncidentEmit(data: any) {
    if(data) {
      this.open(data);
    } 
  }
}
