using CvSender.Core.ApplicationServices;
using CvSender.Core.Interfaces;
using CvSender.Core.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CvSender.WindowsFormsClient
{
        public partial class MainForm : Form
        {
                //https://www.jobscontact.cz/prace/praha?jobFilterFulltext%5B0%5D=C%23

                //https://www.jobs.cz/prace/praha/programator/?q%5B%5D=%D0%A1%23

                //https://www.jobs.cz/prace/praha/?q%5B%5D=.net

                //https://www.startupjobs.cz/nabidky?superinput=.net&lokalita=ChIJi3lwCZyTC0cRkEAWZg-vAAQ

                //https://www.linkedin.com/feed/

                //https://cz.indeed.com/jobs?q=.net&l=Praha%2C+Hlavn%C3%AD+m%C4%9Bsto+Praha&vjk=718b536667e24385

                private readonly IList<ICVManager> _cvManagers;

                private string _selectedSite;

                public MainForm([FromKeyedServices(JobsCzCvSender.ServiceKey)] ICVManager _jobsCzCvSender, IConfiguration config)
                {
                        InitializeComponent();

                        _cvManagers = new List<ICVManager>();

                        _cvManagers.Add(_jobsCzCvSender);
                }

                private void Form1_Load(object sender, EventArgs e)
                {

                }

                private void bindingSource1_CurrentChanged(object sender, EventArgs e)
                {

                }

                private void button1_Click_2(object sender, EventArgs e)
                {
                        Button clickedButton = (sender as Button)!;

                        sitelabel.Text = clickedButton?.Text;

                        _selectedSite = clickedButton!.Text;
                }

                private void button2_Click(object sender, EventArgs e)
                {
                        foreach (var cvManager in _cvManagers)
                        {
                                cvManager.SendCv("https://www.jobs.cz/prace/praha/programator/?q%5B%5D=%D0%A1%23",
                                        new UserInfo() { Email = "loker2356@outlook.com", Name = "Danil", Surname = "Tkachenko", Telephone = "+420605190161" });
                        }
                }
        }
}
