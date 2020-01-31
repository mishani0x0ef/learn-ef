import { BaseHttpService } from 'src/app/shared/services';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Environment } from '../models';
import { Injectable } from '@angular/core';

@Injectable()
export class EnvironmentService extends BaseHttpService {
    constructor(http: HttpClient) {
        super(http);
    }

    getEnvironments(): Observable<Environment[]> {
        return this.http.get<Environment[]>('https://localhost:44346/api/environments');
    }
}
