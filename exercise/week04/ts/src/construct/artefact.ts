export class Artefact {
    name: string;
    timeToLive: number;
    integrity: number;

    constructor(name: string, timeToLive: number, integrity: number) {
        this.name = name;
        this.timeToLive = timeToLive;
        this.integrity = integrity;
    }

    toString(): string {
        return `${this.name}, 🥄 integrity: ${this.integrity}, 💓 timeToLive: ${this.timeToLive}`;
    }
}