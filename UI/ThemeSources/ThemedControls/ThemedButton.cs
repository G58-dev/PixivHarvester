using System.ComponentModel;

namespace UI.ThemeSources.ThemedControls
{
    [ToolboxBitmap(typeof(Button))] // Uses the Button icon in the ToolBox
    [DesignerCategory("code")] // To display as a class instead like a component in the solution explorer
    public class ThemedButton : Button
    {
        private bool _isHovered = false;
        private bool _isPressed = false;

        public ThemedButton()
        {
            SetStyle(ControlStyles.UserPaint, true);
            Themes.ThemeChanged += OnThemeChanged;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isHovered = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isHovered = false;
            _isPressed = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isPressed = true;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isPressed = false;
            Invalidate();
            base.OnMouseUp(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var button = Themes.Current.Button;

            Color backgroundColor = button.Base;
            Color borderColor = button.Border;
            Color textColor = Themes.Current.Text;

            if (!Enabled)
            {
                backgroundColor = button.Disabled;
                borderColor = button.BorderDisabled;
                textColor = Themes.Current.TextDisabled;
            }
            else if (_isPressed)
            {
                backgroundColor = button.Pressed;
                borderColor = button.BorderPressed;
            }
            else if (_isHovered)
            {
                backgroundColor = button.Hover;
                borderColor = button.BorderHover;
            }

            e.Graphics.Clear(backgroundColor);

            // Dibuja el borde si está enfocado o activo
            ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, borderColor, ButtonBorderStyle.Solid);

            // Dibuja el texto personalizado centrado
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(e.Graphics, Text, this.Font, this.ClientRectangle, textColor, flags);
        }

        private void OnThemeChanged()
        {
            this.Invalidate();
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            base.OnHandleDestroyed(e);
            Themes.ThemeChanged -= OnThemeChanged;      // Evita fugas de memoria
        }
    }
}
