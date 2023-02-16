using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CAPSTONEPROJ
{

    class MedicineDB
    {
        private MySqlCommand cmd;
        private MySqlConnection connection;

        public MedicineDB()
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

        public Boolean insertMedicine(string brand, string name, string price, string dosage, string desc)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `medicine_tbl`(`id`, `brand`, `name`, `price`, `dosage`, `description`) VALUES "+"(NULL,'" + brand + "','" + name + "','" + price + "','" + dosage + "','" + desc + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }

        public DataTable getMedicinewithPrice()
        {
            openConnection();
            cmd.CommandText = "SELECT `id`, `brand`, `name`, `price`, `dosage`, `description` FROM `medicine_tbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }

        public MySqlDataReader editMedicine(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `medicine_tbl` WHERE `id` = '" + id + "' ";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updateMedicine(string id, string brand, string name, string price, string dosage, string desc)
        {
            openConnection();
            cmd.CommandText = "UPDATE `medicine_tbl` SET `brand`='" + brand + "',`name`='" + name + "',`price`='" + price + "',`dosage`='" + dosage + "',`description`='" + desc + "' WHERE `medicine_tbl`.`id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deleteMedicine(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `medicine_tbl` WHERE `id` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }
        public MySqlDataReader getmed(string id)
        {
            openConnection();
            cmd.CommandText = "select * from medicine_tbl where id='" + id + "'";
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
        public DataTable getMedicineInfo()
        {
            openConnection();
            cmd.CommandText = "SELECT `id` as 'Item ID', `brand` as 'Brand', `name` as 'Name', `price` as 'Price', `dosage` as 'Dosage',  1description` as 'Rx' FROM `medicine_tbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }


        //////////// NONDRUGS
        ///
        public Boolean insertItems(string brand, string name, string price, string dosage, string desc)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `nondrugs_tbl`(`id`, `brand`, `name`, `price`, `usage`, `description`) VALUES " + "(NULL,'" + brand + "','" + name + "','" + price + "','" + dosage + "','" + desc + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getNondrugswithPrice()
        {
            openConnection();
            cmd.CommandText = "SELECT `id`, `brand`, `name`, `price`, `dosage`, `description` FROM `nondrugs_tbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public Boolean updateNondrugs(string id, string brand, string name, string price, string dosage, string desc)
        {
            openConnection();
            cmd.CommandText = "UPDATE `nondrugs_tbl` SET `brand`='" + brand + "',`name`='" + name + "',`price`='" + price + "',`usage`='" + dosage + "',`description`='" + desc + "' WHERE `nondrugs_tbl`.`id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }

    }
}
