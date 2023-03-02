﻿namespace LMS.Common.Services
{
    public interface IAdminService
    {
        Task CreateAsync<TDto>(string uri, TDto dto);
        Task DeleteAsync<TDto>(string uri);
        Task DeleteAsync<TDto>(string uri, TDto dto);
        Task EditAsync<TDto>(string uri, TDto dto);
        Task<List<TDto>> GetAsync<TDto>(string uri);
        Task<TDto?> SingleAsync<TDto>(string uri);
    }
}
