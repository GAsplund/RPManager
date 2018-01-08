using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Windows.Forms;
using GAsplund_s_WynnPack_Manager;

namespace GAsplund_s_WynnPack_Manager
{
    public class Updating {
    /*public async Task updateWebListAsync()
        {
            TimeSpan timeoutTimespan = new TimeSpan(0,0,10);
            var httpClient = new HttpClient();
            httpClient.Timeout = timeoutTimespan;
            var clientResponse = await httpClient.GetAsync("https://pastebin.com/raw/sVMxqhSr");
            updateList(await clientResponse.Content.ReadAsStringAsync());
        }

        private ManagerForm form;
        public Updating(ManagerForm f)
        {
            this.form = f;
        }

        public void updateList(string list)
        {
            Updating upd = new Updating(this.form);
            dynamic packListJSON = JObject.Parse(list);
            JObject jObj = (JObject)JsonConvert.DeserializeObject(list);
            int objCount = jObj.Count;
            for (int i = 0; i >= 5; i++)
                {

            };

        }

        public void addStuff(string text)
        {
            //this.form.packSelectionListBox.Items.Add("IT WORKS");
            //this.form.packSelectionListBox.Update();
        }*/
    }
}
