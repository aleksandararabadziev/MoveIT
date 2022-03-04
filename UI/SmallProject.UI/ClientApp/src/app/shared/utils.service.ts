import { HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MatDialog } from "@angular/material/dialog";
import { throwError } from "rxjs";
import { ErrorDialogComponent } from "./dialogs/error-dialog.component";

@Injectable({
    providedIn: "root"
})
export class Utils {
    constructor(private dialog: MatDialog) {

    }

    handleError(err: HttpErrorResponse) {
        // var error = JSON.parse(err.error);
        // if (typeof error === 'object') {
        //     if (error.hasOwnProperty('Message')) {
                this.dialog.open(ErrorDialogComponent, {
                    width: '500px',
                    data: err.error
                });
        //     }
        // }
        return throwError(err.error);
    }
}