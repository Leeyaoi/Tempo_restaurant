using AutoMapper;
using Tempo_BLL.Models;
using Tempo_DAL.Entities;

namespace Tempo_BLL.Mapper;

public class BllMapperProfile : Profile
{
    public BllMapperProfile()
    {
        CreateMap<BillEntity, BillModel>().ReverseMap();
        CreateMap<CategoryEntity, CategoryModel>().ReverseMap();
        CreateMap<CookEntity, CookModel>().ReverseMap();
        CreateMap<DishEntity, DishModel>().ReverseMap();
        CreateMap<DishwareDishEntity, DishModel>().ReverseMap();
        CreateMap<DishwareEntity, DishModel>().ReverseMap();
        CreateMap<DrinkEntity, DrinkModel>().ReverseMap();
        CreateMap<EmployeeEntity, EmployeeModel>().ReverseMap();
        CreateMap<IngredientDishEntity, IngredientDishModel>().ReverseMap();
        CreateMap<IngredientEntity, IngredientModel>().ReverseMap();
        CreateMap<OrderEntity, OrderModel>().ReverseMap();
        CreateMap<TableEntity, TableModel>().ReverseMap();
        CreateMap<TablewareDishEntity, TablewareDishModel>().ReverseMap();
        CreateMap<TablewareEntity, TablewareModel>().ReverseMap();
        CreateMap<UserEntity, UserModel>().ReverseMap();
        CreateMap<WaiterEntity, WaiterModel>().ReverseMap();
        CreateMap<DishOrderEntity, DishOrderModel>().ReverseMap();
        CreateMap<DrinkOrderEntity, DrinkOrderModel>().ReverseMap();
    }
}
