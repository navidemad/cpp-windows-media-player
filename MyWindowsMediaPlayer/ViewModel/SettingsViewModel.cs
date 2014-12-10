using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using FirstFloor.ModernUI.Presentation;

namespace MyWindowsMediaPlayer.ViewModel
{
    class SettingsViewModel : ViewModel
    {
        private const string FontSmall = "Small";
        private const string FontLarge = "Large";
        public string[] FontSizes
        {
            get { return new string[] { FontSmall, FontLarge }; }
        }


        private Color[] _Colors = new Color[] {
            Color.FromRgb(0xa4, 0xc4, 0x00),   // lime
            Color.FromRgb(0x60, 0xa9, 0x17),   // green
            Color.FromRgb(0x00, 0x8a, 0x00),   // emerald
            Color.FromRgb(0x00, 0xab, 0xa9),   // teal
            Color.FromRgb(0x1b, 0xa1, 0xe2),   // cyan
            Color.FromRgb(0x00, 0x50, 0xef),   // cobalt
            Color.FromRgb(0x6a, 0x00, 0xff),   // indigo
            Color.FromRgb(0xaa, 0x00, 0xff),   // violet
            Color.FromRgb(0xf4, 0x72, 0xd0),   // pink
            Color.FromRgb(0xd8, 0x00, 0x73),   // magenta
            Color.FromRgb(0xa2, 0x00, 0x25),   // crimson
            Color.FromRgb(0xe5, 0x14, 0x00),   // red
            Color.FromRgb(0xff, 0x45, 0x00),   // orange red
            Color.FromRgb(0xfa, 0x68, 0x00),   // orange
            Color.FromRgb(0xf0, 0xa3, 0x0a),   // amber
            Color.FromRgb(0xe3, 0xc8, 0x00),   // yellow
            Color.FromRgb(0x82, 0x5a, 0x2c),   // brown
            Color.FromRgb(0x6d, 0x87, 0x64),   // olive
            Color.FromRgb(0x64, 0x76, 0x87),   // steel
            Color.FromRgb(0x76, 0x60, 0x8a),   // mauve
            Color.FromRgb(0xa2, 0x00, 0xff),   // purple            
            Color.FromRgb(0x87, 0x79, 0x4e),   // taupe
        };

        public Color[] Colors
        {
            get { return _Colors; }
        }

        private Color selectedColor;
        public Color SelectedColor
        {
            get { return selectedColor; }
            set
            {
                selectedColor = value;
                RaisePropertyChanged("SelectedAccentColor");

                AppearanceManager.Current.AccentColor = value;
            }
        }

        private LinkCollection _Themes = new LinkCollection();
        public LinkCollection Themes
        {
            get { return _Themes; }
        }

        private Link _SelectedTheme;
        public Link SelectedTheme
        {
            get { return _SelectedTheme; }
            set
            {
                _SelectedTheme = value;
                RaisePropertyChanged("SelectedTheme");

                AppearanceManager.Current.ThemeSource = value.Source;
            }
        }

        private string _SelectedFontSize;
        public string SelectedFontSize
        {
            get { return _SelectedFontSize; }
            set
            {
                _SelectedFontSize = value;
                RaisePropertyChanged("SelectedFontSize");

                AppearanceManager.Current.FontSize = value == FontLarge ? FontSize.Large : FontSize.Small;
            }
        }

        private static SettingsViewModel _Instance = null;
        public static SettingsViewModel getInstance()
        {
            if (_Instance == null)
                _Instance = new SettingsViewModel();

            return _Instance;
        }

        public SettingsViewModel()
        {
            _Themes.Add(new Link { DisplayName = "Dark", Source = AppearanceManager.DarkThemeSource });
            _Themes.Add(new Link { DisplayName = "Light", Source = AppearanceManager.LightThemeSource });

            SelectedFontSize = AppearanceManager.Current.FontSize == FontSize.Large ? FontLarge : FontSmall;
            SelectedTheme = _Themes.FirstOrDefault(l => l.Source.Equals(AppearanceManager.Current.ThemeSource));
            SelectedColor = AppearanceManager.Current.AccentColor;
        }
    }
}
