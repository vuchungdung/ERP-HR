import { ResponseStatus } from '../enums/response-status.enum';

export class ResponseModel {
  status: ResponseStatus;
  result: any;
}
