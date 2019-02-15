using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MembersIntersection
{
    public partial class MembersIntersection : Form
    {
        List<string> groupsids;
        List<List<int>> result;
        List<List<int>> membersids;
        List<string> memberidpaths;
        bool closed;

        public MembersIntersection()
        {
            InitializeComponent();
            groupsids = new List<string>();
            result = new List<List<int>>();
            membersids = new List<List<int>>();
            memberidpaths = new List<string>();
            closed = false;
        }

        private void groupsopen_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "Выберите файл групп";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                groupspathbox.Text = openFileDialog1.FileName.ToString();
            }
        }

        private void membersopen_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "Выберите файл участников";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                memberspathbox.Text = openFileDialog1.FileName.ToString();
            }
        }

        private void DisEnb(bool action)
        {
            groupsopen.Enabled = action;
            membersopen.Enabled = action;
            start.Enabled = action;
            logout.Enabled = action;
            Add.Enabled = action;
            Clear.Enabled = action;
            Look.Enabled = action;
        }

        private void start_Click(object sender, EventArgs e)
        {
            string[] readText;
            groupsids = new List<string>();
            membersids = new List<List<int>>();

            //Проверка файла групп
            try
            {
                readText = File.ReadAllLines(groupspathbox.Text);
                foreach (string a in readText)
                {
                    int i = a.IndexOf("club");
                    if (i == -1)
                    {
                        i = a.IndexOf("public");
                        if (i == -1)
                        {
                            MessageBox.Show("Неправильный формат групп");
                            return;
                        }
                        else
                            i += 6;
                    }
                    else
                        i += 4;

                    groupsids.Add(a.Substring(i));
                }
            }
            catch
            {
                MessageBox.Show("Считать файл групп не удалось!");
                return;
            }

            foreach (var x in memberidpaths)
            {
                //Проверка файла участников
                try
                {
                    readText = File.ReadAllLines(x);
                    List<int> tmp = new List<int>();
                    foreach (string a in readText)
                    {
                        tmp.Add(int.Parse(a));
                    }
                    membersids.Add(tmp);
                }
                catch
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.AppendLine("Считать файл участников не удалось!");
                    stringBuilder.AppendLine(x);
                    MessageBox.Show(stringBuilder.ToString());
                    return;
                }
            }

            if(memberidpaths.Count == 0)
            {
                MessageBox.Show("Вы не добавили файл(ы) с участниками");
                return;
            }

            DisEnb(false);
            
            for(int i = 0; i < memberidpaths.Count; i++)
            {
                result.Add(new List<int>());
            }
            

            for(int i = 0; i < membersids.Count; i++)
            {
                membersids[i].Sort();
            }
            

            for(int i = 0; i < groupsids.Count && !closed; i++)
            {
                progressBar1.Value = (i + 1) * 100 / groupsids.Count;
                groupscounterlabel.Text = $"{i + 1} из {groupsids.Count}";

                List<int> members = GetMember(groupsids[i]);

                for (int j = 0; j < membersids.Count; j++)
                {
                    if (members.Count < membersids[j].Count)
                    {
                        result[j].Add(SameValues(members, membersids[j]));
                    }
                    else
                    {
                        result[j].Add(SameValues(membersids[j], members));
                    }
                }
            }

            if (!closed)
            {
                Saving();
            }

            DisEnb(true);
        }

        private void Saving()
        {

            for (int j = 0; j < result.Count; j++)
            {
                StreamWriter writer = new StreamWriter($"out{j + 1}.csv");

                for (int i = 0; i < result[j].Count; ++i)
                {
                    writer.WriteLine($"{groupsids[i]};{result[j][i]};");
                }

                writer.Close();
            }
        }

        private int SameValues(List<int> a, List<int> b)
        {
            int res = 0;
            for(int i = 0; i < a.Count; i++)
            {
                if(b.BinarySearch(a[i]) >= 0)
                {
                    ++res;
                }
            }
            return res;
        }

        private List<int> GetMember(string groupid)
        {
            List<int> members = new List<int>();
            int offset = 0;
            int times = 25;
            while (!closed)
            {
                string code = "";
                for (int i = 0; i < times; i++)
                {
                    code += String.Format($"var {(char)(i + 'a')}=API.groups.getMembers(") + "{" + String.Format($"\"group_id\":\"{groupid}\",\"offset\":\"{offset * 1000}\",\"count\":\"1000\"") + "});";
                    offset++;
                }

                code += "return [";

                for (int i = 0; i < times; i++)
                {
                    code += (char)(i + 'a') + ",";
                }

                code += "];";

                string got = get("https://api.vk.com/method/execute?code=" + code + "&access_token=" + Prog.Token + "&v=" + Prog.Version).ToString();


                string save = got;
                got = got.Substring(12);
                try
                {
                    got = got.Remove(got.IndexOf(",\"execute_errors\""));
                }
                catch { }

                got = got.Replace("false", "{\"count\":0,\"items\":[]}");

                MembersResponse[] membersResponses;
                try
                {
                    using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(got)))
                    {
                        DataContractJsonSerializer jsonFormatter = new DataContractJsonSerializer(typeof(MembersResponse[]));
                        membersResponses = (MembersResponse[])jsonFormatter.ReadObject(ms);
                    }
                }
                catch
                {

                    int s = save.IndexOf("{\"error\":{\"error_code\":6,\"error_msg");
                    if (s == 0)
                    {
                        Thread.Sleep(500);
                    }

                    offset -= times;
                    continue;
                }

                for(int i = 0; i < membersResponses.Length; ++i)
                {
                    if (membersResponses[i].count == 0)
                        break;
                    members.AddRange(membersResponses[i].items);
                }

                if (membersResponses[membersResponses.Length - 1].count == 0 || membersResponses[membersResponses.Length - 1].items.Length == 0)
                {
                    progressBar2.Value = 100;
                    memberscounterlaber.Text = "Участники группы были выгружены";
                    break;
                }

                progressBar2.Value = members.Count * 100 / membersResponses[0].count;
                memberscounterlaber.Text = $"{members.Count} из {membersResponses[0].count} участников";
            }
            return members;
        }

        private void logout_Click(object sender, EventArgs e)
        {
            Auth.LogOut();
            Close();
        }

        private void groupscounterlabel_TextChanged(object sender, EventArgs e)
        {
            groupscounterlabel.Left = this.Width / 2 - groupscounterlabel.Width / 2;
            Application.DoEvents();
        }

        private void memberscounterlaber_TextChanged(object sender, EventArgs e)
        {
            memberscounterlaber.Left = this.Width / 2 - memberscounterlaber.Width / 2;
            Application.DoEvents();
        }

        private static string get(string Url)
        {
            System.Net.WebRequest req = System.Net.WebRequest.Create(Url);
            System.Net.WebResponse resp = req.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string Out = sr.ReadToEnd();
            sr.Close();
            return Out;
        }

        private void MembersIntersection_FormClosing(object sender, FormClosingEventArgs e)
        {
            closed = true;
            Saving();
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (memberspathbox.Text == "")
            {
                MessageBox.Show("Вы ничего не добавляете");
                return;
            }
            
            memberidpaths.Add(memberspathbox.Text);
            memberspathbox.Clear();
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            memberidpaths.Clear();
        }

        private void Look_Click(object sender, EventArgs e)
        {
            StringBuilder paths = new StringBuilder();
            foreach(var x in memberidpaths)
            {
                paths.AppendLine(x);
            }
            MessageBox.Show(memberidpaths.Count == 0 ? "Список пуст" : paths.ToString());
        }
    }
}
