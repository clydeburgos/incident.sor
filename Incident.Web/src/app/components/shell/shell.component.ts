import { ChangeDetectorRef, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { IncidentCardComponent } from '../incidents/incident-card/incident-card.component';
import { IncidentListComponent } from '../incidents/incident-list/incident-list.component';
import { IncidentManagementComponent } from '../incidents/incident-management/incident-management.component';

@Component({
  selector: 'app-shell',
  templateUrl: './shell.component.html',
  styleUrls: ['./shell.component.scss']
})
export class ShellComponent implements OnInit {
  @ViewChild('incidentList') incidentList: IncidentListComponent;
  @ViewChild('incidentCards') incidentCards: IncidentCardComponent;

  viewMode: number = 0; //0 = list, 1 = card
  searchInput: string = '';
  constructor(private modalService: NgbModal, private changeDetection: ChangeDetectorRef) {

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

  search(){
    if(this.viewMode === 0) {
      this.incidentList.getIncidents();
    } else {
      this.incidentCards.getIncidents();
    }
  }

  toggleViewMode(viewMode: number){
    this.viewMode = viewMode;
    this.changeDetection.detectChanges();
  }
}
