import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { noop } from "rxjs";
import { tap } from "rxjs/operators";
import { ExamRequest } from '../models/request/exam-request.model';
import { ExamService } from '../services/exam.service';

@Component({
  selector: 'app-exam-form',
  templateUrl: './exam-form.component.html',
  styleUrls: ['./exam-form.component.scss']
})
export class ExamFormComponent implements OnInit {
  form: FormGroup;
  request: ExamRequest;
  hide = true;

  constructor(
    private fb: FormBuilder,
    private examService: ExamService) {

    this.form = fb.group({
      text: ['', [Validators.required]],
      subtext: ['', [Validators.required]]
    });
  }

  ngOnInit() {

  }

  submit() {
    this.request = this.form.value;
    this.examService.findTextMatchIndex(this.request)
      .pipe(
        tap(resp => {
          console.log(resp);
        })
      )
      .subscribe(
        err => alert(err)
      );
  }
}
