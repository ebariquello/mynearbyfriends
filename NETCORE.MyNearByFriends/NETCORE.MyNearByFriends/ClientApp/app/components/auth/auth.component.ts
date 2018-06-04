import { Component, Inject, ContentChild, ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';


@Component({
    selector: 'auth',
    templateUrl: './auth.component.html',
    providers: [AuthService]
})
export class AuthComponent {
    private userName: string;
    private password: string;

    constructor(
        private authService: AuthService,
        private router: Router
    ) { }

    login() {
        this.authService.login(this.userName, this.password)
            .then(result => {
                if (result.State == 1) {
                    this.router.navigate(["./list-mfp"]);
                }
                else {
                    alert(result.Msg);
                }
            });
    }
}