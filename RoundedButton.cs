using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundedButton : Button
{
    private int _radius = 6;
    public int CornerRadius
    {
        get => _radius;
        set { _radius = value; Invalidate(); }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
        using (GraphicsPath path = GetRoundedPath(rect, _radius))
        using (SolidBrush brush = new SolidBrush(BackColor))
        {
            e.Graphics.FillPath(brush, path);
            e.Graphics.DrawPath(new Pen(BackColor), path);
        }
        // Vẽ text
        TextRenderer.DrawText(e.Graphics, Text, Font,
            rect, ForeColor,
            TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }

    private GraphicsPath GetRoundedPath(Rectangle rect, int r)
    {
        GraphicsPath path = new GraphicsPath();
        path.AddArc(rect.X, rect.Y, r * 2, r * 2, 180, 90);
        path.AddArc(rect.Right - r * 2, rect.Y, r * 2, r * 2, 270, 90);
        path.AddArc(rect.Right - r * 2, rect.Bottom - r * 2, r * 2, r * 2, 0, 90);
        path.AddArc(rect.X, rect.Bottom - r * 2, r * 2, r * 2, 90, 90);
        path.CloseFigure();
        return path;
    }

    protected override void OnMouseEnter(EventArgs e)
    {
        base.OnMouseEnter(e);
        BackColor = ControlPaint.Light(BackColor, 0.1f);
    }
    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        // Màu sẽ reset khi form gọi lại StyleButton
    }
}