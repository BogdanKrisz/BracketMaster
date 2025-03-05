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
    public class KnockoutHandlerFactory
    {
        readonly IServiceProvider _serviceProvider;

        public KnockoutHandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IKnockoutLogic GetLogic(KnockoutSystem knockout)
        {
            return knockout.Name switch
            {
                "None" => _serviceProvider.GetRequiredService<NoneEleminationLogic>(),
                "Single" => _serviceProvider.GetRequiredService<SingleEleminationLogic>(),
                "Double" => _serviceProvider.GetRequiredService<DoubleEleminationLogic>(),
                "Triple" => _serviceProvider.GetRequiredService<TripleEleminationLogic>(),
                _ => throw new ArgumentException("Unknown knockout type")
            };
        }
    }
}
