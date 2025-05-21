using System.ComponentModel;

namespace UI.ThemeSources.ThemedControls
{
    /// <summary>
    /// Custom ProgressBar made by: RJ Code Advance
    /// YouTube Channel: https://www.youtube.com/@RJCodeAdvance
    /// ProgresBar Video: https://www.youtube.com/watch?v=CLlqYqCctZY
    /// </summary>
    public enum TextPosition
    {
        Left,
        Right,
        Center,
        Sliding,
        None
    }

    [ToolboxBitmap(typeof(ProgressBar))] // Uses the ProgresBar icon in the ToolBox
    [DesignerCategory("code")] // To display as a class instead like a component in the solution explorer
    public class ThemedProgressBar : ProgressBar
    {
        //Fields
        //-> Appearance
        private Color channelColor = Themes.Current.ProgressBar.Border;
        private Color sliderColor = Themes.Current.ProgressBar.Base;
        private int channelHeight = 100;
        private int sliderHeight = 100;
        //-> Others
        private bool paintedBack = false;
        private bool stopPainting = false;

        public ThemedProgressBar()
        {
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            if (stopPainting == false)
            {
                if (paintedBack == false)
                {
                    //Fields
                    Graphics graph = pevent.Graphics;
                    Rectangle rectChannel = new Rectangle(0, 0, this.Width, channelHeight);
                    using (var brushChannel = new SolidBrush(channelColor))
                    {
                        if (channelHeight >= sliderHeight)
                            rectChannel.Y = this.Height - channelHeight;
                        else rectChannel.Y = this.Height - ((channelHeight + sliderHeight) / 2);
                        //Painting
                        graph.Clear(channelColor);// Surface
                        graph.FillRectangle(brushChannel, rectChannel);// Channel
                                                                       // Stop painting the back & Channel
                        if (this.DesignMode == false)
                            paintedBack = true;
                    }
                }
                // Reset painting the back & channel
                if (this.Value == this.Maximum || this.Value == this.Minimum)
                    paintedBack = false;
            }
        }

        //-> Paint slider
        protected override void OnPaint(PaintEventArgs e)
        {
            if (stopPainting == false)
            {
                // Fields
                Graphics graph = e.Graphics;
                double scaleFactor = (((double)this.Value - this.Minimum) / ((double)this.Maximum - this.Minimum));
                int sliderWidth = (int)(this.Width * scaleFactor);
                Rectangle rectSlider = new Rectangle(0, 0, sliderWidth, sliderHeight);
                using (var brushSlider = new SolidBrush(sliderColor))
                {
                    if (sliderHeight >= channelHeight)
                        rectSlider.Y = this.Height - sliderHeight;
                    else rectSlider.Y = this.Height - ((sliderHeight + channelHeight) / 2);
                    //Painting
                    if (sliderWidth > 1) // Slider
                        graph.FillRectangle(brushSlider, rectSlider);
                }
            }
            if (this.Value == this.Maximum) stopPainting = true;// Stop painting
            else stopPainting = false; // Keep painting
        }
        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
        }
    }
}
