﻿// Project:         Daggerfall Tools For Unity
// Copyright:       Copyright (C) 2009-2017 Daggerfall Workshop
// Web Site:        http://www.dfworkshop.net
// License:         MIT License (http://www.opensource.org/licenses/mit-license.php)
// Source Code:     https://github.com/Interkarma/daggerfall-unity
// Original Author: Gavin Clayton (interkarma@dfworkshop.net)
// Contributors:    
// 
// Notes:
//

using UnityEngine;
using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace DaggerfallWorkshop.Game.Questing
{
    /// <summary>
    /// Manages a text symbol used by quest system.
    /// Symbols are used by resources, tasks, and text replacement.
    /// </summary>
    public class Symbol : IComparable
    {
        [SerializeField]
        string original;
        [SerializeField]
        string name;

        /// <summary>
        /// Gets original symbol at time it was set from source.
        /// This is used for serialization/deserialization only.
        /// </summary>
        public string Original
        {
            get { return original; }
            set { SetValue(value); }
        }

        /// <summary>
        /// Gets name of symbol stripped to inner symbol name only.
        /// This is what should be used by quest system.
        /// </summary>
        public string Name
        {
            get { return name; }
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Symbol()
        {
        }

        /// <summary>
        /// Set symbol constructor.
        /// </summary>
        /// <param name="original">Symbol text from source.</param>
        public Symbol(string original)
        {
            SetValue(original);
        }

        /// <summary>
        /// Gets original value.
        /// </summary>
        /// <returns>Symbol text from source.</returns>
        public string GetValue()
        {
            return original;
        }

        /// <summary>
        /// Set symbol original value. Name value is derived from inner text.
        /// </summary>
        /// <param name="original">Symbol text from source.</param>
        public void SetValue(string original)
        {
            this.original = original;
            name = Parser.GetInnerSymbolName(original);
        }

        /// <summary>
        /// Clone this symbol.
        /// </summary>
        /// <returns>New Symbol with same details as this one.</returns>
        public Symbol Clone()
        {
            Symbol clone = new Symbol();
            clone.original = original;
            clone.name = name;
            return clone;
        }

        #region IComparable

        /// <summary>
        /// Compare name value with other symbol.
        /// </summary>
        /// <param name="other">Other symbol to compare name value. Case sensitive.</param>
        /// <returns>Compare result. 0 means equal.</returns>
        public int CompareTo(object other)
        {
            return string.Compare(name, (other as Symbol).Name);
        }

        #endregion
    }
}