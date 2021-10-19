// using DBMSServices.Mappers;
// using DBMSServices.Services;
// using MyDBMS.Contexts;
// using MyDBMS.Models;
// using MyDBMS.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        // private DatabaseRepository _databaseRepository;
        // private readonly DatabaseService _databaseService;
        // private DatabaseMapper _databaseMapper;

        // public Form1(DatabaseService databaseService)
        // {
        //     _databaseService = databaseService;
        //     InitializeComponent();
        //    
        //     //GetData();
        // }
        
        public Form1()
        {
            
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // dataGridView1.DataSource = _databaseService.GetAll();
            /*new List<Database>
        {
            new Database { Id = 1, Name = "The Very Big Corporation of America" },
            new Database { Id = 2, Name = "Old Accountants Ltd" }
        };*/
        }

        private void GetData()
        {
            /*using (MyDBMSContext db = new MyDBMSContext())
            {
                _databaseRepository = new DatabaseRepository(db);
                _databaseMapper = new DatabaseMapper();
                _databaseService = new DatabaseService(_databaseRepository, _databaseMapper);
            }*/
        }
    }
}
