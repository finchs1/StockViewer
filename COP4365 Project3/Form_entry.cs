using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Windows.Forms.DataVisualization.Charting;

namespace COP4365_Project3
{
    public partial class Form_entry : Form
    {

        /*
         * Form constructor for main form to load stocks.
         */
        public Form_entry()
        {
            InitializeComponent();
            chart_csticks.Hide();
            button_update.Hide();
            button_load.Show();
            this.Text = "Stock Loader";
            this.Size = new System.Drawing.Size(320, 140);
        }

        /*
         * Second form constructor to make stock viewer with
         * specified ticker and date.
        */
        public Form_entry(string ticker_filename, DateTime start, DateTime end)
        {
            InitializeComponent();

            stock_candlesticks = new BindingList<SmartCandlestick>();
            all_candlesticks = new List<Candlestick>(1024);

            stock_filename = ticker_filename;
            string stock_filename_no_ext = Path.GetFileNameWithoutExtension(stock_filename);
            all_candlesticks = load_stock(stock_filename);
            chart_csticks.Titles.Clear();
            chart_csticks.Titles.Add(stock_filename_no_ext);

            recognizers = new List<Recognizer>();
            recognizers.Add(new BearishRecognizer());
            recognizers.Add(new BullishRecognizer());
            recognizers.Add(new NeutralRecognizer());
            recognizers.Add(new MarubozuRecognizer());
            recognizers.Add(new HammerRecognizer());
            recognizers.Add(new DojiRecognizer());
            recognizers.Add(new DragonflyRecognizer());
            recognizers.Add(new GravestoneRecognizer());
            recognizers.Add(new InvertedHammerRecognizer());
            recognizers.Add(new BullishEngulfingRecognizer());
            recognizers.Add(new BearishEngulfingRecognizer());
            recognizers.Add(new BullishHaramiRecognizer());
            recognizers.Add(new BearishHaramiRecognizer());
            recognizers.Add(new PeakRecognizer());
            recognizers.Add(new ValleyRecognizer());

            comboBox_pattern.Items.Add("None");

            foreach (Recognizer r in recognizers)
                comboBox_pattern.Items.Add(r.patternName);

            //update_data(); changing index makes update_data() get called by combobox_pattern event handler
            comboBox_pattern.SelectedIndex = 0;

            this.Text += (" - " + stock_filename_no_ext);
        }

        /*
         * Button handler for load stock button.
         * Shows file dialog.
         */
        private void button_load_Click(object sender, EventArgs e)
        {
            openFileDialog_csv.ShowDialog();
        }

        /*
         * Loads stock file by into list checking if it exists and if the format is correct.
         * Uses regex to parse the strings into variables for the candlesticks.
         * Returns List<Candlestick>, objects in list are SmartCandlestick type.
         */
        private List<Candlestick> load_stock(string file_name)
        {
            //Check if filename is valid
            if (file_name.Length > 0)
            {
                //Check if file exists
                if (!File.Exists(file_name))
                {
                    MessageBox.Show("File " + file_name + " does not exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }

                stock_candlesticks.Clear();
                all_candlesticks.Clear();

                List<Candlestick> result = new List<Candlestick>(1024);
                using (StreamReader sr = new StreamReader(file_name))
                {
                    //Verify file is correct structure
                    if (sr.ReadLine() != reference_header_str)
                    {
                        MessageBox.Show("Invalid File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                    string file = Path.GetFileName(file_name);
                    //Parse period from file to set radio buttons
                    Regex stock_period = new Regex("(Month|Week|Day)");
                    trigger_period = false;
                    radioButton_daily.Enabled = true;
                    radioButton_weekly.Enabled = true;
                    radioButton_monthly.Enabled = true;
                    switch (Candlestick.strToPeriod(stock_period.Match(file).Groups[1].Value))
                    {
                        case Period.Daily:
                            radioButton_daily.Checked = true;
                            break;
                        case Period.Weekly:
                            radioButton_weekly.Checked = true;
                            break;
                        case Period.Monthly:
                            radioButton_monthly.Checked = true;
                            break;
                    }
                    trigger_period = true;
                    while (!sr.EndOfStream)
                    {
                        //Parse file lines into Candlesticks
                        string line = sr.ReadLine();
                        Regex reg = new Regex("\"([^\"]*)\",\"([^\"]*)\",\"([^\"]*)\",([0-9]*.[0-9]*),([0-9]*.[0-9]*),([0-9]*.[0-9]*),([0-9]*.[0-9]*),([0-9]+)", RegexOptions.IgnoreCase);
                        Match match = reg.Match(line);
                        string ticker = match.Groups[1].Value;
                        string period = match.Groups[2].Value;
                        DateTime date = DateTime.Parse(match.Groups[3].Value);
                        decimal open = Convert.ToDecimal(match.Groups[4].Value);
                        decimal high = Convert.ToDecimal(match.Groups[5].Value);
                        decimal low = Convert.ToDecimal(match.Groups[6].Value);
                        decimal close = Convert.ToDecimal(match.Groups[7].Value);
                        long volume = Convert.ToInt64(match.Groups[8].Value);
                        SmartCandlestick cs = new SmartCandlestick(ticker, period, date, open, high, low, close, volume);
                        result.Add(cs);
                    }

                    //Reverse list to get data in correct order of earliest to lastest
                    result.Reverse();
                }
                return result;
            }
            return null;
        }

        /*
         * Handles changing the candlestick period by
         * opening the corresponding file with the specified period.
         * Loads the new stock file.
         */
        private void radioButton_PeriodCheckedChanged(object sender, EventArgs e)
        {
            RadioButton s = (RadioButton)sender;
            if (trigger_period)
            {
                if (s.Checked)
                {
                    //Check if initial stock file has been loaded
                    if (stock_candlesticks.Count == 0)
                    {
                        MessageBox.Show("Stock file not loaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string stock_ticker = stock_candlesticks[0].ticker;
                    //Concatenate correct ending to ticker name for the specified period
                    switch (Candlestick.strToPeriod(s.Text))
                    {
                        case Period.Daily:
                            stock_ticker += "-Day.csv";
                            break;
                        case Period.Monthly:
                            stock_ticker += "-Month.csv";
                            break;
                        case Period.Weekly:
                            stock_ticker += "-Week.csv";
                            break;
                    }
                    //Create correct filename string to load new stock file
                    stock_filename = Path.GetDirectoryName(stock_filename).ToString() + "\\" + stock_ticker;
                    //Load new file
                    var list = load_stock(stock_filename);
                    if (list != null)
                    {
                        all_candlesticks = list;
                        update_data();
                    }
                }
            }
        }
        
        /*
         * Handles the click event for the update button.
         * Calls update_data();
         */
        private void button_update_Click(object sender, EventArgs e)
        {
            update_data();
        }

        /*
         * Generates annotations based on the specified SmartCandlestick pattern.
         * Returns a customized Annotation for the specified candlestick.
         * If pattern size == 3 (peak or valley), move annotation back one candlestick.
        */
        private Annotation generateAnnotation(int i, int pattern)
        {
            ArrowAnnotation a = new ArrowAnnotation();
            a.AnchorDataPoint = chart_csticks.Series[0].Points[i];
            a.AnchorOffsetY -= 2;
            a.Height = -5;
            a.Width = 0;
            a.ArrowSize = 2;
            a.LineWidth = 2;
            switch (pattern)
            {
                case (int)Pattern.Bearish:
                    {
                        a.LineColor = Color.Red;
                        break;
                    }
                case (int)Pattern.Bullish:
                    {
                        a.LineColor = Color.Green;
                        break;
                    }
                case (int)Pattern.Neutral:
                    {
                        a.LineColor = Color.Gray;
                        break;
                    }
                case (int)Pattern.Marubozu:
                    {
                        a.LineColor = Color.Aqua;
                        break;
                    }
                case (int)Pattern.Hammer:
                    {
                        a.LineColor = Color.Gray;
                        break;
                    }
                case (int)Pattern.Doji:
                    {
                        a.LineColor = Color.Blue;
                        break;
                    }
                case (int)Pattern.Dragonfly:
                    {
                        a.LineColor = Color.Firebrick;
                        break;
                    }
                case (int)Pattern.Gravestone:
                    {
                        a.LineColor = Color.Firebrick;
                        break;
                    }
                case (int)Pattern.InvertedHammer:
                    {
                        a.LineColor = Color.Firebrick;
                        break;
                    }
                case (int)Pattern.BullishEngulfing:
                    {
                        a.LineColor = Color.DarkGreen;
                        break;
                    }
                case (int)Pattern.BearishEngulfing:
                    {
                        a.LineColor = Color.DarkRed;
                        break;
                    }
                case (int)Pattern.BullishHarami:
                    {
                        a.LineColor = Color.DarkGreen;
                        break;
                    }
                case (int)Pattern.BearishHarami:
                    {
                        a.LineColor = Color.DarkRed;
                        break;
                    }
                case (int)Pattern.Peak:
                    {
                        a.LineColor = Color.Violet;
                        a.AnchorDataPoint = chart_csticks.Series[0].Points[i - 1];
                        break;
                    }
                case (int)Pattern.Valley:
                    {
                        a.LineColor = Color.Teal;
                        a.AnchorDataPoint = chart_csticks.Series[0].Points[i - 1];
                        break;
                    }
            }

            return a;
        }

        /*
         * Updates data by clearing and readding candlesticks to
         * stock_candlesticks BindingList variable.
         * Also sets chart_csticks to the list and calls DataBind().
         * Clears annotations and readds selected annotations to chart.
        */
        private void update_data()
        {
            stock_candlesticks.Clear();
            foreach (SmartCandlestick cs in all_candlesticks)
            {
                if (cs.date > dateTimePicker_enddate.Value)
                    break;
                if (cs.date >= dateTimePicker_startdate.Value)
                    stock_candlesticks.Add(cs);
            }

            chart_csticks.DataSource = stock_candlesticks;
            chart_csticks.DataBind();

            chart_csticks.Annotations.Clear();

            //Add annotations if a pattern is selected
            if (comboBox_pattern.SelectedIndex > 0)
            {
                List<int> recognized_indices = recognizers[comboBox_pattern.SelectedIndex - 1].recognize(stock_candlesticks.ToList());

                foreach (int index in recognized_indices)
                {
                    Annotation a = generateAnnotation(index, comboBox_pattern.SelectedIndex);
                    chart_csticks.Annotations.Add(a);
                }
            }
        }

        /*
         * Handles file dialog when files are selected.
         * Creates forms with specified file names and specified dates.
         * Shows the new forms.
        */
        private void openFileDialog_csv_FileOk(object sender, CancelEventArgs e)
        {
            foreach (string file in openFileDialog_csv.FileNames)
            {
                Form_entry new_form = new Form_entry(file, dateTimePicker_startdate.Value, dateTimePicker_enddate.Value);
                new_form.Show();
            }
        }

        /*
         * Event handler for when pattern is changed. 
         * Calls update_data to update chart.
        */
        private void pattern_changed(object sender, EventArgs e)
        {
            update_data();
        }

        //holds full filename and path of current stock
        private string stock_filename { get; set; }
        //holds stock candlesticks
        private BindingList<SmartCandlestick> stock_candlesticks { get; set; }
        //holds all candlesticks from csv
        private List<Candlestick> all_candlesticks { get; set; }
        //makes sure that the period radiobutton events are not triggered by code
        private bool trigger_period { get; set; }
        //reference string for csv
        private readonly string reference_header_str = "\"Ticker\",\"Period\",\"Date\",\"Open\",\"High\",\"Low\",\"Close\",\"Volume\"";

        //Recognizer list
        private List<Recognizer> recognizers { get; set; }

        //Pattern enum for annotations
        enum Pattern
        {
            None,
            Bearish,
            Bullish,
            Neutral,
            Marubozu,
            Hammer,
            Doji,
            Dragonfly,
            Gravestone,
            InvertedHammer,
            BullishEngulfing,
            BearishEngulfing,
            BullishHarami,
            BearishHarami,
            Peak,
            Valley
        }
    }
}
