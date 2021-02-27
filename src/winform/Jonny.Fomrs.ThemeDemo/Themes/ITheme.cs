namespace Jonny.Fomrs.ThemeDemo.Themes
{
    /// <summary>
    /// 主题
    /// </summary>
    public interface ITheme
    {
        int Code { get; }
        /// <summary>
        /// 初始化
        /// </summary>
        void Init();
    }
}