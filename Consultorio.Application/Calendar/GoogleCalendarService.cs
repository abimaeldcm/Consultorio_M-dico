using Consultorio.Domain.Entity;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;

namespace Consultorio.Application.Calendario
{
    public class GoogleCalendarService : IGoogleCalendarService
    {
        const string CALENDAR_ID = "primary";

        public async Task<CalendarService> ConnectGoogleAgenda(string[] scopes)
        {
            try
            {
                string applicationName = "Consultorio Medico Calendario";
                UserCredential credential;
                using (var stream = new FileStream("credential.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json";
                    credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                            GoogleClientSecrets.FromStream(stream).Secrets,
                            scopes,
                            "user",
                            CancellationToken.None,
                            new FileDataStore(credPath, true)
                    );
                }

                //define services
                var services = new CalendarService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = applicationName
                });

                return services;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public  async Task<Event> CreateQuickEventGoogleCalendar(string description)
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR_ID}/events/quickAdd" };
            var services = await ConnectGoogleAgenda(scopes);

            var requestCreate = services.Events.QuickAdd(CALENDAR_ID, description).Execute();

            return requestCreate;
        }

        public  async Task<Event> CreateGoogleCalendar(GoogleCalendar request, string? emailPaciente)
        {
            string[] scopes = { "https://www.googleapis.com/auth/calendar " };
            var services = await ConnectGoogleAgenda(scopes);

            Event eventCalendar = new Event()
            {
                Summary = request.Summary,
                Location = request.Location,
                Start = new EventDateTime
                {
                    DateTime = request.Start.ToUniversalTime(),
                    TimeZone = "America/Fortaleza"
                },
                End = new EventDateTime
                {
                    DateTime = request.End.ToUniversalTime(),
                    TimeZone = "America/Fortaleza"
                },
                Description = request.Description,
            };
            eventCalendar.Attendees = new List<EventAttendee>
            {
                new EventAttendee { Email = emailPaciente}
            };

            var eventRequest = services.Events.Insert(eventCalendar, CALENDAR_ID);
            var requestCreate = await eventRequest.ExecuteAsync();

            return requestCreate;
        }

        public  async Task<IList<Event>> GetEventsGoogleCalendar()
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR_ID}/events" };
            var services = await ConnectGoogleAgenda(scopes);

            var events = services.Events.List(CALENDAR_ID).Execute();

            return events.Items;
        }

        public  async Task<Event> GetEventGoogleCalendar(string eventId)
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR_ID}/events" };
            var services = await ConnectGoogleAgenda(scopes);

            var events = await services.Events.Get(CALENDAR_ID, eventId).ExecuteAsync();

            return events;
        }

        public  async Task<string> DeleteEventGoogleCalendar(string eventId)
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR_ID}/events/{eventId}" };
            var services = await ConnectGoogleAgenda(scopes);

            var events = await services.Events.Delete(CALENDAR_ID, eventId).ExecuteAsync();

            return events;
        }

        public  async Task<Event> UpdateEventGoogleCalendar(string eventId, string title, DateTime start, DateTime end)
        {
            string[] scopes = { $"https://www.googleapis.com/calendar/v3/calendars/{CALENDAR_ID}/events/{eventId}" };
            var services = await ConnectGoogleAgenda(scopes);

            Event eventCalendar = await GetEventGoogleCalendar(eventId);

            eventCalendar.Summary = title;

            eventCalendar.Start = new EventDateTime
            {
                DateTime = start.ToUniversalTime(),
                TimeZone = "America/Fortaleza"
            };

            eventCalendar.End = new EventDateTime
            {
                DateTime = end.ToUniversalTime(),
                TimeZone = "America/Fortaleza"
            };

            var events = await services.Events.Update(eventCalendar, CALENDAR_ID, eventId).ExecuteAsync();

            return events;
        }

    }
}


