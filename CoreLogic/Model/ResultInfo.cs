using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLogic
{
    public class ResultInfo
    {
        public ResultInfo(bool isValid = false)
        {
            Text = string.Empty;
            IsValid = isValid;
        }

        public string Text { get; set; }
        public bool IsValid { get; set; }
    }
}
