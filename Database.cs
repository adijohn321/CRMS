using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace CAPSTONEPROJ
{
    class Database
    {
        private MySqlCommand cmd;
        private MySqlConnection connection;
        public Database()
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

        public Boolean login(string username, string password)
        {
            return true;
        }
        public MySqlDataReader getUserLevel(string username, string password)
        {
            openConnection();
            cmd.CommandText = "select * from users where username='" + username + "' and password='" + password + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public MySqlDataReader getData(string database, string id)
        {
            openConnection();
            cmd.CommandText = "select * from "+database+" where id='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
       
        public Boolean insertUser(string name, string username, string password, string userlevel)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `users`(`id`, `username`, `password`, `userlevel`, `name`) VALUES " + " (NULL,'" + username + "','" + password + "','" + userlevel + "','" + name + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }


        //EMPLOYEE
        public Boolean insertEmployee(string id, string firstname, string middlename, string lastname, string dob, string age, string title, string license, string religion, string contactnum, string province, string municipality, string barangay, string houseno, string street)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `employeetbl`(`id`, `firstname`, `middlename`, `lastname`, `dateofbirth`, `age`, `title`, `license`, `religion`, `contactnumber`, `province`, `city/mun`, `barangay`, `houseno`, `street`) VALUES " + " ('"+id+"','" + firstname + "','" + middlename + "','" + lastname + "','" + dob + "','" + age + "','" + title + "','" + license + "','" + religion + "','" + contactnum + "','" + province + "','" + municipality + "','" + barangay + "','" + houseno + "','" + street + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getEmployee()
        {
            openConnection();
            cmd.CommandText = "SELECT `id` as 'Employee ID', `firstname` as 'First Name', `middlename` as 'Middle Name', `lastname` as 'Last Name', `title` as 'Title' FROM `employeetbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public DataTable getEmployeeCredit()
        {
            openConnection();
            cmd.CommandText = "SELECT `id` as 'Employee ID', `firstname` as 'First Name', `middlename` as 'Middle Name', `lastname` as 'Last Name' FROM `employeetbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public MySqlDataReader editEmployee(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `employeetbl` WHERE `id` = '" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updateEmployee(string id, string firstname, string middlename, string lastname, string dob, string age, string title, string license, string religion, string contactnum, string province, string municipality, string barangay, string houseno, string street)
        {
            openConnection();
            cmd.CommandText = "UPDATE `employeetbl` SET `firstname`='" + firstname + "',`middlename`='" + middlename + "',`lastname`='" + lastname + "',`dateofbirth`='" + dob + "',`age`='" + age + "',`title`='" + title + "',`license`='" + license + "',`religion`='" + religion + "',`contactnumber`='" + contactnum + "',`province`='" + province + "',`city/mun`='" + municipality + "',`barangay`='" + barangay + "',`houseno`='" + houseno + "',`street`='" + street + "' WHERE `employeetbl`.`id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deleteEmployee(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `employeetbl` WHERE `id` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }
        //PATIENT Pediatric
        public Boolean insertChildren(string id, string firstname, string middlename, string lastname, string dob, string age, string sex,string religion,string mother, string father, string addressId, string street, string houseno)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `childrentbl`(`id`, `firstname`, `middlename`, `lastname`, `p_DOB`, `age`, `sex`, `religion`, `mother`, `father`, `addressId`,`street`, `houseno`) VALUES " + " ('"+id+"', '"+firstname+ "','" + middlename + "','" + lastname + "','" + dob + "','" + age + "','" + sex + "','" + religion + "','" + mother + "','" + father + "','" + addressId + "','" + street + "','" + houseno + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public MySqlDataReader getPediatricInfo(string id)
        {
            openConnection();
            cmd.CommandText = "select * from childrentbl INNER JOIN philippinelocaltbl ON philippinelocaltbl.addressId = childrentbl.addressId where id='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public MySqlDataReader editChildren(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `childrentbl` WHERE `id` = '" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updateChildren(string id, string firstname, string middlename, string lastname, string dob, string age, string sex, string religion, string mother, string father, string addressId, string street, string houseno)
        {
            openConnection();
            cmd.CommandText = "UPDATE `childrentbl` SET `firstname`='" + firstname + "',`middlename`='" + middlename + "',`lastname`='" + lastname + "',`p_DOB`='" + dob + "',`age`='" + age + "',`sex`='" + sex + "',`religion`='" + religion + "', `mother`='" + mother + "',`father`='" + father + "',`addressId`='" + addressId + "',`street`='" + street + "',`houseno`='" + houseno + "' WHERE `childrentbl`.`id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deleteChildren(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `childrentbl` WHERE `id` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }//PATIENT Newborn
        public Boolean insertNewborn(string id, string firstname, string middlename, string lastname,string suffix, string sex, string dob , string religion, string motherId,  string wt, string hc, string cc, string ac, string amstl, string einc, string hepab, string bcg, string eo, string apgar, string attendant, string date)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `newborn_tbl`(`newbornId`, `firstname`, `middlename`, `lastname`, `suffix`, `sex`, `dob`, `religion`, `patientId`, `weight`, `hc`, `cc`, `ac`, `amstl`, `einc`, `hepab`, `bcg`, `eyeOintment`, `apgar`, `attendant`, `date`) VALUES " + "('"+id+"','" + firstname + "','" + middlename + "','" + lastname + "','" + suffix + "','" + sex + "','" + dob + "','" + religion + "','" + motherId + "','" + wt + "','" + hc + "','" + cc + "','" + ac + "','" + amstl + "','" + einc + "','" + hepab + "','" + bcg + "','" + eo + "','" + apgar + "', '" + attendant + "', '"+date+"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public MySqlDataReader getNewbornInfo(string id)
        {
            openConnection();
            cmd.CommandText = "select * from newborn_tbl INNER JOIN patienttbl ON patienttbl.id = newborn_tbl.motherId WHERE newbornId='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        /*public DataTable getNewborn()
        {
            openConnection();
            cmd.CommandText = "SELECT `newbornId` as 'Newborn ID', `firstname` as 'First name', `middlename` as 'Middle name', `lastname` as 'Last name', `suffix` as 'Suffix', `sex` as 'Sex' FROM `newborn_tbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }*/
        public MySqlDataReader editNewborn(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `newborn_tbl` WHERE `newbornId` = '" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean UpdateNewborn(string id, string firstname, string middlename, string lastname, string suffix, string sex, string dob, string religion, string motherId,string wt,  string hc, string cc, string ac, string amstl, string einc, string hepab, string bcg, string eo, string apgar, string attendant)
        {
            openConnection();
            cmd.CommandText = "UPDATE `newborn_tbl` SET `firstname`='" + firstname + "',`middlename`='" + middlename + "',`lastname`='" + lastname + "',`suffix`='" + suffix + "',`sex`='" + sex + "',`dob`='" + dob + "',`religion`='" + religion + "',`patientId`='" + motherId + "',`weight`='" + wt + "',`hc`='" + hc + "',`cc`='" + cc + "',`ac`='" + ac + "',`amstl`='" + amstl + "',`einc`='" + einc + "',`hepab`='" + hepab + "',`bcg`='" + bcg + "',`eyeOintment`='" + eo + "',`apgar`='" + apgar + "',`attendant`='" + attendant + "' WHERE `newborn_tbl`.`newbornId`='" + id + "'";
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
            cmd.CommandText = "DELETE FROM `newborn_tbl` WHERE `newbornId` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }
        //PATIENT
        public Boolean insertPatient(string id, string firstname, string middlename, string lastname, string dob, string religion, string contactnum, string addressId, string street, string houseno,string married, string hfirst, string hmiddle, string hlast, string hdob, string hreligion)
        {
            openConnection();
            
            cmd.CommandText = "INSERT INTO `patienttbl`(`id`, `firstname`, `middlename`, `lastname`, `dateofbirth`, `religion`, `contactnum`, `addressId`, `street`, `house_no`, `married`, `husbandfirst`, `husbandmiddle`, `husbandlast`, `husbanddob`, `husbandreligion`) VALUES ('"+id+"','" + firstname + "','" + middlename + "','" + lastname + "','" + dob + "','" + religion + "','" + contactnum + "','" + addressId + "','" + street + "','" + houseno + "','" + married + "','" + hfirst + "','" + hmiddle + "','" + hlast + "','" + hdob + "', '" + hreligion + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public MySqlDataReader getPateintInfo(string id)
        {
            openConnection();
            cmd.CommandText = "select * from patienttbl INNER JOIN philippinelocaltbl ON philippinelocaltbl.addressId = patienttbl.addressId where id='" + id + "'";
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
        public DataTable getPatient()
        {
            openConnection();
            cmd.CommandText = "SELECT `id` as 'ID', `firstname` as 'First Name', `middlename` as 'Middle Name', `lastname` as 'Last Name' FROM `patienttbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public MySqlDataReader editPatient(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `patienttbl` WHERE `id` = '" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public Boolean updatePateint(string id, string firstname, string middlename, string lastname, string dob, string religion, string contactnum, string addressId, string street, string houseno, string married, string hfirst, string hmiddle, string hlast, string hdob, string hreligion)
        {
            openConnection();
            cmd.CommandText = "UPDATE `patienttbl` SET `firstname`='" + firstname + "',`middlename`='" + middlename + "',`lastname`='" + lastname + "',`dateofbirth`='" + dob + "',`religion`='" + religion + "',`contactnum`='" + contactnum + "',`addressId`='" +addressId+ "',`street`='" + street + "',`house_no`='" + houseno + "',`married`='" + married + "',`husbandfirst`='"+hfirst+"',`husbandmiddle`='"+hmiddle+"',`husbandlast`='"+hlast+"',`husbanddob`='"+hdob+"',`husbandreligion`='"+hreligion+"' WHERE `patienttbl`.`id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public Boolean deletePatient(string id)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `patienttbl` WHERE `id` = '" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }
        //Transaction
        public Boolean consultation(string p_id,  string name, string age, string dob, string dt, string time, string attendant, string bp, string wt, string temp, string symptoms, string medication, string diagnosis)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `consultationtbl`(`case_id`, `p_id`, `p_name`, `p_age`, `p_DOB`, `p_DT`,`p_Time`, `p_attendant`, `p_bp`, `p_wt`, `p_temp`, `p_symptoms`, `p_medication`, `p_diagnosis`) VALUES (NULL,'" + p_id + "','" + name + "','" + age + "','" + dob + "','" + dt + "', '" + time + "','" + attendant + "','" + bp + "','" + wt + "','" + temp + "','" + symptoms + "','" + medication + "','" + diagnosis + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean admission(string p_id, string name, string age, string dob, string dt,string time, string attendant, string bp, string wt, string temp, string diagnosis, string finaldiagnosis)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `admissiontbl`(`case_id`, `p_id`, `p_name`, `p_age`, `p_DOB`, `p_DT`, `p_Time`, `p_attendant`, `p_bp`, `p_wt`, `p_temp`, `p_diagnosis`, `p_finaldiagnosis`) VALUES (NULL,'" + p_id + "','" + name + "','" + age + "','" + dob + "','" + dt + "','" + time + "','" + attendant + "','" + bp + "','" + wt + "','" + temp + "','" + diagnosis + "','" + finaldiagnosis + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean discharge(string p_id, string name, string age, string dob, string dt, string address, string bp, string wt, string temp, string medatHome, string deliverydate, string followup, string remarks)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `dischargetbl`(`case_id`, `p_id`, `p_name`, `p_age`, `p_DOB`, `p_DT`, `p_address`, `p_bp`, `p_wt`, `p_temp`, `p_medathome`, `p_dateofdelivery`, `p_followup`, `p_remarks`) VALUES (NULL,'" + p_id + "','" + name + "','" + age + "','" + dob + "','" + dt + "','" + address + "','" + bp + "','" + wt + "','" + temp + "','" + medatHome + "','" + deliverydate + "','" + followup + "','" + remarks + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean prenatal(string p_id, string name, string age, string dob, string dt, string time, string address, string trimester, string bp, string wt, string temp, string pal, string lmp, string edc, string followup)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `prenataltbl`(`case_id`, `p_id`, `p_name`, `p_age`, `p_DOB`, `p_DT`, `p_Time`, `p_address`, `p_trimester`, `p_bp`, `p_wt`, `p_temp`, `p_pal`, `p_lmp`, `p_edc`, `p_followup`) VALUES (NULL,'" + p_id+"','"+name+"','"+age+"','"+dob+"','"+dt+ "', '" + time + "','" + address+"','"+trimester+"','"+bp+"','"+wt+"','"+temp+"','"+pal+"','"+lmp+"','"+edc+"','"+followup+"');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getCaseRecord()
        {
            openConnection();
            cmd.CommandText = "SELECT `case_id`, `p_id`, `p_name` FROM `consultationtbl` UNION SELECT `case_id`, `p_id`, `p_name` FROM `prenataltbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public DataTable getAdmission()
        {
            openConnection();
            cmd.CommandText = "SELECT `case_id` as 'Case ID', `p_name` as 'Patient Name', `p_DT` as 'Date of Admission' FROM `admissiontbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        //Medicine+Service Price
        public Boolean insertmedicineServicePrice(string itemName, string itemPrice, string itemtype)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `pricetbl`(`itemId`, `itemName`, `itemPrice`, `itemType`) VALUES (NULL,'" + itemName + "','" + itemPrice+ "','" + itemtype + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public MySqlDataReader getServiceMed(string id)
        {
            openConnection();
            cmd.CommandText = "select * from pricetbl where itemId='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public DataTable getmedicineServicePrice()
        {
            openConnection();
            cmd.CommandText = "SELECT `itemId` as 'Item ID', `itemName` as 'Item Name', `itemPrice` as 'Item Price', `itemType` as 'Item Type' FROM `pricetbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public MySqlDataReader editmedicineServicePrice(string itemId)
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `pricetbl` WHERE `itemId`='" + itemId + "";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public Boolean updatemedService(string id, string name, string price, string itemtype)
        {
            openConnection();
            cmd.CommandText = "UPDATE `pricetbl` SET `itemName`='"+name+"',`itemPrice`='"+price+"',`itemType`='"+itemtype+ "' WHERE `pricetbl`.`itemId`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        /*public Boolean updatemedicineServicePrice(string itemId, string itemName, string itemPrice, string itemType)
        {
            openConnection();
            cmd.CommandText = "UPDATE `pricetbl` SET `itemName`='"+itemName+"',`itemPrice`='"+itemPrice+"',`itemType`='"+itemType+"' WHERE `pricetbl`.`itemId`='"+itemId+"";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }*/
        public Boolean deletemedicineServicePrice(string itemId)
        {
            openConnection();
            cmd.CommandText = "DELETE FROM `pricetbl` WHERE `itemId`='" + itemId + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }

            return false;
        }


        public Boolean updatePateintStatus(string id, string status)
        {
            openConnection();
            cmd.CommandText = "UPDATE `patienttbl` SET `status`='" + status + "' WHERE `id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        //insert case Information
        public Boolean insertCaseInfo(string caseNumber, string pateintId, string age, string bp, string weight, string temp, string roomNumber, string bedNumber, string attendantId, string admittingDiagnosis , string time,string date)
        {
            openConnection();

            //cmd = INSERT INTO `admittedpateinttbl`(`caseNumber`, `pateintId`, `admissionType`, `bp`, `weight`, `temp`, `roomNumber`, `bedNumber`, `attendantId`, `admittingDiagnosis`, `finalDiagnosis`) VALUES ([value-1],[value-2],[value-3],[value-4],[value-5],[value-6],[value-7],[value-8],[value-9],[value-10],[value-11])
            cmd.CommandText = "INSERT INTO `admittedpateinttbl`(`caseNumber`, `pateintId`, `age`, `bp`, `weight`, `temp`, `roomNumber`, `bedNumber`, `attendantId`, `admittingDiagnosis`, `time`,`date`) VALUES ('" + caseNumber+"','"+pateintId+ "','" + age + "','" + bp+ "','"+weight+ "','"+temp+ "','"+roomNumber+ "','"+bedNumber+ "','"+attendantId+ "','"+admittingDiagnosis+ "','" + time + "','" + date+"')";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getadmitted()
        {
            openConnection();
            cmd.CommandText = "SELECT `caseNumber` as 'Case ID', `pateintId` as 'Patient ID', `roomNumber` as 'Room No.', `bedNumber` as 'Bed No.', `attendantId` as 'Attendant', `admittingDiagnosis` as 'Admitting Diagnosis' FROM `admittedpateinttbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public Boolean insertBill(string invoiceNumber, string pateintId, string caseNumber)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `bills`(`invoiceNumber`, `pateintId`, `status`, `caseNumber`) VALUES ('" + invoiceNumber + "','" + pateintId + "','0','"+caseNumber+"')";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public string getInvoiceNumber(string id) {
            openConnection();
            cmd.CommandText = "SELECT invoiceNumber from bills where pateintId = '"+id+"' AND status ='0'";
            string ret = cmd.ExecuteScalar().ToString();
            closeConnection();
            return ret;
        }
        public string getLaborId()
        {
            openConnection();
            cmd.CommandText = "SELECT itemId from pricetbl where itemName = 'Labor'";
            string ret = cmd.ExecuteScalar().ToString();
            closeConnection();
            return ret;
        }
        public string getWhatFromWhere(string what, string where, string uniqueRow, string uniqueRowVal)
        {
            openConnection();
            cmd.CommandText = "SELECT "+what+" from "+where+" where "+uniqueRow+" = '"+uniqueRowVal+"'";
            string ret = cmd.ExecuteScalar().ToString();
            closeConnection();
            return ret;
        }
        public Boolean updateWhatFromWhere(string what,string value, string where, string uniqueRow, string uniqueRowVal)
        {
            openConnection();
            cmd.CommandText = "UPDATE `"+where+"` SET `"+what+"`='" + value + "' WHERE `"+uniqueRow+"`='" + uniqueRowVal + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }

        public Boolean updateDayAndTotal(string days, string total, string invoice, string itemId)
        {
            openConnection();
            cmd.CommandText = "UPDATE `invoicetbl` SET `quantity`='"+days+"',`total`='"+total+"' WHERE invoiceNo = '"+invoice+"' AND itemId = '"+itemId+"'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }

        public Boolean insertInvoice(string invoiceNumber, string pateintId, string itemId, string qty, string total)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `invoicetbl`(`invoiceNo`, `pateintId`, `itemId`, `quantity`, `date`, `total`) VALUES ('" + invoiceNumber + "','"+pateintId+"','" + itemId + "','"+qty+"','"+DateTime.Now.ToString("yyyy-MM-dd")+"', '"+total+"')";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public MySqlDataReader getTotalAmount(string invoiceNumber)
        {
            openConnection();
            cmd.CommandText = "select total from invoicetbl where invoiceNo='" + invoiceNumber + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }


        public Boolean insertPrenatal(string caseNumber, string date, string lmp, string time, string pateintId, string bp, string weight, string diagnosis, string attendant)
        {
            openConnection();

            cmd.CommandText = "INSERT INTO `prenatal`(`caseNumber`, `date`, `lmp`, `time`, `pateintId`, `bp`, `weight`, `diagnosis`, `attendant`) VALUES ('" + caseNumber + "','" + date + "','" + lmp + "','" + time + "','" + pateintId + "','" + bp + "','" + weight + "','" + diagnosis + "','" + attendant + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }

        public DataTable getPrenatal()
        {
            openConnection();
            cmd.CommandText = "SELECT * FROM `prenatal` WHERE lmp >= '"+DateTime.Now.AddMonths(-10).ToString("yyyy-MM-dd")+"'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public string getLmp(string id)
        {
            openConnection();
            try
            {
                cmd.CommandText = "SELECT lmp from prenatal where pateintId='" + id + "' AND lmp >='" + DateTime.Now.AddMonths(-10).ToString("yyyy-MM-dd") + "'";
                if(cmd.ExecuteScalar()!=null)
                    return DateTime.Parse(cmd.ExecuteScalar().ToString()).ToString("yyyy-MM-dd");
                closeConnection();
            }
            catch (NullReferenceException) {
            }
            return null;
        }
        public DataTable getHistory(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT caseNumber as 'Case ID',date as 'Date' FROM `prenatal` WHERE pateintId='" + id + "' UNION SELECT caseNumber,date FROM admittedpateinttbl WHERE pateintId ='" + id + "'UNION SELECT caseNumber, date FROM consultationtbl WHERE pateintId ='" + id+ "'UNION SELECT caseNumber, date FROM discharge_tbl WHERE pateintId ='" + id + "'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }

        public Boolean insertConsultation(string caseNumber,string pateintId, string date, string time, string attendant, string bp, string weight, string temp, string symptoms, string urinetest, string diagnosis)
        {
            openConnection();

            cmd.CommandText = "INSERT INTO `consultationtbl`(`caseNumber`, `pateintId`, `date`, `time`, `attendant`, `bp`, `weight`, `temp`, `symptoms`, `urinary_test`, `diagnosis`) VALUES  ('" + caseNumber + "','" + pateintId + "','" + date + "','" + time + "','" + attendant + "','" + bp + "','" + weight + "','" + temp + "','" + symptoms + "','" + urinetest + "','" + diagnosis + "');";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }

        public DataTable getConsultation()
        {
            openConnection();
            cmd.CommandText = "SELECT `caseNumber` as 'Case ID', `pateintId` as 'Patient ID', `date` as 'Date', `time` as 'Time'  FROM `consultationtbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }

        public DataTable getOutPatient(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT id as 'Patient ID',firstname as 'First Name', middlename as 'Middle Name', lastname as 'Last Name' FROM `patienttbl` WHERE id='" + id + "' UNION SELECT newbornid AS 'id',firstname,middlename,lastname FROM newbornpatient_tbl WHERE newbornid ='" + id + "'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }

        public Boolean insertApgar(string id, string apearance, string pulse, string grimace, string activity, string respiration, string total)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `newbornapgarscore_tbl`(`newbornid`, `appearance`, `pulse`, `grimace`, `activity`, `respiration`, `apgartotalscore`) VALUES ('"+id +"','"+apearance+"','"+pulse+"','"+grimace+"','"+activity+"','"+respiration+"','"+total+"')";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }

        public Boolean insertAMSTLeinc(string newbornid, string args)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `amstlandeinc`(`newbornid`, `amstlEINC`) VALUES('"+newbornid+"', '"+args+"')";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }


        public Boolean insertMedicine(string id, string brand, string name,  string dosage, string price, string desc)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `medicine_tbl`(`id`, `brand`, `name`, `dosage`, `price`, `description`) VALUES " + "('"+id+"','" + brand + "','" + name + "','" + dosage + "','" + price + "','" + desc + "');";
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
            cmd.CommandText = "SELECT `id`, `brand`, `name`, `dosage`, `price`, `description` FROM `medicine_tbl`";
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
        public Boolean updateMedicine(string id, string brand, string name, string dosage, string price, string desc)
        {
            openConnection();
            cmd.CommandText = "UPDATE `medicine_tbl` SET `brand`='" + brand + "',`name`='" + name + "',`dosage`='" + dosage + "',`price`='" + price + "',`description`='" + desc + "' WHERE `medicine_tbl`.`id`='" + id + "'";
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
       /* public MySqlDataReader getData(string database, string id)
        {
            openConnection();
            cmd.CommandText = "select * from " + database + " where id='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }*/
        public DataTable getMedicineInfo()
        {
            openConnection();
            cmd.CommandText = "SELECT `id` as 'Item ID', `brand` as 'Brand', `name` as 'Name', `dosage` as 'Dosage',  `price` as 'Price', 1description` as 'Rx' FROM `medicine_tbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }


        //////////// NONDRUGS
        ///
        public Boolean insertItems(string id, string brand, string name, string dosage , string price, string desc)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `nondrugs_tbl`(`id`, `brand`, `name`,  `usages`, `price`,`description`) VALUES " + "('"+id+"','" + brand + "','" + name + "','" + dosage + "','" + price + "','" + desc + "');";
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
            cmd.CommandText = "SELECT `id`, `brand`, `name`, `price`, `usages`, `description` FROM `nondrugs_tbl`";
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
            cmd.CommandText = "UPDATE `nondrugs_tbl` SET `brand`='" + brand + "',`name`='" + name + "',`price`='" + price + "',`usages`='" + dosage + "',`description`='" + desc + "' WHERE `nondrugs_tbl`.`id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public string getRoomId(string data,string name, string number)
        {
            openConnection();
            try
            {
                cmd.CommandText = "SELECT "+data+" from roombed_tbl where roomName='" + name + "' AND bedNo = '"+number+"'";
                if (cmd.ExecuteScalar() != null)
                    return cmd.ExecuteScalar().ToString();
                closeConnection();
            }
            catch (NullReferenceException)
            {
            }
            return null;
        }

        //////////// DELIVERY
        ///
        public Boolean insertDelivery(string caseNum,string patientId, string gravida, string para, string datedeliver, string timedeliver, string ampm, string status, string sex, string weight, string height, string hc, string cc, string ac, string hepab, string attendant, string assisted, string management, string fullname, string address, string age)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `delivery_tbl`(`caseNumber`, `patientId`, `gravida`, `para`, `dateDeliver`, `timeDeliver`, `ampm`, `status`, `sex`, `weight`, `height`, `hc`, `cc`, `ac`, `hepab`, `attendant`, `assisted`, `management`,`age`,`fullName`,`address`,`g/p`) VALUES ('"+caseNum+"','"+patientId+"','"+gravida+"','"+para+"','"+datedeliver+"','"+timedeliver+"','"+ampm+"','"+status+"','"+sex+"','"+weight+"','"+height+"','"+hc+"','"+cc+"','"+ac+"','"+hepab+"','"+attendant+"','"+assisted+"','"+management+"','"+age+"','"+fullname+"','"+address+"','"+gravida+"/"+para+"')";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }

        public MySqlDataReader getAddress(string id)
        {
            openConnection();
            cmd.CommandText = "select * from philippinelocaltbl where addressId='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }

        public string getAdmissionDate(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT date from admittedpateinttbl where pateintId = '"+id+"' and status = '1'";
            string ret = cmd.ExecuteScalar().ToString();
            closeConnection();
            return ret;
        }

        public string getcaseNo(string id)
        {
            openConnection();
            cmd.CommandText = "SELECT caseNumber from admittedpateinttbl where pateintId = '" + id + "' and status = '1'";
            string ret = cmd.ExecuteScalar().ToString();
            closeConnection();
            return ret;
        }
        public string getbedId(string room, string bed)
        {
            openConnection();
            cmd.CommandText = "SELECT roomBed_Id from roombed_tbl where roomName = '" + room + "' and bedNo = '"+bed+"'";
            string ret = cmd.ExecuteScalar().ToString();
            closeConnection();
            return ret;
        }

        public Boolean updatestatuscasenumber(string id)
        {
            openConnection();
            cmd.CommandText = "UPDATE `admittedpateinttbl` SET `status`='0' WHERE `pateintId`='" + id + "' and status ='1'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        //////////// DELIVERY
        ///
        public Boolean insertdischarge(string caseNum, string patientId, string age, string date, string attendant, string time, string bp, string weight, string temp, string finaldiag, string med, string disposition)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `discharge_tbl`(`caseNumber`, `pateintId`, `age`, `date`, `time`, `attendant`, `bp`, `weight`, `temp`, `finaldiag`, `medathome`, `disposition`) VALUES ('" + caseNum + "','" + patientId + "','" + age + "','" + date + "','" + time + "','"+attendant+"','" + bp + "','" + weight + "','" + temp + "','" + finaldiag + "','" + med + "','" + disposition + "')";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public Boolean insertBrand(string id, string type, string name, string distributor)
        {
            openConnection();
            cmd.CommandText = "INSERT INTO `brand_tbl`(`id`, `type`, `name`, `distributor`) VALUES ('" + id + "','" + type + "','" + name + "','" + distributor + "')";
            if (cmd.ExecuteNonQuery() == 1)
            {
                closeConnection();
                return true;
            }
            closeConnection();
            return false;
        }
        public DataTable getBrands()
        {
            openConnection();
            cmd.CommandText = "SELECT `id`, `type`, `name`, `distributor` FROM `brand_tbl`";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public Boolean UpdateBrand(string id, string type, string name, string distributor)
        {
            openConnection();
            cmd.CommandText = "UPDATE `brand_tbl` SET `type`='"+type+"',`name`='"+name+"',`distributor`='"+distributor+ "' WHERE `brand_tbl`.`id`='" + id + "'";
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected == 1)
            {
                return true;
            }
            return false;
        }
        public MySqlDataReader getBrand(string id)
        {
            openConnection();
            cmd.CommandText = "select * from brand_tbl where id='" + id + "'";
            MySqlDataReader dr = cmd.ExecuteReader();
            return dr;
        }
        public DataTable getToCasheir()
        {
            openConnection();
            cmd.CommandText = "SELECT `invoiceNumber` as 'Invoice No.', `pateintId` as 'Patient ID', `status` as 'Status', `discountType` as 'Discount', `grand_total` as 'Total' FROM `bills` WHERE status = '2'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }
        public DataTable getDelivery(DateTime from, DateTime to)
        {
            openConnection();
            cmd.CommandText = "SELECT `dateDeliver` as 'Date of Delivery',`fullName` as 'Fullname', `address` as 'Address',`age` as 'Age', `g/p` as 'G/P', `status` as 'Status',  `sex` as 'Sex', `weight` as 'Weight',`hepab` as HepaB, `nbs` as 'NBS'  FROM delivery_tbl WHERE dateDeliver BETWEEN '" + from.ToString("yyyyy-MM-dd").Substring(1, 10) + "' AND '" + to.ToString("yyyyy-MM-dd").Substring(1, 10) + "'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }

        public DataTable getSales(DateTime from, DateTime to)
        {
            
            openConnection();
            cmd.CommandText = "SELECT patienttbl.firstname as 'Firstname',patienttbl.middlename as 'Middlename', patienttbl.lastname as 'Lastname', bills.grand_total as 'Bill Total' , admittedpateinttbl.date as 'Date' FROM `bills` INNER JOIN patienttbl ON bills.pateintId = patienttbl.id INNER JOIN admittedpateinttbl on bills.caseNumber = admittedpateinttbl.caseNumber WHERE admittedpateinttbl.date BETWEEN '" + from.ToString("yyyy-MM-dd").Substring(0, 10) + "' AND '" + to.ToString("yyyy-MM-dd").Substring(0, 10) + "'";
            cmd.ExecuteNonQuery();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            closeConnection();
            return table;
        }

    }

}
