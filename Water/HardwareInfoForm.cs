using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Water
{
    public partial class HardwareInfoForm : Form
    {
        public HardwareInfoForm()
        {
            InitializeComponent();
        }

        private void HardwareInfoForm_Load(object sender, EventArgs e)
        {
            LoadHardwareInfo();
        }

        private void LoadHardwareInfo()
        {
            try
            {
                // جلب جميع معلومات الجهاز
                Dictionary<string, string> hardwareInfo = Clas.HardwareInfo.GetAllHardwareInfo();

                // عرض المعلومات
                txtHardwareID.Text = hardwareInfo.ContainsKey("HardwareID") ? hardwareInfo["HardwareID"] : "";
                txtMachineName.Text = hardwareInfo.ContainsKey("MachineName") ? hardwareInfo["MachineName"] : "";
                txtProcessorID.Text = hardwareInfo.ContainsKey("ProcessorID") ? hardwareInfo["ProcessorID"] : "";
                txtMotherboardSerial.Text = hardwareInfo.ContainsKey("MotherboardSerial") ? hardwareInfo["MotherboardSerial"] : "";
                txtDiskSerial.Text = hardwareInfo.ContainsKey("DiskSerial") ? hardwareInfo["DiskSerial"] : "";
                txtMACAddress.Text = hardwareInfo.ContainsKey("MACAddress") ? hardwareInfo["MACAddress"] : "";
                txtGeneratedDate.Text = hardwareInfo.ContainsKey("GeneratedDate") ? hardwareInfo["GeneratedDate"] : "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في جلب معلومات الجهاز: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                saveFileDialog.FileName = "hardware_info.xml";
                saveFileDialog.Title = "حفظ ملف معلومات الجهاز";
                saveFileDialog.DefaultExt = "xml";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    if (Clas.HardwareInfo.SaveHardwareInfoToFile(filePath))
                    {
                        MessageBox.Show($"تم حفظ ملف معلومات الجهاز بنجاح في:\n{filePath}\n\nيرجى إرسال هذا الملف للمسؤول للحصول على الترخيص.", 
                            "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في حفظ الملف: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnCopyHardwareID_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtHardwareID.Text))
                {
                    Clipboard.SetText(txtHardwareID.Text);
                    MessageBox.Show("تم نسخ Hardware ID إلى الحافظة", "نجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"خطأ في النسخ: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

