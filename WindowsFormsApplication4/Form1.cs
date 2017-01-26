using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;


namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine speechreco = new SpeechRecognitionEngine();
        SpeechSynthesizer jarvis = new SpeechSynthesizer();
        public Form1()
        {
            InitializeComponent();
            speechreco.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(speechreco_SpeechRecognized);
            LoadGrammar();
            speechreco.SetInputToDefaultAudioDevice();
            speechreco.RecognizeAsync(RecognizeMode.Multiple);
        }
        private void LoadGrammar()
        {
            Choices texts = new Choices();
            string[] lines = File.ReadAllLines(Environment.CurrentDirectory+"\\commands.txt");
            texts.Add(lines);
            Grammar wordsList = new Grammar(new GrammarBuilder(texts));
            speechreco.LoadGrammar(wordsList);
        }
        private void speechreco_SpeechRecognized(object sender,SpeechRecognizedEventArgs e)
        {
            richTextBox1.Text = e.Result.Text;
            string speech = e.Result.Text;
            if(speech == "hello")
            {
                jarvis.Speak("hello and good morning");
            }
            if(speech=="open bing")
            {
                jarvis.Speak("loading");
                System.Diagnostics.Process.Start("http://www.bing.com");
            }
            if (speech == "Who am I")
            {
                jarvis.Speak("Your name is Sanchi ");
            }
            /*else
            {
                jarvis.Speak("I didn't catch that ");
            }*/
        }
    }
}
