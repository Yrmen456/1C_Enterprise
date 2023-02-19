using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1C_Enterprise
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowEmployee();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool result = Method.inputControl(textBox1.Text);
            bool result2 = Method.inputControl(textBox2.Text);
            if (!result || !result2)
            {
                MessageBox.Show("Данные введены не коректно");
                return;
            }
            ShowNewEmployee(int.Parse(textBox1.Text), int.Parse(textBox2.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result = Method.inputControl(textBox1.Text);
            bool result2 = Method.inputControl(textBox2.Text);
            if (!result || !result2)
            {
                MessageBox.Show("Данные введены не коректно");
                return;
            }
            ShowUpdateEmployee(int.Parse(textBox1.Text), int.Parse(textBox2.Text));

        }
        public DataSet dataSet = new DataSet();
        public async void ShowEmployee()
        {
            await Task.Run(() => {
                dataSet = SQL.Table($@" EXEC SelectAttendance ;");
            });


            if (dataSet.Tables.Count <= 0)
            {
                MessageBox.Show("Данные введены не коректно");
                return;
            }
            dataSet.Tables[0].TableName = "Employees";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            Employee employees= new Employee();
            employees = JsonConvert.DeserializeObject<Employee>(json);

            dataGridView1.DataSource = employees.Employees;
            dataGridView1.Columns["ID"].HeaderText = "Код";
            dataGridView1.Columns["FIO"].HeaderText = "ФИО";
            dataGridView1.Columns["Experience"].HeaderText = "Стаж на вредном производстве, лет";
            dataGridView1.Columns["Pension_"].HeaderText = "Пенсионер";
    

        }
        public async void ShowNewEmployee(int yearsold, int Harmfulyearsold)
        {
            await Task.Run(() => {
                dataSet = SQL.Table($@"EXEC SelectUpdateAttendance {yearsold}, {Harmfulyearsold};");
            });


            if (dataSet.Tables.Count <= 0)
            {

                return;
            }
            dataSet.Tables[0].TableName = "Employees";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            Employee employees = new Employee();
            employees = JsonConvert.DeserializeObject<Employee>(json);
       
            dataGridView1.DataSource = employees.Employees;
            dataGridView1.Columns["ID"].HeaderText = "Код";
            dataGridView1.Columns["FIO"].HeaderText = "ФИО";
            dataGridView1.Columns["Age"].HeaderText = "Возраст";
            dataGridView1.Columns["Experience"].HeaderText = "Стаж на вредном производстве, лет";
            dataGridView1.Columns["Pension_"].HeaderText = "Пенсионер";
        }
 
        public async void ShowUpdateEmployee(int yearsold, int Harmfulyearsold)
        {
            await Task.Run(() => {
                dataSet = SQL.Table($@"EXEC UpdateAttendance {yearsold}, {Harmfulyearsold}; EXEC SelectAttendance ;");
            });


            if (dataSet.Tables.Count <= 0)
            {

                return;
            }
            dataSet.Tables[0].TableName = "Employees";
            string json = JsonConvert.SerializeObject(dataSet, Formatting.Indented);
            Employee employees = new Employee();
            employees = JsonConvert.DeserializeObject<Employee>(json);
           
            dataGridView1.DataSource = employees.Employees;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


    }
}
