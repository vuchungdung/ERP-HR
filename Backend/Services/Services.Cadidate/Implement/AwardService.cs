using Core.CommonModel;
using Database.Sql.ERP;
using Services.Cadidates.Interfaces;
using Services.Cadidates.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Core.CommonModel.Enum;

namespace Services.Cadidates.Implement
{
    public class AwardService : IAwardService
    {
        private readonly IERPUnitOfWork _context;
        
        public AwardService(IERPUnitOfWork context)
        {
            _context = context;
        }

        public Task<ResponseModel> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from a in _context.AwardRepository.Query()
                            where !a.Deleted && a.CandidateId == Convert.ToInt32(filter.CandidateId)
                            orderby a._From
                            select new AwardViewModel()
                            {
                                Id = a.Id,
                                CandidateId = a.CandidateId,
                                Title = a.Title,
                                Institute = a.Institute,
                                _From = a._From,
                                Description = a.Description,
                                _To = a._To
                            };

                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.Title.ToLower().Contains(filter.Text.ToLower())
                                        || x.Description.ToLower().Contains(filter.Text.ToLower()));
                }
                BaseListModel<AwardViewModel> listItems = new BaseListModel<AwardViewModel>();

                listItems.Items = await query.Skip((filter.Paging.PageIndex - 1) * filter.Paging.PageSize)
                                            .Take(filter.Paging.PageSize)
                                            .ToListAsync()
                                            .ConfigureAwait(true);
                listItems.TotalItems = await query.CountAsync();

                response.Result = listItems;
                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public Task<ResponseModel> Insert(AwardViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Item(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> Update(AwardViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
