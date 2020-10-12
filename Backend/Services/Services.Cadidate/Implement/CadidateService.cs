﻿using Core.CommonModel;
using Core.CommonModel.Enum;
using Database.Sql.ERP;
using Microsoft.AspNetCore.Http;
using Services.Cadidates.Interfaces;
using Services.Cadidates.ViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;
using Database.Sql.ERP.Entities.Cadidate;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Core.Services.InterfaceService;
using System.Net.Http.Headers;
using Database.Sql.ERP.Entities.Common;
using Services.Common.ViewModel;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Services.Cadidates.Implement
{
    public partial class CadidateService : ICadidateService
    {
        private IERPUnitOfWork _context;
        private IHttpContextAccessor _httpContext;
        private ISequenceService _sequenceService;
        public CadidateService(IERPUnitOfWork context,
            IHttpContextAccessor httpContext,
            ISequenceService sequenceService)
        {
            _context = context;
            _httpContext = httpContext;
            _sequenceService = sequenceService;
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
            catch(Exception ex)
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
                            join f in _context.FileCVRepository.Query()
                            on m.CadidateId equals f.CadidateId
                            join t in _context.TagRepository.Query()
                            on m.TagId equals t.Id
                            join p in _context.ProviderRepository.Query()
                            on m.ProviderId equals p.ProviderId
                            join cp in _context.InterviewProcessRepository.Query()
                            on m.CadidateId equals cp.CadidateId
                            join ps in _context.ProcessRepository.Query()
                            on cp.ProcessId equals ps.ProcessId
                            join c in _context.JobCategoryRepository.Query()
                            on m.CategoryId equals c.CategoryId
                            join j in _context.JobDescriptionRepository.Query()
                            on m.JobId equals j.JobId
                            where !m.Deleted
                            orderby m.Name
                            select new ListCadidateViewModel()
                            {
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
                                Skill = GetListSkill(m.Skill),
                                Provider = p.Name,
                                Category = c.Name,
                                Job = j.Title,
                                Tag = t.Name
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

                //listItems.Items = await query.Skip((filter.Paging.PageIndex - 1) * filter.Paging.PageSize)
                //                       .Take(filter.Paging.PageSize)
                //                       .OrderByDescending(x => x.Name)
                //                       .ToListAsync()
                //                       .ConfigureAwait(true);
                listItems.TotalItems = await query.CountAsync();

                response.Result = listItems;
                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public List<string> GetListSkill(string stringId)
        {
            string[] arr = stringId.Split(',');
            List<string> result = new List<string>();
            for(int i = 0;i< arr.Length; i++)
            {
                result.Add(arr[i]);
            }
            return result;
        }
        public async Task<ResponseModel> Insert(CadidateViewModel model)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Cadidate md = new Cadidate();
                var cadidateId = await _sequenceService.GetCadidateNewId();
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
                md.Skill = JsonConvert.SerializeObject(model.Skill);
                md.CreateDate = DateTime.Now;
                md.CreateBy = Convert.ToInt32(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);

                foreach(var item in model.Files)
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

                await _context.CadidateRepository.AddAsync(md);
                await _context.SaveChangesAsync();

                response.Status = ResponseStatus.Success;
            }
            catch(Exception ex)
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
            catch(Exception ex)
            {
                throw ex;
            }
            return response;
        }
        public async Task<ResponseModel> Tagging(int id,int tagId)
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
            catch(Exception ex)
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
