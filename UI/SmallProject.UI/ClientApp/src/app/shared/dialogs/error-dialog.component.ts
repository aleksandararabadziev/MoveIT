import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';

@Component({
  selector: 'app-error-dialog',
  templateUrl: './error-dialog.component.html'
})
export class ErrorDialogComponent implements OnInit {

  message: string;

  constructor(public dialogRef: MatDialogRef<ErrorDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {

    dialogRef.disableClose = true;

    if (this.data) {
      this.message = this.data;
    }

  }

  ngOnInit(): void { }

  close() {
    this.dialogRef.close();
  }

}