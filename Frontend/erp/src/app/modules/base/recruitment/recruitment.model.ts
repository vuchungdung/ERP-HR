import { JobStatus } from 'src/app/core/enums/job-status.enum';
import { JobType } from 'src/app/core/enums/job-type.enum';

export interface Recruitment{
  jobId:number,
  title:string,
  description:string,
  skill:string,
  categoryId:number,
  offerFrom:number,
  offerTo:number,
  requestJob:string,
  benefit:string,
  endow:string,
  createDte:Date,
  timeEnd:Date,
  timeStart:Date,
  quatity:number,
  status:JobStatus,
  type:JobType
}