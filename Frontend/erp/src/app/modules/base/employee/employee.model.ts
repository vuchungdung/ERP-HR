import { dateSelectionJoinTransformer } from "@fullcalendar/core";

export interface Employee{
  id : number,
  name : string,
  dob : Date,
  email : string,
  phone : string,
  address: string,
  position : string,
  gender : number
}