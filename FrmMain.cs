﻿using Vosk;

using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Project.STT.SGT.Tool._2111.Services.STT;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Project.STT.SGT.Tool._2111
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            var v = new VoskApi();
            v.OnResult += V_OnResult;
            v.Test();
            MessageBox.Show("执行完成");
        }

        private void V_OnResult(object sender, VoskResultEventArgs e)
        {
            var data = new string[] {
                DateTime.Now.ToString(),
                "",
                "",
                e.Message
            };
            
            this.LstTranslate.Items.Insert(0, new ListViewItem(data));
        }
    }
}