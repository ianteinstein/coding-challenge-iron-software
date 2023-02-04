using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLogic
{
    public class PhonePadDictionary
    {
        public PhonePadDictionary()
        {
            CharDictionary = new Dictionary<(char, int), char>();
            CharDictionary.Add(('1', 1), '&');
            CharDictionary.Add(('1', 2), '\'');
            CharDictionary.Add(('1', 3), 'C');
            CharDictionary.Add(('2', 1), 'A');
            CharDictionary.Add(('2', 2), 'B');
            CharDictionary.Add(('2', 3), 'C');
            CharDictionary.Add(('3', 1), 'D');
            CharDictionary.Add(('3', 2), 'E');
            CharDictionary.Add(('3', 3), 'F');
            CharDictionary.Add(('4', 1), 'G');
            CharDictionary.Add(('4', 2), 'H');
            CharDictionary.Add(('4', 3), 'I');
            CharDictionary.Add(('5', 1), 'J');
            CharDictionary.Add(('5', 2), 'K');
            CharDictionary.Add(('5', 3), 'L');
            CharDictionary.Add(('6', 1), 'M');
            CharDictionary.Add(('6', 2), 'N');
            CharDictionary.Add(('6', 3), 'O');
            CharDictionary.Add(('7', 1), 'P');
            CharDictionary.Add(('7', 2), 'Q');
            CharDictionary.Add(('7', 3), 'R');
            CharDictionary.Add(('7', 4), 'S');
            CharDictionary.Add(('8', 1), 'T');
            CharDictionary.Add(('8', 2), 'U');
            CharDictionary.Add(('8', 3), 'V');
            CharDictionary.Add(('9', 1), 'W');
            CharDictionary.Add(('9', 2), 'X');
            CharDictionary.Add(('9', 3), 'Y');
            CharDictionary.Add(('9', 4), 'Z');
        }
        public Dictionary<(char, int), char> CharDictionary { get; set; }

    }
}
