using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AppreciationApp.Core.Models;
using AppreciationApp.Function.Query;
using AzureFromTheTrenches.Commanding.Abstractions;

namespace AppreciationApp.Function.Handler
{
    public class GetAppreciationsHandler : ICommandHandler<GetAppreciationsQuery, List<Appreciation>>
    {
        public Task<List<Appreciation>> ExecuteAsync(GetAppreciationsQuery command, List<Appreciation> previousResult)
        {
            // TODO: Replace with 15Five handler
            return Task.FromResult(new List<Appreciation>()
            {
                new Appreciation()
                {
                    NameOfSubmitter = new Person()
                    {
                        Name = "John Smith",
                        NumberOfAppreciationsGivenTotal = 5,
                        NumberOfAppreciationsReceivedTotal = 3
                    },

                    AppreciatedPeople = new List<Person>()
                    {
                        new Person()
                        {
                            Name = "Joe Bloggs",
                            NumberOfAppreciationsGivenTotal = 7,
                            NumberOfAppreciationsReceivedTotal = 2
                        }
                    },
                    Message = "@JohnSmith Thanks for being an imaginary person",
                    Submitted = DateTime.Now.AddHours(-4)
                },
                new Appreciation()
                {
                    NameOfSubmitter = new Person()
                    {
                        Name = "Joe Bloggs",
                        NumberOfAppreciationsGivenTotal = 7,
                        NumberOfAppreciationsReceivedTotal = 2
                    },

                    AppreciatedPeople = new List<Person>()
                    {
                        new Person()
                        {
                            Name = "John Smith",
                            NumberOfAppreciationsGivenTotal = 5,
                            NumberOfAppreciationsReceivedTotal = 3
                        }
                    },
                    Message = "@Joe Bloggs Thanks for also being an imaginary person",
                    Submitted = DateTime.Now.AddHours(-3)
                }
            });
        }
    }
}
