using System.Drawing;

namespace Jonny.Fomrs.ThemeDemo.Themes
{
    public interface IThemeBaseForm
    {
        public Color BaseFormBackgroundColor { get; }
        public Color BaseFormTitleColor { get; }
        public Color BaseFormForeColor { get; }        
    }
}