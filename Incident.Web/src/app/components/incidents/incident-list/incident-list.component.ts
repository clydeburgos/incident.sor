import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { DataStateChangeEventArgs, GridComponent, PageSettingsModel } from '@syncfusion/ej2-angular-grids';
import { BehaviorSubject, tap } from 'rxjs';
import { IncidentDto } from 'src/app/dtos/incident.dto';
import { IncidentService } from 'src/app/services/incident.service';

@Component({
  selector: 'app-incident-list',
  templateUrl: './incident-list.component.html',
  styleUrls: ['./incident-list.component.scss']
})
export class IncidentListComponent implements OnInit{
  public isFetching: boolean = false;
  public incidents: any[] = [];
  public filterOptions: any;
  public searchKeyword: string = '';
  public state : DataStateChangeEventArgs = { skip: 0, take: 10, search: [], sorted: [] };

  public orderBy: string = 'systemid';
  public sortDir: string = 'asc';

  public selectedRowData: any;
  @ViewChild('incidentGrid', { static : false }) public grid: GridComponent;
  @Input() searchInput: string;
  @Output() showDetailIncidentEmit = new EventEmitter();
  
  public pageSettings: PageSettingsModel = { pageSize: 20, pageSizes: true };
  public format = { type:'date', format:'dd/MM/yyyy' } 
  constructor(private incidentService: IncidentService) {
    
  }
  ngOnInit() {
    this.filterOptions = {
      type: 'Menu'
    }
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

  rowSelected(args : any){
    this.selectedRowData = args.data;
  }

  viewDetails(data: any){
    this.showDetailIncidentEmit.emit(data);
  }

  delete(data: any){
    this.isFetching = true;
    this.selectedRowData = data; // set the current row
    this.grid.selectRow(Number(data.index)); //data contains the index, so automatically pick the index for the selectRow

    if(!this.selectedRowData){
      return;
    }

    this.grid.deleteRecord();
    this.grid.refresh();

    this.incidentService.delete(data.systemId).subscribe((res) => {
      this.getIncidents();
    });
  }
}
