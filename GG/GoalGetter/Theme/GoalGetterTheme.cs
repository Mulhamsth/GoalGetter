using MudBlazor;

namespace GoalGetter.Theme
{
    /// <summary>
    /// Centralized MudBlazor theme for GoalGetter.
    /// Keeps the brand blue (#0088d3) as the primary color but exposes it through a
    /// proper light/dark palette so colors no longer need to be hard-coded inline and
    /// dark mode renders correctly across the app.
    /// </summary>
    public static class GoalGetterTheme
    {
        public const string Brand = "#0088d3";

        public static readonly MudTheme Theme = new MudTheme
        {
            Palette = new PaletteLight
            {
                Primary = Brand,
                PrimaryDarken = "#0067a3",
                PrimaryLighten = "#4db1e4",
                Secondary = "#0ea5a4",            // teal accent, used sparingly
                Tertiary = "#5b6cff",
                AppbarBackground = Brand,
                AppbarText = "#ffffff",
                Background = "#f5f7fa",            // soft off-white app background
                Surface = "#ffffff",
                DrawerBackground = "#ffffff",
                DrawerText = "#2a3243",
                DrawerIcon = "#5a6678",
                TextPrimary = "#1a2027",
                TextSecondary = "#5a6678",
                ActionDefault = "#5a6678",
                LinesDefault = "#e6e9ef",
                TableLines = "#e6e9ef",
                Success = "#2e9e6b",
                Info = Brand,
                Warning = "#f0a020",
                Error = "#e5484d",
            },
            PaletteDark = new PaletteDark
            {
                Primary = "#2ba3e3",              // a touch brighter so it reads on dark surfaces
                PrimaryDarken = "#0088d3",
                PrimaryLighten = "#62c0ef",
                Secondary = "#26c6c4",
                Tertiary = "#7d8bff",
                AppbarBackground = "#1b1e27",
                AppbarText = "#ffffff",
                Background = "#15171e",
                Surface = "#1e2129",
                DrawerBackground = "#1b1e27",
                DrawerText = "#c7ccd6",
                DrawerIcon = "#9aa3b2",
                TextPrimary = "#e7eaf0",
                TextSecondary = "#9aa3b2",
                ActionDefault = "#9aa3b2",
                LinesDefault = "#2c2f3a",
                TableLines = "#2c2f3a",
                Success = "#34b37c",
                Info = "#2ba3e3",
                Warning = "#f0a020",
                Error = "#ff5963",
            },
            LayoutProperties = new LayoutProperties
            {
                DefaultBorderRadius = "10px",
            },
            Typography = new Typography
            {
                Default = new Default
                {
                    FontFamily = new[] { "Roboto", "Helvetica Neue", "Arial", "sans-serif" },
                },
                H4 = new H4 { FontWeight = 600 },
                H5 = new H5 { FontWeight = 600 },
                H6 = new H6 { FontWeight = 600 },
                Button = new Button { FontWeight = 600, TextTransform = "none" },
            },
        };
    }
}
