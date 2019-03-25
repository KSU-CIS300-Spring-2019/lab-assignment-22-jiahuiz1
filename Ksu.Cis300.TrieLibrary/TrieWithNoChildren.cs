using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Whether the string is empty
        /// </summary>
        private bool _hasEmptyString = false;

        /// <summary>
        /// Add the given string =
        /// </summary>
        /// <param name="s">the given string</param>
        /// <returns>ITrie</returns>
        public ITrie Add(string s)
        {  
            if(s == "")
            {
                _hasEmptyString = true;
                return this;
            }
            else
            {
                return new TrieWithOneChildren(s, _hasEmptyString);
            }
        }
                        

        /// <summary>
        /// Whether contain the string
        /// </summary>
        /// <param name="s">the given string</param>
        /// <returns>bool</returns>
        public bool Contains(string s)
        {
            if(s == "")
            {
                return _hasEmptyString;
            }
            else{
                return false;
            }
        }
    }
}
