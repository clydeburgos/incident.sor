import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModal, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FilterService, GridAllModule, GridModule, GroupService, PageService, SortService } from '@syncfusion/ej2-angular-grids';
import { ColorPickerModule } from '@syncfusion/ej2-angular-inputs';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { IncidentListComponent } from './components/incidents/incident-list/incident-list.component';
import { IncidentManagementComponent } from './components/incidents/incident-management/incident-management.component';
import { ShellComponent } from './components/shell/shell.component';
import { IncidentCardComponent } from './components/incidents/incident-card/incident-card.component';

@NgModule({
  declarations: [
    AppComponent,
    IncidentListComponent,
    IncidentManagementComponent,
    ShellComponent,
    IncidentCardComponent
  ],
  imports: [
    BrowserModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    GridModule,
    GridAllModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule,
    NgbModule,
    ColorPickerModule 
  ],
  providers: [
    PageService,
    SortService,
    FilterService,
    GroupService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
