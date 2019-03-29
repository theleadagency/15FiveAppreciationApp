using System;
using System.Collections.Generic;
using AppreciationApp.Core.Models;
using AzureFromTheTrenches.Commanding.Abstractions;

namespace AppreciationApp.Function.Query
{
    public class GetAppreciationsQuery : ICommand<List<Appreciation>>
    {
        public int DaysToLookBack { get; set; } = 7;
    }
}
