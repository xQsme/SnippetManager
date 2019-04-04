using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnippetManager
{
    public class ColoredCheckboxList : CheckedListBox
    {
        public Color color
        {
            get; set;
        }

        public ColoredCheckboxList(Color color)
        {
            this.color = color;
        }
        protected override void OnDrawItem(DrawItemEventArgs e)
        {

            DrawItemEventArgs e2 =
                new DrawItemEventArgs
                (
                    e.Graphics,
                    e.Font,
                    new Rectangle(e.Bounds.Location, e.Bounds.Size),
                    e.Index,
                    DrawItemState.None,
                    e.ForeColor,
                    SelectedIndex == e.Index ? color : BackColor
                );

            base.OnDrawItem(e2);
        }
    }
}
