using DesktopTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopTest.Logic.Interface
{
    interface ITextInput
    {
        bool InputText(TextModel model);
        bool CloseApp();
    }
}
