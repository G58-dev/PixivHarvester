namespace UI.ThemeSources.ControlConfig
{
    public class ControlVisual
    {
        public Color Base { get; init; }
        public ControlStyle Style { get; init; } = new();

        public Color Hover => CalculateHover();
        public Color Pressed => ControlPaint.Light(Base, Style.PressedFactor);
        public Color Disabled => CalculateDisabled();

        public Color Border => CalculateBorder();
        public Color BorderHover => ControlPaint.Light(Border, Style.HoverFactor);
        public Color BorderPressed => CalculatePressedBorder();
        public Color BorderDisabled => ControlPaint.Light(Border, Style.DisabledFactor);

        private bool IsLight => Themes.Current.CurrentTheme == ThemeType.Light;

        private Color CalculateHover() =>
            !IsLight ? ControlPaint.Light(Base, Style.HoverFactor)
                     : ControlPaint.Light(Base, Style.HoverFactor * -1);
        private Color CalculateDisabled() =>
            !IsLight ? ControlPaint.Light(Base, Style.DisabledFactor - 0.2f)
                     : ControlPaint.Dark(Base, Style.DisabledFactor * -1);
        private Color CalculateBorder() =>
            !IsLight ? ControlPaint.Light(Base, Style.BorderFactor)
                     : ControlPaint.Dark(Base, Style.BorderFactor);
        private Color CalculatePressedBorder() =>
            !IsLight ? ControlPaint.Light(Border, Style.PressedFactor)
                     : ControlPaint.Dark(Border, Style.PressedFactor);
    }
}
