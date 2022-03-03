export class OfferModel{
    public id: string = '';
    public distance: number = 0;
    public livingArea: number = 0;
    public atticArea: number = 0;
    public pianoIncluded: boolean = false;
    public userId: string = null;
    public totalPrice: number = 0;

    constructor(){

    }
}

export class GetOfferModel{
    public Distance: number = 0;
    public LivingArea: number = 0;
    public AtticArea: number = 0;
    public PianoIncluded: boolean = false;

    constructor(){
        
    }
}

export class DetailsOfferModel{
    public id: string = '';
    public distance: number = 0;
    public livingArea: number = 0;
    public atticArea: number = 0;
    public pianoIncluded: boolean = false;
    public userFullName: string = '';
    public totalPrice: number = 0;

    constructor(){}
}