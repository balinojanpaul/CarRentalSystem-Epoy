using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem2.Helpers
{
    public class PanelStyle
    {
        public static void ApplyRoundedCorners(Panel panel, int radius)
        {
            panel.Paint += (sender, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle panelRect = panel.ClientRectangle;
                GraphicsPath path = new GraphicsPath();

                // Create rounded corners
                path.AddArc(panelRect.X, panelRect.Y, radius, radius, 180, 90);
                path.AddArc(panelRect.Right - radius, panelRect.Y, radius, radius, 270, 90);
                path.AddArc(panelRect.Right - radius, panelRect.Bottom - radius, radius, radius, 0, 90);
                path.AddArc(panelRect.X, panelRect.Bottom - radius, radius, radius, 90, 90);
                path.CloseAllFigures();

                // Set the panel region to the rounded rectangle
                panel.Region = new Region(path);
            };
        }

        public static void ApplyShadow(Panel panel, int shadowOffset, Color shadowColor)
        {
            panel.Paint += (sender, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle shadowRect = new Rectangle(panel.ClientRectangle.X + shadowOffset,
                                                     panel.ClientRectangle.Y + shadowOffset,
                                                     panel.ClientRectangle.Width,
                                                     panel.ClientRectangle.Height);

                // Create a semi-transparent shadow
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(50, shadowColor)))
                {
                    g.FillRectangle(shadowBrush, shadowRect);
                }
            };
        }
    }
}
