namespace AppreciationApp.Web.Models
{
    public class HighFives
    {
        /// <summary>
        /// The user who give the High Five
        /// </summary>
        /// <value>
        /// The appreciator.
        /// </value>
        public string  AppreciatorUser { get; set; }
        /// <summary>
        /// Gets or sets the appreciated user.
        /// </summary>
        /// <value>
        /// The appreciated user.
        /// </value>
        public string AppreciatedUser { get; set; }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string Message { get; set; }

    }
}
