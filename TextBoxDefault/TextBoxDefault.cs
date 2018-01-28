using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KnjigaOom
{
    class TextBoxDefault : System.Windows.Forms.TextBox
    {
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            SetStyle(ControlStyles.UserPaint, TextLength == 0);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (TextLength == 0)
                DrawDefaultText(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            SetStyle(ControlStyles.UserPaint, TextLength == 0);
            Invalidate();
        }

        private void DrawDefaultText(PaintEventArgs e)
        {
            Rectangle rect = ClientRectangle;
            rect.Offset(-2, +1);
            rect.Width += 1;
            TextRenderer.DrawText(e.Graphics, defaultText, Font, rect, SystemColors.GrayText, TextFormatFlags.TextBoxControl);
        }

        private string defaultText = "Podrazumijevana vrijednost";
    }
}
