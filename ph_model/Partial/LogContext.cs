using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ph_model
{
    public partial class LogContext
    {
        public LogContext(string connectionString = null) : base(connectionString)
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;

            //// Sets the command timeout for all the commands
            //objectContext.CommandTimeout = 300;

            this.Database.CommandTimeout = 900;
        }

        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
        }

        public static LogContext CreateContext()
        {
            string metaData = "res://*/LogModel.csdl|res://*/LogModel.ssdl|res://*/LogModel.msl";
            string dataSource = "localhost\\sqlexpress2014";
            string initialCatalog = "ph_log";
            string user = "ph_dbuser";
            string pw = "xwing";

            return new LogContext(Utility.CreateConnectionString(metaData, dataSource, initialCatalog, user, pw));
        }
    }
}
