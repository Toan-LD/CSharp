using Doanqlchdt.connect;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Doanqlchdt
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
        }

       public void loadData()
        {
            using (SqlConnection conn = new connectToan().connection())
            {
                SqlCommand cmd = new SqlCommand("select * from SanPham", conn);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                conn.Close();
            }
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                this.Text=open.FileName;
            }
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            using (SqlConnection conn = new connectToan().connection())
            {
                byte[] b = ImageToByteArray(pictureBox1.Image);
                SqlCommand cmd = new SqlCommand("update SanPham set HinhAnh = @hinhanh where MaSP = @ten", conn);
                cmd.Parameters.Add("@hinhanh", SqlDbType.Image).Value=b;
                cmd.Parameters.Add("@ten", SqlDbType.Char).Value=textBox1.Text;
                cmd.ExecuteNonQuery();
            }
        }

        byte[] ImageToByteArray(Image img)
        {
            MemoryStream m = new MemoryStream();
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }

        byte[] PathToImage(string Path)
        {
            MemoryStream m = new MemoryStream();
            Image img = Image.FromFile(Path);
            img.Save(m, System.Drawing.Imaging.ImageFormat.Png);
            return m.ToArray();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
