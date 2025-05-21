namespace UI.ThemeSources.ThemedControls
{
    public class ThemedMenuStrip : ToolStripProfessionalRenderer
    {
        public ThemedMenuStrip() : base(new BrowserColors()) { }
    }
    public class BrowserColors : ProfessionalColorTable
    {
        // MenuItemPressed (top items selected)
        public override Color MenuItemPressedGradientBegin => Themes.Current.MenuStrip.Pressed;
        public override Color MenuItemPressedGradientMiddle => Themes.Current.MenuStrip.Pressed;
        public override Color MenuItemPressedGradientEnd => Themes.Current.MenuStrip.Pressed;

        // MenuItemSelected (top items & inner items)
        public override Color MenuItemSelectedGradientBegin => Themes.Current.MenuStrip.Pressed;
        public override Color MenuItemSelectedGradientEnd => Themes.Current.MenuStrip.Pressed;

        // MenuItemBorder & InnerBorder
        public override Color MenuBorder => Themes.Current.MenuStrip.Border;
        public override Color MenuItemBorder => Themes.Current.MenuStrip.Border;

        // Image Color (left side)
        public override Color ImageMarginGradientBegin => Themes.Current.ItemImageBackground;
        public override Color ImageMarginGradientMiddle => Themes.Current.ItemImageBackground;
        public override Color ImageMarginGradientEnd => Themes.Current.ItemImageBackground;

        // Items background
        public override Color ToolStripDropDownBackground => Themes.Current.ItemBackground;
    }
}
