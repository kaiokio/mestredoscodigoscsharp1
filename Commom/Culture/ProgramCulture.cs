using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Commom.Culture
{
    public static class ProgramCulture
    {
        public static void ChangeCurrentCulture(string culture)
        {
            CultureInfo.DefaultThreadCurrentCulture = CultureInfo.CreateSpecificCulture(culture);
            CultureInfo.DefaultThreadCurrentUICulture = CultureInfo.CreateSpecificCulture(culture);
        }
    }
}
