using BestHTMLparser.Core;
using BestHTMLparser.Core.Habra;
using System;
using System.Windows.Forms;

namespace BestHTMLparser
{
    public partial class Form1 : Form
    {
        ParserWorker<string[]> parser;


        public Form1()
        {
            InitializeComponent();
            // settings needs position
            parser = new ParserWorker<string[]>(
                    new HabraParser()
                );

            parser.OnComplete += Parser_OnCompleted;
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, string[] arg2)
        {
            ListTitles.Items.AddRange(arg2);
        }

        private void Parser_OnCompleted(object obj)
        {
            MessageBox.Show("Complete");
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            parser.GetParserSettings = new HabraSettings((int)StartNumeric.Value, (int)EndNumeric.Value);
            parser.Start();
        }

        private void AbortButton_Click(object sender, EventArgs e)
        {
            parser.Abort();
        }
    }
}