# IncidentWeb

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 15.1.6.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.


## Database

Please check Incident.tbl and execute the script to generate database

## Deployed copy
Please visit : https://polite-moss-0b3d0d110.2.azurestaticapps.net/

## Components
The application is deployed to Azure :

API - AppService

SPA - Static Web Apps

DB - Azure MSSQL

CI/CD - Azure and Git Actions

## What's not included?
Docker has only been added to the API but not on the UI part

The right pinned form, if there was enough time, would have done some more CSS stuff, right now the dialog is centered

## What's included?
CRUD functionality

UI Aesthetics

View mode support (Tile / List)

Deployed on Cloud (additional)

## If give more time, what could have I improved?

Currently, it doesnt track the person who's updating the records, ideally, it would have been good to save the identity, via Asp.net Identity, and have
an authentication process to save the updatedBy record.

That said, could have added a security layer, securing the API by token.

Also, add logging properly.

Additional Code Clean up
