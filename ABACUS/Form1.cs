using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABACUS
{
    public partial class Form1 : Form
    {
        private int ticks;
        int questionno = 1;
        int intquetionno = 1;
        int mulquestionno = 1;
        string yourAnswer = "";
        string CorrectAnser;
        string yourintAnswer = "";
        string CorrectintAnser;
        int marks = 0;
        int intmarks = 0;
        string yourmulAnswer = "";
        string CorrectmulAnser;
        int mulmarks = 0;
        List<ResultClass> resultdata;
        List<ResultClass> intresultdata;
        List<ResultClass> mulresultdata;
        bool stop;
        bool intstop;
        bool mulstop;
        public Form1()
        {

            #region decimal constructor 
            resultdata = new List<ResultClass>();
            InitializeComponent();
            double rbtext1 = 0.00;
            double rbtext2;
            double rbtext3;
            double rbtext4;
            timer1.Start(); 
            label1.Text = "Question : " + questionno.ToString();

            for (int i = 0; i < 8; i++)
            {
                double randomnumber = GetRandomNumber(0.01, 9.99);               
                listView2.Items[i].Text = randomnumber.ToString();
                rbtext1 = Math.Round(rbtext1 + randomnumber,2);                
                rbtext2 = Math.Round(rbtext1 + GetRandomNumber(0.50,2.00),2) ;
                rbtext3 = Math.Round(rbtext1 + GetRandomNumber(0.50, 2.00), 2);
                rbtext4 = Math.Round(rbtext1 + GetRandomNumber(0.50, 2.00), 2);
                CorrectAnser = rbtext1.ToString();

                string[] options = { rbtext1.ToString(), rbtext2.ToString(), rbtext3.ToString(), rbtext4.ToString() };

                Random random = new Random();
                options = options.OrderBy(x => random.Next()).ToArray();

                radioButton1.Text = options[0];                
                radioButton2.Text = options[1];
                radioButton3.Text = options[2];
                radioButton4.Text = options[3];
            }
            label1.Text = "Question : " + questionno.ToString();
            button2.Visible = false;
            label2.Visible = false;
            dataGridView1.Visible = false;
            #endregion

            #region int constructor
            intresultdata = new List<ResultClass>();
            double rbtext5 = 0.00;
            double rbtext6;
            double rbtext7;
            double rbtext8;
            //timer1.Start();
          

            for (int i = 0; i < 8; i++)
            {
                 Random rnd = new Random();
                 int num = rnd.Next(-25,100);
                listView1.Items[i].Text = num.ToString();
                rbtext5 = rbtext5 + num;
                rbtext6 = rbtext5 + rnd.Next(-10, -5);
                rbtext7 = rbtext5 + rnd.Next(-4, 1);
                rbtext8 = rbtext5 + rnd.Next(-2, 6);
                CorrectintAnser = rbtext5.ToString();

                string[] intoptions = { rbtext5.ToString(), rbtext6.ToString(), rbtext7.ToString(), rbtext8.ToString() };

                Random random = new Random();
                intoptions = intoptions.OrderBy(x => random.Next()).ToArray();

                radioButton5.Text = intoptions[0];
                radioButton6.Text = intoptions[1];
                radioButton7.Text = intoptions[2];
                radioButton8.Text = intoptions[3];;
            }
            label7.Text = "Question : " + intquetionno.ToString();
            button3.Visible = false;
            label8.Visible = false;
            dataGridView2.Visible = false;
            #endregion
            mulresultdata = new List<ResultClass>();
            int rbtext9 = 0;
            int rbtext10;
            int rbtext11;
            int rbtext12;
            Random r = new Random();
            int mul1 = r.Next(1,100);
            int mul2 = r.Next(1,100);
            label10.Text = mul1.ToString();
            label11.Text = "X";
            label12.Text = mul2.ToString();
            label9.Text = "Question : " + mulquestionno.ToString();
            label13.Visible = false;
            
            Finish.Visible = false;
            button5.Enabled = false;
            dataGridView3.Visible = false;
            rbtext9 = mul1 * mul2;
            CorrectmulAnser = rbtext9.ToString();
            rbtext10 = rbtext9 + r.Next(-10, -5);
            rbtext11 = rbtext9 + r.Next(-4, -1);
            rbtext12 = rbtext9 + r.Next(0, 6);
            string[] muloptions = { rbtext9.ToString(), rbtext10.ToString(), rbtext11.ToString(), rbtext12.ToString() };

           // Random random = new Random();
            muloptions = muloptions.OrderBy(x => r.Next()).ToArray();

            radioButton9.Text = muloptions[0];
            radioButton10.Text = muloptions[1];
            radioButton11.Text = muloptions[2];
            radioButton12.Text = muloptions[3]; ;

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ////Random rnd = new Random();
            ////int num = rnd.Next(4000);
            ////double num1 = rnd.NextDouble() + num;
            ////double output = Math.Round(num1, 2);
            ////double kk = 0.00;
            //double rbtext1 =0.00;
            //double rbtext2;
            //double rbtext3;
            //double rbtext4;

            //for (int i=0;i<5;i++)
            //{
            //    Random rnd = new Random();
            //    int num = rnd.Next(4000);
            //    double num1 = rnd.NextDouble() + num;
            //    double output = Math.Round(num1, 2);
            //    listView2.Items[i].Text = output.ToString();

            //    rbtext1 = rbtext1 + output;
            //    rbtext1 = Math.Round(rbtext1, 2);
            //    rbtext2 = rbtext1 + rnd.Next(100);
            //    rbtext3 = rbtext1 + rnd.Next(100);
            //    rbtext4 = rbtext1 + rnd.Next(100);

            //    radioButton1.Text = rbtext1.ToString();
            //    radioButton2.Text = rbtext2.ToString();
            //    radioButton3.Text = rbtext3.ToString();
            //    radioButton4.Text = rbtext4.ToString();



            //}
           
            

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            yourAnswer = radioButton1.Text;
            button1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;

            if(!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)
            {
                button1.Enabled = false;
            }
            ResultClass res = new ResultClass();
            res.QuestionNo = questionno;
            res.CorrectAnswer = CorrectAnser;
            res.YourAnswer = yourAnswer;

            resultdata.Add(res);

            if (yourAnswer == CorrectAnser)
            {
                marks = marks + 1;
            }

            double rbtext1 = 0.00;
            double rbtext2;
            double rbtext3;
            double rbtext4;
            questionno = questionno + 1; ;
            label1.Text = "Question : " + questionno.ToString();

            for (int i = 0; i < 8; i++)
            {
                double randomnumber = GetRandomNumber(0.01, 9.99);
                // Random rnd = new Random();
                // int num = rnd.Next(10);
                // double num1 = rnd.NextDouble() + num;
                // double output = Math.Round(num1, 2);
                listView2.Items[i].Text = randomnumber.ToString();

                rbtext1 = rbtext1 + randomnumber;
                // rbtext1 = Math.Round(rbtext1, 2);
                rbtext2 = Math.Round(rbtext1 + GetRandomNumber(0.50, 2.00), 2);
                rbtext3 = Math.Round(rbtext1 + GetRandomNumber(0.50, 2.00), 2);
                rbtext4 = Math.Round(rbtext1 + GetRandomNumber(0.50, 2.00), 2);
                CorrectAnser = rbtext1.ToString();

                string[] options = { rbtext1.ToString(), rbtext2.ToString(), rbtext3.ToString(), rbtext4.ToString() };

                Random random = new Random();
                options = options.OrderBy(x => random.Next()).ToArray();

                radioButton1.Text = options[0];
                radioButton2.Text = options[1];
                radioButton3.Text = options[2];
                radioButton4.Text = options[3];

            }

            if(questionno == 80)
            {
                button1.Visible = false;
                button2.Visible = true;
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void intializecontent()
        {
            double rbtext1 = 0.00;
            double rbtext2;
            double rbtext3;
            double rbtext4;
            questionno = questionno + 1; ;
            label1.Text = "Question" + questionno.ToString();

            for (int i = 0; i < 5; i++)
            {
                Random rnd = new Random();
                int num = rnd.Next(4000);
                double num1 = rnd.NextDouble() + num;
                double output = Math.Round(num1, 2);
                listView2.Items[i].Text = output.ToString();

                rbtext1 = rbtext1 + output;
                rbtext1 = Math.Round(rbtext1, 2);
                rbtext2 = rbtext1 + rnd.Next(100);
                rbtext3 = rbtext1 + rnd.Next(100);
                rbtext4 = rbtext1 + rnd.Next(100);

                radioButton1.Text = rbtext1.ToString();
                radioButton2.Text = rbtext2.ToString();
                radioButton3.Text = rbtext3.ToString();
                radioButton4.Text = rbtext4.ToString();

            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            yourAnswer = radioButton2.Text;
            button1.Enabled = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            yourAnswer = radioButton3.Text;
            button1.Enabled = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            yourAnswer = radioButton4.Text;
            button1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            stop = true;
            ResultClass res = new ResultClass();
            res.QuestionNo = questionno;
            res.CorrectAnswer = CorrectAnser;
            res.YourAnswer = yourAnswer;

            resultdata.Add(res);

            if (yourAnswer == CorrectAnser)
            {
                marks = marks + 1;
            }
            label2.Text = "Your Score is " + marks.ToString();
            label2.Visible = true;
            dataGridView1.Visible = true;

            dataGridView1.DataSource = resultdata;
            button2.Visible = false;
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ticks++;
            int mins = 0;
            int secs = ticks;
            if(ticks > 60)
            {
                mins = ticks / 60;
                secs = ticks % 60;
            }

            if(!stop && !intstop && !mulstop)
           // label4.Text = mins.ToString() + ":" + secs.ToString();
            this.Text = "ABACUS Practice " + mins.ToString() + ":" + secs.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        public double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            double result = random.NextDouble() * (maximum - minimum) + minimum;
            return Math.Round(result, 2);
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;

            if (!radioButton5.Checked && !radioButton6.Checked && !radioButton7.Checked && !radioButton8.Checked)
            {
                button4.Enabled = false;
            }
            ResultClass res = new ResultClass();
            res.QuestionNo = intquetionno;
            res.CorrectAnswer = CorrectintAnser;
            res.YourAnswer = yourintAnswer;

            intresultdata.Add(res);

            if (yourintAnswer == CorrectintAnser)
            {
                intmarks = intmarks + 1;
            }
            double rbtext5 = 0.00;
            double rbtext6;
            double rbtext7;
            double rbtext8;
            intquetionno = intquetionno + 1; 
           

            for (int i = 0; i < 8; i++)
            {
                Random rnd = new Random();
                int num = rnd.Next(-25, 100);
                listView1.Items[i].Text = num.ToString();
                rbtext5 = rbtext5 + num;
                rbtext6 = rbtext5 + rnd.Next(-10, -5);
                rbtext7 = rbtext5 + rnd.Next(-4, 1);
                rbtext8 = rbtext5 + rnd.Next(2, 6);
                CorrectintAnser = rbtext5.ToString();
                string[] intoptions = { rbtext5.ToString(), rbtext6.ToString(), rbtext7.ToString(), rbtext8.ToString() };

                Random random = new Random();
                intoptions = intoptions.OrderBy(x => random.Next()).ToArray();

                radioButton5.Text = intoptions[0];
                radioButton6.Text = intoptions[1];
                radioButton7.Text = intoptions[2];
                radioButton8.Text = intoptions[3];
            }
            label7.Text = "Question : " + intquetionno.ToString();
            button3.Visible = false;
            label8.Visible = false;
            dataGridView2.Visible = false;

            if (intquetionno == 80)
            {
                button4.Visible = false;
                button3.Visible = true;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;

            if (!radioButton9.Checked && !radioButton10.Checked && !radioButton11.Checked && !radioButton12.Checked)
            {
                button5.Enabled = false;
            }
            ResultClass res = new ResultClass();
            res.QuestionNo = mulquestionno;
            res.CorrectAnswer = CorrectmulAnser;
            res.YourAnswer = yourmulAnswer;

            mulresultdata.Add(res);

            if (yourmulAnswer == CorrectmulAnser)
            {
                mulmarks = mulmarks + 1;
            }

            mulquestionno = mulquestionno + 1;
            Decimal rbtext9 = 0;
            Decimal rbtext10;
            Decimal rbtext11;
            Decimal rbtext12;
            string[] act = { "X", "%" };
            Random r = new Random();
            string selectaction = act[r.Next(0, 2)];
            int mul1;
            int mul2;
            label11.Text = selectaction;
            
            label9.Text = "Question : " + mulquestionno.ToString();
            //button6.Visible = false;
            button5.Enabled = false;
            if (selectaction == "X")
            {
                 mul1 = r.Next(1,100);
                 mul2 = r.Next(1,100);
                label10.Text = mul1.ToString();
                label12.Text = mul2.ToString();
                rbtext9 = mul1 * mul2;
            }
            else
            {
                mul1 = r.Next(50,100);
                mul2 = r.Next(1,50);
                label10.Text = mul1.ToString();
                label12.Text = mul2.ToString();
                rbtext9 = Decimal.Divide( mul1,mul2);
            }
            CorrectmulAnser = rbtext9.ToString();
            rbtext10 = rbtext9 + r.Next(-5, -1);
            rbtext11 = rbtext9 + r.Next(15, 20);
            rbtext12 = rbtext9 + r.Next(5, 10);
            string[] muloptions = { rbtext9.ToString(), rbtext10.ToString(), rbtext11.ToString(), rbtext12.ToString() };

            // Random random = new Random();
            muloptions = muloptions.OrderBy(x => r.Next()).ToArray();

            radioButton9.Text = muloptions[0];
            radioButton10.Text = muloptions[1];
            radioButton11.Text = muloptions[2];
            radioButton12.Text = muloptions[3];

            if (mulquestionno == 120)
            {
                button5.Visible = false;
                Finish.Visible = true;
            }
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            yourintAnswer = radioButton7.Text;
            button4.Enabled = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            yourintAnswer = radioButton5.Text;
            button4.Enabled = true;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            yourintAnswer = radioButton6.Text;
            button4.Enabled = true;
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            yourintAnswer = radioButton8.Text;
            button4.Enabled = true;
        }
        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            yourmulAnswer = radioButton9.Text;
            button5.Enabled = true;
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            yourmulAnswer = radioButton10.Text;
            button5.Enabled = true;

        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            yourmulAnswer = radioButton11.Text;
            button5.Enabled = true;
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            yourmulAnswer = radioButton12.Text;
            button5.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            intstop = true;
            ResultClass res = new ResultClass();
            res.QuestionNo = intquetionno;
            res.CorrectAnswer = CorrectintAnser;
            res.YourAnswer = yourintAnswer;

            intresultdata.Add(res);

            if (yourintAnswer == CorrectintAnser)
            {
                intmarks = intmarks + 1;
            }
            label8.Text = "Your Score is " + intmarks.ToString();
            label8.Visible = true;
            dataGridView2.Visible = true;

            dataGridView2.DataSource = intresultdata;
            button3.Visible = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            mulstop = true;
            ResultClass res = new ResultClass();
            res.QuestionNo = mulquestionno;
            res.CorrectAnswer = CorrectmulAnser;
            res.YourAnswer = yourmulAnswer;

            mulresultdata.Add(res);

            if (yourmulAnswer == CorrectmulAnser)
            {
                mulmarks = mulmarks + 1;
            }
            label13.Text = "Your Score is " + mulmarks.ToString();
            label13.Visible = true;
            dataGridView3.Visible = true;

            dataGridView3.DataSource = mulresultdata;
            Finish.Visible = false;
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }       
    }
}
