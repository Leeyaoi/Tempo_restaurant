using AutoMapper;
using Tempo_API.DTOs.BillDtos;
using Tempo_API.DTOs.CategoryDtos;
using Tempo_API.DTOs.CookDtos;
using Tempo_API.DTOs.DishDtos;
using Tempo_API.DTOs.DishwareDishDtos;
using Tempo_API.DTOs.DishwareDtos;
using Tempo_API.DTOs.DrinkDtos;
using Tempo_API.DTOs.EmployeeDtos;
using Tempo_API.DTOs.IngredientDishDtos;
using Tempo_API.DTOs.IngredientDtos;
using Tempo_API.DTOs.OrderDtos;
using Tempo_API.DTOs.TableDtos;
using Tempo_API.DTOs.TablewareDishDtos;
using Tempo_API.DTOs.TablewareDtos;
using Tempo_API.DTOs.UserDtos;
using Tempo_API.DTOs.WaiterDtos;
using Tempo_BLL.Models;

namespace Tempo_API.Mapper;

public class ApiMapperProfile : Profile 
{
    public ApiMapperProfile()
    {
        CreateMap<BillModel, BillDto>().ReverseMap();
        CreateMap<BillModel, CreateBillDto>().ReverseMap();
        CreateMap<BillDto, CreateBillDto>().ReverseMap();

        CreateMap<CategoryModel, CategoryDto>().ReverseMap();
        CreateMap<CategoryModel, CreateCategoryDto>().ReverseMap();
        CreateMap<CategoryDto, CreateCategoryDto>().ReverseMap();

        CreateMap<CookModel, CookDto>().ReverseMap();
        CreateMap<CookModel, CreateCookDto>().ReverseMap();
        CreateMap<CookDto, CreateCookDto>().ReverseMap();

        CreateMap<DishModel, DishDto>().ReverseMap();
        CreateMap<DishModel, CreateDishDto>().ReverseMap();
        CreateMap<DishDto, CreateDishDto>().ReverseMap();

        CreateMap<DishwareDishModel, DishwareDishDto>().ReverseMap();
        CreateMap<DishwareDishModel, CreateDishwareDishDto>().ReverseMap();
        CreateMap<DishwareDishDto, CreateDishwareDishDto>().ReverseMap();

        CreateMap<DishwareModel, DishwareDto>().ReverseMap();
        CreateMap<DishwareModel, CreateDishwareDto>().ReverseMap();
        CreateMap<DishwareDto, CreateDishwareDto>().ReverseMap();

        CreateMap<DrinkModel, DrinkDto>().ReverseMap();
        CreateMap<DrinkModel, CreateDrinkDto>().ReverseMap();
        CreateMap<DrinkDto, CreateDrinkDto>().ReverseMap();

        CreateMap<EmployeeModel, EmployeeDto>().ReverseMap();
        CreateMap<EmployeeModel, CreateEmoloyeeDto>().ReverseMap();
        CreateMap<EmployeeDto, CreateEmoloyeeDto>().ReverseMap();

        CreateMap<IngredientModel, IngredientDto>().ReverseMap();
        CreateMap<IngredientModel, CreateIngredientDto>().ReverseMap();
        CreateMap<IngredientDto, CreateIngredientDto>().ReverseMap();

        CreateMap<IngredientDishModel, IngredientDishDto>().ReverseMap();
        CreateMap<IngredientDishModel, CreateIngredientDishDto>().ReverseMap();
        CreateMap<IngredientDishDto, CreateIngredientDishDto>().ReverseMap();

        CreateMap<OrderModel, OrderDto>().ReverseMap();
        CreateMap<OrderModel, CreateOrderDto>().ReverseMap();
        CreateMap<OrderDto, CreateOrderDto>().ReverseMap();

        CreateMap<TableModel, TableDto>().ReverseMap();
        CreateMap<TableModel, CreateTableDto>().ReverseMap();
        CreateMap<TableDto, CreateTableDto>().ReverseMap();

        CreateMap<TablewareDishModel, TablewareDishDto>().ReverseMap();
        CreateMap<TablewareDishModel, CreateTablewareDishDto>().ReverseMap();
        CreateMap<TablewareDishDto, CreateTablewareDishDto>().ReverseMap();

        CreateMap<TablewareModel, TablewareDto>().ReverseMap();
        CreateMap<TablewareModel, CreateTablewareDto>().ReverseMap();
        CreateMap<TablewareDto, CreateTablewareDto>().ReverseMap();

        CreateMap<UserModel, UserDto>().ReverseMap();
        CreateMap<UserModel, CreateUserDto>().ReverseMap();
        CreateMap<UserDto, CreateUserDto>().ReverseMap();

        CreateMap<WaiterModel, WaiterDto>().ReverseMap();
        CreateMap<WaiterModel, CreateWaiterDto>().ReverseMap();
        CreateMap<WaiterDto, CreateWaiterDto>().ReverseMap();
    }
}
