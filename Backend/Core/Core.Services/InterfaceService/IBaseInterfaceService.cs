﻿using Core.CommonModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.InterfaceService
{
    public interface IBaseInterfaceService<T> where T: class
    {
        Task<ResponseModel> GetList(FilterModel filter);
        Task<ResponseModel> Item(int id);
        Task<ResponseModel> Insert(T model);
        Task<ResponseModel> Update(T model);
        Task<ResponseModel> Delete(T model);
    }
}
