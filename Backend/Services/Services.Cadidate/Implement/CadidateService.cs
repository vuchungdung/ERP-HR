using Core.CommonModel;
using Core.CommonModel.Enum;
using Core.Services.InterfaceService;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Candidate;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Candidates.Interfaces;
using Services.Candidates.ViewModel;
using Services.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services.Candidates.Implement
{
    public partial class CandidateService : ICandidateService
    {
        private IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;
        private ISequenceService _sequenceService;
        private ISkillService _skillService;

        public CandidateService(IERPUnitOfWork context,
            IHttpContextAccessor httpContext,
            ISequenceService sequenceService,
            ISkillService skillService)
        {
            _context = context;
            _httpContext = httpContext;
            _sequenceService = sequenceService;
            _skillService = skillService;
        }

        public Task<ResponseModel> ApplyToJob(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel> ChangeProcess(int id, int processId)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> Delete(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Candidate md = _context.CandidateRepository.FirstOrDefault(x => x.CandidateId == id && !x.Deleted);

                md.Deleted = true;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = 1;

                _context.CandidateRepository.Update(md);

                await _context.SaveChangesAsync();

                response.Result = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatus.Error;
                response.Errors.Add(ex.InnerException.InnerException.Message);
                throw ex;
            }
            return response;
        }

        public Task<ResponseModel> DropdownSelection()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel> GetList(FilterModel filter)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from m in _context.CandidateRepository.Query()
                            join p in _context.ProviderRepository.Query()
                            on m.ProviderId equals p.ProviderId
                            join f in _context.FileCVRepository.Query()
                            on m.CandidateId equals f.CandidateId
                            where !m.Deleted && f.FileType != ".pdf"
                            orderby m.CreateDate descending
                            select new ListCandidateViewModel()
                            {
                                CandidateId = m.CandidateId,
                                Name = m.Name,
                                Email = m.Email,
                                Address = m.Address,
                                Phone = m.Phone,
                                Gender = m.Gender,
                                ApplyDate = m.ApplyDate,
                                Skill = m.Skill,
                                Provider = p.Name,
                                CreatedDate = m.CreateDate,
                                Dob = m.Dob,
                                Img = Path.Combine(Path.Combine("wwwroot/cadidate-cv"), f.FileName)
                            };
                if (!string.IsNullOrEmpty(filter.Text))
                {
                    query = query.Where(x => x.Name.ToLower().Contains(filter.Text.ToLower())
                                        || x.Email.ToLower().Contains(filter.Text.ToLower())
                                        || x.Address.ToLower().Contains(filter.Text.ToLower())
                                        || x.Phone.ToLower().Contains(filter.Text.ToLower())
                                        || x.Degree.ToLower().Contains(filter.Text.ToLower())
                                        );
                }
                BaseListModel<ListCandidateViewModel> listItems = new BaseListModel<ListCandidateViewModel>();

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

        public async Task<ResponseModel> Insert(CandidateViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Candidate md = new Candidate();
                md.Name = model.Name;
                md.Email = model.Email;
                md.Address = model.Address;
                md.Dob = model.Dob;
                md.Phone = model.Phone;
                md.Gender = model.Gender;
                md.ApplyDate = model.ApplyDate;
                md.ProviderId = model.ProviderId;
                md.CategoryId = model.CategoryId;
                md.Skill = model.Skill;
                md.CreateDate = DateTime.Now;
                md.CreateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                await _context.CandidateRepository.AddAsync(md);
                await _context.SaveChangesAsync();

                var cadidateId = await _sequenceService.GetCandidateNewId();

                foreach (var item in model.Files)
                {
                    Database.Sql.ERP.Entities.Common.File f = new Database.Sql.ERP.Entities.Common.File();
                    f.CandidateId = cadidateId;
                    f.Deleted = false;
                    f.FileName = item.FileName;
                    var folderName = Path.Combine("wwwroot/cadidate-cv");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    var fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var fileSize = item.Length / 1024;
                    var fileType = Path.GetExtension(fileName);
                    f.CandidateId = Convert.ToInt32(await _sequenceService.GetCandidateNewId());
                    f.FileName = fileName;
                    f.FilePath = fullPath;
                    f.FileSize = Convert.ToInt32(fileSize);
                    f.FileType = fileType;
                    f.CreateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
                    f.CreateDate = DateTime.Now;
                    _context.FileCVRepository.Add(f);
                    _context.SaveChanges();
                }

                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Item(int id)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var query = from c in _context.CandidateRepository.Query()
                            join j in _context.JobDescriptionRepository.Query()
                            on c.JobId equals j.JobId
                            join f in _context.FileCVRepository.Query()
                            on c.CandidateId equals f.CandidateId
                            where c.CandidateId == id && f.FileType != ".pdf"
                            select new ListCandidateViewModel()
                            {
                                CandidateId = c.CandidateId,
                                Name = c.Name,
                                Email = c.Email,
                                Address = c.Address,
                                Phone = c.Phone,
                                Gender = c.Gender,
                                ApplyDate = c.ApplyDate,
                                JobId = c.JobId,
                                Dob = c.Dob,
                                Skype = c.Skype,
                                JobName = j.Title,
                                FilePath = Path.Combine(Path.Combine("wwwroot/cadidate-cv"), f.FilePath)
                            };

                var model = await query.ToListAsync();

                response.Result = model;
                response.Status = ResponseStatus.Success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public async Task<ResponseModel> Tagging(int id, int tagId)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Candidate md = _context.CandidateRepository.FirstOrDefault(x => x.CandidateId == id && !x.Deleted);

                md.TagId = tagId;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _context.CandidateRepository.Update(md);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public Task<ResponseModel> Update(CandidateViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}