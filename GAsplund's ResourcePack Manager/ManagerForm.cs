using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using GAspsRPmngr;

namespace GAsplund_s_WynnPack_Manager
{
    public partial class ManagerForm : Form
    {
        public dynamic currentPackList;
        public dynamic currentEditionsList;
        int currentSelectedItemNumber;
        int currentSelectedEditionNumber;
        bool packIsInstalled;
        bool packIsOutdated;
        bool packHasOneEdition;
        bool packHasNoEditions;
        string packCreator;
        string packDescription;
        string packImage;
        string packVersion;
        string packName;
        string packFileName;
        string packMD5;
        string packResolutions;
        string packDownload;
        string pastSelectedItem;
        string pastSelectedEdition;
        string packSource;
        private delegate void EnableDelegate(string enable);



        public ManagerForm()
        {
            InitializeComponent();
            updateWebList();
        }
        private Updating formm;
        public ManagerForm(Updating f)
        {
            this.formm = f;
        }
        private void fetchPacksButton_Click(object sender, EventArgs e)
        {
            updateWebList();
        }

        public void addItemsToResourcePackList(string item)
        { packSelectionListBox.Items.Add(item); }

        private void updatingBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        public void packSelectionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //  
                if (currentPackList != null) {
                    if (packSelectionListBox.SelectedItem != null)
                    {
                        if (pastSelectedItem != packSelectionListBox.SelectedItem.ToString()) // If the same pack was selected again, why go through all this crap once more?
                        {
                            packPreviewPictureBox.Image = null;
                            currentSelectedItemNumber = packSelectionListBox.Items.IndexOf(packSelectionListBox.SelectedItem.ToString());
                            currentSelectedItemNumber++;
                            updateEditionsList(JsonConvert.SerializeObject((object)currentPackList[currentSelectedItemNumber.ToString()]["editions"]));
                            // Setting all the variables to their new value
                            packDescription = (string)currentPackList[currentSelectedItemNumber.ToString()]["description"];
                            packImage = (string)currentPackList[currentSelectedItemNumber.ToString()]["image_preview"];
                            string packResolutions = (string)currentPackList[currentSelectedItemNumber.ToString()]["resolutions"];
                            string packCompatibility = (string)currentPackList[currentSelectedItemNumber.ToString()]["compatibility"];
                            packVersion = (string)currentPackList[currentSelectedItemNumber.ToString()]["latest_version"];
                            packName = (string)currentPackList[currentSelectedItemNumber.ToString()]["name"];
                            packCreator = (string)currentPackList[currentSelectedItemNumber.ToString()]["creator"];
                            packResolutions = (string)currentPackList[currentSelectedItemNumber.ToString()]["resolutions"];
                            // Setting all the form stuff to their new value
                            currentPackLabel.Text = packName;
                            packDescriptionTextBox.Text = packDescription;
                            packPreviewPictureBox.ImageLocation = packImage;
                            packVersionLabel.Text = "Latest Version: " + packVersion;
                            packCompatibilityLabel.Text = "MC Versions: " + packCompatibility;
                            ResolutionsLabel.Text = "Resolution(s): " + packResolutions;
                            creatorLabel.Text = "Created by " + packCreator;
                            PackEditionComboBox.Text = "";
                            setApplyButton(); //Essentially checking which buttons need to be enabled or disabled.
                            pastSelectedItem = packSelectionListBox.SelectedItem.ToString(); //Checked a new pack, no need to check it again
                        }
                    }

                }
                else //
                {
                    throw new System.ArgumentNullException("Pack List is null.");
                }

            } catch (Exception er)
            {
                ErrorForm form3 = new ErrorForm(er.Message,er.StackTrace, e.GetType().ToString());
                form3.ShowDialog();

            }
}

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            // Me trying to play around with scaling (might happen sometime when I care more)

            //this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            //this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowOnly;
        }

        private void currentPackLabel_Click(object sender, EventArgs e)
        {
            // Why is this here?
        }

        public void updateWebList()
        {
            if (GAspsRPmngr.Properties.Settings.Default.SourceSelection == 2) // Setting 2 = custom source
            {
                packSource = GAspsRPmngr.Properties.Settings.Default.CustomSource;
            } else if (GAspsRPmngr.Properties.Settings.Default.SourceSelection == 0) // Setting 0 = Wynn
            {
                packSource = "https://gasplund.github.io/downloads/packlist_wynn.json";  // Wynn packs JSON direct ("official" source)
            }
            else if (GAspsRPmngr.Properties.Settings.Default.SourceSelection == 1) // Setting 1 = Vanilla
            {
                packSource = "https://gasplund.github.io/downloads/packlist_vanilla.json";  // Vanilla packs JSON ("official" source)
            }

            TimeSpan timeoutTimespan = new TimeSpan(0, 0, 10);
            WebClient httpClient = new WebClient();
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                string clientResponse = httpClient.DownloadString(packSource);
                string updateListList = clientResponse;
                updateList(updateListList);
            } catch (System.ArgumentException e)
            {
                ErrorForm form3 = new ErrorForm("Your custom link is invalid!", e.StackTrace, e.GetType().ToString());
                // Get your shit together yo
                form3.ShowDialog();
            } catch (Exception e)
            {
                ErrorForm form3 = new ErrorForm(e.Message, e.StackTrace, e.GetType().ToString());
                form3.ShowDialog();
            }
        }

        public void updateList(string list)
        // Updating the pack list from the downloaded JSON
        {
            packSelectionListBox.Items.Clear();
            dynamic packListJSON = JObject.Parse(list);
            JObject jObj = (JObject)JsonConvert.DeserializeObject(list);
            dynamic info = JObject.Parse(list);
            currentPackList = info;
            int objCount = jObj.Count;
            for (int i = 1; i <= objCount; i++)
            {
                string packTitle = (string)info[i.ToString()]["name"];
                packSelectionListBox.Items.Add(packTitle.ToString());
                Console.WriteLine("Added Pack \"" + packTitle + "\" for i = " + i);
            }

        }

        public void updateEditionsList(string list)
        // Could be more compact, just cba. Otherwise this shit is pretty self explanatory.
        {
            PackEditionComboBox.Items.Clear();
            JObject jObj = (JObject)JsonConvert.DeserializeObject(list);
            dynamic info = JObject.Parse(list);
            currentEditionsList = info;
            int objCount = jObj.Count;
            if (objCount == 0) { packHasNoEditions = true; } else if (objCount == 1) { packHasOneEdition = true; } else { packHasNoEditions = false; packHasOneEdition = false; }
            for (int i = 1; i <= objCount; i++)
            {
                string EditionName = (string)info[i.ToString()]["name"];
                PackEditionComboBox.Items.Add(EditionName.ToString());
                Console.WriteLine("Added Edition \"" + EditionName + "\" for i = " + i);
            }

        }

        public static void DownloadProgressCallback(object sender, DownloadProgressChangedEventArgs e)
        // Unfinished shit. I need to get to this sometime but I'm to lazy to learn multithreading.
        //Feel free to create a pull request to make this work.
        {
            Console.WriteLine(e.ProgressPercentage);
            //statusProgressBar.Value = e.ProgressPercentage;
        }

        private void setApplyButton()
        {
            if (PackEditionComboBox.SelectedIndex == -1 && packHasNoEditions == false) 
            // Disable all buttons if a new pack with editions is selected
            {
                installOrUninstallPackButton.Enabled = false;
                forceUpdatePackButton.Enabled = false;
                uninstallPackButton.Enabled = false;
            }

            if (packHasOneEdition)
            // If the selected pack has only one edition, the pack edition selection isn't needed and will be disabled and
            // the pack hash, file name and download for the first edition will be used. Simple enough.
            {
                packFileName = (string)currentEditionsList["1"]["file_name"];
                packDownload = (string)currentEditionsList["1"]["download"];
                packMD5 = (string)currentEditionsList["1"]["md5"];
                //PackEditionLabel.Visible = false;
                PackEditionComboBox.Enabled = false;
            }
            else if (packHasNoEditions)
            // Self explanatory
            {
                //PackEditionLabel.Visible = false;
                PackEditionComboBox.Enabled = false;
            }
            else
            // Just in case
            {
                //PackEditionLabel.Visible = true;
                PackEditionComboBox.Enabled = true;
            }

            if (PackEditionComboBox.SelectedItem == null && packHasOneEdition == false) { packStatusLabel.Text = "Pack Status: n/a"; installOrUninstallPackButton.Enabled = false; } else if (PackEditionComboBox.SelectedItem != null || packHasOneEdition == true)
            // Checking if pack has no edition edition selected or if nothing is selected, and will make pack status n/a if returned true.
            {
                if (FileManagement.CurrentPackIsInstalled(currentSelectedItemNumber, packFileName))
                // Checking if the selected pack is installed
                {
                    packIsInstalled = true;
                    if (FileManagement.CurrentPackIsOutdated(currentSelectedItemNumber, packFileName, packMD5))
                    // Checking if the selected pack is outdated or damaged/corrupt
                    {
                        packIsOutdated = true;
                        installOrUninstallPackButton.Enabled = true;
                        uninstallPackButton.Enabled = true;
                        forceUpdatePackButton.Enabled = true;
                        installOrUninstallPackButton.Text = "Update Pack";
                        packStatusLabel.Text = "Pack Status: Outdated or damaged";
                    }
                    else
                    // If it isn't outdated, it's installed and working fine
                    {
                        packIsInstalled = true;
                        packIsOutdated = false;
                        installOrUninstallPackButton.Enabled = false;
                        uninstallPackButton.Enabled = true;
                        forceUpdatePackButton.Enabled = true;
                        installOrUninstallPackButton.Text = "Install Pack";
                        packStatusLabel.Text = "Pack Status: Installed";
                    }
                }
                else
                // CurrentPackIsInstalled returned false, therefore it's is not installed
                {
                    packIsInstalled = false;
                    packIsOutdated = false;
                    installOrUninstallPackButton.Enabled = true;
                    uninstallPackButton.Enabled = false;
                    forceUpdatePackButton.Enabled = false;
                    installOrUninstallPackButton.Text = "Install Pack";
                    packStatusLabel.Text = "Pack Status: Not Installed";
                }
            }
        }

        private void installOrUninstallPackButton_Click(object sender, EventArgs e)
        {
            installOrUninstallPackButton.Enabled = false;
            if (packIsInstalled)
            {
                if (packIsOutdated)
                {
                    FileManagement.downloadPack(packDownload, packFileName);
                }
            }
            else
            {
                FileManagement.downloadPack(packDownload, packFileName);
            }

            setApplyButton();
        }

        private void uninstallPackButton_Click(object sender, EventArgs e)
        {
            uninstallPackButton.Enabled = false;
            FileManagement.removePack(packFileName);
            setApplyButton();
        }

        private void forceUpdatePackButton_Click(object sender, EventArgs e)
        {
            FileManagement.downloadPack(packDownload, packFileName);
            setApplyButton();
        }

        private void PackEditionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            packStatusLabel.Text = "Pack Status: Checking...";
            if (pastSelectedEdition != PackEditionComboBox.SelectedItem.ToString()) {
                currentSelectedEditionNumber = PackEditionComboBox.Items.IndexOf(PackEditionComboBox.SelectedItem.ToString());
                currentSelectedEditionNumber++;
                packFileName = (string)currentEditionsList[currentSelectedEditionNumber.ToString()]["file_name"];
                packMD5 = (string)currentEditionsList[currentSelectedEditionNumber.ToString()]["md5"];
                packDownload = (string)currentEditionsList[currentSelectedEditionNumber.ToString()]["download"];

                setApplyButton();
                
            }
            pastSelectedEdition = PackEditionComboBox.SelectedItem.ToString();

            try
            {
                if ((string)currentEditionsList[currentSelectedEditionNumber.ToString()]["edition_preview"] != null)
                { packImage = (string)currentEditionsList[currentSelectedEditionNumber.ToString()]["edition_preview"]; packPreviewPictureBox.ImageLocation = packImage; }
            }
            catch { }
        }

        private void packPreviewPictureBox_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start(packImage); } catch { MessageBox.Show("Please select a pack first.", "Warning"); }
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            OptionsForm form2 = new OptionsForm();
            form2.ShowDialog();
        }
    }


}

