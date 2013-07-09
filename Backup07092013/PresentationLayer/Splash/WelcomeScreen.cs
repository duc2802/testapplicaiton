using System.Windows.Forms;
using System.Linq;

namespace PresentationLayer.Splash
{
    public partial class WelcomeScreen : Form
    {
        private delegate void ProgressDelegate(int progress);

        private ProgressDelegate del;
        public WelcomeScreen()
        {
            InitializeComponent();
        }
        
        public void UpdateProgress(int progress)
        {
            this.Invoke(del, progress);
        }
    }
}
