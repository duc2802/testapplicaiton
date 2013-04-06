using System.Windows.Forms;
using System.Linq;

namespace PresentationLayer
{
    public partial class WelcomeScreen : Form
    {
        private delegate void ProgressDelegate(int progress);

        private ProgressDelegate del;
        public WelcomeScreen()
        {
            InitializeComponent();
            this.progressBar1.Maximum = 100;
            del = this.UpdateProgressInternal;
        }

        private void UpdateProgressInternal(int progress)
        {
            if (this.Handle == null)
            {
                return;
            }

            this.progressBar1.Value = progress;
        }

        public void UpdateProgress(int progress)
        {
            this.Invoke(del, progress);
        }
    }
}
