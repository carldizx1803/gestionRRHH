using AutoMapper;
using gestionRRHH.DTO;
using gestionRRHH.Models;
using Microsoft.EntityFrameworkCore;

namespace gestionRRHH.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            
            // MAPEOS PARA LA ENTIDAD EMPLEADO
            CreateMap<Empleado, EmpleadoReadDTO>();
            CreateMap<Empleado, EmpleadoCreateDTO>();
            CreateMap<Empleado, EmpleadoUpdateDTO>();
            // al reves
            CreateMap<EmpleadoCreateDTO, Empleado>();
            CreateMap<EmpleadoReadDTO, Empleado>();
            CreateMap<EmpleadoUpdateDTO, Empleado>();

            //MAPEOS PARA LA ENTIDAD PUESTO
            CreateMap<Puesto, PuestoReadDTO>();
            CreateMap<Puesto, PuestoCreateDTO>();
            CreateMap<Puesto, PuestoUpdateDTO>();
            // al reves
            CreateMap<PuestoReadDTO, Puesto>();
            CreateMap<PuestoCreateDTO, Puesto>();
            CreateMap<PuestoUpdateDTO, Puesto>();


            //MAPEOS PARA LA ENTIDAD DEPARTAMENTO
            CreateMap<Departamento, DepartamentoReadDTO>();
            CreateMap<Departamento, DepartamentoCreateDTO>();
            CreateMap<Departamento, DepartamentoUpdateDTO>();
            // al reves
            CreateMap<DepartamentoReadDTO, Departamento>();
            CreateMap<DepartamentoCreateDTO, Departamento>();
            CreateMap<DepartamentoUpdateDTO, Departamento>();

            // MAPEOS PARA LA ENTIDAD BENEFICIO
            CreateMap<BeneficioReadDTO, Beneficio>();
            CreateMap<BeneficioCreateDTO, Beneficio>();
            CreateMap<BeneficioUpdateDTO, Beneficio>();
            // al reves
            CreateMap<Beneficio, BeneficioReadDTO>();
            CreateMap<Beneficio, BeneficioCreateDTO>();
            CreateMap<Beneficio, BeneficioUpdateDTO>();

            // MAPEOS PARA LA ENTIDAD CAPACITACION
            CreateMap<Capacitacion, CapacitacionReadDTO>();
            CreateMap<Capacitacion, CapacitacionUpdateDTO>();
            CreateMap<Capacitacion, CapacitacionCreateDTO>();
            // alreves
            CreateMap<CapacitacionReadDTO, Capacitacion>();
            CreateMap<CapacitacionCreateDTO, Capacitacion>();
            CreateMap<CapacitacionUpdateDTO, Capacitacion>();

            //MAPEOS PARA LA ENTIDAD EVALUACION
            CreateMap<Evaluacion, EvaluacionReadDTO>();
            CreateMap<Evaluacion, EvaluacionCreateDTO>();
            CreateMap<Evaluacion, EvaluacionUpdateDTO>();
            // alreves
            CreateMap<EvaluacionReadDTO, Evaluacion>();
            CreateMap<EvaluacionCreateDTO, Evaluacion>();
            CreateMap<EvaluacionUpdateDTO, Evaluacion>();

            //MAPEOS PARA LA ENTIDAD NOMINA
            CreateMap<Nomina, NominaReadDTO>();
            CreateMap<Nomina, NominaCreateDTO>();
            CreateMap<Nomina, NominaUpdateDTO>();
            // alreves
            CreateMap<NominaReadDTO, Nomina>();
            CreateMap<NominaCreateDTO, Nomina>();
            CreateMap<NominaUpdateDTO, Nomina>();

            // MAPEOS PARA LA ENTIDAD VACACION
            CreateMap<Vacacion, VacacionReadDTO>();
            CreateMap<Vacacion, VacacionCreateDTO>();
            CreateMap<Vacacion, VacacionUpdateDTO>();
            // al reves
            CreateMap<VacacionCreateDTO, Vacacion>();
            CreateMap<VacacionReadDTO, Vacacion>();
            CreateMap<VacacionUpdateDTO, Vacacion>();
        }
    }
}
