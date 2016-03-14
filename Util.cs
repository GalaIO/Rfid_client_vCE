using System;

class Util
{
    public static void maxForm2Screen(System.Windows.Forms.Form form)
    {

        int srcWidth = form.Width;
        int srcHeight = form.Height;
        form.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width;
        form.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
        if (srcWidth < form.Width)
        {
            double bl = 1.0 * form.Width / srcWidth;
            foreach (System.Windows.Forms.Control cntrl in form.Controls)
            {
                cntrl.Width = (int)(cntrl.Width * bl);
                cntrl.Left = (int)(cntrl.Left * bl);
            }
        }
        if (srcHeight < form.Height)
        {
            double bl = 1.0 * form.Height / srcHeight;
            foreach (System.Windows.Forms.Control cntrl in form.Controls)
            {
                cntrl.Height = (int)(cntrl.Height * bl);
                cntrl.Top = (int)(cntrl.Top * bl);
            }
        }
    }
}