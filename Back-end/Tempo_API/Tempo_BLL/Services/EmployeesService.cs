using AutoMapper;
using Tempo_BLL.Interfaces;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;
using Tempo_DAL.Interfaces;

namespace Tempo_BLL.Services;

public class EmployeesService : GenericService<EmployeeModel, EmployeeEntity>, IEmployeeService
{
    public EmployeesService(IMapper mapper, IEmployeeRepository repository) : base(mapper, repository) 
    {
    }
}
