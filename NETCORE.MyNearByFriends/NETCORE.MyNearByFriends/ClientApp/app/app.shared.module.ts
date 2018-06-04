import { NgModule } from '@angular/core';


import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchMFPComponent } from './components/fetchmfp/fetchmfp.component'

import { BootstrapModalModule } from 'ng2-bootstrap-modal';
import { MFPService } from './services/mfp.service';
import { MVFPComponent } from './components/fetchmfp/visitedmfp.component';
import { AuthService } from './services/auth.service';

import { AuthComponent } from './components/auth/auth.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        AuthComponent,
        FetchMFPComponent,
        HomeComponent,
        MVFPComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        BootstrapModalModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'auth', component: AuthComponent },
            { path: 'home', component: HomeComponent },
            { path: 'list-mfp', component: FetchMFPComponent },
            { path: '**', redirectTo: 'home' },

        ])
    ],
    exports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [MFPService, AuthService],
    entryComponents: [
        MVFPComponent
    ],
    bootstrap: [AppComponent]
})
export class AppModuleShared {
}
