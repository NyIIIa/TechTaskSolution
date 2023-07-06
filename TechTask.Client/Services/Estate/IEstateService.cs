using TechTask.Client.Dto.Estate.Add;
using TechTask.Client.Dto.Estate.Update;

namespace TechTask.Client.Services.Estate;

public interface IEstateService
{
    Task<AddEstateResponse> Add(AddEstateRequest addEstateRequest);
    Task<UpdateEstateResponse> Update(UpdateEstateRequest updateEstateRequest);
    Task<IEnumerable<Data.Estate>> GetAll();
    
    Task<Data.Estate> GetById(int estateId);
}