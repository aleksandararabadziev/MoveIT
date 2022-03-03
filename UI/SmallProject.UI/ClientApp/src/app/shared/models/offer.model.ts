export class OfferModel{
    //public Id: string = '';
    public Distance: number = 0;
    public LivingArea: number = 0;
    public AtticArea: number = 0;
    public PianoIncluded: boolean = false;
    //public UserId: string = null;

    constructor( Distance, LivingArea, AtticArea, PianoIncluded){
        //this.Id = Id;
        this.Distance = Distance;
        this.LivingArea = LivingArea;
        this.AtticArea = AtticArea;
        this.PianoIncluded = PianoIncluded;
        //this.UserId = UserId;
    }

}