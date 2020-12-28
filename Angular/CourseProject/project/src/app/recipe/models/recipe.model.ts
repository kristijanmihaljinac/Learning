export class Recipe {

    public name: string | undefined;
    public description: string | undefined;
    public imagePath: string | undefined;

    constructor(name: string, description: string, imagePath:string){
        this.name = name;
        this.description = description;
        this.imagePath = imagePath;
    }
}