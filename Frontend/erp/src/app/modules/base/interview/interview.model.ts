import { RecruitType } from 'src/app/core/enums/recruit-type.enum';

export interface InterviewDate{
  dateId : number,
  cadidateId :number,
  timeDate : Date
  address :string
  recruitType : RecruitType
  time : number
  jobId : number
  note : string
  sendMail :boolean,
  email:string
}