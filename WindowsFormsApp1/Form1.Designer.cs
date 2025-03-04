namespace WindowsFormsApp1
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.Btn_Output = new System.Windows.Forms.Button();
            this.Btn_Quit = new System.Windows.Forms.Button();
            this.Gbx_OutputVoltage = new System.Windows.Forms.GroupBox();
            this.Lbl_Device = new System.Windows.Forms.Label();
            this.Lbl_Amplitude = new System.Windows.Forms.Label();
            this.Lbl_DcOffset = new System.Windows.Forms.Label();
            this.Lbl_DutyCycle = new System.Windows.Forms.Label();
            this.Lbl_Waveform = new System.Windows.Forms.Label();
            this.Gbx_FreqRange = new System.Windows.Forms.GroupBox();
            this.Rbtn_10000Hz = new System.Windows.Forms.RadioButton();
            this.Rbtn_1000Hz = new System.Windows.Forms.RadioButton();
            this.Rbtn_100Hz = new System.Windows.Forms.RadioButton();
            this.Rbtn_10Hz = new System.Windows.Forms.RadioButton();
            this.Rbtn_1Hz = new System.Windows.Forms.RadioButton();
            this.Lbl_ActualFreq = new System.Windows.Forms.Label();
            this.Lbl_ActFreqValue = new System.Windows.Forms.Label();
            this.Cbx_Devices = new System.Windows.Forms.ComboBox();
            this.Cbx_Waveform = new System.Windows.Forms.ComboBox();
            this.NumUD_Amplitude = new System.Windows.Forms.NumericUpDown();
            this.NumUD_DutyCycle = new System.Windows.Forms.NumericUpDown();
            this.NumUD_DcOffset = new System.Windows.Forms.NumericUpDown();
            this.cht_Data = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.NumUD_Frequency = new System.Windows.Forms.NumericUpDown();
            this.Gbx_OutputVoltage.SuspendLayout();
            this.Gbx_FreqRange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_Amplitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_DutyCycle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_DcOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_Data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_Frequency)).BeginInit();
            this.SuspendLayout();
            // 
            // Btn_Output
            // 
            this.Btn_Output.Location = new System.Drawing.Point(19, 19);
            this.Btn_Output.Name = "Btn_Output";
            this.Btn_Output.Size = new System.Drawing.Size(68, 55);
            this.Btn_Output.TabIndex = 0;
            this.Btn_Output.Text = "Output";
            this.Btn_Output.UseVisualStyleBackColor = true;
            this.Btn_Output.Click += new System.EventHandler(this.Btn_Output_Click);
            this.Btn_Output.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Btn_Output_MouseClick);
            // 
            // Btn_Quit
            // 
            this.Btn_Quit.Location = new System.Drawing.Point(93, 19);
            this.Btn_Quit.Name = "Btn_Quit";
            this.Btn_Quit.Size = new System.Drawing.Size(68, 55);
            this.Btn_Quit.TabIndex = 1;
            this.Btn_Quit.Text = "Quit";
            this.Btn_Quit.UseVisualStyleBackColor = true;
            this.Btn_Quit.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Btn_Quit_MouseClick);
            // 
            // Gbx_OutputVoltage
            // 
            this.Gbx_OutputVoltage.Controls.Add(this.Btn_Quit);
            this.Gbx_OutputVoltage.Controls.Add(this.Btn_Output);
            this.Gbx_OutputVoltage.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gbx_OutputVoltage.Location = new System.Drawing.Point(17, 352);
            this.Gbx_OutputVoltage.Name = "Gbx_OutputVoltage";
            this.Gbx_OutputVoltage.Size = new System.Drawing.Size(177, 86);
            this.Gbx_OutputVoltage.TabIndex = 2;
            this.Gbx_OutputVoltage.TabStop = false;
            this.Gbx_OutputVoltage.Text = "Output Voltage";
            // 
            // Lbl_Device
            // 
            this.Lbl_Device.AutoSize = true;
            this.Lbl_Device.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Device.Location = new System.Drawing.Point(33, 25);
            this.Lbl_Device.Name = "Lbl_Device";
            this.Lbl_Device.Size = new System.Drawing.Size(54, 14);
            this.Lbl_Device.TabIndex = 3;
            this.Lbl_Device.Text = "Devices:";
            // 
            // Lbl_Amplitude
            // 
            this.Lbl_Amplitude.AutoSize = true;
            this.Lbl_Amplitude.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Amplitude.Location = new System.Drawing.Point(33, 53);
            this.Lbl_Amplitude.Name = "Lbl_Amplitude";
            this.Lbl_Amplitude.Size = new System.Drawing.Size(69, 14);
            this.Lbl_Amplitude.TabIndex = 4;
            this.Lbl_Amplitude.Text = "Amplitude:";
            // 
            // Lbl_DcOffset
            // 
            this.Lbl_DcOffset.AutoSize = true;
            this.Lbl_DcOffset.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_DcOffset.Location = new System.Drawing.Point(33, 81);
            this.Lbl_DcOffset.Name = "Lbl_DcOffset";
            this.Lbl_DcOffset.Size = new System.Drawing.Size(64, 14);
            this.Lbl_DcOffset.TabIndex = 5;
            this.Lbl_DcOffset.Text = "DC Offset:";
            // 
            // Lbl_DutyCycle
            // 
            this.Lbl_DutyCycle.AutoSize = true;
            this.Lbl_DutyCycle.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_DutyCycle.Location = new System.Drawing.Point(33, 109);
            this.Lbl_DutyCycle.Name = "Lbl_DutyCycle";
            this.Lbl_DutyCycle.Size = new System.Drawing.Size(73, 14);
            this.Lbl_DutyCycle.TabIndex = 6;
            this.Lbl_DutyCycle.Text = "Duty Cycle:";
            // 
            // Lbl_Waveform
            // 
            this.Lbl_Waveform.AutoSize = true;
            this.Lbl_Waveform.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Waveform.Location = new System.Drawing.Point(33, 137);
            this.Lbl_Waveform.Name = "Lbl_Waveform";
            this.Lbl_Waveform.Size = new System.Drawing.Size(67, 14);
            this.Lbl_Waveform.TabIndex = 7;
            this.Lbl_Waveform.Text = "Waveform:";
            // 
            // Gbx_FreqRange
            // 
            this.Gbx_FreqRange.Controls.Add(this.Rbtn_10000Hz);
            this.Gbx_FreqRange.Controls.Add(this.Rbtn_1000Hz);
            this.Gbx_FreqRange.Controls.Add(this.Rbtn_100Hz);
            this.Gbx_FreqRange.Controls.Add(this.Rbtn_10Hz);
            this.Gbx_FreqRange.Controls.Add(this.Rbtn_1Hz);
            this.Gbx_FreqRange.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Gbx_FreqRange.Location = new System.Drawing.Point(99, 172);
            this.Gbx_FreqRange.Name = "Gbx_FreqRange";
            this.Gbx_FreqRange.Size = new System.Drawing.Size(131, 142);
            this.Gbx_FreqRange.TabIndex = 8;
            this.Gbx_FreqRange.TabStop = false;
            this.Gbx_FreqRange.Text = "Frequency Range:";
            // 
            // Rbtn_10000Hz
            // 
            this.Rbtn_10000Hz.AutoSize = true;
            this.Rbtn_10000Hz.Location = new System.Drawing.Point(6, 117);
            this.Rbtn_10000Hz.Name = "Rbtn_10000Hz";
            this.Rbtn_10000Hz.Size = new System.Drawing.Size(71, 18);
            this.Rbtn_10000Hz.TabIndex = 4;
            this.Rbtn_10000Hz.TabStop = true;
            this.Rbtn_10000Hz.Text = "x10 kHz";
            this.Rbtn_10000Hz.UseVisualStyleBackColor = true;
            this.Rbtn_10000Hz.CheckedChanged += new System.EventHandler(this.Rbtn_10000Hz_CheckedChanged);
            // 
            // Rbtn_1000Hz
            // 
            this.Rbtn_1000Hz.AutoSize = true;
            this.Rbtn_1000Hz.Location = new System.Drawing.Point(6, 93);
            this.Rbtn_1000Hz.Name = "Rbtn_1000Hz";
            this.Rbtn_1000Hz.Size = new System.Drawing.Size(64, 18);
            this.Rbtn_1000Hz.TabIndex = 3;
            this.Rbtn_1000Hz.TabStop = true;
            this.Rbtn_1000Hz.Text = "x1 kHz";
            this.Rbtn_1000Hz.UseVisualStyleBackColor = true;
            this.Rbtn_1000Hz.CheckedChanged += new System.EventHandler(this.Rbtn_1000Hz_CheckedChanged);
            // 
            // Rbtn_100Hz
            // 
            this.Rbtn_100Hz.AutoSize = true;
            this.Rbtn_100Hz.Location = new System.Drawing.Point(6, 69);
            this.Rbtn_100Hz.Name = "Rbtn_100Hz";
            this.Rbtn_100Hz.Size = new System.Drawing.Size(71, 18);
            this.Rbtn_100Hz.TabIndex = 2;
            this.Rbtn_100Hz.TabStop = true;
            this.Rbtn_100Hz.Text = "x100 Hz";
            this.Rbtn_100Hz.UseVisualStyleBackColor = true;
            this.Rbtn_100Hz.CheckedChanged += new System.EventHandler(this.Rbtn_100Hz_CheckedChanged);
            // 
            // Rbtn_10Hz
            // 
            this.Rbtn_10Hz.AutoSize = true;
            this.Rbtn_10Hz.Location = new System.Drawing.Point(6, 45);
            this.Rbtn_10Hz.Name = "Rbtn_10Hz";
            this.Rbtn_10Hz.Size = new System.Drawing.Size(64, 18);
            this.Rbtn_10Hz.TabIndex = 1;
            this.Rbtn_10Hz.TabStop = true;
            this.Rbtn_10Hz.Text = "x10 Hz";
            this.Rbtn_10Hz.UseVisualStyleBackColor = true;
            this.Rbtn_10Hz.CheckedChanged += new System.EventHandler(this.Rbtn_10Hz_CheckedChanged);
            // 
            // Rbtn_1Hz
            // 
            this.Rbtn_1Hz.AutoSize = true;
            this.Rbtn_1Hz.Location = new System.Drawing.Point(6, 21);
            this.Rbtn_1Hz.Name = "Rbtn_1Hz";
            this.Rbtn_1Hz.Size = new System.Drawing.Size(57, 18);
            this.Rbtn_1Hz.TabIndex = 0;
            this.Rbtn_1Hz.TabStop = true;
            this.Rbtn_1Hz.Text = "x1 Hz";
            this.Rbtn_1Hz.UseVisualStyleBackColor = true;
            this.Rbtn_1Hz.CheckedChanged += new System.EventHandler(this.Rbtn_1Hz_CheckedChanged);
            // 
            // Lbl_ActualFreq
            // 
            this.Lbl_ActualFreq.AutoSize = true;
            this.Lbl_ActualFreq.Font = new System.Drawing.Font("Mongolian Baiti", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ActualFreq.Location = new System.Drawing.Point(21, 328);
            this.Lbl_ActualFreq.Name = "Lbl_ActualFreq";
            this.Lbl_ActualFreq.Size = new System.Drawing.Size(107, 14);
            this.Lbl_ActualFreq.TabIndex = 9;
            this.Lbl_ActualFreq.Text = "Actual Frequency:";
            // 
            // Lbl_ActFreqValue
            // 
            this.Lbl_ActFreqValue.AutoSize = true;
            this.Lbl_ActFreqValue.Location = new System.Drawing.Point(136, 332);
            this.Lbl_ActFreqValue.Name = "Lbl_ActFreqValue";
            this.Lbl_ActFreqValue.Size = new System.Drawing.Size(0, 13);
            this.Lbl_ActFreqValue.TabIndex = 10;
            // 
            // Cbx_Devices
            // 
            this.Cbx_Devices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbx_Devices.Font = new System.Drawing.Font("Mongolian Baiti", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbx_Devices.FormattingEnabled = true;
            this.Cbx_Devices.Location = new System.Drawing.Point(132, 24);
            this.Cbx_Devices.Name = "Cbx_Devices";
            this.Cbx_Devices.Size = new System.Drawing.Size(98, 19);
            this.Cbx_Devices.TabIndex = 11;
            // 
            // Cbx_Waveform
            // 
            this.Cbx_Waveform.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cbx_Waveform.Font = new System.Drawing.Font("Mongolian Baiti", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Cbx_Waveform.FormattingEnabled = true;
            this.Cbx_Waveform.Location = new System.Drawing.Point(132, 136);
            this.Cbx_Waveform.Name = "Cbx_Waveform";
            this.Cbx_Waveform.Size = new System.Drawing.Size(98, 19);
            this.Cbx_Waveform.TabIndex = 12;
            this.Cbx_Waveform.SelectedIndexChanged += new System.EventHandler(this.Cbx_Waveform_SelectedIndexChanged);
            // 
            // NumUD_Amplitude
            // 
            this.NumUD_Amplitude.DecimalPlaces = 2;
            this.NumUD_Amplitude.Location = new System.Drawing.Point(132, 53);
            this.NumUD_Amplitude.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumUD_Amplitude.Name = "NumUD_Amplitude";
            this.NumUD_Amplitude.Size = new System.Drawing.Size(98, 20);
            this.NumUD_Amplitude.TabIndex = 13;
            this.NumUD_Amplitude.ValueChanged += new System.EventHandler(this.NumUD_Amplitude_ValueChanged);
            // 
            // NumUD_DutyCycle
            // 
            this.NumUD_DutyCycle.DecimalPlaces = 2;
            this.NumUD_DutyCycle.Location = new System.Drawing.Point(132, 107);
            this.NumUD_DutyCycle.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.NumUD_DutyCycle.Name = "NumUD_DutyCycle";
            this.NumUD_DutyCycle.Size = new System.Drawing.Size(98, 20);
            this.NumUD_DutyCycle.TabIndex = 14;
            this.NumUD_DutyCycle.ValueChanged += new System.EventHandler(this.NumUD_DutyCycle_ValueChanged);
            // 
            // NumUD_DcOffset
            // 
            this.NumUD_DcOffset.DecimalPlaces = 2;
            this.NumUD_DcOffset.Location = new System.Drawing.Point(132, 79);
            this.NumUD_DcOffset.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumUD_DcOffset.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.NumUD_DcOffset.Name = "NumUD_DcOffset";
            this.NumUD_DcOffset.Size = new System.Drawing.Size(98, 20);
            this.NumUD_DcOffset.TabIndex = 15;
            this.NumUD_DcOffset.ValueChanged += new System.EventHandler(this.NumUD_DcOffset_ValueChanged);
            // 
            // cht_Data
            // 
            chartArea1.Name = "ChartArea1";
            this.cht_Data.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.cht_Data.Legends.Add(legend1);
            this.cht_Data.Location = new System.Drawing.Point(248, 24);
            this.cht_Data.Name = "cht_Data";
            this.cht_Data.Size = new System.Drawing.Size(540, 414);
            this.cht_Data.TabIndex = 16;
            this.cht_Data.Text = "cht_Data";
            // 
            // NumUD_Frequency
            // 
            this.NumUD_Frequency.DecimalPlaces = 2;
            this.NumUD_Frequency.Location = new System.Drawing.Point(17, 230);
            this.NumUD_Frequency.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.NumUD_Frequency.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUD_Frequency.Name = "NumUD_Frequency";
            this.NumUD_Frequency.Size = new System.Drawing.Size(76, 20);
            this.NumUD_Frequency.TabIndex = 17;
            this.NumUD_Frequency.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumUD_Frequency.ValueChanged += new System.EventHandler(this.NumUD_Frequency_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NumUD_Frequency);
            this.Controls.Add(this.cht_Data);
            this.Controls.Add(this.NumUD_DcOffset);
            this.Controls.Add(this.NumUD_DutyCycle);
            this.Controls.Add(this.NumUD_Amplitude);
            this.Controls.Add(this.Cbx_Waveform);
            this.Controls.Add(this.Cbx_Devices);
            this.Controls.Add(this.Lbl_ActFreqValue);
            this.Controls.Add(this.Lbl_ActualFreq);
            this.Controls.Add(this.Gbx_FreqRange);
            this.Controls.Add(this.Lbl_Waveform);
            this.Controls.Add(this.Lbl_DutyCycle);
            this.Controls.Add(this.Lbl_DcOffset);
            this.Controls.Add(this.Lbl_Amplitude);
            this.Controls.Add(this.Lbl_Device);
            this.Controls.Add(this.Gbx_OutputVoltage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Gbx_OutputVoltage.ResumeLayout(false);
            this.Gbx_FreqRange.ResumeLayout(false);
            this.Gbx_FreqRange.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_Amplitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_DutyCycle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_DcOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cht_Data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumUD_Frequency)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_Output;
        private System.Windows.Forms.Button Btn_Quit;
        private System.Windows.Forms.GroupBox Gbx_OutputVoltage;
        private System.Windows.Forms.Label Lbl_Device;
        private System.Windows.Forms.Label Lbl_Amplitude;
        private System.Windows.Forms.Label Lbl_DcOffset;
        private System.Windows.Forms.Label Lbl_DutyCycle;
        private System.Windows.Forms.Label Lbl_Waveform;
        private System.Windows.Forms.GroupBox Gbx_FreqRange;
        private System.Windows.Forms.RadioButton Rbtn_10000Hz;
        private System.Windows.Forms.RadioButton Rbtn_1000Hz;
        private System.Windows.Forms.RadioButton Rbtn_100Hz;
        private System.Windows.Forms.RadioButton Rbtn_10Hz;
        private System.Windows.Forms.RadioButton Rbtn_1Hz;
        private System.Windows.Forms.Label Lbl_ActualFreq;
        private System.Windows.Forms.Label Lbl_ActFreqValue;
        private System.Windows.Forms.ComboBox Cbx_Devices;
        private System.Windows.Forms.ComboBox Cbx_Waveform;
        private System.Windows.Forms.NumericUpDown NumUD_Amplitude;
        private System.Windows.Forms.NumericUpDown NumUD_DutyCycle;
        private System.Windows.Forms.NumericUpDown NumUD_DcOffset;
        private System.Windows.Forms.DataVisualization.Charting.Chart cht_Data;
        private System.Windows.Forms.NumericUpDown NumUD_Frequency;
    }
}

