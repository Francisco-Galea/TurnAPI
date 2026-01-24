using TurnApi.DTOs.Request;
using TurnApi.DTOs.Response;
using TurnApi.Models;
using TurnApi.Models.Enums;
using TurnApi.Repositories.Interface;
using TurnApi.Services.Interfaces;

namespace TurnApi.Services
{
    public class AgendaService : IAgendaService
    {

        private readonly IAgendaRepository agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            this.agendaRepository = agendaRepository;
        }

        public void AsignEmployeeToAgenda(int agendaId, int employeeId)
        {
            agendaRepository.AsignEmployeeToAgenda(agendaId, employeeId);
        }

        public void CreateAgenda(CreateAgendaRequest createAgendaRequest)
        {
            agendaRepository.CreateAgenda(createAgendaRequest);
        }

        public void CreateAgendaSchedule(CreateAgendaScheduleRequest createAgendaScheduleRequest)
        {
            AgendaSchedule agendaSchedule = new()
            {
                agendaId = createAgendaScheduleRequest.agendaId,
                workableDay = createAgendaScheduleRequest.workableDay.ToUpper(),
                appointmentInit = createAgendaScheduleRequest.appointmentInit,
                appointmentEnd = createAgendaScheduleRequest.appointmentEnd,
                appointmentDurationInMinutes = createAgendaScheduleRequest.appointmentDurationInMinutes
            };
            agendaRepository.CreateAgendaSchedule(agendaSchedule);
        }

        public AgendaResponse CreateShifts(int agendaId, DateOnly dateSearched)
        {
            List<AvailableAppointmentResponse> list = new();
            string dayOfWeek = dateSearched.DayOfWeek.ToString().ToUpper();
            AgendaResponse agendaResponse = agendaRepository.GetShifts(agendaId, dayOfWeek);
            TimeOnly appointmentInixAux = agendaResponse.appointmentInit;
            for (int appointmentDuration = agendaResponse.appointmentDurationInMinutes; appointmentInixAux < agendaResponse.appointmentEnd; appointmentInixAux = appointmentInixAux.AddMinutes(appointmentDuration))
            {
                AvailableAppointmentResponse availableTurnResponse = new()
                {
                    appointmentInit = appointmentInixAux,
                    appointmentEnd = appointmentInixAux.AddMinutes(appointmentDuration)
                };
                list.Add(availableTurnResponse);
                agendaResponse.availableappointment = list;
            }
            return agendaResponse;
        }

        public AgendaResponse GetAgenda(int agendaId, DateOnly dateSearched)
        {
            AgendaResponse agendaSchedule = CreateShifts(agendaId, dateSearched);
            List<Appointment> appointments = agendaRepository.GetAppointments(agendaId, dateSearched);
            foreach (var timeBlock in agendaSchedule.availableappointment.ToList())
            {
                foreach (var appointment in appointments)
                {
                    if (timeBlock.appointmentInit == appointment.appointmentInit)
                    {
                        timeBlock.shiftState = ShiftStateEnum.Reservado;
                    }
                    else
                    {
                        timeBlock.shiftState = ShiftStateEnum.Disponible;
                    }
                }
            }
            return agendaSchedule;
        }

        public AgendaResponse GetAgenda(int agendaId, DateOnly dateSearched, TimeOnly hourSearched)
        {
            AgendaResponse agendaSchedule = CreateShifts(agendaId, dateSearched);
            if(hourSearched <= agendaSchedule.appointmentInit || hourSearched >= agendaSchedule.appointmentEnd)
            {
                throw new Exception("No se puede agendar un turno fuera del horario laboral");
            }
            List<Appointment> appointments = agendaRepository.GetAppointments(agendaId, dateSearched);
            foreach (var timeBlock in agendaSchedule.availableappointment.ToList())
            {
                foreach(var appointment in appointments)
                {
                    if (appointment.appointmentInit == hourSearched)
                    {
                        throw new Exception("Horario no disponible");
                    }
                    else if(timeBlock.appointmentInit == appointment.appointmentInit)
                    {
                        timeBlock.shiftState = ShiftStateEnum.Reservado;
                    }
                    else
                    {
                        timeBlock.shiftState = ShiftStateEnum.Disponible;
                    }
                }
            }
            return agendaSchedule;
        }

        public AgendaResponse IsAppointmentAvailable(CreateAppointmentRequest createAppointmentRequest)
        {
            return GetAgenda(createAppointmentRequest.agendaId, createAppointmentRequest.appointmentDate, createAppointmentRequest.appointmentInit);
        }

    }
}
