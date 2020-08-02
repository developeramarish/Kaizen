import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
	selector: 'app-error-dialog',
	templateUrl: './error-dialog.component.html',
	styleUrls: [ './error-dialog.component.css' ]
})
export class ErrorDialogComponent implements OnInit {
	constructor(
		public dialogRef: MatDialogRef<ErrorDialogComponent>,
		@Inject(MAT_DIALOG_DATA) public message: string
	) {}

	ngOnInit(): void {}
}
