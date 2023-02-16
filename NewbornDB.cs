using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPSTONEPROJ
{
    class NewbornDB
    {
        private MySqlCommand cmd;
        private MySqlConnection connection;

        public NewbornDB()
        {
            connection = new MySqlConnection("datasource=localhost;port=3306;username=root;password=;database=safrahbirthingclinic_db;");
            cmd = connection.CreateCommand();
            cmd.CommandType = CommandType.Text;
        }
        public MySqlConnection getConnection()
        {
            return connection;
        }
        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public Boolean insertNewborn(string id, string motherId, string first, string middle, string last, string suffix, string sex, string dob, string religionId, string weight, string height, string headc, string chestc, string abdomenc, string attendantId, string date, string time)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `newbornpatient_tbl`(`newbornid`, `motherId`, `firstname`, `middlename`, `lastname`, `suffix`, `sex`, `dob`, `religion`, `weight`, `height`, `headc`, `chestc`, `abdomenc`, `attendantId`, `date`, `time`) VALUES " + "('"+id+"','"+motherId+"','" + first+"','"+middle+"','"+last+"','"+suffix+"','"+sex+"','"+dob+"','"+religionId+"','"+weight+"','"+height+"','"+headc+"','"+chestc+"','"+abdomenc+"','"+attendantId+"','"+date+"','"+time+"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }

        public DataTable getNewborn()
        {
            openConnection();
            cmd.CommandText = "SELECT `newbornid`,`firstname`, `middlename`, `lastname`, `suffix` FROM `newbornpatient_tbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }

        public MySqlDataReader editNewborn(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `newbornpatient_tbl` WHERE `newbornid` = '" + id + "' ";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updateNewborn(string id, string motherId, string first, string middle, string last, string suffix, string sex, string dob, string religionId, string weight, string height, string headc, string chestc, string abdomenc, string attendantId)
        {
            openConnection();
            cmd.CommandText = "UPDATE `newbornpatient_tbl` SET `motherId`='"+motherId+"',`firstname`='"+first+"',`middlename`='"+middle+"',`lastname`='"+last+"',`suffix`='"+suffix+"',`sex`='"+sex+"',`dob`='"+dob+"',`religion`='"+religionId+"',`weight`='"+weight+"',`height`='"+height+"',`headc`='"+headc+"',`chestc`='"+chestc+"',`abdomenc`='"+abdomenc+"',`attendantId`='"+attendantId+ "' WHERE `newbornpatient_tbl`.`newbornid`='" + id+"'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deleteNewborn(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `newbornpatient_tbl` WHERE `newbornid` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }
        public MySqlDataReader getNewborn(string id)
        {
            openConnection();
            cmd.CommandText = "select * from newbornpatient_tbl where newbornid='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public MySqlDataReader getData(string database, string id)
        {
            openConnection();
            cmd.CommandText = "select * from " + database + " where id='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public DataTable getNewnornInfo()
        {
            openConnection();
            cmd.CommandText = "SELECT `newbornid`, `motherId`, `firstname`, `middlename`, `lastname`, `suffix`, `sex` FROM `newbornpatient_tbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public MySqlDataReader getNewbornInfo(string id)
        {
            openConnection();
            cmd.CommandText = "select * from newbornpatient_tbl INNER JOIN patienttbl ON patienttbl.id = newbornpatient_tbl.motherId WHERE newbornid='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public MySqlDataReader setChildParents(string id)
        {
            openConnection();
            cmd.CommandText = "select * from patienttbl where id='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public MySqlDataReader setNewbornAttendant(string id)
        {
            openConnection();
            cmd.CommandText = "select * from employeetbl where id='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
    }
}
