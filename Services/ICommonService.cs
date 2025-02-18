using CRUD_VideoGamesConsoles.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_VideoGamesConsoles.Services
{
    public interface ICommonService<T, TI, TU>
    {
        Task<IEnumerable<T>> Get();
        Task<T>GetById(int id);
        Task<T>Add(TI genericInsert);
        Task<T> Update(int id, TU genericUpdate);
        Task<T> Delete(int id);
    }
}