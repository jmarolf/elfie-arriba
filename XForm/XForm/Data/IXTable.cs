﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;

using XForm.Types;

namespace XForm.Data
{
    /// <summary>
    ///  IXTable is the interface type all XForm Pipeline stages must implement.
    ///  It represents tabular data enumerable in arrays of rows.
    /// </summary>
    public interface IXTable : IDisposable
    {
        /// <summary>
        ///  Return a function which returns the XArray for the desired column
        ///  for the current batch of rows.
        /// </summary>
        /// <param name="columnIndex">Index of column to provide a getter for</param>
        /// <returns>Function which will return the XArray for columnName for the current row xarray on each call</returns>
        IReadOnlyList<IXColumn> Columns { get; }

        /// <summary>
        ///  Go back to the first rows from this source again.
        /// </summary>
        void Reset();

        /// <summary>
        ///  Request the next batch of rows from the source of up to desiredCount rows.
        /// </summary>
        /// <param name="desiredCount">Desired Row count; fewer or more rows may be returned.</param>
        /// <returns>Row count returned, zero if no more rows available</returns>
        int Next(int desiredCount);

        /// <summary>
        ///  Return the row count in the current array..
        /// </summary>
        int CurrentRowCount { get; }

        /// <summary>
        ///  Return the selector for the current row position
        ///  (to get matching rows if using readers directly).
        /// </summary>
        ArraySelector CurrentSelector { get; }
    }

    /// <summary>
    ///  IXArrayList is a seekable extension to IXTable, exposed by
    ///  sources and pipelines which are able to seek to specific rows in the set
    ///  efficiently.
    /// </summary>
    public interface ISeekableXTable : IXTable
    {
        /// <summary>
        ///  Get the total row count of this list.
        /// </summary>
        int Count { get; }
    }
}
