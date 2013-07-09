using System.Windows.Forms;

namespace PresentationLayer.Explorer
{
    public class NodeExplorer : TreeNode
    {
        public NodeDateItem NodeData { set; get; }

        public NodeExplorer(string nameNode, ContextMenuStrip contextMenuStrip) : base()
        {
            this.Text = nameNode;
            this.ContextMenuStrip = contextMenuStrip;
        }

        public NodeExplorer(string nameNode, ContextMenuStrip contextMenuStrip, NodeDateItem data)
            : this(nameNode, contextMenuStrip)
        {
            this.NodeData = data;
        }
    }
}
