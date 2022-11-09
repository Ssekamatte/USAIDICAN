using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USAIDICANBLAZOR.Models;

namespace USAIDICANBLAZOR.Schedules
{
    public class CommTeamRegSchedule : IJob
    {
        private IServiceApi _service;
        public Task Execute(IJobExecutionContext context)
        {
            LoadData();
            return Task.CompletedTask;
        }

        public async void LoadData()
        {
            using (var serviceScope = ServiceActivator.GetScope())
            {
                _service = (IServiceApi)serviceScope.ServiceProvider.GetService(typeof(IServiceApi));

                await _service.SavecommteamregData();
            }
        }
    }
}
