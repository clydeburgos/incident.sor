import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { IncidentListComponent } from './components/incidents/incident-list/incident-list.component';
import { ShellComponent } from './components/shell/shell.component';

const routes: Routes = [
  { path: '', component: ShellComponent, pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
