using System;
using System.Drawing;
using System.Windows.Forms;

public static class UIHelper
{
    // ===== BẢNG MÀU =====
    public static readonly Color PrimaryBlue = ColorTranslator.FromHtml("#1B3A6B");
    public static readonly Color SecondaryBlue = ColorTranslator.FromHtml("#2E75B6");
    public static readonly Color GreenSave = ColorTranslator.FromHtml("#375623");
    public static readonly Color RedDelete = ColorTranslator.FromHtml("#C00000");
    public static readonly Color OrangeEdit = ColorTranslator.FromHtml("#E36C09");
    public static readonly Color GrayCancel = ColorTranslator.FromHtml("#888888");
    public static readonly Color LightGrayBg = ColorTranslator.FromHtml("#F0F0F0");
    public static readonly Color BorderGray = ColorTranslator.FromHtml("#CCCCCC");
    public static readonly Color White = Color.White;

    // ===== FONT CHUẨN =====
    public static readonly Font FontTitle = new Font("Segoe UI", 14f, FontStyle.Bold);
    public static readonly Font FontLabel = new Font("Segoe UI", 10f, FontStyle.Regular);
    public static readonly Font FontButton = new Font("Segoe UI", 10f, FontStyle.Regular);
    public static readonly Font FontTimer = new Font("Segoe UI", 20f, FontStyle.Bold);

    // ===== STYLE BUTTON =====
    public static void StyleButton(Button btn, Color backColor)
    {
        btn.BackColor = backColor;
        btn.ForeColor = Color.White;
        btn.Font = FontButton;
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.Cursor = Cursors.Hand;
        btn.Height = 32;
    }

    // ===== STYLE HEADER PANEL =====
    // Gọi trong Paint event của Panel header
    public static void PaintHeader(object sender, PaintEventArgs e, string title)
    {
        Panel pnl = (Panel)sender;
        e.Graphics.FillRectangle(new SolidBrush(PrimaryBlue), pnl.ClientRectangle);
        using (Font f = new Font("Segoe UI", 14f, FontStyle.Bold))
        using (StringFormat sf = new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center })
            e.Graphics.DrawString(title, f, Brushes.White, new Rectangle(12, 0, pnl.Width, pnl.Height), sf);
    }

    // ===== STYLE FORM =====
    public static void ApplyFormStyle(Form form)
    {
        form.BackColor = LightGrayBg;
        form.Font = FontLabel;
    }

    // ===== STYLE DATAGRIDVIEW =====
    public static void StyleDataGridView(DataGridView dgv)
    {
        dgv.BorderStyle = BorderStyle.FixedSingle;
        dgv.BackgroundColor = White;
        dgv.GridColor = BorderGray;
        dgv.RowHeadersVisible = false;
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgv.AllowUserToAddRows = false;
        dgv.ReadOnly = true;
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        // Header
        dgv.ColumnHeadersDefaultCellStyle.BackColor = PrimaryBlue;
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = White;
        dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
        dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = PrimaryBlue;
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        dgv.ColumnHeadersHeight = 34;
        dgv.EnableHeadersVisualStyles = false;

        // Dòng xen kẽ màu
        dgv.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#EEF4FB");
        dgv.DefaultCellStyle.SelectionBackColor = SecondaryBlue;
        dgv.DefaultCellStyle.SelectionForeColor = White;
        dgv.DefaultCellStyle.Font = FontLabel;
    }

    // ===== STYLE GROUPBOX =====
    public static void StyleGroupBox(GroupBox gb)
    {
        gb.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
        gb.ForeColor = PrimaryBlue;
    }

    // ===== STYLE COMBOBOX / TEXTBOX =====
    public static void StyleInput(Control ctrl)
    {
        ctrl.Font = FontLabel;
        ctrl.BackColor = White;
    }
    // Style nút outline — phù hợp nút có enable/disable
    public static void StyleButtonOutline(Button btn, Color accentColor)
    {
        btn.BackColor = Color.White;
        btn.ForeColor = accentColor;
        btn.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderColor = accentColor;
        btn.FlatAppearance.BorderSize = 2;
        btn.Cursor = Cursors.Hand;
    }
}