import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { buildIsoDate } from '@core/utils/date-utils';

@Component({
  selector: 'app-select-date-modal',
  templateUrl: './select-date-modal.component.html',
  styleUrls: [ './select-date-modal.component.scss' ]
})
export class SelectDateModalComponent implements OnInit {
  dateForm: FormGroup;

  constructor(public dialogRef: MatDialogRef<SelectDateModalComponent>, private formBuilder: FormBuilder) {}

  ngOnInit(): void {
    this.dateForm = this.formBuilder.group({
      newDate: [ '', [ Validators.required ] ],
      newTime: [ '', [ Validators.required ] ]
    });
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  saveDate(): void {
    if (this.dateForm.valid) {
      const date = this.dateForm.controls['newDate'].value as Date;
      const time = this.dateForm.controls['newTime'].value;
      const isoDate = buildIsoDate(date, time);
      this.dialogRef.close(isoDate);
    }
  }
}
