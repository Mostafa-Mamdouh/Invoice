import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { SharedModule } from '../shared/shared.module';
import { NotFountComponent } from './not-fount/not-fount.component';
import { ServerErrorComponent } from './server-error/server-error.component';
@NgModule({
  declarations: [
    NotFountComponent,
    ServerErrorComponent,
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    }),
  ],
  exports: [],
})
export class CoreModule {}
