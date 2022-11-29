using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Responsi_2
{
    internal class Karyawan : Departemen
    {
        private int _id_karyawan;
        private string _nama;
        private string _id_dep;
        private NpgsqlConnection conn;
        string connstring = "Host=localhost;Port=2022;Username=adyasena;Password=dysnasp;Database=dbadyaresponsi";
        public DataTable dt;
        public static NpgsqlCommand cmd;
        private string sql = null;
        private DataGridViewRow r;

        public int IdKaryawan
        {
            get { return _id_karyawan; }
        }
        public string Nama
        {
            get { return _nama; }
            set { _nama = value; }
        }
        public string IdDep
        {
            get { return _id_dep; }
            set { _id_dep = value; }
        }

        public Karyawan() {}
        public Karyawan(int IdKaryawan)
        {
            _id_karyawan = IdKaryawan;
        }
        public Karyawan(string Nama, string IdDep)
        {
            _nama = Nama;
            _id_dep = IdDep;
        }
        public Karyawan(int IdKaryawan, string Nama, string IdDep)
        {
            _id_karyawan = IdKaryawan;
            _nama = Nama;
            _id_dep = IdDep;
        }

        public void TambahKaryawan(Karyawan karyawan)
        {
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = "select * from tambah_karyawan(:_nama,:_id_dep)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_nama", _nama);
                cmd.Parameters.AddWithValue("_id_dep", _id_dep);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data karyawan berhasil ditambah", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UbahKaryawan(Karyawan karyawan)
        {
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = "select * from ubah_karyawan(:_id_karyawan, :_nama, :_id_dep)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_id_karyawan", _id_karyawan);
                cmd.Parameters.AddWithValue("_nama", _nama);
                cmd.Parameters.AddWithValue("_id_dep", _id_dep);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data User Berhasil diupdate", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void HapusKaryawan(Karyawan karyawan)
        {
            try
            {
                conn = new NpgsqlConnection(connstring);
                conn.Open();
                sql = "select * from hapus_karyawan(:_id_karyawan)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("_id_karyawan", _id_karyawan);
                if ((int)cmd.ExecuteScalar() == 1)
                {
                    MessageBox.Show("Data karyawan berhasil dihapus", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
