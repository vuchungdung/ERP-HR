import { Result } from "src/app/core/enums/result.enum";

export interface InterviewProcess{
  Id :number;  
  ApplyId :number;
  ProcessId :number;
  Result : Result;
  ResultDate : Date;
}