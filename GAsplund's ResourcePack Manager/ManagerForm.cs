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
        public int currentSelectedItemNumber;
        public int currentSelectedEditionNumber;
        public bool ErrorOccurredWhileTryingToApplySettingDisabled;
        public string pastSelectedItem;
        public string pastSelectedEdition;

        public int CurrentSelectedItemNumber { get => currentSelectedItemNumber; set => currentSelectedItemNumber = value; }
        public int CurrentSelectedEditionNumber { get => currentSelectedEditionNumber; set => currentSelectedEditionNumber = value; }

        public PackMetadata Pack = new PackMetadata();
        public Updating _updating = new Updating();

        private dynamic currentPackList;
        private dynamic currentEditionsList;
        private dynamic currentSettings;

        Exception ErrorOutsideOfCatch;
        JObject SetjObj;
        private delegate void EnableDelegate(string enable);


        public ManagerForm()
        {
            InitializeComponent();
            _updating.updateWebList(this, Pack);
            updateThemes();
        }
        private Updating formm;

        public dynamic CurrentPackList { get => currentPackList; set => currentPackList = value; }
        public dynamic CurrentEditionsList { get => currentEditionsList; set => currentEditionsList = value; }
        public dynamic CurrentSettings { get => currentSettings; set => currentSettings = value; }

        public ManagerForm(Updating f)
        {
            this.formm = f;
        }
        private void fetchPacksButton_Click(object sender, EventArgs e)
        {
            _updating.updateWebList(this, Pack);
            updateThemes();
        }

        public void addItemsToResourcePackList(string item)
        { packSelectionListBox.Items.Add(item); }

        private void updatingBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        public void packSelectionListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _updating.UpdateVisualAndPackData(this, Pack);
        }
    

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ManagerForm_Load(object sender, EventArgs e)
        {
            // Me trying to play around with scaling (might happen sometime when I care more)

            //this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height); 
            //this.MaximizeBox = false;
            //this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowOnly;
            FileManagement.CheckForProgramData();
        }

        private void ManagerForm_Resize(object sender, EventArgs e)
        {

        }

            private void currentPackLabel_Click(object sender, EventArgs e)
        {
            // Why is this here?
        }

        public string GetExternalSource(string source)
        {
            WebClient httpClient = new WebClient();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            string clientResponse = httpClient.DownloadString(source);
            return clientResponse;
        }

        public void updateList(string list)
        // Updating the pack list from the downloaded JSON
        {
            packSelectionListBox.Items.Clear();
            JObject jObj = (JObject)JsonConvert.DeserializeObject(list);
            dynamic info = JObject.Parse(list);
            CurrentPackList = info;
            int objCount = jObj.Count;
            for (int i = 1; i <= objCount; i++)
            {
                JObject packRoot = (JObject)info[i.ToString()];
                Console.WriteLine("External source is " + (bool)info[i.ToString()]["external_source"]);
                if ((bool)info[i.ToString()]["external_source"]) {
                    string externalPackRoot = GetExternalSource((string)info[i.ToString()]["external_link"]); 
                    packRoot.Merge(JObject.Parse(externalPackRoot));
                    info[i.ToString()]["external_source"] = false;
                }
            }

            foreach (int i in Enumerable.Range(1, objCount))
            {
                string packTitle = (string)info[i.ToString()]["name"];
                packSelectionListBox.Items.Add(packTitle.ToString());
                Console.WriteLine("Added Pack \"" + packTitle + "\" for i = " + i);
            }

        }

        public void updateThemes()
        {
            if (GAspsRPmngr.Properties.Settings.Default.BackgroundTheme == 0) { this.BackgroundImage = null; setAllLabelsColor(Color.Black); }
            if (GAspsRPmngr.Properties.Settings.Default.BackgroundTheme == 1) { this.BackgroundImage = GAspsRPmngr.Properties.Resources.wynn_dirt; setAllLabelsColor(Color.White); }
            if (GAspsRPmngr.Properties.Settings.Default.BackgroundTheme == 2) { this.BackgroundImage = GAspsRPmngr.Properties.Resources.dirt; setAllLabelsColor(Color.White); }
        }


        public void updateEditionsList(string list)
        // Could be more compact, just cba. Otherwise this shit is pretty self explanatory.
        {
            PackEditionComboBox.Items.Clear();
            JObject jObj = (JObject)JsonConvert.DeserializeObject(list);
            dynamic info = JObject.Parse(list);
            CurrentEditionsList = info;
            int objCount = jObj.Count;
            if (objCount == 0) { Pack.HasNoEditions = true; } else if (objCount == 1) { Pack.HasOneEdition = true; } else { Pack.HasNoEditions = false; Pack.HasOneEdition = false; }
            foreach (int i in Enumerable.Range(1, objCount))
            {
                string EditionName = (string)info[i.ToString()]["name"];
                PackEditionComboBox.Items.Add(EditionName.ToString());
                Console.WriteLine("Added Edition \"" + EditionName + "\" for i = " + i);
            }

        }

        public void updateSettingsList(string settings)
        {
            PackSettingsCheckedListBox.Items.Clear();
                if (settings != "null")
                {
                    SetjObj = (JObject)JsonConvert.DeserializeObject(settings);
                    Pack.SettingsInfo = JObject.Parse(settings);
                    CurrentSettings = Pack.SettingsInfo;
                    Pack.SettingsCount = SetjObj.Count;
                } else
                {
                    Pack.SettingsCount = 0;
                    Pack.HasNoSettings = true;
                }
            foreach (int i in Enumerable.Range(1, Pack.SettingsCount))
                {
                    JArray settingEditions = (JArray)CurrentSettings[i.ToString()]["edition"];
                    
                    if ( DoesThisJArrayContain(settingEditions, CurrentSelectedEditionNumber) )
                    {
                        string EditionName = (string)Pack.SettingsInfo[i.ToString()]["name"];
                        PackSettingsCheckedListBox.Items.Add(EditionName.ToString());
                        Pack.HasNoSettings = false;
                        Console.WriteLine("Added Setting " + i + ": " + EditionName);
                    }
                }
            PackSettingsCheckedListBox.Enabled = !Pack.HasNoSettings && Pack.IsInstalled;
            ApplySettingsButton.Enabled = !Pack.HasNoSettings && Pack.IsInstalled;
                
        }

        private bool DoesThisJArrayContain(JArray Array, dynamic valueToMatch)
        {
            for (int i = 0; i <= Array.Count; i++)
            {
                Console.WriteLine("JArray[i] is " + (int)Array[i] + " and i is " + i + " with value to match " + valueToMatch);
                if ((int)Array[i] == valueToMatch) { Console.WriteLine("I returned true"); return true; } else 
                    if (i+1 == Array.Count) { Console.WriteLine("I returned false"); return false; }
            }
            return false;
        }


        private int LookForSetting(string SettingName)
        {
            int Success = 1;
            for (int i = 1; i <= (Pack.SettingsCount); i++)
            {
                if((string)Pack.SettingsInfo[i.ToString()]["name"] == SettingName) { Success = i; return i; }
            }
            return Success;
        }


        

        private async void installOrUninstallPackButton_Click(object sender, EventArgs e)
        {
            installOrUninstallPackButton.Enabled = false;
            if (Pack.IsInstalled)
            {
                if (Pack.IsOutdated)
                {
                    packStatusLabel.Text = "Pack Status: Downloading...";
                    await FileManagement.downloadPack(Pack.Download, Pack.FileName);
                }
            }
            else
            {
                packStatusLabel.Text = "Pack Status: Downloading...";
                await FileManagement.downloadPack(Pack.Download, Pack.FileName);
            }

            _updating.UpdateVisualAndPackData(this, Pack);
        }

        private void uninstallPackButton_Click(object sender, EventArgs e)
        {
            uninstallPackButton.Enabled = false;
            FileManagement.removePack(Pack.FileName);
            _updating.UpdateVisualAndPackData(this, Pack);
        }

        private void setAllLabelsColor(Color color)
        {
            currentPackLabel.ForeColor = color;
            creatorLabel.ForeColor = color;
            packVersionLabel.ForeColor = color;
            packCompatibilityLabel.ForeColor = color;
            ResolutionsLabel.ForeColor = color;
            packStatusLabel.ForeColor = color;
            selectPackLabel.ForeColor = color;
            PackEditionLabel.ForeColor = color;
            SettingsLabel.ForeColor = color;
        }


        private async void forceUpdatePackButton_Click(object sender, EventArgs e)
        {
            packStatusLabel.Text = "Pack Status: Downloading...";
            await FileManagement.downloadPack(Pack.Download, Pack.FileName);
            _updating.UpdateVisualAndPackData(this, Pack);
        }

        private void PackEditionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            packStatusLabel.Text = "Pack Status: Checking...";
            if (pastSelectedEdition != PackEditionComboBox.SelectedItem.ToString()) {
                CurrentSelectedEditionNumber = PackEditionComboBox.Items.IndexOf(PackEditionComboBox.SelectedItem.ToString());
                CurrentSelectedEditionNumber++;
                Pack.FileName = (string)CurrentEditionsList[CurrentSelectedEditionNumber.ToString()]["file_name"];
                Pack.MD5 = (string)CurrentEditionsList[CurrentSelectedEditionNumber.ToString()]["md5"];
                Pack.Download = (string)CurrentEditionsList[CurrentSelectedEditionNumber.ToString()]["download"];

                _updating.UpdateVisualAndPackData(this, Pack);
                
            }
            pastSelectedEdition = PackEditionComboBox.SelectedItem.ToString();

            if (!Pack.HasOneEdition) { updateSettingsList(JsonConvert.SerializeObject((object)CurrentPackList[CurrentSelectedItemNumber.ToString()]["settings"]));

            /* It threw an error. So what? It just means that settings are absent. No biggie.
                PackSettingsCheckedListBox.Enabled = false;
                ApplySettingsButton.Enabled = false;*/
            }
            // If pack has editions, check here for settings

            try
            {
                if ((string)CurrentEditionsList[CurrentSelectedEditionNumber.ToString()]["edition_preview"] != null)
                { Pack.Image = (string)CurrentEditionsList[CurrentSelectedEditionNumber.ToString()]["edition_preview"]; packPreviewPictureBox.ImageLocation = Pack.Image; }
            }
            catch { }
        }

        private void packPreviewPictureBox_Click(object sender, EventArgs e)
        {
            try { System.Diagnostics.Process.Start(Pack.Image); } catch { MessageBox.Show("Please select a pack first.", "Warning"); }
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            OptionsForm form2 = new OptionsForm();
            form2.ShowDialog();
        }

        private void PackSettingsCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ApplySettingsButton_Click(object sender, EventArgs e)
        {
            string appDataLocation = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\resourcepacks\\" + Pack.FileName + "\\";
            string SettingCachePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\resourcepack_manager\\localsettings\\";
            string s = "Successfully applied settings: ";
            for (int i = 0; i <= (PackSettingsCheckedListBox.Items.Count - 1); i++)
            {
                if (PackSettingsCheckedListBox.GetItemChecked(i))
                {
                    s += "\n" + PackSettingsCheckedListBox.Items[i].ToString() + " as true";
                    int realsetting = LookForSetting(PackSettingsCheckedListBox.Items[i].ToString());
                    Console.WriteLine(CurrentSettings[realsetting.ToString()]["settingpaths"]);
                    JArray SettingsAmount1 = CurrentSettings[realsetting.ToString()]["settingpaths"];
                    int SettingsAmount = SettingsAmount1.Count();
                    for (int f = 0; f <= (SettingsAmount - 1); f++)
                    {
                        string settingPath = CurrentSettings[realsetting.ToString()]["settingpaths"][f];
                        Console.WriteLine(settingPath);
                        try
                        {
                            if (File.Exists(appDataLocation + settingPath + ".disabled"))
                            {   // If the file doesnt exist already, do copy it from settings cache.
                                string newPathForFile = Path.GetFileName(appDataLocation + settingPath);
                                File.Move(appDataLocation + settingPath + ".disabled", appDataLocation + settingPath);
                                // Copy the files for settings from .minecraft\resourcepack_manager\localsettings\(SELECTED PACK NAME)\(SELECTED EDITION NAME)\(SELECTED SETTING NAME)\(SETTING FILE NAME)
                                // ... to .minecraft\resourcepacks\(SELECTED PACK NAME)\(SETTING PATH NAME)\(SETTING FILE NAME)
                            }
                        }
                        catch (Exception er)
                        {
                            s = s.Replace("\n" + PackSettingsCheckedListBox.Items[i].ToString() + " as true", "\n" + PackSettingsCheckedListBox.Items[i].ToString() + " not applied (error occurred)");
                            ErrorForm form3 = new ErrorForm(er.Message, er.StackTrace, e.GetType().ToString());
                            form3.ShowDialog();
                        }
                    }
                } else if (!PackSettingsCheckedListBox.GetItemChecked(i))
                {
                    s += "\n" + PackSettingsCheckedListBox.Items[i].ToString() + " as false";
                    int realsetting = LookForSetting(PackSettingsCheckedListBox.Items[i].ToString());
                    Console.WriteLine(CurrentSettings[realsetting.ToString()]["settingpaths"]);
                    JArray SettingsAmount1 = CurrentSettings[realsetting.ToString()]["settingpaths"];
                    int SettingsAmount = SettingsAmount1.Count();
                    for(int f = 0; f <= (SettingsAmount-1); f++)
                    {
                        
                        string settingPath = CurrentSettings[realsetting.ToString()]["settingpaths"][f];

                        Console.WriteLine(settingPath);
                        try
                        {
                            if (!File.Exists(appDataLocation + settingPath + ".disabled"))
                            {
                                string newPathForFile = Path.GetFileName(appDataLocation + settingPath);
                                File.Move(appDataLocation + settingPath, appDataLocation + settingPath + ".disabled");
                                //File.Delete(appDataLocation + settingPath);
                                // Copy it to settings as backup and delete where it was before
                            }
                        }
                        catch (FileNotFoundException err)
                        {
                            ErrorOccurredWhileTryingToApplySettingDisabled = true;
                            ErrorOutsideOfCatch = err;
                        }
                        catch (Exception er)
                        {
                            ErrorForm form3 = new ErrorForm(er.Message, er.StackTrace, er.GetType().ToString());
                            form3.ShowDialog();
                            s = s.Replace("\n" + PackSettingsCheckedListBox.Items[i].ToString() + " as false","\n" + PackSettingsCheckedListBox.Items[i].ToString() + " was not applied (error occurred)");
                        }
                    }
                    if (ErrorOccurredWhileTryingToApplySettingDisabled)
                    {
                        ErrorForm form3 = new ErrorForm(ErrorOutsideOfCatch.Message + " PLEASE NOTE: There may have been more errors that have followed.", ErrorOutsideOfCatch.StackTrace, ErrorOutsideOfCatch.GetType().ToString());
                        form3.ShowDialog();
                    }

                }
            }
            if (GAspsRPmngr.Properties.Settings.Default.EnableDebug) { MessageBox.Show(s); }
            Console.WriteLine(s);
        }
    }


}

