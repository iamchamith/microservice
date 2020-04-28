using App.SharedKernel.Model;
using System.Threading.Tasks;

namespace App.SharedKernel.Utilities
{
    public class ErroLogService
    {
        DbConnector _dbConnector;
        public ErroLogService(DbConnector dbConnector)
        {
            _dbConnector = dbConnector;
        }
        public async Task DoErrorLog(System.Exception e,string requestObject) {

            try
            {
                var errorLog = new ErrorLogModel(e);
                await _dbConnector.Execute("");
            }
            catch (System.Exception)
            {
                 
            }
        }
    }
}
