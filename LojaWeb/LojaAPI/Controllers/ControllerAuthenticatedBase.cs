using AutoMapper;
using LojaAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPI.Controllers;

[ServiceFilter(typeof(UsuarioAutenticadoFilter))]
public class ControllerAuthenticatedBase : Controller
{
    protected readonly IMapper _mapper;

    public ControllerAuthenticatedBase(IMapper mapper)
    {
        _mapper = mapper;
    }
}