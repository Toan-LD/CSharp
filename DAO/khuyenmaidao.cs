using Doanqlchdt.connect;
using Doanqlchdt.GUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doanqlchdt.DTO
{
    public class khuyenmaidao
    {

        public ArrayList GetKM()
        {
            ArrayList array = new ArrayList();
            using (SqlConnection connection = new connectToan().connection())
            {
                SqlCommand sql = new SqlCommand("select * from KhuyenMai", connection);
                SqlDataReader reader = sql.ExecuteReader();
                while (reader.Read())
                {
                    khuyenmaidto kmdto = new khuyenmaidto
                    {
                        MaKM = reader.GetString(0),
                        Tile = reader.GetDouble(1)
                    };
                    array.Add(kmdto);
                }
            }
            return array;
        }

        public bool GetMaKM(string maKM)
        {
            using (SqlConnection connection = new connectToan().connection())
            {
                SqlCommand sql = new SqlCommand("SELECT COUNT(*) FROM KhuyenMai WHERE MaKM = @maKhuyenMai", connection);
                sql.Parameters.AddWithValue("@maKhuyenMai", maKM);

                int count = (int)sql.ExecuteScalar();
                return count > 0; // Nếu count > 0, tức là mã khuyến mãi đã tồn tại
            }
        }

        public void AddMaKM(string maKM, double tiLe)
        {
            using (SqlConnection connection = new connectToan().connection())
            {
                SqlCommand sql = new SqlCommand("Insert into KhuyenMai Values (@maKM, @tiLe)", connection);
                sql.Parameters.AddWithValue("@maKM", maKM);
                sql.Parameters.AddWithValue("@tiLe", tiLe);

                sql.ExecuteNonQuery();
            }
        }

        public void DeleteMaKM(string maKM)
        {
            using (SqlConnection connection = new connectToan().connection())
            {
                SqlCommand sql = new SqlCommand("DELETE FROM KhuyenMai WHERE MaKM = @maKM", connection);
                sql.Parameters.AddWithValue("@maKM", maKM);

                sql.ExecuteNonQuery();
            }
        }

        public Boolean checkKM(string makh,string makm)
        {
            int a = 0;
            using(SqlConnection conn = new connectToan().connection())
            {
                string query = "SELECT * FROM SuDungKM WHERE MaKH = @makh AND MaKM COLLATE SQL_Latin1_General_CP1_CS_AS = @makm;";
                SqlCommand cmd=new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@makh",makh);
                cmd.Parameters.AddWithValue("@makm", makm);
                SqlDataReader reader= cmd.ExecuteReader();
                if (reader.Read())
                {
                    a = 1;
                }
                else return false;
            }
            if(a==1) return true; 
            return false;
        }
        public double getTiLe(string id)
        {
            double tile=1;
            using (SqlConnection conn=new connectToan().connection())
            {
                string query = "select * from KhuyenMai where MaKM=@id";
                SqlCommand cmd=new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    tile = (double)reader["TiLeKM"];
                }
            }
            return tile;
        }

        public void updateTrangthai(string makh,string makm)
        {
            using (SqlConnection conn = new connectToan().connection())
            {
                string query = "delete from SuDungKM where MaKM=@makm and MaKH=@makh";
                SqlCommand cmd=new SqlCommand  (query, conn);
                cmd.Parameters.AddWithValue("@makh", makh);
                cmd.Parameters.AddWithValue("@makm", makm);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
