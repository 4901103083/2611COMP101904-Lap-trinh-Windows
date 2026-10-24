using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace Lab12.DAL
{
    public class KetQuaDAL
    {
        // 1. Gọi SP lấy danh sách lớp
        public DataTable GetLop()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand("sp_Lop_GetAll", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // 2. Gọi SP lấy danh sách môn học
        public DataTable GetMonHoc()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand("sp_MonHoc_GetAll", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // 3. Gọi SP lấy danh sách sinh viên theo lớp và môn học
        public DataTable GetKetQua(string maLop, string maMon)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = Database.GetConnection())
            using (SqlCommand cmd = new SqlCommand("sp_KetQua_GetByLopMon", conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaLop", maLop);
                cmd.Parameters.AddWithValue("@MaMon", maMon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // 4. Gọi SP lưu điểm với Transaction
        public bool LuuDiemTransaction(DataTable dtKetQua, string maMon, out int soDongDaLuu)
        {
            soDongDaLuu = 0;
            using (SqlConnection conn = Database.GetConnection())
            {
                conn.Open();
                // Bắt đầu Transaction
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("sp_KetQua_Save", conn, trans))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            // Định nghĩa các tham số trước để tối ưu
                            cmd.Parameters.Add("@MaSV", SqlDbType.VarChar, 20);
                            cmd.Parameters.Add("@MaMon", SqlDbType.VarChar, 20);
                            cmd.Parameters.Add("@Diem", SqlDbType.Float);
                            cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 255);

                            // Duyệt qua từng dòng trong DataTable để lưu
                            foreach (DataRow row in dtKetQua.Rows)
                            {
                                // Chỉ lưu khi ô Điểm không bị trống
                                if (row["Diem"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["Diem"].ToString()))
                                {
                                    cmd.Parameters["@MaSV"].Value = row["MaSV"].ToString();
                                    cmd.Parameters["@MaMon"].Value = maMon;
                                    cmd.Parameters["@Diem"].Value = Convert.ToDouble(row["Diem"]);
                                    cmd.Parameters["@GhiChu"].Value = row["GhiChu"] == DBNull.Value ? "" : row["GhiChu"].ToString();

                                    cmd.ExecuteNonQuery();
                                    soDongDaLuu++;
                                }
                            }
                        }
                        // Nếu mọi thứ suôn sẻ, xác nhận lưu vào CSDL
                        trans.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Nếu có bất kỳ lỗi gì (vd: điểm nhập sai, lỗi ràng buộc), hủy toàn bộ thao tác lưu
                        trans.Rollback();
                        throw new Exception("Quá trình lưu thất bại, đã rollback! Lỗi chi tiết: " + ex.Message);
                    }
                }
            }
        }
    }
}