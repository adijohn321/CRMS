using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;
using System.Security.Cryptography;

namespace CAPSTONEPROJ
{
    class DropDownAdd
    {
        private MySqlCommand cmd;
        private MySqlConnection connection;
        public DropDownAdd()
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


        //ADD TRANSACTION
        public Boolean insertTransaction(string trans)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `transactiontbl`(`id`, `transaction`) VALUES" + " (NULL,'" + trans + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getTransaction()
        {
            openConnection();
            cmd.CommandText = "SELECT `id` as 'ID', `transaction` as 'Transaction Type' FROM `transactiontbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public MySqlDataReader editTransaction(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `transactiontbl` WHERE `id` = '" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updateTransactionn(string id, string trans)
        {
            openConnection();
            cmd.CommandText = "UPDATE `transactiontbl` SET `transaction`='" + trans + "' WHERE `transactiontbl`.`id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deleteTransaction(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `transactiontbl` WHERE `id` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }
        //ADD RELIGION
        public Boolean insertReligion(string religion)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `religiontbl`(`id`, `religion`) VALUES" + " (NULL,'" + religion + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getReligion()
        {
            openConnection();
            cmd.CommandText = "SELECT `id` as 'ID', `religion` as 'Religion' FROM `religiontbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public MySqlDataReader editReligion(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `religiontbl` WHERE `id` = '" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updateReligion(string id, string religion)
        {
            openConnection();
            cmd.CommandText = "UPDATE `religiontbl` SET `religion`='" + religion + "' WHERE `religiontbl`.`id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deleteReligion(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `religiontbl` WHERE `id` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }
        //ADD PATIENT TYPE
        public Boolean insertPatientType(string patientType)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `patienttypetbl`(`id`, `patienttype`) VALUES " + "(NULL,'" + patientType + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getPatientType()
        {
            openConnection();
            cmd.CommandText = "SELECT `id` as 'ID', `patienttype` as 'Patient Type' FROM `patienttypetbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public MySqlDataReader editPatientType(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `patienttypetbl` WHERE `id` = '" + id + "' ";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updatePatientType(string id, string patientType)
        {
            openConnection();
            cmd.CommandText = "UPDATE `patienttypetbl` SET `patienttype`='" + patientType + "' WHERE `patienttypetbl`.`id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deletePatientType(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `patienttypetbl` WHERE `id` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }

        //ADD EMPLOYEE TYPE

        public Boolean insertEmployeeType(string employeeType)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `employeetitletbl`(`id`, `employeetitle`) VALUES " + "(NULL,'" + employeeType + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getEmployeeType()
        {
            openConnection();
            cmd.CommandText = "SELECT `id` as 'ID', `employeetitle` as 'Employee Title' FROM `employeetitletbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public MySqlDataReader editEmployeeType(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `employeetitletbl` WHERE `id` = '" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updateEmployeeType(string id, string employeeType)
        {
            openConnection();
            cmd.CommandText = "UPDATE `employeetitletbl` SET `employeetitle`='" + employeeType + "' WHERE `employeetitletbl`.`id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deleteEmployeeType(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `employeetitletbl` WHERE `id` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }

        //ADD PROVINCE
        public Boolean insertProvince(string province)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `provincetbl`(`id`, `province`) VALUES" + " (NULL,'" + province + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getProvince()
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `provincetbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public MySqlDataReader editProvince(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `provincetbl` WHERE `id` = '" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updateProvince(string id, string province)
        {
            openConnection();
            cmd.CommandText = "UPDATE `provincetbl` SET `province`='" + province + "' WHERE `provincetbl`.`id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deleteProvince(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `provincetbl` WHERE `id` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }

        //MUNICIPALITY
        public Boolean insertMunicipality(string province, string municipality)
        {

            openConnection();
            cmd.CommandText = "INSERT INTO `municipalitytbl`(`id`, `province`, `municipality`) VALUES" + " (NULL,'" + province + "','" + municipality + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getMunicipality()
        {
            openConnection();
            cmd.CommandText = "SELECT `id` as 'ID', `province` as 'Province', `municipality` as 'City/Municipality' FROM `municipalitytbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public MySqlDataReader editMunicipality(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `municipalitytbl` WHERE `id` = '" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updateMunicipality(string id, string province, string citymuni)
        {
            openConnection();
            cmd.CommandText = "UPDATE `municipalitytbl` SET `province`='" + province + "',`municipality`='" + citymuni + "' WHERE `municipalitytbl`.`id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deleteMunicipality(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `municipalitytbl` WHERE `id` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }

        //BARANGAY
        public Boolean insertBarangay(string province, string municipality, string barangay)
        {

            openConnection();
            cmd.CommandText = "INSERT INTO `philippinelocaltbl`(`addressId`, `province`, `citymunicipality`, `barangay`) VALUES" + " (NULL,'" + province + "','" + municipality + "','" + barangay + "')";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getBarangay()
        {
            openConnection();
            cmd.CommandText = "SELECT `addressId` as 'Barangay ID', `province` as 'Province', `citymunicipality` as 'City/Municipality', `barangay` as 'Barangay' FROM `philippinelocaltbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public MySqlDataReader editBarangay(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `philippinelocaltbl` WHERE `addressId` = '" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updateBarangay(string id, string province, string citymuni, string barangay)
        {
            openConnection();
            cmd.CommandText = "UPDATE `philippinelocaltbl` SET `province`='" + province + "',`citymunicipality`='" + citymuni + "',`barangay`='" + barangay + "' WHERE `philippinelocaltbl`.`addressId`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deleteBarangay(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `philippinelocaltbl` WHERE `addressId` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }
        //DISCOUNT
        public Boolean insertDiscount(string discountType, string discountRate)
        {

            openConnection();
            cmd.CommandText = "INSERT INTO `discount_tbl`(`discountId`, `discountType`, `discountrate`) VALUES " + " (NULL,'" + discountType + "','" + discountRate + "')";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getDiscount()
        {
            openConnection();
            cmd.CommandText = "SELECT `discountId`, `discountType`, `discountrate` FROM `discount_tbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public MySqlDataReader editDiscount(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `discount_tbl` WHERE `discountId` = '" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public MySqlDataReader getDiscountRate(string id)
        {
            openConnection();
            cmd.CommandText = "select * from discount_tbl where discountId='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updateDiscount(string id,string discountType, string discountRate)
        {
            openConnection();
            cmd.CommandText = "UPDATE `discount_tbl` SET `discountType`='" + discountType + "',`discountrate`='" + discountRate + "' WHERE `discount_tbl`.`discountId`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deleteDiscount(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `discount_tbl` WHERE `discountId` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }
        //RoomBed
        public Boolean insertRoomBed(string id, string room, string bed, string type, string price, string capacity, string roomType)
        {

            openConnection();
            if(bed==null)
                cmd.CommandText = "INSERT INTO `roombed_tbl`(`roomBed_Id`, `roomName`, `bedNo`, `type`, `capacity`, `roomType`) VALUES  " + " ('"+id+"','" + room + "','', '" + type + "','" + capacity + "','" + roomType + "')";
            else
                cmd.CommandText = "INSERT INTO `roombed_tbl`(`roomBed_Id`, `roomName`, `bedNo`, `type`, `price`) VALUES  " + " ('"+id+"','"+room+"','"+bed+"', '"+type+"', '"+price+"')";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getRoomBed()
        {
            openConnection();
            cmd.CommandText = "SELECT `roomBed_Id` as 'Room/Bed ID', `roomName` as 'Room', `bedNo` as 'Bed No.', `type` as 'Type', `price` as 'Price' , `roomType`, `capacity` FROM `roombed_tbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public MySqlDataReader editRoomBed(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `roombed_tbl` WHERE `roomBed_Id` = '" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public MySqlDataReader getRoomBedType(string id)
        {
            openConnection();
            cmd.CommandText = "select * from roombed_tbl where roomBed_Id='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updateRoomBed(string id, string room, string bed, string price)
        {
            openConnection();
            if(bed==null)
                cmd.CommandText = "UPDATE `roombed_tbl` SET `roomName`='" + room + "',`bedNo`= NULL,`price`= NULL WHERE `roombed_tbl`.`roomBed_Id`='" + id + "'";
            else
                cmd.CommandText = "UPDATE `roombed_tbl` SET `roomName`='"+room+"',`bedNo`='"+bed+"',`price`='"+price+"' WHERE `roombed_tbl`.`roomBed_Id`='" + id+"'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deleteRoomBed(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `roombed_tbl` WHERE `roomBed_Id` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }
    }
}
