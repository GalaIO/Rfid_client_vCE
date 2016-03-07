using System;

/*
 * Author:  GalaIO
 * Data:    2016-2-28
 * Describe:    The main of application!
 * */
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Rfid_client_vCE;

namespace uhf_test2
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            Login login = new Login();
            login.ShowDialog();
            /*TaskList taskList = new TaskList();
            taskList.ShowDialog();
            TaskForm taskForm = new TaskForm();
            taskForm.ShowDialog();*/
            if (login.DialogResult == DialogResult.OK)
            {
                Application.Run(new TaskList());
            }
        }
    }
}