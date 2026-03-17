using MemberApi.Data;
using MemberApi.Interface;
using MemberApi.Model;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace MemberApi.Repository
{
    public class MembersRepository : IMember
    {

        MySqlConnection conn;
        public MembersRepository()
        {
            conn = new MySqlConnection(DbConnection.ConnectionString);
        }
        public List<Member> GetAllMembers()
        {

            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            string query = "SELECT  * FROM member";
            var cmd = new MySqlCommand(query, conn);

            var reader = cmd.ExecuteReader();
            List<Member> members = new List<Member>();
            while (reader.Read())
            {
                members.Add(new Member
                {
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["lastname"]
                });
            }
            conn.Close();
            return members;
        }
        public Member GetMemberbyId(int id)
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            Member? member = null;

            string query = "SELECT * FROM member WHERE MemberId = @id";
            var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            var reader = cmd.ExecuteReader();

            if (reader.Read()) {
                member = new Member
                {
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["lastname"]
                };
            }
            

            conn.Close();
            return member;
        }

        public void CreateMember(Member member)
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            string query = "INSERT INTO member(FirstName,lastname, email, password) VALUES(@FirstName, @lastname, @email, @password)";
            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@FirstName", member.FirstName);
            cmd.Parameters.AddWithValue("@lastname", member.LastName);
            cmd.Parameters.AddWithValue("@email", member.Email);
            cmd.Parameters.AddWithValue("@password", member.Password);
            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void UpdateMember(Member member, int id)
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            string query = "UPDATE member SET FirstName = @FirstName, lastname = @lastname WHERE MemberId = @id";
            using var cmd = new MySqlCommand(query, conn);

            cmd.Parameters.AddWithValue("@FirstName", member.FirstName);
            cmd.Parameters.AddWithValue("@lastname", member.LastName);
            int affectedrows = cmd.ExecuteNonQuery();
            conn.Close();

        }

        public void DeleteMember(int id)
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();

            string query = "DELETE FROM member WHERE MemberId = @id";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);

            int Affectedrows = cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
