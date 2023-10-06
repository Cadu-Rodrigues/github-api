export interface Language {
    id: string;
    name: string;
    repositories: Array<Repository>;
}
interface Repository {
    id: string,
    name: string,
    ownerName: string,
    description:string,
    url: string,
    creationDate: Date,
    updatedDate: Date,
    stars: Number,
    watchers: Number,
    language: string
}