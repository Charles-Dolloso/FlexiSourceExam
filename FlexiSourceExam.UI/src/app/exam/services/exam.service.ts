import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
import { ExamResponse } from "../models/response/exam-response.model";
import { ExamRequest } from "../models/request/exam-request.model";
import { environment } from "src/environments/environment";


@Injectable()
export class ExamService {

    constructor(private http: HttpClient) { }

    findTextMatchIndex(examRequest: ExamRequest): Observable<ExamResponse> {
        return this.http.post<ExamResponse>(`${environment.API_URL}/Exam`, examRequest);
    }
}
