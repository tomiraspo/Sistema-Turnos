using Turnos.Domain.Entities;
using Turnos.Model.UI;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Turnos.SharedKernel.Interfaces.Services;
using Radzen.Blazor;
using Radzen;
using Turnos.Web.Pages.Appointments;
using Microsoft.AspNetCore.Authorization;
using System.Globalization;

namespace Turnos.Web.Pages.TurnosCalendar;

[Authorize]
public partial class TurnosEdit : ComponentBase
{
    [CascadingParameter] private Task<AuthenticationState> AuthenticationStateTask { get; set; }
    [Inject] IAppointmentService AppointmentService { get; set; }

    List<AppointmentDto> appointments { get; set; } = new List<AppointmentDto>();
    RadzenScheduler<AppointmentDto> scheduler { get; set; }
    
    protected void OnSlotRender(SchedulerSlotRenderEventArgs args)
    {
        // Highlight today in month view
        if (args.View.Text == "Mes" && args.Start.Date == DateTime.Today)
        {
            args.Attributes["style"] = "background: rgba(255,220,40,.2);";
        }


        // Highlight working hours (9-18)
        if ((args.View.Text == "Semana" || args.View.Text == "Dia") && args.Start.Hour > 8 && args.Start.Hour < 19)
        {
            args.Attributes["style"] = "background: rgba(255,220,40,.2);";
        }

        if (args.Start.DayOfWeek == DayOfWeek.Sunday)
        {
            args.Attributes["style"] = "background: rgba(202,203,204,.2); color:red";          
        }
    }

    protected async Task OnSlotSelect(SchedulerSlotSelectEventArgs args)
    {
        if (args.View.Text != "Año")
        {
            AppointmentDto data = await DialogService.OpenAsync<AddAppointmentPage>("Agregar Turno",
                new Dictionary<string, object> { { "Start", args.Start }, { "End", args.End } });

            if (data != null)
            {
                appointments.Add(data);
                // Either call the Reload method or reassign the Data property of the Scheduler
                await scheduler.Reload();
            }
        }
    }

    protected async Task OnAppointmentSelect(SchedulerAppointmentSelectEventArgs<AppointmentDto> args)
    {
        await DialogService.OpenAsync<EditAppointmentPage>("Editar Turno", parameters: new Dictionary<string, object> { { "Appointment", args.Data } });

        await scheduler.Reload();
    }

    protected void OnAppointmentRender(SchedulerAppointmentRenderEventArgs<AppointmentDto> args)
    {
        // Never call StateHasChanged in AppointmentRender - would lead to infinite loop

        if (args.Data.Motivo == "Birthday")
        {
            args.Attributes["style"] = "background: red";
        }
    }

    public void Refresh()
    {
        appointments = AppointmentService.GetAppointmentsAsync().ToList();
    }
}
