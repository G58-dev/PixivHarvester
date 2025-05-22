using System.Xml;
using UI.ThemeSources;

namespace UI.Settings
{
    public static class XmlSettings
    {
        public static void WriteTheme(ThemeType themeEnum)
        {
            using (XmlWriter outputFile = XmlWriter.Create("settings.xml"))
            {
                outputFile.WriteStartDocument();

                outputFile.WriteStartElement("Themes");
                outputFile.WriteElementString("PreferredTheme", themeEnum.ToString());
                outputFile.WriteEndElement();
            }
        }

        public static ThemeType ReadTheme()
        {
            ThemeType theme = ThemeType.Light;
            if (!File.Exists("settings.xml"))
            {
                return theme;
            }            

            using (XmlReader inputFile = XmlReader.Create("settings.xml"))
            {
                while (inputFile.Read())
                {
                    if (inputFile.IsStartElement())
                    {
                        switch (inputFile.Name.ToString())
                        {
                            case "PreferredTheme":
                                theme = Enum.Parse<ThemeType>(inputFile.ReadString());
                                break;
                            default:
                                theme = ThemeType.Light;
                                break;
                        }
                    }
                }                
            }
            return theme;
        }
    }
}
