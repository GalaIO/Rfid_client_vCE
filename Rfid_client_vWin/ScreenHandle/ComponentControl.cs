
using System.Windows.Forms;

namespace ScreenHandle
{
    class ComponentControl
    {
        public static void disableAll(Form form)
        {
            foreach (Control cntrl in form.Controls)
            {
                cntrl.Enabled = false;
            }
        }
        public static void enableAll(Form form)
        {
            foreach (Control cntrl in form.Controls)
            {
                cntrl.Enabled = true;
            }
        }
    }
}