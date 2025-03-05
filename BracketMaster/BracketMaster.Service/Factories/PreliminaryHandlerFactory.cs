using BracketMaster.Logic;
using BracketMaster.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BracketMaster.Service
{
    public class PreliminaryHandlerFactory
    {
        readonly IServiceProvider _serviceProvider;

        public PreliminaryHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IPreliminaryLogic GetLogic(PreliminarySystem preliminary)
        {
            return preliminary.Name switch
            {
                "Groups" => _serviceProvider.GetRequiredService<GroupsLogic>(),
                "Random" => _serviceProvider.GetRequiredService<RandomEnemyLogic>(),
                "Swiss" => _serviceProvider.GetRequiredService<SwissLogic>(),
                "Robin" => _serviceProvider.GetRequiredService<RoundRobinLogic>(),
                _ => throw new ArgumentException("Unknown preliminary type")
            };
        }
    }
}
