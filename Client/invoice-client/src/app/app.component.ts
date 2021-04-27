import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { BehaviorSubject } from 'rxjs';
import { AppService } from './app.service';
import { IInvoiceEditor, ItemDto } from './shared/models/invoice';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  invoiceForm: FormGroup;
  invoiceItems: FormArray;
  invoiceItemsData: ItemDto[] = [];

  invoiceEditor: IInvoiceEditor;
  invoiceItem: ItemDto;

  private invoiceItemsSource = new BehaviorSubject<ItemDto[]>(
    null
  );
  currentInvoiceProductItems$ = this.invoiceItemsSource.asObservable();
  totalInvoiceAmount: number = 0;

  constructor(
    private invoiceService: AppService,
    private router: Router,
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private activatedroute: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.createInvoiceForm();
    this.resetInvoiceItems();
  }

 
  createInvoiceForm() {
    this.invoiceForm = this.formBuilder.group({
      invoiceId: new FormControl(0),
      invoiceDate: new FormControl('', [Validators.required]),
      customer: new FormControl('',Validators.required),
      paymentMethod: new FormControl(null,Validators.required),
      description: new FormControl(''),
      itemDtos: this.formBuilder.array([]),
    });
  }

  createinvoiceItem(
  
  ): FormGroup {
    return this.formBuilder.group({
      itemCode: new FormControl(0),
      itemName: new FormControl('',Validators.required),
      qty: new FormControl(null,[Validators.required,Validators.min(1)]),
      price: new FormControl(null,[Validators.required, Validators.pattern('[0-9]+(.[0-9][0-9]?)?')]),
    });
  }

  collectFormData() {
    const model: IInvoiceEditor = {
      invoiceId: this.invoiceForm.controls['invoiceId'].value,
      invoiceDate: this.invoiceForm.controls['invoiceDate'].value,
      customer: this.invoiceForm.controls['customer'].value,
      paymentMethod: this.invoiceForm.controls['paymentMethod'].value=="0"?true:false,
      description: this.invoiceForm.controls['description'].value,
      itemDtos: this.invoiceForm.controls['itemDtos'].value,
    
    };
    this.invoiceEditor = model;
  }

  reloadCurrentPage(){
    window.location.reload();
  }

  resetInvoiceItems() {
    debugger
 
    this.invoiceItems = this.invoiceForm.get(
      'itemDtos'
    ) as FormArray;

    this.invoiceItems.push(this.createinvoiceItem())


    this.invoiceItemsData = this.invoiceForm.controls[
      'itemDtos'
    ].value;
    this.invoiceItemsSource.next(this.invoiceItemsData);
    this.updateTotalInvoiceAmount();
  }

  
  updateTotalInvoiceAmount() {
    if (this.invoiceForm.controls['itemDtos'].value.length > 0) {
      this.totalInvoiceAmount = this.invoiceForm.controls[
        'itemDtos'
      ].value
        .map((a) => a.price * a.qty)
        .reduce(function (a, b) {
          return a + b;
        });
    }
  }

  onSubmit() {
    this.markFormGroupTouched(this.invoiceForm);
 
if(this.totalInvoiceAmount>10000){
  this.toastr.error('the invoice Total should not exceed 10,000 EGP');
}
    if (this.invoiceForm.valid && this.totalInvoiceAmount<=10000) {
      this.collectFormData();
      this.saveInvoice();
    }
  }

  saveInvoice() {
    this.invoiceService
      .saveInvoice( this.invoiceEditor)
      .subscribe(
        () => {
          this.toastr.success('invoice saved successfully');
          setTimeout (() => {
            this.reloadCurrentPage()
         }, 2000);
        },
        (err) => {
          console.log(err);
        }
      );
  }
  private markFormGroupTouched(formGroup: FormGroup) {
    (<any>Object).values(formGroup.controls).forEach((control) => {
      control.markAsTouched();

      if (control.controls) {
        this.markFormGroupTouched(control);
      }
    });
  }

}

