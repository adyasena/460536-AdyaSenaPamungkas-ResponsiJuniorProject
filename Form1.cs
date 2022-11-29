using Npgsql;
using System.Data;
using System.Xml.Linq;
using System.Windows.Forms;

namespace Responsi_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=2022;Username=adyasena;Password=dysnasp;Database=dbadyaresponsi";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;
        Karyawan karyawan;

        private void Form1_Load(object sender, EventArgs e)
        {
            LihatKaryawan();
        }

        private void LihatKaryawan()
        {
            conn = new NpgsqlConnection(connstring);
            conn.Open();
            dgvData.DataSource = null;
            sql = "select * from lihat_karyawan()";
            cmd = new NpgsqlCommand(sql, conn);
            dt = new DataTable();
            NpgsqlDataReader rd = cmd.ExecuteReader();
            dt.Load(rd);
            dgvData.DataSource = dt;
            conn.Close();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbNamaKaryawan.Text == "" || cbDepKaryawan.SelectedItem == null)
                {
                    MessageBox.Show("Isi data karyawan dengan benar", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    karyawan = new Karyawan(tbNamaKaryawan.Text, cbDepKaryawan.SelectedItem.ToString());
                    karyawan.TambahKaryawan(karyawan);
                    LihatKaryawan();
                    cbDepKaryawan.SelectedItem = tbNamaKaryawan.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (r == null)
                {
                    MessageBox.Show("Mohon pilih baris data karyawan yang akan diubah", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    karyawan = new Karyawan(Convert.ToInt32(r.Cells["_id_karyawan"].Value), tbNamaKaryawan.Text, cbDepKaryawan.SelectedItem.ToString());
                    karyawan.UbahKaryawan(karyawan);
                    LihatKaryawan();
                    cbDepKaryawan.SelectedItem = tbNamaKaryawan.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (r == null)
                {
                    MessageBox.Show("Mohon pilih baris data karyawan yang akan dihapus", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("Apakah benar anda ingin menghapus data karyawan " + r.Cells["_nama"].Value.ToString() + " ?", "Konfirmasi",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    karyawan = new Karyawan(Convert.ToInt32(r.Cells["_id_karyawan"].Value));
                    karyawan.UbahKaryawan(karyawan);
                    LihatKaryawan();
                    cbDepKaryawan.SelectedItem = tbNamaKaryawan.Text = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvData.Rows[e.RowIndex];
                tbNamaKaryawan.Text = r.Cells["_nama"].Value.ToString();
                cbDepKaryawan.SelectedItem = r.Cells["_id_dep"].Value.ToString();
            }
        }

        private void cbDepKaryawan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}