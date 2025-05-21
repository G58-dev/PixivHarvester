using UI.ThemeSources.ControlConfig;

namespace UI.ThemeSources
{
    public enum ThemeType
    {
        Light,
        Dark,
        SuperDark
    }

    public static class Themes
    {
        public static event Action? ThemeChanged;

        private static readonly Dictionary<ThemeType, ThemeColors> themes = new()
        {
            [ThemeType.Light] = new ThemeColors
            {
                CurrentTheme = ThemeType.Light,

                OuterPanel = Color.FromArgb(240, 240, 240),
                InnerPanel = Color.FromArgb(255, 255, 255),
                Button = new ControlVisual { Base = Color.FromArgb(225, 225, 225) },
                TextBox = new ControlVisual { Base = Color.FromArgb(235, 235, 235) },
                ListBox = new ControlVisual { Base = Color.FromArgb(235, 235, 235) },
                ProgressBar = new ControlVisual { Base = Color.FromArgb(0, 196, 48) },
                Text = Color.FromArgb(0, 0, 0),
                TextDisabled = Color.FromArgb(109, 109, 109),

                MenuStrip = new ControlVisual { Base = Color.FromArgb(255, 255, 255) },
                ItemBackground = Color.FromArgb(253, 253, 253),
                ItemImageBackground = Color.FromArgb(241, 241, 241)
            },
            [ThemeType.Dark] = new ThemeColors
            {
                CurrentTheme = ThemeType.Dark,

                OuterPanel = Color.FromArgb(111, 111, 111),
                InnerPanel = Color.FromArgb(126, 126, 126),
                Button = new ControlVisual { Base = Color.FromArgb(112, 112, 112) },
                TextBox = new ControlVisual { Base = Color.FromArgb(150, 150, 150) },
                ListBox = new ControlVisual { Base = Color.FromArgb(150, 150, 150) },
                ProgressBar = new ControlVisual { Base = Color.FromArgb(0, 196, 48) },
                Text = Color.FromArgb(228, 228, 228),
                TextDisabled = Color.FromArgb(191, 191, 191),

                MenuStrip = new ControlVisual { Base = Color.FromArgb(126, 126, 126) },
                ItemBackground = Color.FromArgb(150, 150, 150),
                ItemImageBackground = Color.FromArgb(139, 139, 139)
            },
            [ThemeType.SuperDark] = new ThemeColors
            {
                CurrentTheme = ThemeType.SuperDark,

                InnerPanel = Color.FromArgb(36, 36, 47),
                OuterPanel = Color.FromArgb(0, 0, 0),
                Button = new ControlVisual { Base = Color.FromArgb(7, 7, 9) },
                TextBox = new ControlVisual { Base = Color.FromArgb(19, 20, 22) },
                ListBox = new ControlVisual { Base = Color.FromArgb(19, 20, 22) },
                ProgressBar = new ControlVisual { Base = Color.FromArgb(0, 196, 48) },
                Text = Color.FromArgb(228, 228, 228),
                TextDisabled = Color.FromArgb(134, 134, 134),

                MenuStrip = new ControlVisual { Base = Color.FromArgb(0, 0, 0) },
                ItemBackground = Color.FromArgb(57, 57, 57),
                ItemImageBackground = Color.FromArgb(81, 81, 81)
            }
        };
        
        private static ThemeColors _current = themes[ThemeType.Light];
        public static ThemeColors Current => _current;

        public static void ChangeTheme(ThemeType theme)
        {
            if (themes.TryGetValue(theme, out var themeColors))
            {
                _current = themeColors;
                ThemeChanged?.Invoke();
            }
        }   
    }

    public class ThemeColors
    {
        public ThemeType CurrentTheme { get; init; }

        #region Colors for the Forms
        public Color OuterPanel { get; init; }
        public Color InnerPanel { get; init; }

        public ControlVisual Button { get; init; } = null!;
        public ControlVisual TextBox { get; init; } = null!;
        public ControlVisual ListBox { get; init; } = null!;
        public ControlVisual ProgressBar { get; init; } = null!;

        public Color Text { get; init; }
        public Color TextDisabled { get; init; }
        #endregion

        #region Colors for the MenuStrip
        public ControlVisual MenuStrip { get; init; } = null!;
        public Color ItemBackground { get; init; }
        public Color ItemImageBackground { get; init; }
        #endregion
    }
}
