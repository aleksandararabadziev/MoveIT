(self.webpackChunkclient_app=self.webpackChunkclient_app||[]).push([[164],{5164:(e,t,n)=>{"use strict";n.r(t),n.d(t,{OffersModule:()=>Z});var i=n(8583),o=n(3256),l=n(8207),r=n(3018),c=n(8756),a=n(9725),u=n(665);let s=(()=>{class e{constructor(e,t){this.dialogRef=e,this._offerService=t,this.model=new l.xD}submitProposal(){this._offerService.createOffer(this.model).subscribe(e=>{this.dialogRef.close(!0)})}cancel(){this.dialogRef.close(!1)}}return e.\u0275fac=function(t){return new(t||e)(r.Y36(c.so),r.Y36(a.K))},e.\u0275cmp=r.Xpm({type:e,selectors:[["get-offer"]],decls:24,vars:4,consts:[["mat-dialog-title",""],["mat-dialog-content",""],["type","number",3,"ngModel","ngModelChange"],["type","checkbox",3,"ngModel","ngModelChange"],["mat-dialog-actions",""],[3,"click"]],template:function(e,t){1&e&&(r.TgZ(0,"h1",0),r._uU(1,"Get an offer"),r.qZA(),r.TgZ(2,"div",1),r.TgZ(3,"div"),r.TgZ(4,"label"),r._uU(5,"Distance"),r.qZA(),r.TgZ(6,"input",2),r.NdJ("ngModelChange",function(e){return t.model.Distance=e}),r.qZA(),r.qZA(),r.TgZ(7,"div"),r.TgZ(8,"label"),r._uU(9,"Living area"),r.qZA(),r.TgZ(10,"input",2),r.NdJ("ngModelChange",function(e){return t.model.LivingArea=e}),r.qZA(),r.qZA(),r.TgZ(11,"div"),r.TgZ(12,"label"),r._uU(13,"Attic area"),r.qZA(),r.TgZ(14,"input",2),r.NdJ("ngModelChange",function(e){return t.model.AtticArea=e}),r.qZA(),r.qZA(),r.TgZ(15,"div"),r.TgZ(16,"label"),r._uU(17,"Piano included"),r.qZA(),r.TgZ(18,"input",3),r.NdJ("ngModelChange",function(e){return t.model.PianoIncluded=e}),r.qZA(),r.qZA(),r.qZA(),r.TgZ(19,"div",4),r.TgZ(20,"button",5),r.NdJ("click",function(){return t.submitProposal()}),r._uU(21,"Submit"),r.qZA(),r.TgZ(22,"button",5),r.NdJ("click",function(){return t.cancel()}),r._uU(23,"Cancel"),r.qZA(),r.qZA()),2&e&&(r.xp6(6),r.Q6J("ngModel",t.model.Distance),r.xp6(4),r.Q6J("ngModel",t.model.LivingArea),r.xp6(4),r.Q6J("ngModel",t.model.AtticArea),r.xp6(4),r.Q6J("ngModel",t.model.PianoIncluded))},directives:[c.uh,c.xY,u.wV,u.Fj,u.JJ,u.On,u.Wl,c.H8],encapsulation:2}),e})();function f(e,t){if(1&e){const e=r.EpF();r.TgZ(0,"tr"),r.TgZ(1,"td"),r._uU(2),r.qZA(),r.TgZ(3,"td"),r._uU(4),r.qZA(),r.TgZ(5,"td"),r._uU(6),r.qZA(),r.TgZ(7,"td"),r._uU(8),r.qZA(),r.TgZ(9,"td"),r._uU(10),r.qZA(),r.TgZ(11,"td"),r.TgZ(12,"a",0),r.NdJ("click",function(){const t=r.CHM(e).$implicit;return r.oxw(2).openOfferDetails(t.id)}),r._uU(13,"click here"),r.qZA(),r.qZA(),r.qZA()}if(2&e){const e=t.$implicit;r.xp6(2),r.Oqu(e.distance),r.xp6(2),r.Oqu(e.livingArea),r.xp6(2),r.Oqu(e.atticArea),r.xp6(2),r.Oqu(e.pianoIncluded),r.xp6(2),r.Oqu(e.totalPrice)}}function g(e,t){if(1&e&&(r.TgZ(0,"table"),r.TgZ(1,"tr"),r.TgZ(2,"th"),r._uU(3,"Distance"),r.qZA(),r.TgZ(4,"th"),r._uU(5,"Living area"),r.qZA(),r.TgZ(6,"th"),r._uU(7,"Attic area"),r.qZA(),r.TgZ(8,"th"),r._uU(9,"Piano included"),r.qZA(),r.TgZ(10,"th"),r._uU(11,"Total price"),r.qZA(),r.TgZ(12,"th"),r._uU(13,"Details"),r.qZA(),r.qZA(),r.YNc(14,f,14,5,"tr",2),r.qZA()),2&e){const e=r.oxw();r.xp6(14),r.Q6J("ngForOf",e.offers)}}let d=(()=>{class e{constructor(e,t,n){this._offerService=e,this.dialog=t,this._router=n}ngOnInit(){this.getAllOffers()}getAllOffers(){this._offerService.getAllOffers().subscribe(e=>{this.offers=e})}openGetOfferModal(){this.dialog.open(s,{width:"450px"}).afterClosed().subscribe(e=>{e&&this.getAllOffers()})}openOfferDetails(e){let t=this._router.createUrlTree(["offer-details",e]),n=window.location.href.replace(this._router.url,"");window.open(n+t,"_blank")}}return e.\u0275fac=function(t){return new(t||e)(r.Y36(a.K),r.Y36(c.uw),r.Y36(o.F0))},e.\u0275cmp=r.Xpm({type:e,selectors:[["offers"]],decls:5,vars:1,consts:[[3,"click"],[4,"ngIf"],[4,"ngFor","ngForOf"]],template:function(e,t){1&e&&(r.TgZ(0,"h3"),r._uU(1,"Offers"),r.qZA(),r.TgZ(2,"button",0),r.NdJ("click",function(){return t.openGetOfferModal()}),r._uU(3,"Get an offer"),r.qZA(),r.YNc(4,g,15,1,"table",1)),2&e&&(r.xp6(4),r.Q6J("ngIf",null!=t.offers&&null!=t.offers))},directives:[i.O5,i.sg],encapsulation:2}),e})(),Z=(()=>{class e{}return e.\u0275fac=function(t){return new(t||e)},e.\u0275mod=r.oAB({type:e}),e.\u0275inj=r.cJS({imports:[[i.ez,o.Bz.forChild([{path:"",component:d}])]]}),e})()}}]);