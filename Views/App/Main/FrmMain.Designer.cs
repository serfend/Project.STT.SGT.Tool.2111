
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
            this.LstTranslate = new System.Windows.Forms.ListView();
            this.LstTranslateTimeStart = new System.Windows.Forms.ColumnHeader();
            this.LstTranslateTimeEnd = new System.Windows.Forms.ColumnHeader();
            this.LstTranslateWordCount = new System.Windows.Forms.ColumnHeader();
            this.LstTranslateConfidence = new System.Windows.Forms.ColumnHeader();
            this.LstTranslateResult = new System.Windows.Forms.ColumnHeader();
            this.TabPanelMenu = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BtnModelSelect = new System.Windows.Forms.Button();
            this.TxtModelSelect = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtTemp = new System.Windows.Forms.TextBox();
            this.BtnExportResult = new System.Windows.Forms.Button();
            this.BtnExportText = new System.Windows.Forms.Button();
            this.BtnStartTask = new System.Windows.Forms.Button();
            this.BtnLoad = new System.Windows.Forms.Button();
            this.TxtMediaSrc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TabPanelMenuAdvance = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TxtMediaOutputTempPath = new System.Windows.Forms.TextBox();
            this.TxtMediaOutputSampleRate = new System.Windows.Forms.TextBox();
            this.TxtMediaOutputFormat = new System.Windows.Forms.TextBox();
            this.TxtMediaMediaAudioCodec = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtMediaCustomArguments = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label123 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TxtRecognizerMaxModelTrySingleLength = new System.Windows.Forms.TextBox();
            this.TxtRecognizerMaxModelTryTimes = new System.Windows.Forms.TextBox();
            this.TxtRecognizerMaxAlternatives = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.ChkRecognizerSetWord = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StatusMain.SuspendLayout();
            this.TabPanelMenu.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.TabPanelMenuAdvance.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            // LstTranslate
            // 
            this.LstTranslate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LstTranslate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LstTranslateTimeStart,
            this.LstTranslateTimeEnd,
            this.LstTranslateWordCount,
            this.LstTranslateConfidence,
            this.LstTranslateResult});
            this.LstTranslate.HideSelection = false;
            this.LstTranslate.Location = new System.Drawing.Point(0, 409);
            this.LstTranslate.Name = "LstTranslate";
            this.LstTranslate.Size = new System.Drawing.Size(1082, 614);
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
            // LstTranslateWordCount
            // 
            this.LstTranslateWordCount.Text = "词数";
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
            // TabPanelMenu
            // 
            this.TabPanelMenu.Controls.Add(this.tabPage1);
            this.TabPanelMenu.Controls.Add(this.TabPanelMenuAdvance);
            this.TabPanelMenu.Location = new System.Drawing.Point(0, 3);
            this.TabPanelMenu.Name = "TabPanelMenu";
            this.TabPanelMenu.SelectedIndex = 0;
            this.TabPanelMenu.Size = new System.Drawing.Size(1086, 400);
            this.TabPanelMenu.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnModelSelect);
            this.tabPage1.Controls.Add(this.TxtModelSelect);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.TxtTemp);
            this.tabPage1.Controls.Add(this.BtnExportResult);
            this.tabPage1.Controls.Add(this.BtnExportText);
            this.tabPage1.Controls.Add(this.BtnStartTask);
            this.tabPage1.Controls.Add(this.BtnLoad);
            this.tabPage1.Controls.Add(this.TxtMediaSrc);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 33);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1078, 363);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "主页";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnModelSelect
            // 
            this.BtnModelSelect.Location = new System.Drawing.Point(730, 14);
            this.BtnModelSelect.Name = "BtnModelSelect";
            this.BtnModelSelect.Size = new System.Drawing.Size(96, 30);
            this.BtnModelSelect.TabIndex = 17;
            this.BtnModelSelect.Text = "加载";
            this.BtnModelSelect.UseVisualStyleBackColor = true;
            this.BtnModelSelect.Click += new System.EventHandler(this.BtnModelSelect_Click);
            // 
            // TxtModelSelect
            // 
            this.TxtModelSelect.Location = new System.Drawing.Point(143, 11);
            this.TxtModelSelect.Name = "TxtModelSelect";
            this.TxtModelSelect.Size = new System.Drawing.Size(582, 30);
            this.TxtModelSelect.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 24);
            this.label2.TabIndex = 15;
            this.label2.Text = "选择训练模型";
            // 
            // TxtTemp
            // 
            this.TxtTemp.AllowDrop = true;
            this.TxtTemp.Location = new System.Drawing.Point(7, 169);
            this.TxtTemp.Multiline = true;
            this.TxtTemp.Name = "TxtTemp";
            this.TxtTemp.Size = new System.Drawing.Size(1046, 189);
            this.TxtTemp.TabIndex = 14;
            this.TxtTemp.Text = "点击开始说话...（暂不支持语音输入）";
            this.TxtTemp.Click += new System.EventHandler(this.TextTemp_Click);
            // 
            // BtnExportResult
            // 
            this.BtnExportResult.Location = new System.Drawing.Point(177, 127);
            this.BtnExportResult.Name = "BtnExportResult";
            this.BtnExportResult.Size = new System.Drawing.Size(163, 38);
            this.BtnExportResult.TabIndex = 10;
            this.BtnExportResult.Text = "导出结果(json)";
            this.BtnExportResult.UseVisualStyleBackColor = true;
            this.BtnExportResult.Click += new System.EventHandler(this.BtnExportJsonText_Click);
            // 
            // BtnExportText
            // 
            this.BtnExportText.Location = new System.Drawing.Point(177, 83);
            this.BtnExportText.Name = "BtnExportText";
            this.BtnExportText.Size = new System.Drawing.Size(163, 38);
            this.BtnExportText.TabIndex = 11;
            this.BtnExportText.Text = "导出文本(txt)";
            this.BtnExportText.UseVisualStyleBackColor = true;
            this.BtnExportText.Click += new System.EventHandler(this.BtnExportPlainText_Click);
            // 
            // BtnStartTask
            // 
            this.BtnStartTask.Enabled = false;
            this.BtnStartTask.Location = new System.Drawing.Point(8, 83);
            this.BtnStartTask.Name = "BtnStartTask";
            this.BtnStartTask.Size = new System.Drawing.Size(163, 80);
            this.BtnStartTask.TabIndex = 12;
            this.BtnStartTask.Text = "开始语音转文字";
            this.BtnStartTask.UseVisualStyleBackColor = true;
            this.BtnStartTask.Click += new System.EventHandler(this.BtnStartTask_Click);
            // 
            // BtnLoad
            // 
            this.BtnLoad.Location = new System.Drawing.Point(730, 50);
            this.BtnLoad.Name = "BtnLoad";
            this.BtnLoad.Size = new System.Drawing.Size(96, 30);
            this.BtnLoad.TabIndex = 13;
            this.BtnLoad.Text = "加载";
            this.BtnLoad.UseVisualStyleBackColor = true;
            this.BtnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // TxtMediaSrc
            // 
            this.TxtMediaSrc.Location = new System.Drawing.Point(143, 47);
            this.TxtMediaSrc.Name = "TxtMediaSrc";
            this.TxtMediaSrc.Size = new System.Drawing.Size(582, 30);
            this.TxtMediaSrc.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoEllipsis = true;
            this.label3.Location = new System.Drawing.Point(346, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(707, 73);
            this.label3.TabIndex = 7;
            this.label3.Text = "此工具是基于Vosk-api实现的离线语音识别样例体验版，正式版需服务器部署，如需，请联系作者(serfend@foxmail.com)。使用前需确认ffmpeg" +
    ".exe、ffprobe.exe是否已放到工具所在目录。开启程序后加载语音训练模型和媒体文件后可开始识别。";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 24);
            this.label1.TabIndex = 8;
            this.label1.Text = "选择音频文件";
            // 
            // TabPanelMenuAdvance
            // 
            this.TabPanelMenuAdvance.Controls.Add(this.groupBox2);
            this.TabPanelMenuAdvance.Controls.Add(this.groupBox1);
            this.TabPanelMenuAdvance.Location = new System.Drawing.Point(4, 33);
            this.TabPanelMenuAdvance.Name = "TabPanelMenuAdvance";
            this.TabPanelMenuAdvance.Padding = new System.Windows.Forms.Padding(3);
            this.TabPanelMenuAdvance.Size = new System.Drawing.Size(1078, 363);
            this.TabPanelMenuAdvance.TabIndex = 1;
            this.TabPanelMenuAdvance.Text = "设置";
            this.TabPanelMenuAdvance.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TxtMediaOutputTempPath);
            this.groupBox2.Controls.Add(this.TxtMediaOutputSampleRate);
            this.groupBox2.Controls.Add(this.TxtMediaOutputFormat);
            this.groupBox2.Controls.Add(this.TxtMediaMediaAudioCodec);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.TxtMediaCustomArguments);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label123);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(356, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(336, 347);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "媒体处理";
            // 
            // TxtMediaOutputTempPath
            // 
            this.TxtMediaOutputTempPath.Location = new System.Drawing.Point(6, 302);
            this.TxtMediaOutputTempPath.Name = "TxtMediaOutputTempPath";
            this.TxtMediaOutputTempPath.Size = new System.Drawing.Size(320, 30);
            this.TxtMediaOutputTempPath.TabIndex = 7;
            this.TxtMediaOutputTempPath.Text = "temp_convert.wav";
            // 
            // TxtMediaOutputSampleRate
            // 
            this.TxtMediaOutputSampleRate.Location = new System.Drawing.Point(6, 245);
            this.TxtMediaOutputSampleRate.Name = "TxtMediaOutputSampleRate";
            this.TxtMediaOutputSampleRate.Size = new System.Drawing.Size(320, 30);
            this.TxtMediaOutputSampleRate.TabIndex = 7;
            this.TxtMediaOutputSampleRate.Text = "16000";
            // 
            // TxtMediaOutputFormat
            // 
            this.TxtMediaOutputFormat.Location = new System.Drawing.Point(6, 188);
            this.TxtMediaOutputFormat.Name = "TxtMediaOutputFormat";
            this.TxtMediaOutputFormat.Size = new System.Drawing.Size(320, 30);
            this.TxtMediaOutputFormat.TabIndex = 7;
            this.TxtMediaOutputFormat.Text = "wav";
            // 
            // TxtMediaMediaAudioCodec
            // 
            this.TxtMediaMediaAudioCodec.Location = new System.Drawing.Point(6, 126);
            this.TxtMediaMediaAudioCodec.Name = "TxtMediaMediaAudioCodec";
            this.TxtMediaMediaAudioCodec.Size = new System.Drawing.Size(320, 30);
            this.TxtMediaMediaAudioCodec.TabIndex = 7;
            this.TxtMediaMediaAudioCodec.Text = "pcm_s16le";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 275);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 24);
            this.label9.TabIndex = 6;
            this.label9.Text = "输出临时文件路径";
            // 
            // TxtMediaCustomArguments
            // 
            this.TxtMediaCustomArguments.Location = new System.Drawing.Point(6, 64);
            this.TxtMediaCustomArguments.Name = "TxtMediaCustomArguments";
            this.TxtMediaCustomArguments.Size = new System.Drawing.Size(320, 30);
            this.TxtMediaCustomArguments.TabIndex = 7;
            this.TxtMediaCustomArguments.Text = "-ac 1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(212, 24);
            this.label8.TabIndex = 6;
            this.label8.Text = "采样率(SampleRate/HZ)";
            // 
            // label123
            // 
            this.label123.AutoSize = true;
            this.label123.Location = new System.Drawing.Point(6, 161);
            this.label123.Name = "label123";
            this.label123.Size = new System.Drawing.Size(156, 24);
            this.label123.TabIndex = 6;
            this.label123.Text = "输出格式(Format)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 99);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(200, 24);
            this.label6.TabIndex = 6;
            this.label6.Text = "编码格式(AudioCodec)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(172, 24);
            this.label5.TabIndex = 6;
            this.label5.Text = "FFMPEG自定义参数";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtRecognizerMaxModelTrySingleLength);
            this.groupBox1.Controls.Add(this.TxtRecognizerMaxModelTryTimes);
            this.groupBox1.Controls.Add(this.TxtRecognizerMaxAlternatives);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.ChkRecognizerSetWord);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(8, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 299);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "语音识别";
            // 
            // TxtRecognizerMaxModelTrySingleLength
            // 
            this.TxtRecognizerMaxModelTrySingleLength.Location = new System.Drawing.Point(166, 168);
            this.TxtRecognizerMaxModelTrySingleLength.Name = "TxtRecognizerMaxModelTrySingleLength";
            this.TxtRecognizerMaxModelTrySingleLength.Size = new System.Drawing.Size(108, 30);
            this.TxtRecognizerMaxModelTrySingleLength.TabIndex = 4;
            this.TxtRecognizerMaxModelTrySingleLength.Text = "0";
            // 
            // TxtRecognizerMaxModelTryTimes
            // 
            this.TxtRecognizerMaxModelTryTimes.Location = new System.Drawing.Point(166, 132);
            this.TxtRecognizerMaxModelTryTimes.Name = "TxtRecognizerMaxModelTryTimes";
            this.TxtRecognizerMaxModelTryTimes.Size = new System.Drawing.Size(108, 30);
            this.TxtRecognizerMaxModelTryTimes.TabIndex = 4;
            this.TxtRecognizerMaxModelTryTimes.Text = "0";
            // 
            // TxtRecognizerMaxAlternatives
            // 
            this.TxtRecognizerMaxAlternatives.Location = new System.Drawing.Point(6, 64);
            this.TxtRecognizerMaxAlternatives.Name = "TxtRecognizerMaxAlternatives";
            this.TxtRecognizerMaxAlternatives.Size = new System.Drawing.Size(108, 30);
            this.TxtRecognizerMaxAlternatives.TabIndex = 4;
            this.TxtRecognizerMaxAlternatives.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(151, 24);
            this.label11.TabIndex = 2;
            this.label11.Text = "模型加载超时/ms";
            // 
            // ChkRecognizerSetWord
            // 
            this.ChkRecognizerSetWord.AutoSize = true;
            this.ChkRecognizerSetWord.Checked = true;
            this.ChkRecognizerSetWord.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkRecognizerSetWord.Location = new System.Drawing.Point(6, 99);
            this.ChkRecognizerSetWord.Name = "ChkRecognizerSetWord";
            this.ChkRecognizerSetWord.Size = new System.Drawing.Size(108, 28);
            this.ChkRecognizerSetWord.TabIndex = 3;
            this.ChkRecognizerSetWord.Text = "是否分词";
            this.ChkRecognizerSetWord.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 132);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 24);
            this.label10.TabIndex = 2;
            this.label10.Text = "模型尝试加载次数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(215, 24);
            this.label4.TabIndex = 2;
            this.label4.Text = "选择度(MaxAlternatives)";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 1062);
            this.Controls.Add(this.TabPanelMenu);
            this.Controls.Add(this.LstTranslate);
            this.Controls.Add(this.StatusMain);
            this.Name = "FrmMain";
            this.Text = "STT测试工具";
            this.StatusMain.ResumeLayout(false);
            this.StatusMain.PerformLayout();
            this.TabPanelMenu.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.TabPanelMenuAdvance.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip StatusMain;
        private System.Windows.Forms.ToolStripStatusLabel StatusMainTip;
        private System.Windows.Forms.ToolStripProgressBar StatusMainProcess;
        private System.Windows.Forms.ListView LstTranslate;
        private System.Windows.Forms.ColumnHeader LstTranslateTimeStart;
        private System.Windows.Forms.ColumnHeader LstTranslateTimeEnd;
        private System.Windows.Forms.ColumnHeader LstTranslateConfidence;
        private System.Windows.Forms.ColumnHeader LstTranslateResult;
        private System.Windows.Forms.ToolStripStatusLabel StatusMainLog;
        private System.Windows.Forms.ColumnHeader LstTranslateWordCount;
        private System.Windows.Forms.TabControl TabPanelMenu;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage TabPanelMenuAdvance;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtMediaOutputTempPath;
        private System.Windows.Forms.TextBox TxtMediaOutputSampleRate;
        private System.Windows.Forms.TextBox TxtMediaOutputFormat;
        private System.Windows.Forms.TextBox TxtMediaMediaAudioCodec;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtMediaCustomArguments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label123;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtRecognizerMaxModelTrySingleLength;
        private System.Windows.Forms.TextBox TxtRecognizerMaxModelTryTimes;
        private System.Windows.Forms.TextBox TxtRecognizerMaxAlternatives;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox ChkRecognizerSetWord;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnModelSelect;
        private System.Windows.Forms.TextBox TxtModelSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtTemp;
        private System.Windows.Forms.Button BtnExportResult;
        private System.Windows.Forms.Button BtnExportText;
        private System.Windows.Forms.Button BtnStartTask;
        private System.Windows.Forms.Button BtnLoad;
        private System.Windows.Forms.TextBox TxtMediaSrc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}