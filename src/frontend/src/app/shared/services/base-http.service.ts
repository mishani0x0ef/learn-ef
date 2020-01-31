import { HttpClient } from '@angular/common/http';

export abstract class BaseHttpService {
    constructor(protected http: HttpClient) {
    }
}
