using DesktopTest.Model;

namespace DesktopTest.Logic.Interface
{
    interface ITextInput
    {
        bool InputText(TextModel model);
        bool CloseApp();
    }
}
