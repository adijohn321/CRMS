using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CAPSTONEPROJ.File_Management;
using CAPSTONEPROJ.Transaction;
using CAPSTONEPROJ.Inquiry;
using CAPSTONEPROJ.Utilities;
using CAPSTONEPROJ.Report;
using CAPSTONEPROJ.Billing;
using System.Diagnostics;
using CAPSTONEPROJ.Report.SalesReport;

namespace CAPSTONEPROJ
{
    public partial class MainForm : Form
    {
        Database db = new Database();
        public MainForm(string name, string level)
        {
            InitializeComponent();
            lbluserlevel.Text = setUserLevel(level);
            lblusername.Text = name;
            timer1.Start();
            timer1.Interval = 4000;
        }

        public string setUserLevel(string input)
        {
            switch (input)
            {
                case "1":
                    return "Administration";
                case "0":
                    return "Staff";
                default:
                    return "Invalid";
            }
        }
        //
        //TIMER
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTIme = DateTime.Now;
            this.lbltime.Text = dateTIme.ToString("hh:mm tt");
            update();
        }
        private void createNewServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("timedate.cpl");
        }
        //
        //LOAD
        private void MainForm_Load(object sender, EventArgs e)
        {
            lbldate.Text = DateTime.Now.ToString("MM/dd/yyyy");
            lbltime.Text = DateTime.Now.ToString("hh:mm tt");
            inpatientsfrm.MdiParent = MainForm.ActiveForm;
            inpatientsfrm.Show();
        }
        //
        //EXIT
        //
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout.", "System Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                LoginForm frm = new LoginForm();
                frm.Show();
                this.Hide();
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }
        void update()
        {
            employeefrm.dataGridViewEmployee.DataSource = db.getEmployee();
            patientfrm.searchPatient(patientfrm.txtsearch.Text);
            medicine.searchMedicineService(medicine.txtsearch.Text);
            discountRate.searchDiscount(discountRate.txtsearch.Text);
            roomBed.searchRoomBed(roomBed.txtsearch.Text);
            medicinefrm.searchMedicineService(medicinefrm.txtsearch.Text);
            ManageNewbornfrm.searchPatient(ManageNewbornfrm.txtsearch.Text);
            outPatientfrm.searchPatient(outPatientfrm.txtsearch.Text);
            inpatientsfrm.searchPatient(inpatientsfrm.txtsearch.Text);
            Register_Patient.setData();

        }
        //
        //FILE MANAGEMENT
        //
        ManageAddEditDeleteEmployeefrm employeefrm = new ManageAddEditDeleteEmployeefrm();
        ManageAddEditDeletePatientfrm patientfrm = new ManageAddEditDeletePatientfrm();
        ManageAddEditPediatricPatient pediatricPatient = new ManageAddEditPediatricPatient();
        ManageEditDeleteNewbornfrm newbornfrm = new ManageEditDeleteNewbornfrm();
        ManageAddEditDeleteReligionfrm religionfrm = new ManageAddEditDeleteReligionfrm();
        ManageAddEditDeleteEmployeeTitlefrm titlefrm = new ManageAddEditDeleteEmployeeTitlefrm();
        ManageAddEditDeleteProvincefrm provincefrm = new ManageAddEditDeleteProvincefrm();
        ManageAddEditDeleteCityMunicipalityfrm cityMunicipalityfrm = new ManageAddEditDeleteCityMunicipalityfrm();
        ManageAddEditDeleteServiceandMedicine medicine = new ManageAddEditDeleteServiceandMedicine();
        ManageAddEditDeleteBarangayfrm barangayfrm = new ManageAddEditDeleteBarangayfrm();
        ManageAddEditDeleteDiscountfrm discountRate = new ManageAddEditDeleteDiscountfrm();
        ManageAddEditDeleteRoomBedfrm roomBed = new ManageAddEditDeleteRoomBedfrm();
        ManageAddEditDeleteMedicinefrm medicinefrm = new ManageAddEditDeleteMedicinefrm();
        ManageNewbornfrm ManageNewbornfrm = new ManageNewbornfrm();
        List_of_Register_Patient Register_Patient = new List_of_Register_Patient();
        MAnagenondrugs itemtoCharge = new MAnagenondrugs();
        InquiryPatirntInformationfrm InquiryPatirntInformationfrm = new InquiryPatirntInformationfrm();
        TransactionOutPatientfrm outPatientfrm = new TransactionOutPatientfrm();
        TransactionInpatientsfrm inpatientsfrm = new TransactionInpatientsfrm();
        TransactionBillingfrm billingfrm = new TransactionBillingfrm();

        ReportPrenatalfrm ReportPrenatalfrm = new ReportPrenatalfrm();
        ReportNewbornfrm ReportNewbornfrm = new ReportNewbornfrm();

        ReportSales sales = new ReportSales();
        private void registerEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                employeefrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                employeefrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void motherToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                patientfrm.MdiParent = MainForm.ActiveForm;
            
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                patientfrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void toolStripMenuItem7_Click_1(object sender, EventArgs e)
        {

            try
            {
                medicine.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                medicine.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            try
            {
                discountRate.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                discountRate.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            try
            {
                roomBed.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                roomBed.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void addReligionToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                religionfrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                religionfrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void addEmloyeeTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                titlefrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                titlefrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void addProvinceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                provincefrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                provincefrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void addMunicipalityToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                cityMunicipalityfrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                cityMunicipalityfrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void addBarangayToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                barangayfrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                barangayfrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        //
        //SHORTCUTS
        //
        private void btnSpatient_Click(object sender, EventArgs e)
        {
            try
            {
                patientfrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                patientfrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        //
        //INQUIRY
        //

        private void patientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                InquiryPatirntInformationfrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                InquiryPatirntInformationfrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void paymentToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
     
        //
        //TRANSACTION
        //
        //TransactionPayBillfrm payBillfrm = new TransactionPayBillfrm();

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                outPatientfrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                outPatientfrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                inpatientsfrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                inpatientsfrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        private void billingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                billingfrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                billingfrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void paymentToolStripMenuItem2_Click(object sender, EventArgs e)
        {
           /* payBillfrm.MdiParent = MainForm.ActiveForm;
            payBillfrm.Show();*/
        }
        //
        //REPORTS
        //
        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            try
            {
                ReportNewbornfrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                ReportNewbornfrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        //
        //Utilities
        //
        //UtilityChangePasswordfrm passwordfrm = new UtilityChangePasswordfrm();
        private void utilitiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            try
            {
                medicinefrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                medicinefrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }

        }

        private void motherToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                patientfrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                patientfrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void nbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ManageNewbornfrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                ManageNewbornfrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Register_Patient.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                Register_Patient.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
        MAnagenondrugs mAnagenondrugs = new MAnagenondrugs();
        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            try
            {
                mAnagenondrugs.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                mAnagenondrugs.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void inpatientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CashierTab cs = new CashierTab();
                cs.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                cs.Show();
            }
            catch (NullReferenceException) {
                return;
            }
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CreateUser cr = new CreateUser();
                cr.MdiParent = MainForm.ActiveForm;
                //cr.TopMost = true;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.WindowState = FormWindowState.Minimized;
                cr.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void brandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                ManageBrands brands = new ManageBrands();
                brands.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                brands.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            try
            {
                inpatientsfrm.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild !=null)
                    this.ActiveMdiChild.Hide();
                inpatientsfrm.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }

        }

        private void paymentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                sales.MdiParent = MainForm.ActiveForm;
                if(this.ActiveMdiChild!=null)
                    this.ActiveMdiChild.Hide();
                sales.Show();
            }
            catch (NullReferenceException)
            {
                return;
            }
        }
    }
}
