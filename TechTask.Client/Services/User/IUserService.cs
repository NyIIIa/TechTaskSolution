using TechTask.Client.Dto.User.Add;
using TechTask.Client.Dto.User.Update;

namespace TechTask.Client.Services.User;

public interface IUserService
{
    Task<AddUserResponse> Add(AddUserRequest addUserDto);
    Task<UpdateUserResponse> Update(UpdateUserRequest updateUserDto);
    Task<IEnumerable<Data.User>> GetAll();

    Task<Data.User> GetById(int userId);
}