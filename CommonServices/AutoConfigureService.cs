// Code generated by DevUp technologies, 11/12/2023 17:23:46
using System;
using System.Collections.Generic;
using System.Text;

namespace CommonServices
{
	/// <summary>
    /// This class at service layer delegates the db migration work to data access layer, this is invoked by API at startup only
	/// This sets the connection string to data access layer, this connection string is passed by API layer and is used by the 
	/// data access layer
    /// </summary>
    public class AutoConfigureService
    {
        private string connectionString;

        public AutoConfigureService(string connectionString)
        {
            InventoryDAL.Container.IOCContainer.Initialize(connectionString);
            this.connectionString = connectionString;
        }

        public void AutoConfigure()
        {
            InventoryDAL.DbConfigurationService.ConfigureDb(connectionString);
        }
    }
}
