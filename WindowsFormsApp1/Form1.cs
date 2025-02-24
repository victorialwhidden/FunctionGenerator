using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using NationalInstruments.DAQmx;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Task myTask;
        private AnalogSingleChannelWriter writer;

        private int MaxA2Drate = 250000;
        private int maxBufferSize = 2080; //Fix this buffer value
        private int MAXvoltageRange;
        private int MINvoltageRange;
        private bool buttonOnOff;
        private decimal outputFrequency;
        private decimal fRangeValue;
        private string[] aoChannels;
        //private string[] aoChannelNames;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get device list
            PopulateDevices();

            try
            {
                myTask = new Task();
                if (myTask != null)
                {
                    for (int i = 0; i < aoChannels.Length; i++)
                    {   
                        //need to create an AO channel for the task from the selected channel of the combobox
                        string channels = Cbx_Devices.Items[i].ToString();
                        myTask.AOChannels.CreateVoltageChannel(channels, "", -10, 10, AOVoltageUnits.Volts);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("There was an error setting up the Analog Channels", ex.Message); }

            //FINISH DOING STUFF WITH THE TASK
            myTask.Timing.ConfigureSampleClock("", sampleRate, SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, samplesPerChannel)
            myTask.AOChannels.All.UseOnlyOnBoardMemory = true;

            //Default = sine
            Cbx_Waveform.SelectedIndex = 0; // sine
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

        }

        private void NumUD_DcOffset_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NumUD_DutyCycle_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Cbx_Waveform_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbx_Waveform.SelectedIndex == 4)
            {
                MAXvoltageRange = 5;
                MINvoltageRange = -5;
            }
        }

        private void Btn_Output_MouseClick(object sender, MouseEventArgs e)
        {
            if (buttonOnOff == false)
            {
                //Need to add code to send out the waveform voltage continuously (don’t use a while loop). 
                Btn_Output.Text = "ON";
                Btn_Output.BackColor = Color.Green;
                buttonOnOff = true;
            }
            //If you click it again, it stops the voltage (sends out 0 volts)  and the label says OFF and the color is Red.
            else
            {
                //Need to add code here to stop voltage
                Btn_Output.Text = "OFF";
                Btn_Output.BackColor = Color.Red;
                buttonOnOff = false;
            }
        }

        private void Btn_Quit_MouseClick(object sender, MouseEventArgs e)
        {
            //Zero out the voltage and dispose of the task (if it is not already disposed of) when closing the program. 
        }

        private void NumUD_Frequency_ValueChanged(object sender, EventArgs e)
        {

        }

        private void OutputFrequency()
        {
            outputFrequency = NumUD_Frequency.Value * fRangeValue;
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
            }
        }
    }
}
