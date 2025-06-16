using EFForms_P35.Models;

namespace EF_HOME
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateNotesGrid()
        {
            using (var context = new DoctorsContext())
            {
                context.Database.EnsureCreated();
                dataGridView1.DataSource = context.Doctors.ToList();
                dataGridView2.DataSource = context.Patients.ToList();
                dataGridView3.DataSource = context.Specializations.ToList();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateNotesGrid();
        }
    }
}
