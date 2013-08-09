using System.Windows.Forms;
using System.Linq;

namespace PresentationLayer.Splash
{
    public partial class AboutUs : Form
    {
        private delegate void ProgressDelegate(int progress);

        private ProgressDelegate del;
        public AboutUs()
        {
            InitializeComponent();
        }
        
        public void UpdateProgress(int progress)
        {
            this.Invoke(del, progress);
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
