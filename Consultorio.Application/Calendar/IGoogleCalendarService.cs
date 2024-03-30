using Consultorio.Domain.Entity;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;

namespace Consultorio.Application.Calendario
{
    public interface IGoogleCalendarService
    {
        Task<CalendarService> ConnectGoogleAgenda(string[] scopes);
        Task<Event> CreateQuickEventGoogleCalendar(string description);
        Task<Event> CreateGoogleCalendar(GoogleCalendar request, string? emailPaciente);
        Task<IList<Event>> GetEventsGoogleCalendar();
        Task<Event> GetEventGoogleCalendar(string eventId);
        Task<string> DeleteEventGoogleCalendar(string eventId);
        Task<Event> UpdateEventGoogleCalendar(string eventId, string title, DateTime start, DateTime end);
    }
}
