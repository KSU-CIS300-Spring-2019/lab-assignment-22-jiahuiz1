using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ksu.Cis300.TrieLibrary
{
    public class TrieWithOneChildren : ITrie
    {
        /// <summary>
        /// Whether the string is empty
        /// </summary>
        private bool _hasEmptyString;

        /// <summary>
        /// The label of the child
        /// </summary>
        private char _childLabel;

        /// <summary>
        /// The child
        /// </summary>
        private ITrie _child;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="s"></param>
        /// <param name="hasEmpty"></param>
        public TrieWithOneChildren(string s, bool hasEmpty)
        {
            if(s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _hasEmptyString = hasEmpty;
            _childLabel = s[0];
            _child = new TrieWithNoChildren();
            _child = _child.Add(s.Substring(1));
        }

        /// <summary>
        /// Add the string 
        /// </summary>
        /// <param name="s">the given string</param>
        /// <returns>bool</returns>
        public ITrie Add(string s)
        { 
            if (s == "")
            {
                _hasEmptyString = true;             
                return this;
            }           
            else if (s[0] == _childLabel)
            {
                _child = _child.Add(s.Substring(1));
                return this;
            }
            else
            {
                return new TrieWithManyChildren(s, _hasEmptyString, _childLabel, _child);
            }
        }

        /// <summary>
        /// Whether contains the given string
        /// </summary>
        /// <param name="s">the given string</param>
        /// <returns>bool</returns>
        public bool Contains(string s)
        {  
            if(s == "")
            {
                return _hasEmptyString;
            }
            else if (s[0] == _childLabel)
            {
                return _child.Contains(s.Substring(1));
            }
            else
            {
                return false;
            }
        }
    }
}
