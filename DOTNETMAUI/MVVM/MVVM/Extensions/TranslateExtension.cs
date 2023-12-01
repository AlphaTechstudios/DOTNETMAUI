using System;
using System.Globalization;
using MVVM.Resources.Languages;

namespace MVVM.Extensions
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {

        public TranslateExtension()
        {
            AppResources.Culture = CultureInfo.CurrentCulture;
        }
        public string Text { get; set; }


        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (string.IsNullOrEmpty(Text))
            {
                return "";
            }

            try
            {
                var ci = Thread.CurrentThread.CurrentCulture;
                var translation = AppResources.ResourceManager.GetObject(Text, ci);
                if (translation == null)
                {
                    return Text;
                }

                return translation;
            }
            catch (Exception ex)
            {
                return Text;
            }
        }
    }
}

