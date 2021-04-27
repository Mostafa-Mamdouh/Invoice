import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IInvoiceEditor } from './shared/models/invoice';

@Injectable({
  providedIn: 'root'
})
export class AppService {
  baseUrl = environment.apiUrl;
  invoice: IInvoiceEditor;
  constructor(private http: HttpClient) { }


  saveInvoice(values: IInvoiceEditor) {
    debugger
    return this.http
      .post<IInvoiceEditor>(
        this.baseUrl +
          `invoice/${values.invoiceId >0? 'update' : 'create'}`,
        values
      )
      .pipe(
        map((response) => {
          this.invoice = response;
          return this.invoice;
        })
      );
  }
}
