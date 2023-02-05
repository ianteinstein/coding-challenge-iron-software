using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CoreLogic
{
    public class StringEngine
    {
        private PhonePadDictionary _phonePadDictionary;
        public StringEngine(PhonePadDictionary phonePadDictionary)
        {
            _phonePadDictionary = phonePadDictionary;
        }

        public ResultInfo ValidationPhonePadTxt(string input)
        {
            try
            {
                var resultInfo = new ResultInfo(true);
                Regex regex = new Regex(@"^[#*0-9 ]+$");
                if (!regex.IsMatch(input))
                {
                    resultInfo.IsValid = false;
                }

                if (!input.EndsWith("#"))
                {
                    resultInfo.IsValid = false;
                }

                if (!resultInfo.IsValid)
                {
                    resultInfo.Text = "Input is invalid";
                }

                return resultInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new ResultInfo()
                {
                    IsValid = false,
                    Text = $"Error: {ex.Message}"
                };
            }
        }

        public ResultInfo GetResultString(string input)
        {
            try
            {
                var resultInfo = ValidationPhonePadTxt(input);
                if (resultInfo.IsValid)
                {
                    var cleanString = RemoveInvalidStrint(input);
                    var phonePads = GetDuplicateStringAndCount(cleanString);
                    foreach (var phonePad in phonePads)
                    {
                        var charToAdd = _phonePadDictionary.CharDictionary[(phonePad.CharInput, phonePad.CharInputCnt)];
                        resultInfo.Text = $"{resultInfo.Text}{charToAdd}";
                    }
                }

                return resultInfo;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new ResultInfo()
                {
                    IsValid = false,
                    Text = $"Error: {ex.Message}"
                };
            }
        }

        private string RemoveInvalidStrint(string input)
        {
            var index = input.IndexOf("*");
            if (index == -1)
            {
                return input;
            }
            var startIdx = GetStartIndex(input, index, input[index - 1]);
            input = input.Remove(startIdx, (index - startIdx) + 1);
            if (input.IndexOf("*") > -1)
            {
                input = RemoveInvalidStrint(input);
            }
            return input;
        }

        private int GetStartIndex(string source, int idx, char charToCompare)
        {
            int newIdx = idx - 1;
            if (source[newIdx].Equals(charToCompare))
            {
                return GetStartIndex(source, newIdx, charToCompare);
            }
            else
            {
                return newIdx + 1;
            }
        }

        private bool CheckSingle(string text, char charToCompare)
        {
            var endWithSharp = text[text.Length - 1].Equals("#") || text[text.Length - 1].Equals('#');
            var newText = text.Substring(0, endWithSharp ? text.Length - 1 : text.Length);
            var groups = newText.Where(n => n == charToCompare).GroupBy(c => c).Where(g => g.Count() >= 1);
            return groups.Any() && groups.FirstOrDefault().Count() == 1;
        }

        private int GetEndIndex(string source, int idx, char charToCompare)
        {
            if (charToCompare.Equals('#'))
            {
                return idx + 1;
            }
            var isSingle = CheckSingle(source, charToCompare);
            if (isSingle)
            {
                return idx.Equals(0) ? 1 : idx;
            }
            isSingle = CheckSingle(source, source[idx]);
            if (isSingle)
            {
                return idx.Equals(0) ? 1 : idx;
            }
            int newIdx = idx + 1;
            if (newIdx < source.Length && source[newIdx].Equals(charToCompare))
            {
                return GetEndIndex(source, newIdx, charToCompare);
            }
            else
            {
                return newIdx;
            }
        }

        private void GetPhonePadAndCount(string text, int idx, ref List<PhonePadInfo> lst)
        {
            if (text.Length > 1)
            {
                var endWithSharp = text[text.Length - 1].Equals("#") || text[text.Length - 1].Equals('#');
                var newText = text.Substring(0, endWithSharp ? text.Length - 1 : text.Length);
                var groups = newText.GroupBy(c => c).Where(g => g.Count() >= 1);
                if (groups.Any() && groups.Count() == 1)
                {
                    if (newText.Length == newText.Count(n => n == groups.FirstOrDefault().Key))
                    {
                        lst.Add(new PhonePadInfo()
                        {
                            CharInput = text[0],
                            CharInputCnt = newText.Length
                        });
                    }
                }
                else
                {
                    var txtToChk = text[idx];
                    var endIdx = GetEndIndex(text, idx, text[idx + 1]);
                    lst.Add(new PhonePadInfo()
                    {
                        CharInput = txtToChk,
                        CharInputCnt = endIdx - idx
                    });
                    if (endIdx < (text.Length - 1))
                    {
                        GetPhonePadAndCount(text, endIdx, ref lst);
                    }
                }
            }
            else
            {
                lst.Add(new PhonePadInfo()
                {
                    CharInput = text[0],
                    CharInputCnt = 1
                });
            }
        }

        private List<PhonePadInfo> GetDuplicateStringAndCount(string input)
        {
            var result = new List<PhonePadInfo>();

            var strArr = input.Split(' ');
            foreach (var item in strArr)
            {
                GetPhonePadAndCount(item, 0, ref result);
            }

            return result;
        }

    }
}
