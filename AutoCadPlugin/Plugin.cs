using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.AutoCAD.Runtime;

namespace AutoCadPlugin
{
    public class Plugin : IExtensionApplication
    {
        public void Initialize()
        {
            MessageBox.Show("Hello!");
        }

        public void Terminate()
        {
            MessageBox.Show("Goodbye!");
        }

        // эта функция будет вызываться при выполнении в AutoCAD команды «TestCommand»
        [CommandMethod("TestCommand")]
        public void MyCommand()
        {
            MessageBox.Show("Habr!");
        }
    }
}
