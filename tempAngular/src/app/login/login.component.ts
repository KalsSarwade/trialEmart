import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { GetProductsService } from '../get-products.service';

import { Router } from '@angular/router';
import { Customer } from '../customer';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  customer: Customer = new Customer();
  LogForm: FormGroup;

  constructor(private formBuilder: FormBuilder, private service: GetProductsService, private router: Router) {
  }
  submitted = false;

  buildform() {
    this.LogForm = this.formBuilder.group(
      {
        emailId: this.formBuilder.control('', Validators.required),
        password: this.formBuilder.control('', Validators.required)
      });
  }


  get emailId() {
    return this.LogForm.get('emailId');
  }

  get password() {
    return this.LogForm.get('password');
  }

  onSubmit(frm: FormGroup) {
    this.submitted = true;
    console.log("onSubmit Called");
    if (!frm.invalid) {
      this.mapvalue(frm);
      this.service.saveCustomer(this.customer).subscribe(data => {
        if (data)
          this.router.navigate(['/']);
        console.log(data)
      })
    }
    else
      console.log("hhhh" + frm);

  }

  mapvalue(form: FormGroup) {
    this.customer.emailId = form.controls['emailId'].value;
    this.customer.password = form.controls['password'].value;
  }

  onClick(customer: Customer) {
    console.log("inside saveCustomer " + this.customer);
    this.service.saveCustomer(customer).subscribe((data) => {
      if (data == null)
        this.router.navigate([""]);
      else
        this.router.navigate([""]);
    });
  }

  ngOnInit() {

    this.buildform();
  }

}
