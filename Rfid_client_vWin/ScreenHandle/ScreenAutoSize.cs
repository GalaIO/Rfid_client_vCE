/*
 *Author:   GalaIO
 *Date:     2016-3-30
 *Describe: Auto resize the form by it.
 */
using System;
using System.Windows.Forms;
namespace ScreenHandle
{
    class ScreenAutoSize
    {
        public static void maxForm2Screen(Form form, double autobl)
        {
            //获取当前窗口的大小
            int srcWidth = form.Width;
            int srcHeight = form.Height;
            //吧当前窗口扩展成系统最大像素
            form.Width = (int)(autobl * System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width);
            form.Height = (int)(autobl * System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height);
            //开始调整所有组件的横向比例
            if (srcWidth < form.Width)
            {
                double bl = 1.0 * form.Width / srcWidth;
                foreach (System.Windows.Forms.Control cntrl in form.Controls)
                {
                    cntrl.Width = (int)(cntrl.Width * bl);
                    cntrl.Left = (int)(cntrl.Left * bl);
                }
            }
            //开始调整所有组件的纵向比例
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
}