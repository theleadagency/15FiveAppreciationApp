using System.Collections.Generic;
using AppreciationApp.Models;

namespace AppreciationApp.Repository
{
    public interface IFifteenFiveAppreciationRepository
    {
        /// <summary>
        /// Gets the weekly high fives.
        /// </summary>
        /// <returns>List of weekly high fives given out this week</returns>
        List<HighFives> GetWeeklyHighFives();
    }
}