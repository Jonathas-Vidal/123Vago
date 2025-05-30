export class Hotel {
    constructor(
        public nome : string,
        public quarto : number,
        public localizacao : string,
        public descricao: string,
        public id : number
    ) {}

    estaDisponivel(): boolean {
        return this.quarto >= 1;
    }
}