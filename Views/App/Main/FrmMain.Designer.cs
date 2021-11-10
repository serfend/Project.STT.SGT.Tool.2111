﻿
namespace Project.STT.SGT.Tool._2111
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StatusMain = new System.Windows.Forms.StatusStrip();
            this.StatusMainTip = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusMainProcess = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusMainLog = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnModelSelect = new System.Windows.Forms.Button();
            this.TxtModelSelect = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTemp = new System.Windows.Forms.TextBox();
            this.BtnStartTask = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.TxtMediaSrc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LstTranslate = new System.Windows.Forms.ListView();
            this.LstTranslateTimeStart = new System.Windows.Forms.ColumnHeader();
            this.LstTranslateTimeEnd = new System.Windows.Forms.ColumnHeader();
            this.LstTranslateConfidence = new System.Windows.Forms.ColumnHeader();
            this.LstTranslateResult = new System.Windows.Forms.ColumnHeader();
            this.StatusMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusMain
            // 
            this.StatusMain.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StatusMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusMainTip,
            this.StatusMainProcess,
            this.StatusMainLog});
            this.StatusMain.Location = new System.Drawing.Point(0, 1031);
            this.StatusMain.Name = "StatusMain";
            this.StatusMain.Padding = new System.Windows.Forms.Padding(2, 0, 14, 0);
            this.StatusMain.Size = new System.Drawing.Size(1086, 31);
            this.StatusMain.TabIndex = 0;
            // 
            // StatusMainTip
            // 
            this.StatusMainTip.Name = "StatusMainTip";
            this.StatusMainTip.Size = new System.Drawing.Size(257, 24);
            this.StatusMainTip.Text = "github@serfend:STT测试工具";
            // 
            // StatusMainProcess
            // 
            this.StatusMainProcess.Name = "StatusMainProcess";
            this.StatusMainProcess.Size = new System.Drawing.Size(300, 23);
            // 
            // StatusMainLog
            // 
            this.StatusMainLog.Name = "StatusMainLog";
            this.StatusMainLog.Size = new System.Drawing.Size(509, 24);
            this.StatusMainLog.Spring = true;
            this.StatusMainLog.Text = "等待";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.BtnModelSelect);
            this.panel1.Controls.Add(this.TxtModelSelect);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.TxtTemp);
            this.panel1.Controls.Add(this.BtnStartTask);
            this.panel1.Controls.Add(this.BtnLoad);
            this.panel1.Controls.Add(this.TxtMediaSrc);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 191);
            this.panel1.TabIndex = 1;
            // 
            // BtnModelSelect
            // 
            this.BtnModelSelect.Location = new System.Drawing.Point(735, 16);
            this.BtnModelSelect.Name = "BtnModelSelect";
            this.BtnModelSelect.Size = new System.Drawing.Size(96, 30);
            this.BtnModelSelect.TabIndex = 6;
            this.BtnModelSelect.Text = "加载";
            this.BtnModelSelect.UseVisualStyleBackColor = true;
            this.BtnModelSelect.Click += new System.EventHandler(this.BtnModelSelect_Click);
            // 
            // TxtModelSelect
            // 
            this.TxtModelSelect.Location = new System.Drawing.Point(148, 13);
            this.TxtModelSelect.Name = "TxtModelSelect";
            this.TxtModelSelect.Size = new System.Drawing.Size(582, 30);
            this.TxtModelSelect.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(13, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 26);
            this.label2.TabIndex = 4;
            this.label2.Text = "选择训练模型";
            // 
            // TxtTemp
            // 
            this.TxtTemp.Location = new System.Drawing.Point(13, 117);
            this.TxtTemp.Multiline = true;
            this.TxtTemp.Name = "TxtTemp";
            this.TxtTemp.Size = new System.Drawing.Size(1046, 69);
            this.TxtTemp.TabIndex = 3;
            this.TxtTemp.Text = "点击开始说话...（暂不支持语音输入）";
            this.TxtTemp.Click += new System.EventHandler(this.TextTemp_Click);
            // 
            // BtnStartTask
            // 
            this.BtnStartTask.Enabled = false;
            this.BtnStartTask.Location = new System.Drawing.Point(837, 82);
            this.BtnStartTask.Name = "BtnStartTask";
            this.BtnStartTask.Size = new System.Drawing.Size(163, 30);
            this.BtnStartTask.TabIndex = 2;
            this.BtnStartTask.Text = "开始语音转文字";
            this.BtnStartTask.UseVisualStyleBackColor = true;
            this.BtnStartTask.Click += new System.EventHandler(this.BtnStartTask_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(735, 82);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(96, 30);
            this.BtnLoad.TabIndex = 2;
            this.BtnLoad.Text = "加载";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // TxtMediaSrc
            // 
            this.TxtMediaSrc.Location = new System.Drawing.Point(146, 80);
            this.TxtMediaSrc.Name = "TxtMediaSrc";
            this.TxtMediaSrc.Size = new System.Drawing.Size(582, 30);
            this.TxtMediaSrc.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(11, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择音频文件";
            // 
            // LstTranslate
            // 
            this.LstTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstTranslate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LstTranslateTimeStart,
            this.LstTranslateTimeEnd,
            this.LstTranslateConfidence,
            this.LstTranslateResult});
            this.LstTranslate.HideSelection = false;
            this.LstTranslate.Location = new System.Drawing.Point(0, 196);
            this.LstTranslate.Name = "LstTranslate";
            this.LstTranslate.Size = new System.Drawing.Size(1082, 827);
            this.LstTranslate.TabIndex = 2;
            this.LstTranslate.UseCompatibleStateImageBehavior = false;
            this.LstTranslate.View = System.Windows.Forms.View.Details;
            // 
            // LstTranslateTimeStart
            // 
            this.LstTranslateTimeStart.Text = "开始时间";
            this.LstTranslateTimeStart.Width = 120;
            // 
            // LstTranslateTimeEnd
            // 
            this.LstTranslateTimeEnd.Text = "结束时间";
            this.LstTranslateTimeEnd.Width = 120;
            // 
            // LstTranslateConfidence
            // 
            this.LstTranslateConfidence.Text = "置信度";
            this.LstTranslateConfidence.Width = 80;
            // 
            // LstTranslateResult
            // 
            this.LstTranslateResult.Text = "转文字结果";
            this.LstTranslateResult.Width = 600;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 1062);
            this.Controls.Add(this.LstTranslate);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.StatusMain);
            this.Name = "FrmMain";
            this.Text = "STT测试工具";
            this.StatusMain.ResumeLayout(false);
            this.StatusMain.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusMain;
        private System.Windows.Forms.ToolStripStatusLabel StatusMainTip;
        private System.Windows.Forms.ToolStripProgressBar StatusMainProcess;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.TextBox TxtMediaSrc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView LstTranslate;
        private System.Windows.Forms.ColumnHeader LstTranslateTimeStart;
        private System.Windows.Forms.ColumnHeader LstTranslateTimeEnd;
        private System.Windows.Forms.ColumnHeader LstTranslateConfidence;
        private System.Windows.Forms.ColumnHeader LstTranslateResult;
        private System.Windows.Forms.TextBox TxtTemp;
        private System.Windows.Forms.Button BtnModelSelect;
        private System.Windows.Forms.TextBox TxtModelSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel StatusMainLog;
        private System.Windows.Forms.Button BtnStartTask;
    }
}