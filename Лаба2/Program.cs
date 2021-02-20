using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Лаба2
{
    class Client
    {
        public ConcreteBuilder ClientMethod(IAbstractFactory factory)
        {
            //factory.CreateLecturer();
            //var productBook = factory.CreateBook();
            factory.CreateDiscipline();
            factory.CreateLecturer();
            factory.CreateBook();
            return factory.Merge();
        }
    }
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

}
