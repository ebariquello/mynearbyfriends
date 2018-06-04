import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
    selector: 'home',
    templateUrl: './home.component.html',
})
export class HomeComponent {
    isLogin = false;
    userName: string;

    constructor(
        private authService: AuthService
    ) { }

    ngOnInit(): void {
        this.isLogin = this.authService.checkLogin();
        if (this.isLogin) {
            this.authService.getUserInfo().then(res => {
                this.userName = (res.Data as any).UserName;
            });
        }

    }
}
