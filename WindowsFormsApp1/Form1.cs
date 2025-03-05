using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using NationalInstruments.DAQmx;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using NationalInstruments;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        private Task myTask;
        private AnalogSingleChannelWriter writer;

        private int MaxA2Drate = 833000;
        private int sampleRate;
        private int pointsPerCycle;
        private int maxBufferSize = 8191; //Fix this buffer value
        private int MAXvoltageRange;
        private int MINvoltageRange;
        private bool buttonOnOff;
        private decimal outputFrequency;
        private decimal fRangeValue;
        private string[] aoChannels;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cht_Data.Series.Clear(); //Clear the chart during form load
            cht_Data.ChartAreas.Clear(); //Clear data area

            ChartArea chartArea = new ChartArea();
            cht_Data.ChartAreas.Add(chartArea);

            // Create a series to hold the waveform data
            Series waveformSeries = new Series("Waveform");
            waveformSeries.ChartType = SeriesChartType.Line;
            waveformSeries.BorderWidth = 2;
            cht_Data.Series.Add(waveformSeries);
            cht_Data.ChartAreas[0].AxisY.Maximum = 10;
            cht_Data.ChartAreas[0].AxisY.Minimum = -10;

            //Get device list
            PopulateDevices();

            //Add all the waves to the combobox
            Cbx_Waveform.Items.Add("Sine");
            Cbx_Waveform.Items.Add("Square");
            Cbx_Waveform.Items.Add("Triangle");
            Cbx_Waveform.Items.Add("Sawtooth");
            Cbx_Waveform.Items.Add("TTL");

            //Make sine 100hz default
            Cbx_Waveform.SelectedIndex = 0;
            sampleRate = 833000;
            Rbtn_1000Hz.Checked = true;
            pointsPerCycle = (int)(sampleRate / 1000);
            NumUD_Frequency.Value = 10;

            try
            {
                myTask = new Task();
                if (myTask != null)
                {
                        string channels = Cbx_Devices.SelectedItem.ToString();
                        myTask.AOChannels.CreateVoltageChannel(channels, "", -10, 10, AOVoltageUnits.Volts);
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error setting up the Analog Channels", ex.Message); }

            myTask.Timing.ConfigureSampleClock("", sampleRate, SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, pointsPerCycle);
            myTask.AOChannels.All.UseOnlyOnBoardMemory = true;
            writer = new AnalogSingleChannelWriter(myTask.Stream);

            //Default = sine
            NumUD_Amplitude.Value = 5;
            NumUD_Frequency.Value = 5;
            Rbtn_1Hz.Enabled = true;
            NumUD_DutyCycle.Value = 50;
            NumUD_DcOffset.Value = 0;

            //Initializing buttons
            buttonOnOff = false;
            Btn_Output.BackColor = Color.Red;
            Btn_Output.Text = "OFF";



        }

        private void PopulateDevices()
        {
            Cbx_Devices.Items.Clear();

            //get all channels for AO
            aoChannels = DaqSystem.Local.GetPhysicalChannels(PhysicalChannelTypes.AO, PhysicalChannelAccess.External);

            //Check for channels and add to combobox
            if (aoChannels.Length > 0)
            {
                // Iterate over all the AO channels and add them to the ComboBox
                foreach (string channel in aoChannels)
                {
                    Cbx_Devices.Items.Add(channel);
                }
                Cbx_Devices.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("No Analog Output channels found.");
            }
        }


        private void NumUD_Amplitude_ValueChanged(object sender, EventArgs e)
        {
            WaveformGeneration();
        }

        private void NumUD_DcOffset_ValueChanged(object sender, EventArgs e)
        {
            WaveformGeneration();
        }

        private void NumUD_DutyCycle_ValueChanged(object sender, EventArgs e)
        {
            WaveformGeneration();
        }

        private void Cbx_Waveform_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedWaveform = Cbx_Waveform.SelectedIndex;

            switch (selectedWaveform)
            {
                case 0: // Sine Wave
                    NumUD_Amplitude.Enabled = true; 
                    NumUD_DutyCycle.Enabled = false;
                    NumUD_DcOffset.Enabled = true; 
                    MINvoltageRange = -10; 
                    MAXvoltageRange = 10;
                    WaveformGeneration();
                    break;
                case 1: // Square Wave
                    NumUD_Amplitude.Enabled = true;
                    NumUD_DutyCycle.Enabled = true;
                    NumUD_DcOffset.Enabled = true;
                    MINvoltageRange = -10;
                    MAXvoltageRange = 10;
                    WaveformGeneration();
                    break;

                case 2: // Triangle Wave
                    NumUD_Amplitude.Enabled = true; 
                    NumUD_DutyCycle.Enabled = true; 
                    NumUD_DcOffset.Enabled = true;
                    MINvoltageRange = -10;  
                    MAXvoltageRange = 10;
                    WaveformGeneration();
                    break;

                case 3: // Sawtooth Wave
                    NumUD_Amplitude.Enabled = true; 
                    NumUD_DutyCycle.Enabled = false; 
                    NumUD_DcOffset.Enabled = true; 
                    MINvoltageRange = -10; 
                    MAXvoltageRange = 10;
                    WaveformGeneration();
                    break;

                case 4: // TTL Wave
                    NumUD_Amplitude.Enabled = false;
                    NumUD_DutyCycle.Enabled = true;
                    NumUD_DcOffset.Enabled = false; 
                    MINvoltageRange = 0;
                    MAXvoltageRange = 5;
                    WaveformGeneration();
                    break;

                default:
                    break;
            }

            // Update the amplitude range based on selected waveform
            NumUD_Amplitude.Minimum = (decimal)MINvoltageRange;
            NumUD_Amplitude.Maximum = (decimal)MAXvoltageRange;
        }

        private void Btn_Output_MouseClick(object sender, MouseEventArgs e)
        {
            if (buttonOnOff == false)
            {
                buttonOnOff = true;

                int sampleRate = MaxA2Drate;

                double [] waveform = WaveformGeneration();

                Btn_Output.Text = "ON";
                Btn_Output.BackColor = Color.Green;
                buttonOnOff = true;

            }
            else
            {
                Btn_Output.Text = "OFF";
                Btn_Output.BackColor = Color.Red;
                buttonOnOff = false;

                myTask.Stop();
                double[] zeroWave = new double[pointsPerCycle];

                for (int i = 0; i < pointsPerCycle; i++) { zeroWave[i] = 0; }
                writer.WriteMultiSample(false, zeroWave);
                myTask.Start();
            }
        }

        private void Btn_Quit_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void NumUD_Frequency_ValueChanged(object sender, EventArgs e)
        {
            outputFrequency = NumUD_Frequency.Value * fRangeValue;
            Lbl_ActFreqValue.Text = outputFrequency.ToString();

            WaveformGeneration();

        }

        private void Rbtn_1Hz_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_1Hz.Checked) 
            {
                Rbtn_1Hz.Checked = true;
                Rbtn_10Hz.Checked = false;
                Rbtn_100Hz.Checked = false;
                Rbtn_1000Hz.Checked = false;
                Rbtn_10000Hz.Checked = false;
                fRangeValue = 1.00M;
                WaveformGeneration();

            }
        }

        private void Rbtn_10Hz_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_10Hz.Checked)
            {
                Rbtn_1Hz.Checked = false;
                Rbtn_10Hz.Checked = true;
                Rbtn_100Hz.Checked = false;
                Rbtn_1000Hz.Checked = false;
                Rbtn_10000Hz.Checked = false;
                fRangeValue = 10.00M;
                WaveformGeneration();

            }
        }

        private void Rbtn_100Hz_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_100Hz.Checked)
            {
                Rbtn_1Hz.Checked = false;
                Rbtn_10Hz.Checked = false;
                Rbtn_100Hz.Checked = true;
                Rbtn_1000Hz.Checked = false;
                Rbtn_10000Hz.Checked = false;
                fRangeValue = 100.00M;
                WaveformGeneration();

            }
        }

        private void Rbtn_1000Hz_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_1000Hz.Checked)
            {
                Rbtn_1Hz.Checked = false;
                Rbtn_10Hz.Checked = false;
                Rbtn_100Hz.Checked = false;
                Rbtn_1000Hz.Checked = true;
                Rbtn_10000Hz.Checked = false;
                fRangeValue = 1000.00M;
                WaveformGeneration();

            }
        }

        private void Rbtn_10000Hz_CheckedChanged(object sender, EventArgs e)
        {
            if (Rbtn_10000Hz.Checked)
            {
                Rbtn_1Hz.Checked = false;
                Rbtn_10Hz.Checked = false;
                Rbtn_100Hz.Checked = false;
                Rbtn_1000Hz.Checked = false;
                Rbtn_10000Hz.Checked = true;
                fRangeValue = 10000.00M;
                WaveformGeneration();
            }
        }

        private void Btn_Output_Click(object sender, EventArgs e)
        {

        }

        private double[] WaveformGeneration()
        {
            if (buttonOnOff == true)
            {
                double amplitude = (double)NumUD_Amplitude.Value;
                double frequency = (double)NumUD_Frequency.Value * (double)fRangeValue;
                double dutyCycle = (double)NumUD_DutyCycle.Value;
                double dcOffset = (double)NumUD_DcOffset.Value;

                if (frequency > 101)
                {
                    sampleRate = 833000;
                }
                else
                {
                    sampleRate = (int)(maxBufferSize * frequency);
                }
                pointsPerCycle = (int)(sampleRate / frequency);

                // Ensure the points per cycle does not exceed the max buffer size
                if (pointsPerCycle > maxBufferSize)
                {
                    pointsPerCycle = maxBufferSize;
                }

                //Waveform array size needs to be smaller than the buffer
                double[] waveform = new double[pointsPerCycle]; //Sets the waveform to the nmber of points per cycle

                int highPoints = (int)(pointsPerCycle * (dutyCycle / 100)); //duty cycle is 1-99 (needs to be percent)
                int lowPoints = pointsPerCycle - highPoints;
                double actualFrequency = (double)sampleRate / pointsPerCycle;
                Lbl_ActFreqValue.Text = actualFrequency.ToString(); //send actual frequency to label display

                //use a SWITCH CASE to select which function to display
                switch (Cbx_Waveform.SelectedIndex)
                {
                    case 0: //sine
                        for (int i = 0; i < pointsPerCycle; i++)
                        {
                            waveform[i] = amplitude * Math.Sin(2 * Math.PI * frequency * i / sampleRate) + dcOffset;
                        }
                        break;

                    case 1: //Square
                            //Need to make sure duty cycle is incorperated

                        for (int i = 0; i < pointsPerCycle; i++)
                        {
                            if (i < highPoints)
                            {
                                waveform[i] = amplitude + dcOffset; //Sets the high level amplitude (positive)
                            }
                            else
                            {
                                waveform[i] = -amplitude + dcOffset; //Sets the lower level of the amplitude (with DC off) (Neg amp)
                            }
                        }
                        break;

                    case 2: //Triangle

                        for (int i = 0; i < pointsPerCycle; i++)
                        {
                            if (i < highPoints) // Rising part of the wave
                                                // 1 is the normalization factor 
                            {
                                waveform[i] = amplitude * (2.0 * i / highPoints - 1) + dcOffset;
                            }
                            else
                            {
                                //decrease from +Amplitude to -Amplitude
                                waveform[i] = amplitude * (1 - 2.0 * (i - highPoints) / lowPoints) + dcOffset;
                            }
                        }
                        break;

                    case 3: //Sawtooth
                        for (int i = 0; i < pointsPerCycle; i++)
                        {
                            //Sawtooth ramps up and then quickly resets
                            waveform[i] = amplitude * (2.0 * i / pointsPerCycle - 1) + dcOffset;

                            // After reaching the maximum value, it resets back to -amplitude
                            if (i == pointsPerCycle - 1)
                            {
                                waveform[i] = -amplitude + dcOffset;  // Reset to -amplitude after one full cycle
                            }
                        }
                        break;

                    case 4: // TTL Wave
                        for (int i = 0; i < pointsPerCycle; i++)
                        {
                            if (i < highPoints) // High level with duty cycle and offset
                            {
                                waveform[i] = 5 + dcOffset;
                            }
                            else //Low level with duty cycle and offset
                            {
                                waveform[i] = 0 + dcOffset;
                            }
                        }
                        break;
                }

                // Plot the waveform on the chart
                PlotWaveform(waveform);

                myTask.Stop();

                for (int i = 0; i < waveform.Length; i++)
                {
                    if (waveform[i] > 10)
                    { waveform[i] = 10; }
                    if (waveform[i] < -10)
                    { waveform[i] = -10; }
                }

                writer.WriteMultiSample(false, waveform);
                myTask.Start();
                return waveform;
            }
            else { double [] zeroWaveform = new double[0];
                return zeroWaveform; }
        }

        private void PlotWaveform(double[] waveform)
        {
            cht_Data.Series[0].Points.Clear();

            for (int i = 0; i < waveform.Length; i++)
            {
                cht_Data.Series[0].Points.AddXY(i, waveform[i]);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myTask != null) 
            {
                myTask.Stop();
                double[] zeroWave = new double[pointsPerCycle];
                for (int i = 0; i < pointsPerCycle; i++) { zeroWave[i] = 0; }
                writer.WriteMultiSample(false, zeroWave);
                myTask.Start();
                myTask.Dispose();
            }
        }
    }
}
