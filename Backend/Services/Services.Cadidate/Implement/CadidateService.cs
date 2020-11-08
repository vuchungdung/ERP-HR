using Core.CommonModel;
using Core.CommonModel.Enum;
using Core.Services.InterfaceService;
using Database.Sql.ERP;
using Database.Sql.ERP.Entities.Cadidate;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Services.Cadidates.Interfaces;
using Services.Cadidates.ViewModel;
using Services.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Services.Cadidates.Implement
{
    public partial class CadidateService : ICadidateService
    {
        private IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;
        private ISequenceService _sequenceService;
        private ISkillService _skillService;

        public CadidateService(IERPUnitOfWork context,
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

        public async Task<ResponseModel> Delete(CadidateViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Cadidate md = _context.CadidateRepository.FirstOrDefault(x => x.CadidateId == model.CadidateId);

                md.Deleted = true;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = 1;

                _context.CadidateRepository.Update(md);

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
                var query = from m in _context.CadidateRepository.Query()
                            join p in _context.ProviderRepository.Query()
                            on m.ProviderId equals p.ProviderId
                            join c in _context.JobCategoryRepository.Query()
                            on m.CategoryId equals c.CategoryId
                            join f in _context.FileCVRepository.Query()
                            on m.CadidateId equals f.CadidateId
                            where !m.Deleted && f.FileType != ".pdf"
                            orderby m.Name
                            select new ListCadidateViewModel()
                            {
                                CadidateId = m.CadidateId,
                                Name = m.Name,
                                Email = m.Email,
                                Address = m.Address,
                                Phone = m.Phone,
                                Gender = m.Gender,
                                Degree = m.Degree,
                                University = m.University,
                                Major = m.Major,
                                ApplyDate = m.ApplyDate,
                                Experience = m.Experience,
                                Rating = m.Rating,
                                Skill = _skillService.GetListSkill(m.Skill),
                                Provider = p.Name,
                                Category = c.Name,
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
                BaseListModel<ListCadidateViewModel> listItems = new BaseListModel<ListCadidateViewModel>();

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

        public async Task<ResponseModel> Insert(CadidateViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Cadidate md = new Cadidate();
                md.Name = model.Name;
                md.Email = model.Email;
                md.Address = model.Address;
                md.Dob = model.Dob;
                md.Phone = model.Phone;
                md.Gender = model.Gender;
                md.Degree = model.Degree;
                md.University = model.University;
                md.Major = model.Major;
                md.ApplyDate = model.ApplyDate;
                md.Experience = model.Experience;
                md.ProviderId = model.ProviderId;
                md.CategoryId = model.CategoryId;
                md.Skill = model.Skill;
                md.CreateDate = DateTime.Now;
                md.CreateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                await _context.CadidateRepository.AddAsync(md);
                await _context.SaveChangesAsync();

                var cadidateId = await _sequenceService.GetCadidateNewId();

                foreach (var item in model.Files)
                {
                    Database.Sql.ERP.Entities.Common.File f = new Database.Sql.ERP.Entities.Common.File();
                    f.CadidateId = cadidateId;
                    f.Deleted = false;
                    f.FileName = item.FileName;
                    var folderName = Path.Combine("wwwroot/cadidate-cv");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    var fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var fileSize = item.Length / 1024;
                    var fileType = Path.GetExtension(fileName);
                    f.CadidateId = Convert.ToInt32(await _sequenceService.GetCadidateNewId());
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
                Cadidate md = await _context.CadidateRepository.FirstOrDefaultAsync(x => x.CadidateId == id);

                CadidateViewModel model = new CadidateViewModel()
                {
                    Name = md.Name,
                    Email = md.Email,
                    Address = md.Address,
                    Phone = md.Phone,
                    Gender = md.Gender,
                    Degree = md.Degree,
                    University = md.University,
                    Major = md.Major,
                    ApplyDate = md.ApplyDate,
                    Experience = md.Experience,
                    Rating = md.Rating,
                    ProviderId = md.ProviderId,
                    CategoryId = md.CategoryId,
                    Skill = md.Skill,
                    JobId = md.JobId,
                    TagId = md.TagId,
                    FaceBook = md.FaceBook,
                    Zalo = md.Zalo,
                    LinkIn = md.LinkIn,
                    Dob = md.Dob,
                };

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
                Cadidate md = _context.CadidateRepository.FirstOrDefault(x => x.CadidateId == id && !x.Deleted);

                md.TagId = tagId;
                md.UpdateDate = DateTime.Now;
                md.UpdateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _context.CadidateRepository.Update(md);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return response;
        }

        public Task<ResponseModel> Update(CadidateViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}