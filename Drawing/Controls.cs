using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.ComponentModel;

// IMPORTANT:
// Please leave these comments in place as they help protect intellectual rights and allow
// developers to determine the version of the theme they are using. The preffered method
// of distributing this theme is through the Nimoru Software home page at nimoru.com.

// Name: Net Seal Theme
// Created: 4/15/2013
// Version: 1.0.0.0 beta

// This work is licensed under a Creative Commons Attribution 3.0 Unported License.

// Copyright © 2013 Nimoru Software

class ThemeModule
{
    internal static Graphics G;

    public ThemeModule()
    {
        TextBitmap = new Bitmap(1, 1);
        TextGraphics = Graphics.FromImage(TextBitmap);
    }

    private static Bitmap TextBitmap;
    private static Graphics TextGraphics;

    internal static SizeF MeasureString(string text, Font font)
    {
        return TextGraphics.MeasureString(text, font);
    }

    internal static SizeF MeasureString(string text, Font font, int width)
    {
        return TextGraphics.MeasureString(text, font, width, StringFormat.GenericTypographic);
    }

    private static GraphicsPath CreateRoundPath;
    private static Rectangle CreateRoundRectangle;

    internal static GraphicsPath CreateRound(int x, int y, int width, int height, int slope)
    {
        CreateRoundRectangle = new Rectangle(x, y, width, height);
        return CreateRound(CreateRoundRectangle, slope);
    }

    internal static GraphicsPath CreateRound(Rectangle r, int slope)
    {
        CreateRoundPath = new GraphicsPath(FillMode.Winding);
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F);
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F);
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F);
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F);
        CreateRoundPath.CloseFigure();
        return CreateRoundPath;
    }
}

public class NSTheme : ContainerControl
{

    private int _AccentOffset = 0;
    public int AccentOffset
    {
        get { return _AccentOffset; }
        set
        {
            _AccentOffset = value;
            Invalidate();
        }
    }

    public NSTheme()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
        DoubleBuffered = true;
        BackColor = Color.FromArgb(50, 50, 50);

        P1 = new Pen(Color.FromArgb(35, 35, 35));
        P2 = new Pen(Color.FromArgb(60, 60, 60));

        B1 = new SolidBrush(Color.FromArgb(50, 50, 50));
    }

    private readonly Pen P1;
    private readonly Pen P2;

    private SolidBrush B1;

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;

        G.SmoothingMode = SmoothingMode.HighQuality;
        G.CompositingQuality = CompositingQuality.HighQuality;

        G.Clear(BackColor);
        G.DrawRectangle(P2, new Rectangle(1, 1, Width - 3, Height - 3));

        G.DrawLine(P1, 0, 26, Width, 26);
        G.DrawLine(P2, 0, 25, Width, 25);

        G.DrawLine(P1, 0, 29, Width, 29);
        G.DrawLine(P2, 0, 30, Width, 30);

        G.TextRenderingHint = TextRenderingHint.AntiAlias;
        G.DrawString(Text, Font, new SolidBrush(ForeColor), new Point(7, 7));

        G.FillRectangle(B1, 0, 27, Width, 2);
        G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
    }
    private Point MouseP = new Point(0, 0);
    private bool Cap = false;
    private readonly int MoveHeight = 25;
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
        {
            Cap = true; MouseP = e.Location;
        }
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (Cap)
            Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e); Cap = false;
    }
    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        Dock = DockStyle.Fill;
        Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
    }
}

public class NSPopup : ContainerControl
{

    private int _AccentOffset = 0;
    public int AccentOffset
    {
        get { return _AccentOffset; }
        set
        {
            _AccentOffset = value;
            Invalidate();
        }
    }

    private Color _accentColor;
    public Color Accent
    {
        get { return _accentColor; }
        set { _accentColor = value; Invalidate(); }
    }

    public NSPopup()
    {
        SetStyle(ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
        BackColor = Color.Transparent;
        DoubleBuffered = true;
        BackColor = Color.FromArgb(50, 50, 50);

        P1 = new Pen(Color.FromArgb(35, 35, 35));
        P2 = new Pen(Color.FromArgb(60, 60, 60));

        B1 = new SolidBrush(Color.FromArgb(50, 50, 50));
    }

    private readonly Pen P1;
    private readonly Pen P2;

    private SolidBrush B1;
    private SolidBrush B2;

    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics G = e.Graphics;

        B2 = new SolidBrush(_accentColor);

        G.SmoothingMode = SmoothingMode.HighQuality;
        G.CompositingQuality = CompositingQuality.HighQuality;

        G.Clear(BackColor);
        G.DrawRectangle(P2, new Rectangle(1, 1, Width - 3, Height - 3));

        G.FillRectangle(B2, new Rectangle(0, 0, 2, Height - 1));

        G.TextRenderingHint = TextRenderingHint.AntiAlias;
        G.DrawString(Text, Font, new SolidBrush(ForeColor), new Rectangle(14, 0, Width - 1, Height - 1), new StringFormat() { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near});

        //G.FillRectangle(B1, 0, 27, Width, 2);
        G.DrawRectangle(Pens.Black, new Rectangle(0, 0, Width - 1, Height - 1));
    }
    private Point MouseP = new Point(0, 0);
    private bool Cap = false;
    private readonly int MoveHeight = 25;
    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button == MouseButtons.Left & new Rectangle(0, 0, Width, MoveHeight).Contains(e.Location))
        {
            Cap = true; MouseP = e.Location;
        }
    }
    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (Cap)
            Parent.Location = new Point(MousePosition.X - MouseP.X, MousePosition.Y - MouseP.Y);
    }
    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e); Cap = false;
    }
    protected override void OnCreateControl()
    {
        base.OnCreateControl();
        Dock = DockStyle.Fill;
        Parent.FindForm().FormBorderStyle = FormBorderStyle.None;
    }
}

class AALabel : Label
{
    public AALabel()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);
        AutoSize = false;
    }

    private RectangleF R1;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        ThemeModule.G.Clear(BackColor);

        R1 = new RectangleF(0, 0, Width, Height);

        switch (TextAlign)
        {
            case ContentAlignment.TopCenter:
                ThemeModule.G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near });
                break;
            case ContentAlignment.BottomCenter:
                ThemeModule.G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far });
                break;
            case ContentAlignment.MiddleCenter:
                ThemeModule.G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                break;
            case ContentAlignment.TopLeft:
                ThemeModule.G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near });
                break;
            case ContentAlignment.BottomLeft:
                ThemeModule.G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Far });
                break;
            case ContentAlignment.MiddleLeft:
                ThemeModule.G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                break;
            case ContentAlignment.TopRight:
                ThemeModule.G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Near });
                break;
            case ContentAlignment.BottomRight:
                ThemeModule.G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far });
                break;
            case ContentAlignment.MiddleRight:
                ThemeModule.G.DrawString(Text, Font, new SolidBrush(ForeColor), R1, new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
                break;
        }
    }
}

class NSButton : Control
{
    public NSButton()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        P1 = new Pen(Color.FromArgb(35, 35, 35));
        P2 = new Pen(Color.FromArgb(65, 65, 65));
        TextAlign = ContentAlignment.MiddleCenter;
    }

    private ContentAlignment _TextAlign;
    public ContentAlignment TextAlign
    {
        get { return _TextAlign; }
        set { _TextAlign = value; Invalidate();  }
    }

    private bool IsMouseDown;

    private GraphicsPath GP1, GP2;

    private SizeF SZ1;
    private PointF PT1;

    private Pen P1, P2;

    private PathGradientBrush PB1;
    private LinearGradientBrush GB1;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        ThemeModule.G.Clear(BackColor);
        ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

        GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
        GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

        if (IsMouseDown)
        {
            PB1 = new PathGradientBrush(GP1)
            {
                CenterColor = Color.FromArgb(60, 60, 60),
                SurroundColors = new Color[] { Color.FromArgb(55, 55, 55) },
                FocusScales = new PointF(0.8F, 0.5F)
            };

            ThemeModule.G.FillPath(PB1, GP1);
        }
        else
        {
            GB1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F);
            ThemeModule.G.FillPath(GB1, GP1);
        }

        ThemeModule.G.DrawPath(P1, GP1);
        ThemeModule.G.DrawPath(P2, GP2);

        SZ1 = ThemeModule.G.MeasureString(Text, Font);
        PT1 = new PointF(Width / 2 - SZ1.Width / 2, (Height / 2 - SZ1.Height / 2) + 1);

        if (IsMouseDown)
        {
            PT1.X += 1.0F;
            PT1.Y += 1.0F;
        }

        Rectangle R1 = new Rectangle(5, 5, Width - 11, Height - 10);
        SolidBrush B1 = new SolidBrush(Enabled ? ForeColor : Color.FromArgb(120, 120, 120));

        switch (TextAlign)
        {
            case ContentAlignment.TopCenter:
                ThemeModule.G.DrawString(Text, Font, B1, R1, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Near });
                break;
            case ContentAlignment.BottomCenter:
                ThemeModule.G.DrawString(Text, Font, B1, R1, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Far });
                break;
            case ContentAlignment.MiddleCenter:
                ThemeModule.G.DrawString(Text, Font, B1, R1, new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                break;
            case ContentAlignment.TopLeft:
                ThemeModule.G.DrawString(Text, Font, B1, R1, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Near });
                break;
            case ContentAlignment.BottomLeft:
                ThemeModule.G.DrawString(Text, Font, B1, R1, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Far });
                break;
            case ContentAlignment.MiddleLeft:
                ThemeModule.G.DrawString(Text, Font, B1, R1, new StringFormat() { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center });
                break;
            case ContentAlignment.TopRight:
                ThemeModule.G.DrawString(Text, Font, B1, R1, new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Near });
                break;
            case ContentAlignment.BottomRight:
                ThemeModule.G.DrawString(Text, Font, B1, R1, new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Far });
                break;
            case ContentAlignment.MiddleRight:
                ThemeModule.G.DrawString(Text, Font, B1, R1, new StringFormat() { Alignment = StringAlignment.Far, LineAlignment = StringAlignment.Center });
                break;
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        IsMouseDown = true;
        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        IsMouseDown = false;
        Invalidate();
    }
}

class NSProgressBar : Control
{
    private int _Minimum;
    public int Minimum
    {
        get
        {
            return _Minimum;
        }
        set
        {
            if (value < 0)
                throw new Exception("Property value is not valid.");

            _Minimum = value;
            if (value > _Value)
                _Value = value;
            if (value > _Maximum)
                _Maximum = value;
            Invalidate();
        }
    }

    private int _Maximum = 100;
    public int Maximum
    {
        get
        {
            return _Maximum;
        }
        set
        {
            if (value < 0)
                throw new Exception("Property value is not valid.");

            _Maximum = value;
            if (value < _Value)
                _Value = value;
            if (value < _Minimum)
                _Minimum = value;
            Invalidate();
        }
    }

    private int _Value;
    public int Value
    {
        get
        {
            return _Value;
        }
        set
        {
            if (value > _Maximum || value < _Minimum)
                throw new Exception("Property value is not valid.");

            _Value = value;
            Invalidate();
        }
    }
    private Color _accentColor = Color.FromArgb(227, 194, 56);
    public Color Accent
    {
        get { return _accentColor; }
        set { _accentColor = value; Invalidate(); }
    }

    public NSProgressBar()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        P1 = new Pen(Color.FromArgb(35, 35, 35));
        P2 = new Pen(Color.FromArgb(55, 55, 55));
        B1 = new SolidBrush(Color.FromArgb(200, 160, 0));
    }

    private GraphicsPath GP1, GP2, GP3;

    private Rectangle R1, R2;

    private Pen P1, P2;
    private SolidBrush B1;
    private LinearGradientBrush GB1, GB2;

    private int I1;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;

        ThemeModule.G.Clear(BackColor);
        ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

        GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
        GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

        R1 = new Rectangle(0, 2, Width - 1, Height - 1);
        GB1 = new LinearGradientBrush(R1, Color.FromArgb(45, 45, 45), Color.FromArgb(50, 50, 50), 90.0F);

        ThemeModule.G.SetClip(GP1);
        ThemeModule.G.FillRectangle(GB1, R1);

        I1 = System.Convert.ToInt32((_Value - _Minimum) / (double)(_Maximum - _Minimum) * (Width - 3));

        if (I1 > 1)
        {
            GP3 = ThemeModule.CreateRound(1, 1, I1, Height - 3, 7);

            R2 = new Rectangle(1, 1, I1, Height - 3);
            GB2 = new LinearGradientBrush(R2, Color.FromArgb(227, 194, 56), Color.FromArgb(150, 110, 0), 90.0F);

            ThemeModule.G.FillPath(GB2, GP3);
            ThemeModule.G.DrawPath(P1, GP3);

            ThemeModule.G.SetClip(GP3);
            ThemeModule.G.SmoothingMode = SmoothingMode.None;

            ThemeModule.G.FillRectangle(B1, R2.X, R2.Y + 1, R2.Width, R2.Height / 2);

            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;
            ThemeModule.G.ResetClip();
        }

        ThemeModule.G.DrawPath(P2, GP1);
        ThemeModule.G.DrawPath(P1, GP2);
    }
}

class NSLabel : Control
{
    private Color _accentColor = Color.FromArgb(227, 194, 56);
    public Color Accent
    {
        get { return _accentColor; }
        set { _accentColor = value; Invalidate(); }
    }
    public NSLabel()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        Font = new Font("Segoe UI", 11.25F, FontStyle.Bold);

    }

    private string _Value1 = "NET";
    public string Value1
    {
        get
        {
            return _Value1;
        }
        set
        {
            _Value1 = value;
            Invalidate();
        }
    }

    private string _Value2 = "SEAL";
    public string Value2
    {
        get
        {
            return _Value2;
        }
        set
        {
            _Value2 = value;
            Invalidate();
        }
    }

    private SolidBrush B1;

    private PointF PT1, PT2;
    private SizeF SZ1;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        ThemeModule.G.Clear(BackColor);

        B1 = new SolidBrush(_accentColor);

        SZ1 = ThemeModule.G.MeasureString(Value1, Font, Width, StringFormat.GenericTypographic);

        PT1 = new PointF(0, Height / 2 - SZ1.Height / 2);
        PT2 = new PointF(SZ1.Width + 1, Height / 2 - SZ1.Height / 2);

        ThemeModule.G.DrawString(Value1, Font, Brushes.White, PT1);

        ThemeModule.G.DrawString(Value2, Font, B1, PT2);
    }
}

[DefaultEvent("TextChanged")]
public class NSTextBox : Control
{
    private HorizontalAlignment _TextAlign = HorizontalAlignment.Left;
    public HorizontalAlignment TextAlign
    {
        get
        {
            return _TextAlign;
        }
        set
        {
            _TextAlign = value;
            if (Base != null)
                Base.TextAlign = value;
        }
    }

    private int _MaxLength = 32767;
    public int MaxLength
    {
        get
        {
            return _MaxLength;
        }
        set
        {
            _MaxLength = value;
            if (Base != null)
                Base.MaxLength = value;
        }
    }

    private bool _ReadOnly;
    public bool ReadOnly
    {
        get
        {
            return _ReadOnly;
        }
        set
        {
            _ReadOnly = value;
            if (Base != null)
                Base.ReadOnly = value;
        }
    }

    private bool _UseSystemPasswordChar;
    public bool UseSystemPasswordChar
    {
        get
        {
            return _UseSystemPasswordChar;
        }
        set
        {
            _UseSystemPasswordChar = value;
            if (Base != null)
                Base.UseSystemPasswordChar = value;
        }
    }

    private bool _Multiline;
    public bool Multiline
    {
        get
        {
            return _Multiline;
        }
        set
        {
            _Multiline = value;
            if (Base != null)
            {
                Base.Multiline = value;

                if (value)
                    Base.Height = Height - 11;
                else
                    Height = Base.Height + 11;
            }
        }
    }

    public override string Text
    {
        get
        {
            return base.Text;
        }
        set
        {
            base.Text = value;
            if (Base != null)
                Base.Text = value;
        }
    }

    public override Font Font
    {
        get
        {
            return base.Font;
        }
        set
        {
            base.Font = value;
            if (Base != null)
            {
                Base.Font = value;
                Base.Location = new Point(5, 5);
                Base.Width = Width - 8;

                if (!_Multiline)
                    Height = Base.Height + 11;
            }
        }
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        if (!Controls.Contains(Base))
            Controls.Add(Base);

        base.OnHandleCreated(e);
    }

    public TextBox Base;
    public NSTextBox()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, true);

        Cursor = Cursors.IBeam;

        Base = new TextBox
        {
            Font = Font,
            Text = Text,
            MaxLength = _MaxLength,
            Multiline = _Multiline,
            ReadOnly = _ReadOnly,
            UseSystemPasswordChar = _UseSystemPasswordChar,

            ForeColor = Color.White,
            BackColor = Color.FromArgb(50, 50, 50),

            BorderStyle = BorderStyle.None,

            Location = new Point(5, 5),
            Width = Width - 14
        };

        if (_Multiline)
            Base.Height = Height - 11;
        else
            Height = Base.Height + 11;

        Base.TextChanged += OnBaseTextChanged;
        Base.KeyDown += OnBaseKeyDown;

        P1 = new Pen(Color.FromArgb(35, 35, 35));
        P2 = new Pen(Color.FromArgb(55, 55, 55));
    }

    private GraphicsPath GP1, GP2;

    private Pen P1, P2;
    private PathGradientBrush PB1;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;

        ThemeModule.G.Clear(BackColor);
        ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

        GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
        GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

        PB1 = new PathGradientBrush(GP1)
        {
            CenterColor = Color.FromArgb(50, 50, 50),
            SurroundColors =
            new Color[] {
                Color.FromArgb(45, 45, 45)
            },
            FocusScales = new PointF(0.9F, 0.5F)
        };

        ThemeModule.G.FillPath(PB1, GP1);

        ThemeModule.G.DrawPath(P2, GP1);
        ThemeModule.G.DrawPath(P1, GP2);
    }

    private void OnBaseTextChanged(object s, EventArgs e)
    {
        Text = Base.Text;
    }

    private void OnBaseKeyDown(object s, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.A)
        {
            Base.SelectAll();
            e.SuppressKeyPress = true;
        }
    }

    protected override void OnResize(EventArgs e)
    {
        Base.Location = new Point(5, 5);

        Base.Width = Width - 10;
        Base.Height = Height - 11;

        base.OnResize(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        Base.Focus();
        base.OnMouseDown(e);
    }

    protected override void OnEnter(EventArgs e)
    {
        Base.Focus();
        Invalidate();
        base.OnEnter(e);
    }

    protected override void OnLeave(EventArgs e)
    {
        Invalidate();
        base.OnLeave(e);
    }
}

[DefaultEvent("CheckedChanged")]
class NSCheckBox : Control
{
    public event CheckedChangedEventHandler CheckedChanged;

    public delegate void CheckedChangedEventHandler(object sender);

    public NSCheckBox()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        P11 = new Pen(Color.FromArgb(55, 55, 55));
        P22 = new Pen(Color.FromArgb(35, 35, 35));
        P3 = new Pen(Color.Black, 2.0F);
        P4 = new Pen(Color.White, 2.0F);
    }

    private bool _Checked;
    public bool Checked
    {
        get
        {
            return _Checked;
        }
        set
        {
            _Checked = value;
            CheckedChanged?.Invoke(this);

            Invalidate();
        }
    }

    private GraphicsPath GP1, GP2;

    private SizeF SZ1;
    private PointF PT1;

    private Pen P11, P22, P3, P4;

    private PathGradientBrush PB1;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        ThemeModule.G.Clear(BackColor);
        ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

        GP1 = ThemeModule.CreateRound(0, 2, Height - 5, Height - 5, 5);
        GP2 = ThemeModule.CreateRound(1, 3, Height - 7, Height - 7, 5);

        PB1 = new PathGradientBrush(GP1)
        {
            CenterColor = Color.FromArgb(50, 50, 50),
            SurroundColors = new Color[]
            {
                Color.FromArgb(45, 45, 45)
            },
            FocusScales = new PointF(0.3F, 0.3F)
        };

        ThemeModule.G.FillPath(PB1, GP1);
        ThemeModule.G.DrawPath(P11, GP1);
        ThemeModule.G.DrawPath(P22, GP2);

        if (_Checked)
        {
            ThemeModule.G.DrawLine(P3, 5, Height - 9, 8, Height - 7);
            ThemeModule.G.DrawLine(P3, 7, Height - 7, Height - 8, 7);

            ThemeModule.G.DrawLine(P4, 4, Height - 10, 7, Height - 8);
            ThemeModule.G.DrawLine(P4, 6, Height - 8, Height - 9, 6);
        }

        SZ1 = ThemeModule.G.MeasureString(Text, Font);
        PT1 = new PointF(Height - 3, Height / 2 - SZ1.Height / 2);

        //ThemeModule.G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
        ThemeModule.G.DrawString(Text, Font, Brushes.White, PT1);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        Checked = !Checked;
    }
}

[DefaultEvent("CheckedChanged")]
class NSRadioButton : Control
{
    public event CheckedChangedEventHandler CheckedChanged;

    public delegate void CheckedChangedEventHandler(object sender);

    public NSRadioButton()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        P1 = new Pen(Color.FromArgb(55, 55, 55));
        P2 = new Pen(Color.FromArgb(35, 35, 35));
    }

    private bool _Checked;
    public bool Checked
    {
        get
        {
            return _Checked;
        }
        set
        {
            _Checked = value;

            if (_Checked)
                InvalidateParent();

            CheckedChanged?.Invoke(this);
            Invalidate();
        }
    }

    private void InvalidateParent()
    {
        if (Parent == null)
            return;

        foreach (Control C in Parent.Controls)
        {
            if (!(C == this) && (C is NSRadioButton))
                ((NSRadioButton)C).Checked = false;
        }
    }

    private GraphicsPath GP1;

    private SizeF SZ1;
    private PointF PT1;

    private Pen P1, P2;

    private PathGradientBrush PB1;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        ThemeModule.G.Clear(BackColor);
        ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

        GP1 = new GraphicsPath();
        GP1.AddEllipse(0, 2, Height - 5, Height - 5);

        PB1 = new PathGradientBrush(GP1)
        {
            CenterColor = Color.FromArgb(50, 50, 50),
            SurroundColors = new Color[]
            {
                Color.FromArgb(45, 45, 45)
            },
            FocusScales = new PointF(0.3F, 0.3F)
        };

        ThemeModule.G.FillPath(PB1, GP1);

        ThemeModule.G.DrawEllipse(P1, 0, 2, Height - 5, Height - 5);
        ThemeModule.G.DrawEllipse(P2, 1, 3, Height - 7, Height - 7);

        if (_Checked)
        {
            //ThemeModule.G.FillEllipse(Brushes.Black, 6, 8, Height - 15, Height - 15);
            ThemeModule.G.FillEllipse(Brushes.White, 5, 7, Height - 15, Height - 15);
        }

        SZ1 = ThemeModule.G.MeasureString(Text, Font);
        PT1 = new PointF(Height - 3, Height / 2 - SZ1.Height / 2);

        //ThemeModule.G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
        ThemeModule.G.DrawString(Text, Font, Brushes.White, PT1);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        Checked = true;
        base.OnMouseDown(e);
    }
}

class NSComboBox : ComboBox
{
    public NSComboBox()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
        DropDownStyle = ComboBoxStyle.DropDownList;

        BackColor = Color.FromArgb(50, 50, 50);
        ForeColor = Color.White;

        P1 = new Pen(Color.FromArgb(35, 35, 35));
        P2 = new Pen(Color.White, 2.0F);
        P3 = new Pen(Brushes.Black, 2.0F);
        P4 = new Pen(Color.FromArgb(65, 65, 65));

        B1 = new SolidBrush(Color.FromArgb(65, 65, 65));
        B2 = new SolidBrush(Color.FromArgb(55, 55, 55));
    }

    private GraphicsPath GP1, GP2;

    private SizeF SZ1;
    private PointF PT1;

    private Pen P1, P2, P3, P4;
    private SolidBrush B1, B2;

    private LinearGradientBrush GB1;

    protected override void OnPaint(PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        ThemeModule.G.Clear(BackColor);
        ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

        GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
        GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

        GB1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F);
        ThemeModule.G.SetClip(GP1);
        ThemeModule.G.FillRectangle(GB1, ClientRectangle);
        ThemeModule.G.ResetClip();

        ThemeModule.G.DrawPath(P1, GP1);
        ThemeModule.G.DrawPath(P4, GP2);

        SZ1 = ThemeModule.G.MeasureString(Text, Font);
        PT1 = new PointF(5, Height / 2 - SZ1.Height / 2);

        //ThemeModule.G.DrawString(Text, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
        ThemeModule.G.DrawString(Text, Font, Brushes.White, PT1);

        ThemeModule.G.DrawLine(P3, Width - 15, 10, Width - 11, 13);
        ThemeModule.G.DrawLine(P3, Width - 7, 10, Width - 11, 13);
        ThemeModule.G.DrawLine(Pens.Black, Width - 11, 13, Width - 11, 14);

        ThemeModule.G.DrawLine(P2, Width - 16, 9, Width - 12, 12);
        ThemeModule.G.DrawLine(P2, Width - 8, 9, Width - 12, 12);
        ThemeModule.G.DrawLine(Pens.White, Width - 12, 12, Width - 12, 13);

        ThemeModule.G.DrawLine(P1, Width - 22, 0, Width - 22, Height);
        ThemeModule.G.DrawLine(P4, Width - 23, 1, Width - 23, Height - 2);
        ThemeModule.G.DrawLine(P4, Width - 21, 1, Width - 21, Height - 2);
    }

    protected override void OnDrawItem(DrawItemEventArgs e)
    {
        e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            e.Graphics.FillRectangle(B1, e.Bounds);
        else
            e.Graphics.FillRectangle(B2, e.Bounds);

        if (e.Index != -1)
            e.Graphics.DrawString(GetItemText(Items[e.Index]), e.Font, Brushes.White, e.Bounds);
    }
}

class NSTabControl : TabControl
{
    private Color _accentColor;
    public Color Accent
    {
        get { return _accentColor; }
        set { _accentColor = value; Invalidate(); }
    }
    public NSTabControl()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        SizeMode = TabSizeMode.Fixed;
        Alignment = TabAlignment.Left;
        ItemSize = new Size(28, 115);

        DrawMode = TabDrawMode.OwnerDrawFixed;
        Accent = Color.FromArgb(227, 194, 56);

        P1 = new Pen(Color.FromArgb(55, 55, 55));
        P2 = new Pen(Color.FromArgb(35, 35, 35));
        P3 = new Pen(Color.FromArgb(45, 45, 45), 2);

        B1 = new SolidBrush(Color.FromArgb(50, 50, 50));
        B2 = new SolidBrush(Color.FromArgb(35, 35, 35));
        B4 = new SolidBrush(Color.FromArgb(65, 65, 65));

        SF1 = new StringFormat
        {
            LineAlignment = StringAlignment.Center
        };
    }

    protected override void OnControlAdded(ControlEventArgs e)
    {
        if (e.Control is TabPage)
            e.Control.BackColor = Color.FromArgb(50, 50, 50);

        base.OnControlAdded(e);
    }

    private GraphicsPath GP1, GP2, GP3, GP4;

    private Rectangle R1, R2;

    private Pen P1, P2, P3;
    private SolidBrush B1, B2, B3, B4;

    private PathGradientBrush PB1;

    private TabPage TP1;
    private StringFormat SF1;

    private int Offset;
    private int ItemHeight;

    protected override void OnPaint(PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        ThemeModule.G.Clear(Color.FromArgb(50, 50, 50));
        ThemeModule.G.SmoothingMode = SmoothingMode.HighQuality;

        ItemHeight = ItemSize.Height + 2;

        GP1 = ThemeModule.CreateRound(0, 0, ItemHeight + 3, Height - 1, 7);
        GP2 = ThemeModule.CreateRound(1, 1, ItemHeight + 3, Height - 3, 7);

        PB1 = new PathGradientBrush(GP1)
        {
            CenterColor = Color.FromArgb(50, 50, 50),
            SurroundColors = new Color[]
        {
            Color.FromArgb(45, 45, 45)
        },
            FocusScales = new PointF(0.8F, 0.95F)
        };

        ThemeModule.G.FillPath(PB1, GP1);

        ThemeModule.G.DrawPath(P1, GP1);
        ThemeModule.G.DrawPath(P2, GP2);

        B3 = new SolidBrush(_accentColor);

        for (int I = 0; I <= TabCount - 1; I++)
        {
            R1 = GetTabRect(I);
            R1.Y += 3;
            R1.Height -= 3;
            R1.Width += 1;
            R1.X -= 1;

            TP1 = TabPages[I];
            Offset = 0;

            if (SelectedIndex == I)
            {
                ThemeModule.G.FillRectangle(B1, R1);

                for (int J = 0; J <= 1; J++)
                {
                    ThemeModule.G.FillRectangle(B2, R1.X + 5 + (J * 5), R1.Y + 6, 2, R1.Height - 9);

                    ThemeModule.G.SmoothingMode = SmoothingMode.None;
                    ThemeModule.G.FillRectangle(B3, R1.X + 5 + (J * 5), R1.Y + 5, 2, R1.Height - 9);
                    ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

                    Offset += 5;
                }

                ThemeModule.G.DrawRectangle(P3, R1.X + 1, R1.Y - 1, R1.Width, R1.Height + 2);
                ThemeModule.G.DrawRectangle(P1, R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height - 2);
                ThemeModule.G.DrawRectangle(P2, R1);
            }
            else
                for (int J = 0; J <= 1; J++)
                {
                    ThemeModule.G.FillRectangle(B2, R1.X + 5 + (J * 5), R1.Y + 6, 2, R1.Height - 9);

                    ThemeModule.G.SmoothingMode = SmoothingMode.None;
                    ThemeModule.G.FillRectangle(B4, R1.X + 5 + (J * 5), R1.Y + 5, 2, R1.Height - 9);
                    ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

                    Offset += 5;
                }

            R1.X += 8 + Offset;
            //R1.Y += 1;

            R2 = R1;
            R2.Y += 1;
            R2.X += 1;

            //ThemeModule.G.DrawString(TP1.Text, Font, Brushes.Black, R2, SF1);
            ThemeModule.G.DrawString(TP1.Text, Font, Brushes.White, R1, SF1);
        }

        GP3 = ThemeModule.CreateRound(ItemHeight, 0, Width - ItemHeight - 1, Height - 1, 7);
        GP4 = ThemeModule.CreateRound(ItemHeight + 1, 1, Width - ItemHeight - 3, Height - 3, 7);

        ThemeModule.G.DrawPath(P2, GP3);
        ThemeModule.G.DrawPath(P1, GP4);
    }
}

[DefaultEvent("CheckedChanged")]
class NSOnOffBox : Control
{
    public event CheckedChangedEventHandler CheckedChanged;

    public delegate void CheckedChangedEventHandler(object sender);

    private Color _accentColor;
    public Color Accent
    {
        get { return _accentColor; }
        set { _accentColor = value; Invalidate(); }
    }
    public NSOnOffBox()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        Accent = Color.FromArgb(227, 194, 56);

        P1 = new Pen(Color.FromArgb(55, 55, 55));
        P2 = new Pen(Color.FromArgb(35, 35, 35));
        P3 = new Pen(Color.FromArgb(65, 65, 65));

        B1 = new SolidBrush(Color.FromArgb(35, 35, 35));
        B2 = new SolidBrush(Color.FromArgb(85, 85, 85));
        B3 = new SolidBrush(Color.FromArgb(65, 65, 65));
        B5 = new SolidBrush(Color.FromArgb(40, 40, 40));

        SF1 = new StringFormat
        {
            LineAlignment = StringAlignment.Center,
            Alignment = StringAlignment.Near
        };

        SF2 = new StringFormat
        {
            LineAlignment = StringAlignment.Center,
            Alignment = StringAlignment.Far
        };

        Size = new Size(56, 24);
        MinimumSize = Size;
        MaximumSize = Size;
    }

    private bool _Checked;
    public bool Checked
    {
        get
        {
            return _Checked;
        }
        set
        {
            _Checked = value;
            CheckedChanged?.Invoke(this);

            Invalidate();
        }
    }

    private GraphicsPath GP1, GP2, GP3, GP4;

    private Pen P1, P2, P3;
    private SolidBrush B1, B2, B3, B4, B5;

    private PathGradientBrush PB1;
    private LinearGradientBrush GB1;

    private Rectangle R1, R2, R3;
    private StringFormat SF1, SF2;

    private int Offset;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        ThemeModule.G.Clear(BackColor);
        ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

        GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
        GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

        PB1 = new PathGradientBrush(GP1)
        {
            CenterColor = Color.FromArgb(50, 50, 50),
            SurroundColors = new Color[]
        {
            Color.FromArgb(45, 45, 45)
        },
            FocusScales = new PointF(0.3F, 0.3F)
        };

        ThemeModule.G.FillPath(PB1, GP1);
        ThemeModule.G.DrawPath(P1, GP1);
        ThemeModule.G.DrawPath(P2, GP2);

        R1 = new Rectangle(5, 0, Width - 10, Height + 2);
        R2 = new Rectangle(6, 1, Width - 10, Height + 2);

        R3 = new Rectangle(1, 1, (Width / 2) - 1, Height - 3);
        B4 = new SolidBrush(_accentColor);

        if (_Checked)
        {
            //ThemeModule.G.DrawString("On", Font, Brushes.Black, R2, SF1);
            ThemeModule.G.DrawString("On", Font, Brushes.White, R1, SF1);

            R3.X += (Width / 2) - 1;
        }
        else
        {
            //ThemeModule.G.DrawString("Off", Font, B1, R2, SF2);
            ThemeModule.G.DrawString("Off", Font, B2, R1, SF2);
        }

        GP3 = ThemeModule.CreateRound(R3, 7);
        GP4 = ThemeModule.CreateRound(R3.X + 1, R3.Y + 1, R3.Width - 2, R3.Height - 2, 7);

        GB1 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F);

        ThemeModule.G.FillPath(GB1, GP3);
        ThemeModule.G.DrawPath(P2, GP3);
        ThemeModule.G.DrawPath(P3, GP4);

        Offset = R3.X + (R3.Width / 2) - 3;

        for (int I = 0; I <= 1; I++)
        {
            if (_Checked)
                ThemeModule.G.FillRectangle(B1, Offset + (I * 5), 7, 2, Height - 14);
            else
                ThemeModule.G.FillRectangle(B3, Offset + (I * 5), 7, 2, Height - 14);

            ThemeModule.G.SmoothingMode = SmoothingMode.None;

            if (_Checked)
                ThemeModule.G.FillRectangle(B4, Offset + (I * 5), 7, 2, Height - 14);
            else
                ThemeModule.G.FillRectangle(B5, Offset + (I * 5), 7, 2, Height - 14);

            ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        Checked = !Checked;
        base.OnMouseDown(e);
    }
}

class NSControlButton : Control
{
    public enum Button : byte
    {
        None = 0,
        Minimize = 1,
        MaximizeRestore = 2,
        Close = 3
    }

    private Button _ControlButton = Button.Close;
    public Button ControlButton
    {
        get
        {
            return _ControlButton;
        }
        set
        {
            _ControlButton = value;
            Invalidate();
        }
    }

    public NSControlButton()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        Anchor = AnchorStyles.Top | AnchorStyles.Right;

        Width = 18;
        Height = 20;

        MinimumSize = Size;
        MaximumSize = Size;

        Margin = new Padding(0);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.Clear(BackColor);

        switch (_ControlButton)
        {
            case Button.Minimize:
                {
                    DrawMinimize(3, 10);
                    break;
                }

            case Button.MaximizeRestore:
                {
                    if (FindForm().WindowState == FormWindowState.Normal)
                        DrawMaximize(3, 5);
                    else
                        DrawRestore(3, 4);
                    break;
                }

            case Button.Close:
                {
                    DrawClose(4, 5);
                    break;
                }
        }
    }

    private void DrawMinimize(int x, int y)
    {
        ThemeModule.G.FillRectangle(Brushes.White, x, y, 12, 5);
        ThemeModule.G.DrawRectangle(Pens.Black, x, y, 11, 4);
    }

    private void DrawMaximize(int x, int y)
    {
        ThemeModule.G.DrawRectangle(new Pen(Color.White, 2), x + 2, y + 2, 8, 6);
        ThemeModule.G.DrawRectangle(Pens.Black, x, y, 11, 9);
        ThemeModule.G.DrawRectangle(Pens.Black, x + 3, y + 3, 5, 3);
    }

    private void DrawRestore(int x, int y)
    {
        ThemeModule.G.FillRectangle(Brushes.White, x + 3, y + 1, 8, 4);
        ThemeModule.G.FillRectangle(Brushes.White, x + 7, y + 5, 4, 4);
        ThemeModule.G.DrawRectangle(Pens.Black, x + 2, y + 0, 9, 9);

        ThemeModule.G.FillRectangle(Brushes.White, x + 1, y + 3, 2, 6);
        ThemeModule.G.FillRectangle(Brushes.White, x + 1, y + 9, 8, 2);
        ThemeModule.G.DrawRectangle(Pens.Black, x, y + 2, 9, 9);
        ThemeModule.G.DrawRectangle(Pens.Black, x + 3, y + 5, 3, 3);
    }

    private GraphicsPath ClosePath;
    private void DrawClose(int x, int y)
    {
        if (ClosePath == null)
        {
            ClosePath = new GraphicsPath();
            ClosePath.AddLine(x + 1, y, x + 3, y);
            ClosePath.AddLine(x + 5, y + 2, x + 7, y);
            ClosePath.AddLine(x + 9, y, x + 10, y + 1);
            ClosePath.AddLine(x + 7, y + 4, x + 7, y + 5);
            ClosePath.AddLine(x + 10, y + 8, x + 9, y + 9);
            ClosePath.AddLine(x + 7, y + 9, x + 5, y + 7);
            ClosePath.AddLine(x + 3, y + 9, x + 1, y + 9);
            ClosePath.AddLine(x + 0, y + 8, x + 3, y + 5);
            ClosePath.AddLine(x + 3, y + 4, x + 0, y + 1);
        }

        ThemeModule.G.FillPath(Brushes.White, ClosePath);
        ThemeModule.G.DrawPath(Pens.Black, ClosePath);
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            Form F = FindForm();

            switch (_ControlButton)
            {
                case Button.Minimize:
                    {
                        F.WindowState = FormWindowState.Minimized;
                        break;
                    }

                case Button.MaximizeRestore:
                    {
                        if (F.WindowState == FormWindowState.Normal)
                            F.WindowState = FormWindowState.Maximized;
                        else
                            F.WindowState = FormWindowState.Normal;
                        break;
                    }

                case Button.Close:
                    {
                        F.Close();
                        break;
                    }
            }
        }

        Invalidate();
        base.OnMouseClick(e);
    }
}

class NSGroupBox : ContainerControl
{
    private bool _DrawSeperator;
    public bool DrawSeperator
    {
        get
        {
            return _DrawSeperator;
        }
        set
        {
            _DrawSeperator = value;
            Invalidate();
        }
    }

    private string _Title = "GroupBox";
    public string Title
    {
        get
        {
            return _Title;
        }
        set
        {
            _Title = value;
            Invalidate();
        }
    }

    private string _SubTitle = "Details";
    public string SubTitle
    {
        get
        {
            return _SubTitle;
        }
        set
        {
            _SubTitle = value;
            Invalidate();
        }
    }

    private Font _TitleFont;
    public Font TitleFont
    {
        get { return _TitleFont; }
        set { _TitleFont = value; }
    }
    private Font _SubTitleFont;
    public Font SubTitleFont
    {
        get { return _SubTitleFont; }
        set { _SubTitleFont = value; }
    }

    private Color _accentColor;
    public Color Accent
    {
        get { return _accentColor; }
        set { _accentColor = value; Invalidate(); }
    }
    public NSGroupBox()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        _accentColor = Color.FromArgb(227, 194, 56);

        _TitleFont = new Font("Verdana", 10.0F);
        _SubTitleFont = new Font("Verdana", 6.5F);

        P1 = new Pen(Color.FromArgb(35, 35, 35));
        P2 = new Pen(Color.FromArgb(55, 55, 55));
    }

    private GraphicsPath GP1, GP2;

    private PointF PT1;
    private SizeF SZ1, SZ2;

    private Pen P1, P2;

    protected override void OnPaint(PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        ThemeModule.G.Clear(BackColor);
        ThemeModule.G.SmoothingMode = SmoothingMode.HighQuality;

        GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
        GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

        ThemeModule.G.DrawPath(P1, GP1);
        ThemeModule.G.DrawPath(P2, GP2);

        SZ1 = ThemeModule.G.MeasureString(_Title, _TitleFont, Width, StringFormat.GenericTypographic);
        SZ2 = ThemeModule.G.MeasureString(_SubTitle, _SubTitleFont, Width, StringFormat.GenericTypographic);

        ThemeModule.G.DrawString(_Title, _TitleFont, new SolidBrush(_accentColor), 5, 5);

        PT1 = new PointF(6.0F, SZ1.Height + 4.0F);

        ThemeModule.G.DrawString(_SubTitle, _SubTitleFont, Brushes.White, PT1.X, PT1.Y);

        if (_DrawSeperator)
        {
            int Y = System.Convert.ToInt32(PT1.Y + SZ2.Height) + 8;

            ThemeModule.G.DrawLine(P1, 4, Y, Width - 5, Y);
            ThemeModule.G.DrawLine(P2, 4, Y + 1, Width - 5, Y + 1);
        }
    }
}

class NSSeperator : Control
{
    public NSSeperator()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        Height = 10;

        P1 = new Pen(Color.FromArgb(35, 35, 35));
        P2 = new Pen(Color.FromArgb(55, 55, 55));
    }

    private Pen P1, P2;

    protected override void OnPaint(PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.Clear(BackColor);

        ThemeModule.G.DrawLine(P1, 0, 5, Width, 5);
        ThemeModule.G.DrawLine(P2, 0, 6, Width, 6);
    }
}

[DefaultEvent("Scroll")]
public class NSTrackBar : Control
{
    public event ScrollEventHandler Scroll;

    public delegate void ScrollEventHandler(object sender);

    private int _Minimum;
    public int Minimum
    {
        get
        {
            return _Minimum;
        }
        set
        {
            //if (value < 0)
            //    throw new Exception("Property value is not valid.");

            _Minimum = value;
            if (value > _Value)
                _Value = value;
            if (value > _Maximum)
                _Maximum = value;
            Invalidate();
        }
    }

    private int _Maximum = 10;
    public int Maximum
    {
        get
        {
            return _Maximum;
        }
        set
        {
            //if (value < 0)
            //    throw new Exception("Property value is not valid.");

            _Maximum = value;
            if (value < _Value)
                _Value = value;
            if (value < _Minimum)
                _Minimum = value;
            Invalidate();
        }
    }

    private int _Value;
    public int Value
    {
        get
        {
            return _Value;
        }
        set
        {
            if (value == _Value)
                return;

            //if (value > _Maximum || value < _Minimum)
            //    throw new Exception("Property value is not valid.");

            _Value = value;
            Invalidate();

            Scroll?.Invoke(this);
        }
    }
    private Color _accentColor = Color.FromArgb(227, 194, 56);
    public Color Accent
    {
        get { return _accentColor; }
        set { _accentColor = value; Invalidate(); }
    }

    public NSTrackBar()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        Height = 17;

        P2 = new Pen(Color.FromArgb(55, 55, 55));
        P3 = new Pen(Color.FromArgb(35, 35, 35));
        P4 = new Pen(Color.FromArgb(65, 65, 65));
    }

    private GraphicsPath GP1, GP2, GP3, GP4;

    private Rectangle R1, R2, R3;
    private int I1;

    private Pen P1, P2, P3, P4;

    private LinearGradientBrush GB1, GB2, GB3;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;

        ThemeModule.G.Clear(BackColor);
        ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

        GP1 = ThemeModule.CreateRound(0, 5, Width - 1, 10, 5);
        GP2 = ThemeModule.CreateRound(1, 6, Width - 3, 8, 5);

        R1 = new Rectangle(0, 7, Width - 1, 5);
        GB1 = new LinearGradientBrush(R1, Color.FromArgb(45, 45, 45), Color.FromArgb(50, 50, 50), 90.0F);

        P1 = new Pen(Color.FromArgb(225, ControlPaint.Dark(_accentColor)), 2);

        I1 = Convert.ToInt32((_Value - _Minimum) / (double)(_Maximum - _Minimum) * (Width - 11));
        R2 = new Rectangle(I1, 0, 10, 20);

        ThemeModule.G.SetClip(GP2);
        ThemeModule.G.FillRectangle(GB1, R1);

        R3 = new Rectangle(1, 7, R2.X + R2.Width - 2, 8);
        GB2 = new LinearGradientBrush(R3, _accentColor, ControlPaint.Dark(_accentColor), 90.0F);

        ThemeModule.G.SmoothingMode = SmoothingMode.None;
        ThemeModule.G.FillRectangle(GB2, R3);
        ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

        for (int I = 0; I <= R3.Width - 15; I += 5)
            ThemeModule.G.DrawLine(P1, I, 0, I + 15, Height);

        ThemeModule.G.ResetClip();

        ThemeModule.G.DrawPath(P2, GP1);
        ThemeModule.G.DrawPath(P3, GP2);

        GP3 = ThemeModule.CreateRound(R2, 5);
        GP4 = ThemeModule.CreateRound(R2.X + 1, R2.Y + 1, R2.Width - 2, R2.Height - 2, 5);
        GB3 = new LinearGradientBrush(ClientRectangle, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F);

        ThemeModule.G.FillPath(GB3, GP3);
        ThemeModule.G.DrawPath(P3, GP3);
        ThemeModule.G.DrawPath(P4, GP4);
    }

    private bool TrackDown;
    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            I1 = System.Convert.ToInt32((_Value - _Minimum) / (double)(_Maximum - _Minimum) * (Width - 11));
            R2 = new Rectangle(I1, 0, 10, 20);

            TrackDown = true; //  R2.Contains(e.Location);

            if (TrackDown && e.X > -1 && e.X < (Width + 1))
                Value = _Minimum + System.Convert.ToInt32((_Maximum - _Minimum) * (e.X / (double)Width));
        }

        base.OnMouseDown(e);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (TrackDown && e.X > -1 && e.X < (Width + 1))
            Value = _Minimum + System.Convert.ToInt32((_Maximum - _Minimum) * (e.X / (double)Width));

        base.OnMouseMove(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        TrackDown = false;
        base.OnMouseUp(e);
    }
}

[DefaultEvent("ValueChanged")]
class NSRandomPool : Control
{
    public event ValueChangedEventHandler ValueChanged;

    public delegate void ValueChangedEventHandler(object sender);

    private StringBuilder _Value = new StringBuilder();
    public string Value
    {
        get
        {
            return _Value.ToString();
        }
        set
        {
            _Value.Clear();
            _Value.Append(Value);
        }
    }

    public string FullValue
    {
        get
        {
            return BitConverter.ToString(Table).Replace("-", "");
        }
    }

    private Random RNG = new Random();

    private int ItemSize = 9;
    private int DrawSize = 8;

    private Rectangle WA;

    private int RowSize;
    private int ColumnSize;

    public NSRandomPool()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        P1 = new Pen(Color.FromArgb(55, 55, 55));
        P2 = new Pen(Color.FromArgb(35, 35, 35));

        B1 = new SolidBrush(Color.FromArgb(30, 30, 30));
    }

    protected override void OnHandleCreated(EventArgs e)
    {
        UpdateTable();
        base.OnHandleCreated(e);
    }

    private byte[] Table;
    private void UpdateTable()
    {
        WA = new Rectangle(5, 5, Width - 10, Height - 10);

        RowSize = WA.Width / ItemSize;
        ColumnSize = WA.Height / ItemSize;

        WA.Width = RowSize * ItemSize;
        WA.Height = ColumnSize * ItemSize;

        WA.X = (Width / 2) - (WA.Width / 2);
        WA.Y = (Height / 2) - (WA.Height / 2);

        Table = new byte[(RowSize * ColumnSize) - 1 + 1];

        for (int I = 0; I <= Table.Length - 1; I++)
            Table[I] = System.Convert.ToByte(RNG.Next(100));

        Invalidate();
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        UpdateTable();
    }

    private int Index1 = -1;
    private int Index2;

    private bool InvertColors;

    protected override void OnMouseMove(MouseEventArgs e)
    {
        HandleDraw(e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        HandleDraw(e);
        base.OnMouseDown(e);
    }

    private void HandleDraw(MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left || e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            if (!WA.Contains(e.Location))
                return;

            InvertColors = (e.Button == System.Windows.Forms.MouseButtons.Right);

            Index1 = GetIndex(e.X, e.Y);
            if (Index1 == Index2)
                return;

            bool L = !(Index1 % RowSize == 0);
            bool R = !(Index1 % RowSize == (RowSize - 1));

            Randomize(Index1 - RowSize);
            if (L)
                Randomize(Index1 - 1);
            Randomize(Index1);
            if (R)
                Randomize(Index1 + 1);
            Randomize(Index1 + RowSize);

            _Value.Append(Table[Index1].ToString("X"));
            if (_Value.Length > 32)
                _Value.Remove(0, 2);

            ValueChanged?.Invoke(this);

            Index2 = Index1;
            Invalidate();
        }
    }

    private GraphicsPath GP1, GP2;

    private Pen P1, P2;
    private SolidBrush B1, B2;

    private PathGradientBrush PB1;

    protected override void OnPaint(PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;

        ThemeModule.G.Clear(BackColor);
        ThemeModule.G.SmoothingMode = SmoothingMode.HighQuality;

        GP1 = ThemeModule.CreateRound(0, 0, Width - 1, Height - 1, 7);
        GP2 = ThemeModule.CreateRound(1, 1, Width - 3, Height - 3, 7);

        PB1 = new PathGradientBrush(GP1);
        PB1.CenterColor = Color.FromArgb(50, 50, 50);
        PB1.SurroundColors = new Color[]
        {
            Color.FromArgb(45, 45, 45)
        };
        PB1.FocusScales = new PointF(0.9F, 0.5F);

        ThemeModule.G.FillPath(PB1, GP1);

        ThemeModule.G.DrawPath(P1, GP1);
        ThemeModule.G.DrawPath(P2, GP2);

        ThemeModule.G.SmoothingMode = SmoothingMode.None;

        for (int I = 0; I <= Table.Length - 1; I++)
        {
            int C = Math.Max((int)Table[I], 75);

            int X = ((I % RowSize) * ItemSize) + WA.X;
            int Y = ((I / RowSize) * ItemSize) + WA.Y;

            B2 = new SolidBrush(Color.FromArgb(C, C, C));

            ThemeModule.G.FillRectangle(B1, X + 1, Y + 1, DrawSize, DrawSize);
            ThemeModule.G.FillRectangle(B2, X, Y, DrawSize, DrawSize);

            B2.Dispose();
        }
    }

    private int GetIndex(int x, int y)
    {
        return (((y - WA.Y) / ItemSize) * RowSize) + ((x - WA.X) / ItemSize);
    }

    private void Randomize(int index)
    {
        if (index > -1 && index < Table.Length)
        {
            if (InvertColors)
                Table[index] = System.Convert.ToByte(RNG.Next(100));
            else
                Table[index] = System.Convert.ToByte(RNG.Next(100, 256));
        }
    }
}

class NSKeyboard : Control
{
    private Bitmap TextBitmap;
    private Graphics TextGraphics;

    const string LowerKeys = @"1234567890-=qwertyuiop[]asdfghjkl\;'zxcvbnm,./`";
    const string UpperKeys = "!@#$%^&*()_+QWERTYUIOP{}ASDFGHJKL|:\"ZXCVBNM<>?~";

    public NSKeyboard()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        Font = new Font("Verdana", 8.25F);

        TextBitmap = new Bitmap(1, 1);
        TextGraphics = Graphics.FromImage(TextBitmap);

        MinimumSize = new Size(386, 162);
        MaximumSize = new Size(386, 162);

        Lower = LowerKeys.ToCharArray();
        Upper = UpperKeys.ToCharArray();

        PrepareCache();

        P1 = new Pen(Color.FromArgb(45, 45, 45));
        P2 = new Pen(Color.FromArgb(65, 65, 65));
        P3 = new Pen(Color.FromArgb(35, 35, 35));

        B1 = new SolidBrush(Color.FromArgb(100, 100, 100));
    }

    private Control _Target;
    public Control Target
    {
        get
        {
            return _Target;
        }
        set
        {
            _Target = value;
        }
    }

    private bool Shift;

    private int Pressed = -1;
    private Rectangle[] Buttons;

    private char[] Lower;
    private char[] Upper;
    private string[] Other = new[] { "Shift", "Space", "Back" };

    private PointF[] UpperCache;
    private PointF[] LowerCache;

    private void PrepareCache()
    {
        Buttons = new Rectangle[51];
        UpperCache = new PointF[Upper.Length - 1 + 1];
        LowerCache = new PointF[Lower.Length - 1 + 1];

        int I;

        SizeF S;
        Rectangle R;

        for (int Y = 0; Y <= 3; Y++)
        {
            for (int X = 0; X <= 11; X++)
            {
                I = (Y * 12) + X;
                R = new Rectangle(X * 32, Y * 32, 32, 32);

                Buttons[I] = R;

                if (I != 47 && !char.IsLetter(Upper[I]))
                {
                    S = TextGraphics.MeasureString(Upper[I].ToString(), Font);
                    UpperCache[I] = new PointF(R.X + (R.Width / 2 - S.Width / 2), R.Y + R.Height - S.Height - 2);

                    S = TextGraphics.MeasureString(Lower[I].ToString(), Font);
                    LowerCache[I] = new PointF(R.X + (R.Width / 2 - S.Width / 2), R.Y + R.Height - S.Height - 2);
                }
            }
        }

        Buttons[48] = new Rectangle(0, 4 * 32, 2 * 32, 32);
        Buttons[49] = new Rectangle(Buttons[48].Right, 4 * 32, 8 * 32, 32);
        Buttons[50] = new Rectangle(Buttons[49].Right, 4 * 32, 2 * 32, 32);
    }

    private GraphicsPath GP1;

    private SizeF SZ1;
    private PointF PT1;

    private Pen P1, P2, P3;
    private SolidBrush B1;

    private PathGradientBrush PB1;
    private LinearGradientBrush GB1;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;

        ThemeModule.G.Clear(BackColor);

        Rectangle R;

        int Offset;
        ThemeModule.G.DrawRectangle(P1, 0, 0, (12 * 32) + 1, (5 * 32) + 1);

        for (int I = 0; I <= Buttons.Length - 1; I++)
        {
            R = Buttons[I];

            Offset = 0;
            if (I == Pressed)
            {
                Offset = 1;

                GP1 = new GraphicsPath();
                GP1.AddRectangle(R);

                PB1 = new PathGradientBrush(GP1);
                PB1.CenterColor = Color.FromArgb(60, 60, 60);
                PB1.SurroundColors = new Color[]
                {
                    Color.FromArgb(55, 55, 55)
                };
                PB1.FocusScales = new PointF(0.8F, 0.5F);

                ThemeModule.G.FillPath(PB1, GP1);
            }
            else
            {
                GB1 = new LinearGradientBrush(R, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F);
                ThemeModule.G.FillRectangle(GB1, R);
            }

            switch (I)
            {
                case 48:
                case 49:
                case 50:
                    {
                        SZ1 = ThemeModule.G.MeasureString(Other[I - 48], Font);
                        //ThemeModule.G.DrawString(Other[I - 48], Font, Brushes.Black, R.X + (R.Width / 2 - SZ1.Width / 2) + Offset + 1, R.Y + (R.Height / 2 - SZ1.Height / 2) + Offset + 1);
                        ThemeModule.G.DrawString(Other[I - 48], Font, Brushes.White, R.X + (R.Width / 2 - SZ1.Width / 2) + Offset, R.Y + (R.Height / 2 - SZ1.Height / 2) + Offset);
                        break;
                    }

                case 47:
                    {
                        DrawArrow(Color.Black, R.X + Offset + 1, R.Y + Offset + 1);
                        DrawArrow(Color.White, R.X + Offset, R.Y + Offset);
                        break;
                    }

                default:
                    {
                        if (Shift)
                        {
                            //ThemeModule.G.DrawString(Upper[I].ToString(), Font, Brushes.Black, R.X + 3 + Offset + 1, R.Y + 2 + Offset + 1);
                            ThemeModule.G.DrawString(Upper[I].ToString(), Font, Brushes.White, R.X + 3 + Offset, R.Y + 2 + Offset);

                            if (!char.IsLetter(Lower[I]))
                            {
                                PT1 = LowerCache[I];
                                ThemeModule.G.DrawString(Lower[I].ToString(), Font, B1, PT1.X + Offset, PT1.Y + Offset);
                            }
                        }
                        else
                        {
                            //ThemeModule.G.DrawString(Lower[I].ToString(), Font, Brushes.Black, R.X + 3 + Offset + 1, R.Y + 2 + Offset + 1);
                            ThemeModule.G.DrawString(Lower[I].ToString(), Font, Brushes.White, R.X + 3 + Offset, R.Y + 2 + Offset);

                            if (!char.IsLetter(Upper[I]))
                            {
                                PT1 = UpperCache[I];
                                ThemeModule.G.DrawString(Upper[I].ToString(), Font, B1, PT1.X + Offset, PT1.Y + Offset);
                            }
                        }

                        break;
                    }
            }

            ThemeModule.G.DrawRectangle(P2, R.X + 1 + Offset, R.Y + 1 + Offset, R.Width - 2, R.Height - 2);
            ThemeModule.G.DrawRectangle(P3, R.X + Offset, R.Y + Offset, R.Width, R.Height);

            if (I == Pressed)
            {
                ThemeModule.G.DrawLine(P1, R.X, R.Y, R.Right, R.Y);
                ThemeModule.G.DrawLine(P1, R.X, R.Y, R.X, R.Bottom);
            }
        }
    }

    private void DrawArrow(Color color, int rx, int ry)
    {
        Rectangle R = new Rectangle(rx + 8, ry + 8, 16, 16);
        ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

        Pen P = new Pen(color, 1);
        AdjustableArrowCap C = new AdjustableArrowCap(3, 2);
        P.CustomEndCap = C;

        ThemeModule.G.DrawArc(P, R, 0.0F, 290.0F);

        P.Dispose();
        C.Dispose();
        ThemeModule.G.SmoothingMode = SmoothingMode.None;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        int Index = ((e.Y / 32) * 12) + (e.X / 32);

        if (Index > 47)
        {
            for (int I = 48; I <= Buttons.Length - 1; I++)
            {
                if (Buttons[I].Contains(e.X, e.Y))
                {
                    Pressed = I;
                    break;
                }
            }
        }
        else
            Pressed = Index;

        HandleKey();
        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        Pressed = -1;
        Invalidate();
    }

    private void HandleKey()
    {
        if (_Target == null)
            return;
        if (Pressed == -1)
            return;

        switch (Pressed)
        {
            case 47:
                {
                    _Target.Text = string.Empty;
                    break;
                }

            case 48:
                {
                    Shift = !Shift;
                    break;
                }

            case 49:
                {
                    _Target.Text += " ";
                    break;
                }

            case 50:
                {
                    if (_Target.Text.Length != 0)
                        _Target.Text = _Target.Text.Remove(_Target.Text.Length - 1);
                    break;
                }

            default:
                {
                    if (Shift)
                        _Target.Text += Upper[Pressed];
                    else
                        _Target.Text += Lower[Pressed];
                    break;
                }
        }
    }
}

[DefaultEvent("SelectedIndexChanged")]
class NSPaginator : Control
{
    public event SelectedIndexChangedEventHandler SelectedIndexChanged;

    public delegate void SelectedIndexChangedEventHandler(object sender, EventArgs e);

    private Bitmap TextBitmap;
    private Graphics TextGraphics;

    public NSPaginator()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        Size = new Size(202, 26);

        TextBitmap = new Bitmap(1, 1);
        TextGraphics = Graphics.FromImage(TextBitmap);

        InvalidateItems();

        B1 = new SolidBrush(Color.FromArgb(50, 50, 50));
        B2 = new SolidBrush(Color.FromArgb(55, 55, 55));

        P1 = new Pen(Color.FromArgb(35, 35, 35));
        P2 = new Pen(Color.FromArgb(55, 55, 55));
        P3 = new Pen(Color.FromArgb(65, 65, 65));
    }

    private int _SelectedIndex;
    public int SelectedIndex
    {
        get
        {
            return _SelectedIndex;
        }
        set
        {
            _SelectedIndex = Math.Max(Math.Min(value, MaximumIndex), 0);
            Invalidate();
        }
    }

    private int _NumberOfPages;
    public int NumberOfPages
    {
        get
        {
            return _NumberOfPages;
        }
        set
        {
            _NumberOfPages = value;
            _SelectedIndex = Math.Max(Math.Min(_SelectedIndex, MaximumIndex), 0);
            Invalidate();
        }
    }

    public int MaximumIndex
    {
        get
        {
            return NumberOfPages - 1;
        }
    }

    private int ItemWidth;

    public override Font Font
    {
        get
        {
            return base.Font;
        }
        set
        {
            base.Font = value;

            InvalidateItems();
            Invalidate();
        }
    }

    private void InvalidateItems()
    {
        Size S = TextGraphics.MeasureString("000 ..", Font).ToSize();
        ItemWidth = S.Width + 10;
    }

    private GraphicsPath GP1, GP2;

    private Rectangle R1;

    private Size SZ1;
    private Point PT1;

    private Pen P1, P2, P3;
    private SolidBrush B1, B2;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAliasGridFit;

        ThemeModule.G.Clear(BackColor);
        ThemeModule.G.SmoothingMode = SmoothingMode.AntiAlias;

        bool LeftEllipse, RightEllipse;

        if (_SelectedIndex < 4)
        {
            for (int I = 0; I <= Math.Min(MaximumIndex, 4); I++)
            {
                RightEllipse = (I == 4) && (MaximumIndex > 4);
                DrawBox(I * ItemWidth, I, false, RightEllipse);
            }
        }
        else if (_SelectedIndex > 3 && _SelectedIndex < (MaximumIndex - 3))
        {
            for (int I = 0; I <= 4; I++)
            {
                LeftEllipse = (I == 0);
                RightEllipse = (I == 4);
                DrawBox(I * ItemWidth, _SelectedIndex + I - 2, LeftEllipse, RightEllipse);
            }
        }
        else
            for (int I = 0; I <= 4; I++)
            {
                LeftEllipse = (I == 0) && (MaximumIndex > 4);
                DrawBox(I * ItemWidth, MaximumIndex - (4 - I), LeftEllipse, false);
            }
    }

    private void DrawBox(int x, int index, bool leftEllipse, bool rightEllipse)
    {
        R1 = new Rectangle(x, 0, ItemWidth - 4, Height - 1);

        GP1 = ThemeModule.CreateRound(R1, 7);
        GP2 = ThemeModule.CreateRound(R1.X + 1, R1.Y + 1, R1.Width - 2, R1.Height - 2, 7);

        string T = System.Convert.ToString(index + 1);

        if (leftEllipse)
            T = ".. " + T;
        if (rightEllipse)
            T = T + " ..";

        SZ1 = ThemeModule.G.MeasureString(T, Font).ToSize();
        PT1 = new Point(R1.X + (R1.Width / 2 - SZ1.Width / 2), R1.Y + (R1.Height / 2 - SZ1.Height / 2));

        if (index == _SelectedIndex)
        {
            ThemeModule.G.FillPath(B1, GP1);

            Font F = new Font(Font, FontStyle.Underline);
            //ThemeModule.G.DrawString(T, F, Brushes.Black, PT1.X + 1, PT1.Y + 1);
            ThemeModule.G.DrawString(T, F, Brushes.White, PT1);
            F.Dispose();

            ThemeModule.G.DrawPath(P1, GP2);
            ThemeModule.G.DrawPath(P2, GP1);
        }
        else
        {
            ThemeModule.G.FillPath(B2, GP1);

            //ThemeModule.G.DrawString(T, Font, Brushes.Black, PT1.X + 1, PT1.Y + 1);
            ThemeModule.G.DrawString(T, Font, Brushes.White, PT1);

            ThemeModule.G.DrawPath(P3, GP2);
            ThemeModule.G.DrawPath(P1, GP1);
        }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left)
        {
            int NewIndex;
            int OldIndex = _SelectedIndex;

            if (_SelectedIndex < 4)
                NewIndex = (e.X / ItemWidth);
            else if (_SelectedIndex > 3 && _SelectedIndex < (MaximumIndex - 3))
            {
                NewIndex = (e.X / ItemWidth);

                switch (NewIndex)
                {
                    case 2:
                        {
                            NewIndex = OldIndex;
                            break;
                        }

                    case object _ when NewIndex < 2:
                        {
                            NewIndex = OldIndex - (2 - NewIndex);
                            break;
                        }

                    case object _ when NewIndex > 2:
                        {
                            NewIndex = OldIndex + (NewIndex - 2);
                            break;
                        }
                }
            }
            else
                NewIndex = MaximumIndex - (4 - (e.X / ItemWidth));

            if ((NewIndex < _NumberOfPages) && (NewIndex != OldIndex))
            {
                SelectedIndex = NewIndex;
                SelectedIndexChanged?.Invoke(this, null);
            }
        }

        base.OnMouseDown(e);
    }
}

[DefaultEvent("Scroll")]
class NSVScrollBar : Control
{
    public event ScrollEventHandler Scroll;

    public delegate void ScrollEventHandler(object sender);

    private int _Minimum;
    public int Minimum
    {
        get
        {
            return _Minimum;
        }
        set
        {
            if (value < 0)
                throw new Exception("Property value is not valid.");

            _Minimum = value;
            if (value > _Value)
                _Value = value;
            if (value > _Maximum)
                _Maximum = value;

            InvalidateLayout();
        }
    }

    private int _Maximum = 100;
    public int Maximum
    {
        get
        {
            return _Maximum;
        }
        set
        {
            if (value < 0)
                throw new Exception("Property value is not valid.");

            _Maximum = value;
            if (value < _Value)
                _Value = value;
            if (value < _Minimum)
                _Minimum = value;

            InvalidateLayout();
        }
    }

    private int _Value;
    public int Value
    {
        get
        {
            if (!ShowThumb)
                return _Minimum;
            return _Value;
        }
        set
        {
            if (value == _Value)
                return;

            if (value > _Maximum || value < _Minimum)
                throw new Exception("Property value is not valid.");

            _Value = value;
            InvalidatePosition();

            Scroll?.Invoke(this);
        }
    }

    private int _SmallChange = 1;
    public int SmallChange
    {
        get
        {
            return _SmallChange;
        }
        set
        {
            if (value < 1)
                throw new Exception("Property value is not valid.");

            _SmallChange = value;
        }
    }

    private int _LargeChange = 10;
    public int LargeChange
    {
        get
        {
            return _LargeChange;
        }
        set
        {
            if (value < 1)
                throw new Exception("Property value is not valid.");

            _LargeChange = value;
        }
    }

    private int ButtonSize = 16;
    private int ThumbSize = 24; // 14 minimum

    private Rectangle TSA;
    private Rectangle BSA;
    private Rectangle Shaft;
    private Rectangle Thumb;

    private bool ShowThumb;
    private bool ThumbDown;

    public NSVScrollBar()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        Width = 18;
        Value = 0;
        Minimum = 0;
        Maximum = 100;

        B1 = new SolidBrush(Color.FromArgb(55, 55, 55));
        B2 = new SolidBrush(Color.FromArgb(35, 35, 35));

        P1 = new Pen(Color.FromArgb(35, 35, 35));
        P2 = new Pen(Color.FromArgb(65, 65, 65));
        P3 = new Pen(Color.FromArgb(55, 55, 55));
        P4 = new Pen(Color.FromArgb(40, 40, 40));
    }

    private GraphicsPath GP1, GP2, GP3, GP4;

    private Pen P1, P2, P3, P4;
    private SolidBrush B1, B2;

    private int I1;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.Clear(BackColor);

        GP1 = DrawArrow(4, 6, false);
        GP2 = DrawArrow(5, 7, false);

        ThemeModule.G.FillPath(B1, GP2);
        ThemeModule.G.FillPath(B2, GP1);

        GP3 = DrawArrow(4, Height - 11, true);
        GP4 = DrawArrow(5, Height - 10, true);

        ThemeModule.G.FillPath(B1, GP4);
        ThemeModule.G.FillPath(B2, GP3);

        if (ShowThumb)
        {
            ThemeModule.G.FillRectangle(B1, Thumb);
            ThemeModule.G.DrawRectangle(P1, Thumb);
            ThemeModule.G.DrawRectangle(P2, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2);

            int Y;
            int LY = Thumb.Y + (Thumb.Height / 2) - 3;

            for (int I = 0; I <= 2; I++)
            {
                Y = LY + (I * 3);

                ThemeModule.G.DrawLine(P1, Thumb.X + 5, Y, Thumb.Right - 5, Y);
                ThemeModule.G.DrawLine(P2, Thumb.X + 5, Y + 1, Thumb.Right - 5, Y + 1);
            }
        }

        ThemeModule.G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1);
        ThemeModule.G.DrawRectangle(P4, 1, 1, Width - 3, Height - 3);
    }

    private GraphicsPath DrawArrow(int x, int y, bool flip)
    {
        GraphicsPath GP = new GraphicsPath();

        int W = 9;
        int H = 5;

        if (flip)
        {
            GP.AddLine(x + 1, y, x + W + 1, y);
            GP.AddLine(x + W, y, x + H, y + H - 1);
        }
        else
        {
            GP.AddLine(x, y + H, x + W, y + H);
            GP.AddLine(x + W, y + H, x + H, y);
        }

        GP.CloseFigure();
        return GP;
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        InvalidateLayout();
    }

    private void InvalidateLayout()
    {
        TSA = new Rectangle(0, 0, Width, ButtonSize);
        BSA = new Rectangle(0, Height - ButtonSize, Width, ButtonSize);
        Shaft = new Rectangle(0, TSA.Bottom + 1, Width, Height - (ButtonSize * 2) - 1);

        ShowThumb = ((_Maximum - _Minimum) > Shaft.Height);

        if (ShowThumb)
            // ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
            Thumb = new Rectangle(1, 0, Width - 3, ThumbSize);

        Scroll?.Invoke(this);
        InvalidatePosition();
    }

    private void InvalidatePosition()
    {
        Thumb.Y = System.Convert.ToInt32(GetProgress() * (Shaft.Height - ThumbSize)) + TSA.Height;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left && ShowThumb)
        {
            if (TSA.Contains(e.Location))
                I1 = _Value - _SmallChange;
            else if (BSA.Contains(e.Location))
                I1 = _Value + _SmallChange;
            else if (Thumb.Contains(e.Location))
            {
                ThumbDown = true;
                return;
            }
            else if (e.Y < Thumb.Y)
                I1 = _Value - _LargeChange;
            else
                I1 = _Value + _LargeChange;

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
            InvalidatePosition();
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (ThumbDown && ShowThumb)
        {
            int ThumbPosition = e.Y - TSA.Height - (ThumbSize / 2);
            int ThumbBounds = Shaft.Height - ThumbSize;

            I1 = System.Convert.ToInt32((ThumbPosition / (double)ThumbBounds) * (_Maximum - _Minimum)) + _Minimum;

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
            InvalidatePosition();
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        ThumbDown = false;
    }

    private double GetProgress()
    {
        return (_Value - _Minimum) / (double)(_Maximum - _Minimum);
    }
}

[DefaultEvent("Scroll")]
class NSHScrollBar : Control
{
    public event ScrollEventHandler Scroll;

    public delegate void ScrollEventHandler(object sender);

    private int _Minimum;
    public int Minimum
    {
        get
        {
            return _Minimum;
        }
        set
        {
            if (value < 0)
                throw new Exception("Property value is not valid.");

            _Minimum = value;
            if (value > _Value)
                _Value = value;
            if (value > _Maximum)
                _Maximum = value;

            InvalidateLayout();
        }
    }

    private int _Maximum = 100;
    public int Maximum
    {
        get
        {
            return _Maximum;
        }
        set
        {
            if (value < 0)
                throw new Exception("Property value is not valid.");

            _Maximum = value;
            if (value < _Value)
                _Value = value;
            if (value < _Minimum)
                _Minimum = value;

            InvalidateLayout();
        }
    }

    private int _Value;
    public int Value
    {
        get
        {
            if (!ShowThumb)
                return _Minimum;
            return _Value;
        }
        set
        {
            if (value == _Value)
                return;

            if (value > _Maximum || value < _Minimum)
                throw new Exception("Property value is not valid.");

            _Value = value;
            InvalidatePosition();

            Scroll?.Invoke(this);
        }
    }

    private int _SmallChange = 1;
    public int SmallChange
    {
        get
        {
            return _SmallChange;
        }
        set
        {
            if (value < 1)
                throw new Exception("Property value is not valid.");

            _SmallChange = value;
        }
    }

    private int _LargeChange = 10;
    public int LargeChange
    {
        get
        {
            return _LargeChange;
        }
        set
        {
            if (value < 1)
                throw new Exception("Property value is not valid.");

            _LargeChange = value;
        }
    }

    private int ButtonSize = 16;
    private int ThumbSize = 24; // 14 minimum

    private Rectangle LSA;
    private Rectangle RSA;
    private Rectangle Shaft;
    private Rectangle Thumb;

    private bool ShowThumb;
    private bool ThumbDown;

    public NSHScrollBar()
    {
        SetStyle((ControlStyles)139286, true);
        SetStyle(ControlStyles.Selectable, false);

        Height = 18;

        B1 = new SolidBrush(Color.FromArgb(55, 55, 55));
        B2 = new SolidBrush(Color.FromArgb(35, 35, 35));

        P1 = new Pen(Color.FromArgb(35, 35, 35));
        P2 = new Pen(Color.FromArgb(65, 65, 65));
        P3 = new Pen(Color.FromArgb(55, 55, 55));
        P4 = new Pen(Color.FromArgb(40, 40, 40));
    }

    private GraphicsPath GP1, GP2, GP3, GP4;

    private Pen P1, P2, P3, P4;
    private SolidBrush B1, B2;

    private int I1;

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
        ThemeModule.G = e.Graphics;
        ThemeModule.G.Clear(BackColor);

        GP1 = DrawArrow(6, 4, false);
        GP2 = DrawArrow(7, 5, false);

        ThemeModule.G.FillPath(B1, GP2);
        ThemeModule.G.FillPath(B2, GP1);

        GP3 = DrawArrow(Width - 11, 4, true);
        GP4 = DrawArrow(Width - 10, 5, true);

        ThemeModule.G.FillPath(B1, GP4);
        ThemeModule.G.FillPath(B2, GP3);

        if (ShowThumb)
        {
            ThemeModule.G.FillRectangle(B1, Thumb);
            ThemeModule.G.DrawRectangle(P1, Thumb);
            ThemeModule.G.DrawRectangle(P2, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2);

            int X;
            int LX = Thumb.X + (Thumb.Width / 2) - 3;

            for (int I = 0; I <= 2; I++)
            {
                X = LX + (I * 3);

                ThemeModule.G.DrawLine(P1, X, Thumb.Y + 5, X, Thumb.Bottom - 5);
                ThemeModule.G.DrawLine(P2, X + 1, Thumb.Y + 5, X + 1, Thumb.Bottom - 5);
            }
        }

        ThemeModule.G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1);
        ThemeModule.G.DrawRectangle(P4, 1, 1, Width - 3, Height - 3);
    }

    private GraphicsPath DrawArrow(int x, int y, bool flip)
    {
        GraphicsPath GP = new GraphicsPath();

        int W = 5;
        int H = 9;

        if (flip)
        {
            GP.AddLine(x, y + 1, x, y + H + 1);
            GP.AddLine(x, y + H, x + W - 1, y + W);
        }
        else
        {
            GP.AddLine(x + W, y, x + W, y + H);
            GP.AddLine(x + W, y + H, x + 1, y + W);
        }

        GP.CloseFigure();
        return GP;
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        InvalidateLayout();
    }

    private void InvalidateLayout()
    {
        LSA = new Rectangle(0, 0, ButtonSize, Height);
        RSA = new Rectangle(Width - ButtonSize, 0, ButtonSize, Height);
        Shaft = new Rectangle(LSA.Right + 1, 0, Width - (ButtonSize * 2) - 1, Height);

        ShowThumb = ((_Maximum - _Minimum) > Shaft.Width);

        if (ShowThumb)
            // ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
            Thumb = new Rectangle(0, 1, ThumbSize, Height - 3);

        Scroll?.Invoke(this);
        InvalidatePosition();
    }

    private void InvalidatePosition()
    {
        Thumb.X = System.Convert.ToInt32(GetProgress() * (Shaft.Width - ThumbSize)) + LSA.Width;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Left && ShowThumb)
        {
            if (LSA.Contains(e.Location))
                I1 = _Value - _SmallChange;
            else if (RSA.Contains(e.Location))
                I1 = _Value + _SmallChange;
            else if (Thumb.Contains(e.Location))
            {
                ThumbDown = true;
                return;
            }
            else if (e.X < Thumb.X)
                I1 = _Value - _LargeChange;
            else
                I1 = _Value + _LargeChange;

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
            InvalidatePosition();
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (ThumbDown && ShowThumb)
        {
            int ThumbPosition = e.X - LSA.Width - (ThumbSize / 2);
            int ThumbBounds = Shaft.Width - ThumbSize;

            I1 = System.Convert.ToInt32((ThumbPosition / (double)ThumbBounds) * (_Maximum - _Minimum)) + _Minimum;

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum);
            InvalidatePosition();
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        ThumbDown = false;
    }

    private double GetProgress()
    {
        return (_Value - _Minimum) / (double)(_Maximum - _Minimum);
    }
}

class NSContextMenu : ContextMenuStrip
{
    public NSContextMenu()
    {
        Renderer = new ToolStripProfessionalRenderer(new NSColorTable());
        ForeColor = Color.White;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        base.OnPaint(e);
    }
}

class NSColorTable : ProfessionalColorTable
{
    private readonly Color BackColor = Color.FromArgb(55, 55, 55);

    public override Color ButtonSelectedBorder
    {
        get
        {
            return BackColor;
        }
    }

    public override Color CheckBackground
    {
        get
        {
            return BackColor;
        }
    }

    public override Color CheckPressedBackground
    {
        get
        {
            return BackColor;
        }
    }

    public override Color CheckSelectedBackground
    {
        get
        {
            return BackColor;
        }
    }

    public override Color ImageMarginGradientBegin
    {
        get
        {
            return BackColor;
        }
    }

    public override Color ImageMarginGradientEnd
    {
        get
        {
            return BackColor;
        }
    }

    public override Color ImageMarginGradientMiddle
    {
        get
        {
            return BackColor;
        }
    }

    public override Color MenuBorder
    {
        get
        {
            return Color.FromArgb(25, 25, 25);
        }
    }

    public override Color MenuItemBorder
    {
        get
        {
            return BackColor;
        }
    }

    public override Color MenuItemSelected
    {
        get
        {
            return Color.FromArgb(65, 65, 65);
        }
    }

    public override Color SeparatorDark
    {
        get
        {
            return Color.FromArgb(35, 35, 35);
        }
    }

    public override Color ToolStripDropDownBackground
    {
        get
        {
            return BackColor;
        }
    }
}
