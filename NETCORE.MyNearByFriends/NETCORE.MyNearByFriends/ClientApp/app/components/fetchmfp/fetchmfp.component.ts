import { Component, Inject, ContentChild, ViewEncapsulation } from '@angular/core';
import { Http, Headers } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { MFPService } from '../../services/mfp.service'
import { MFPModel } from '../models/mfp.model';
import { DialogService } from 'ng2-bootstrap-modal';
import { MVFPComponent } from './visitedmfp.component';
import { AuthService } from '../../services/auth.service';






@Component({
    selector: 'fetchmfp',
    templateUrl: './fetchmfp.component.html',
})

export class FetchMFPComponent {
    public myFriendPositionList: MFPModel[] | undefined;
    isLogin = false;
    constructor(public http: Http, private _router: Router, private _service: MFPService, private authService: AuthService, private dialogService: DialogService) {
       
    }

    ngOnInit(): void {
        this.isLogin = this.authService.checkLogin();
        if (this.isLogin) {
            this.getMyFriendsPositions();
        }

    }

    getMyFriendsPositions() {
        this.isLogin = this.authService.checkLogin();
        if (this.isLogin) {
            this._service.getMyFriendsPositions().subscribe(
                data => {
                    var resultArray: Array<MFPModel> = [];

                    data.forEach(i => {
                        let mfp = new MFPModel();
                        mfp.id = + i.myFriendPositionId;
                        mfp.name = i.friendName;
                        mfp.latitude = i.latitude;
                        mfp.longitude = i.longitude;
                        resultArray.push(mfp);
                    });
                    this.myFriendPositionList = resultArray;
                }
            );
        }
    }

    showNearFriends(myVisitedfriendPosition) {
        this._service.getTop3FriendsNearByVisitedFriend(myVisitedfriendPosition.id).subscribe(data => {
            var resultArray: Array<MFPModel> = [];
            data.forEach(i => {
                let mfp = new MFPModel();
                mfp.id = + i.myFriendPositionID;
                mfp.name = i.friendName;
                mfp.latitude = i.latitude;
                mfp.longitude = i.longitude;
                mfp.calc = i.calc;
                resultArray.push(mfp);
            });
            let disposable = this.dialogService.addDialog(MVFPComponent, {
                title: 'Lista de Amigos Próximos ao amigo :' + myVisitedfriendPosition.name,
                message: '',
                myVisitedFriendPositionColl: resultArray
            }).subscribe((isConfirmed) => {
                ////We get dialog result
                //if (isConfirmed) {
                //    alert('accepted');
                //}
                //else {
                //    alert('declined');
                //}
            });
            //We can close dialog calling disposable.unsubscribe();
            //If dialog was not closed manually close it by timeout
            setTimeout(() => {
                disposable.unsubscribe();
            }, 10000);

        });
    }
}

