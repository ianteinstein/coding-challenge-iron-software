using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLogic
{
    public class PhonePadInfo
    {
        public PhonePadInfo() 
        {
            CharInput = char.MinValue;
        }

        public char CharInput { get; set; }
        public int CharInputCnt { get; set; }
    }
}
