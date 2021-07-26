import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  returnUrl: string;

  constructor(private accountService: AccountService, private router: Router, private activatedRoute: ActivatedRoute) { }

  ngOnInit() {
    this.returnUrl = this.activatedRoute.snapshot.queryParams.returnUrl || '/shop'; /*tozihat safe 15 mored 4 */
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = new FormGroup({ /*tozihat safe 14 mored 7 */
      email: new FormControl('', [Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]),
      password: new FormControl('', Validators.required) /*tozihat safe 14 mored 4 */
    });
  } /*tozihat safe 14 mored 4 */

  onSubmit() {
    // console.log(this.loginForm.value);  /*tozihat safe 14 mored 4. bad ghesmat 6 comment shod */
    this.accountService.login(this.loginForm.value).subscribe(() => {
      // console.log('user logged in'); /*to ghabl ghesmat 10 baraye check kardan inke login shode */
      this.router.navigateByUrl(this.returnUrl);
    }, error => {
      console.log(error);
    });
  }

}
