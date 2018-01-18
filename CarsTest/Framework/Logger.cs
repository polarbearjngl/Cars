using System.Diagnostics;

namespace CarsTest
{
    public class Logger
    {
        public void LogStep(object step)
        {
            Debug.WriteLine(string.Format("[STEP] Шаг номер {0} пройден успешно",step));
        }

        public void LogAssertFail(string message)
        {
            Debug.WriteLine(string.Format("[FAIL]{0}",message));
        }
    }
}
