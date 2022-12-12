using System.Security.Policy;
using System.Text.Json;
using System.Net.Http;

namespace WinFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generacja_Click(object sender, EventArgs e)
        {
            HttpClient client = new HttpClient();
            string response = client.GetStringAsync("https://api.open-meteo.com/v1/forecast?latitude=54.35&longitude=18.65&current_weather=true&windspeed_unit=ms&timezone=Europe%2FBerlin").Result;

            JsonDocument document = JsonDocument.Parse(response);
            JsonElement element = document.RootElement.GetProperty("current_weather");
            label2.Text = element.GetProperty("temperature").ToString(); label5.Text = element.GetProperty("windspeed").ToString();
            string chuj = element.GetProperty("weathercode").ToString();
            if(chuj == "0") { label7.Text = "Clear Sky"; }
            if (chuj == "1") { label7.Text = "Mainly clear"; }
            if (chuj == "2") { label7.Text = " partly cloudy"; }
            if (chuj == "3") { label7.Text = "Overcast"; }
            if (chuj == "3") { label7.Text = "Overcast"; }

        }

        private void textboxrich_TextChanged(object sender, EventArgs e)
        {

        }
    }
}