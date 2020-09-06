import { ResponseStatus } from '../enums/response-status.enum';

export class ResponseModel {
  status: ResponseStatus;
  errors: any[];
  result: any;
}
