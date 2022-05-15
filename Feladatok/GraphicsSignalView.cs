using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signals
{
    /// <summary>
    /// Osztály, mely felel a grafikon kirajzolásáért.
    /// </summary>
    public partial class GraphicsSignalView : UserControl, IView
    {
        /// <summary>
        /// A megfelelő kirajzolásért felelős osztályok.
        /// </summary>
        double pixelPerSec = 1, pixelPerValue = 100, zoom = 1;
        /// <summary>
        /// IView-ból implementálva.
        /// A dokumentumhoz tartozó nézet sorszáma.
        /// </summary>
        public int ViewNumber
        {
            get; set;
        }
        /// <summary>
        /// Alapértelmezett konstruktor.
        /// </summary>
        public GraphicsSignalView()
        {
            InitializeComponent();
        }
        /// <summary>
        /// A jeleket tartalmazó dokumentum.
        /// </summary>
        private SignalDocument signalDocument;
        /// <summary>
        /// Dokumentumot átadó konstruktor.
        /// </summary>
        /// <param name="s">Az átadott dokumentum.</param>
        public GraphicsSignalView(SignalDocument s)
        {
            signalDocument = s;
        }
        /// <summary>
        /// A jeleket tartalmazó dokumentumot adja vissza.
        /// </summary>
        /// <returns>A jeleket tartalmazó dokumentum</returns>
        public Document GetDocument()
        {
            return signalDocument;
        }
        /// <summary>
        /// A rajzolást megvalósító függvény. A UserControl-ból származó függvény felülírása.
        /// </summary>
        protected override void OnPaint(PaintEventArgs e)
        {
            //Tengelyhez szükséges toll definiálása
            Pen pen = new Pen(Color.Red, 2);
            pen.DashStyle = DashStyle.Dot;
            pen.EndCap = LineCap.ArrowAnchor;

            //Tengelyek megrajzolása
            int h = ClientSize.Height, w = ClientSize.Width;
            Point p1 = new Point(0, h / 2), p2 = new Point(w, h / 2);
            e.Graphics.DrawLine(pen, p1, p2);
            p1 = new Point(2, h);
            p2 = new Point(2, 0);
            e.Graphics.DrawLine(pen, p1, p2);

            //Pontok kirajzolása (itt már float típusúak a pontok paraméterei)
            pen = new Pen(Color.SteelBlue, 1);
            SignalValue prev = null;
            float px = 0, py = 0, x = 0, y = h / 2;
            foreach (SignalValue i in signalDocument.Signals)
            {
                y = h / 2;
                if (prev != null)  x += (float)((i.GetTimeStamp().Ticks - prev.GetTimeStamp().Ticks)/10000000*pixelPerSec*zoom);
                y -= (float)(i.GetValue() * pixelPerSec * pixelPerValue * zoom);
                e.Graphics.FillRectangle(new SolidBrush(Color.SteelBlue), x, y, 3, 3);
                if (prev != null) e.Graphics.DrawLine(pen, px, py, x, y);
                prev = i;
                px = x;
                py = y;
            }
        }

        /// <summary>
        /// A nagyítás gomb működéséért felelős függvény.
        /// </summary>
        private void b_ZoomIn_Click(object sender, EventArgs e)
        {
            zoom += 0.1;
            Update();
        }

        /// <summary>
        /// A kicsinyítés gomb működéséért felelős függvény.
        /// </summary>
        private void b_ZoomOut_Click(object sender, EventArgs e)
        {
            zoom -= 0.1;
            Update();
        }

        /// <summary>
        /// Interfészből implementált függvény.
        /// </summary>
        public void Update()
        {
            Invalidate();
        }
    }
}
