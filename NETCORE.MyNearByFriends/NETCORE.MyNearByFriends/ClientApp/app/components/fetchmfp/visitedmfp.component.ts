import { Component } from '@angular/core';
import { DialogComponent, DialogService } from "ng2-bootstrap-modal";
import { MFPModel } from '../models/mfp.model';
import { MVFPModel } from '../models/mvfp.model';



@Component({  
    selector: 'viewvisitedmfp',
    templateUrl: './visitedmfp.component.html',
   
})
export class MVFPComponent extends DialogComponent<MVFPModel, boolean> implements MVFPModel {
   
  title: string  ='';
  message: string ='';
    myVisitedFriendPositionColl: MFPModel[] = [] ;

    constructor(dialogService: DialogService) {
    super(dialogService);
  }
  confirm() {
    // we set dialog result as true on click on confirm button, 
    // then we can get dialog result from caller code 
    this.result = true;
    this.close();
  }
}