using System.Text;

namespace AOT.Core.Abstractions
{
    public interface IRender
    {
        void RenderScreen(StringBuilder screen);

        void PrintMsg(string msg);

        void ClearScreen();
    }
}
