using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mf = radioM.Checked ? "남" : "여";
            string data = textName.Text + "," +
                cboRegion.SelectedItem + "," +
                dtDOB.Value + "," +
                mf;

            StreamWriter wr = new StreamWriter(@"F:\Test1.txt", true);
            wr.WriteLine(data);
            wr.Close();

            
            textName.Text = "";
            cboRegion.SelectedIndex = -1;
            dtDOB.Value = DateTime.Now;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBoxMulti_TextChanged(object sender, EventArgs e)
        {
            //textBoxMulti.Text = "hello";
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("이름 : 홍길동");
            //sb.AppendLine("나이 : 25세");
            //sb.AppendLine("국적 : 한국");
            //textBoxMulti.Text = sb.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_DragEnter_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy | DragDropEffects.Scroll;
            }

            //if (e.Data.GetDataPresent(typeof(string)))
            //{
            //    // Drop하여 복사함
            //    e.Effect = DragDropEffects.Copy;
            //}
            //else
            //{
            //    // Drop 할 수 없음
            //    e.Effect = DragDropEffects.None;
            //}
        }

        private void textBox1_DragDrop_1(object sender, DragEventArgs e)
        {
            textBoxMulti.Text = "";

            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                this.textBox1.Text = "";
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string str in file)
                {
                    this.textBox1.Text += str;// + "\r" + "\n";
                    //this.textBox1.Text = str + "\r" + "\n";
                }
            }

            //// e.Data.GetData() 메서드는 드래그-앤-드롭에서 전달된 데이타를 가져옴.
            //// 타켓컨트롤(txtDropTarget)에 드랍 데이타 지정
            //textBox1.Text = (string)e.Data.GetData(DataFormats.StringFormat);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 데이타를 읽는 StreamReader
            StreamReader rd = new StreamReader(textBox1.Text);

            // 마지막이 될 때까지 루프
            while (!rd.EndOfStream)
            {
                // 한 라인을 읽는다
                string line = rd.ReadLine();

                textBoxMulti.Text += line +  "\r" + "\n";

                // 라인을 콤마로 분리하여 컬럼을 만든다
                //string[] cols = line.Split(',');

                // 한 라인에 각 컬럼의 데이타를 순서대로 넣는다
                //dataGridView1.Rows.Add(cols[0], cols[1], cols[2], cols[3], cols[4]);
            }

            // StreamReader는 사용 후 반드시 닫는다
            rd.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            XmlDocument xdoc = new XmlDocument();

            // XML 데이타를 파일에서 로드
            // xdoc.Load(@"C:\Temp\Emp.xml"); 
            xdoc.Load(textBox1.Text);
            // 특정 노드들을 필터링
            XmlNodeList nodes = xdoc.SelectNodes("/girlgroup/albums/album");

            foreach (XmlNode emp in nodes)
            {
                // Attribute 읽기
                string order = emp.Attributes["order"].Value;

                string text = emp.InnerText;

                textBoxMulti.Text += order + ", " + text + "\r" + "\n";

                //// 특정 자식 Element 읽기
                //string name = emp.SelectSingleNode("./Name").InnerText; //Relative Path 사용
                //string dept = emp.SelectSingleNode("Dept").InnerText;   //간단히 자식 Element명 사용
                //Console.WriteLine(id + "," + name + "," + dept);

                //// 자식 노드들에 대해 Loop를 도는 예
                //foreach (XmlNode child in emp.ChildNodes)
                //{
                //    Console.WriteLine("{0}: {1}", child.Name, child.InnerText);
                //}
            }

            // 특정 Id 속성으로 하나의 Employee 검색 예
            XmlNode emp1002 = xdoc.SelectSingleNode("/girlgroup/albums/album[@order='EP 3집']");
            textBoxMulti.Text += emp1002.InnerXml;
        }
    }
}
