#if NET45PLUS

using System.Collections.Immutable;
using System.Runtime.CompilerServices;

[assembly: TypeForwardedTo(typeof(ImmutableSortedSet))]

#else

// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace System.Collections.Immutable
{
    /// <summary>
    /// A set of initialization methods for instances of <see cref="ImmutableSortedSet{T}"/>.
    /// </summary>
    public static class ImmutableSortedSet
    {
        /// <summary>
        /// Returns an empty collection.
        /// </summary>
        /// <typeparam name="T">The type of items stored by the collection.</typeparam>
        /// <returns>The immutable collection.</returns>
        [Pure]
        public static ImmutableSortedSet<T> Create<T>()
        {
            return ImmutableSortedSet<T>.Empty;
        }

        /// <summary>
        /// Returns an empty collection.
        /// </summary>
        /// <typeparam name="T">The type of items stored by the collection.</typeparam>
        /// <param name="comparer">The comparer.</param>
        /// <returns>
        /// The immutable collection.
        /// </returns>
        [Pure]
        public static ImmutableSortedSet<T> Create<T>(IComparer<T> comparer)
        {
            return ImmutableSortedSet<T>.Empty.WithComparer(comparer);
        }

        /// <summary>
        /// Creates a new immutable collection prefilled with the specified item.
        /// </summary>
        /// <typeparam name="T">The type of items stored by the collection.</typeparam>
        /// <param name="item">The item to prepopulate.</param>
        /// <returns>The new immutable collection.</returns>
        [Pure]
        public static ImmutableSortedSet<T> Create<T>(T item)
        {
            return ImmutableSortedSet<T>.Empty.Add(item);
        }

        /// <summary>
        /// Creates a new immutable collection prefilled with the specified item.
        /// </summary>
        /// <typeparam name="T">The type of items stored by the collection.</typeparam>
        /// <param name="comparer">The comparer.</param>
        /// <param name="item">The item to prepopulate.</param>
        /// <returns>The new immutable collection.</returns>
        [Pure]
        public static ImmutableSortedSet<T> Create<T>(IComparer<T> comparer, T item)
        {
            return ImmutableSortedSet<T>.Empty.WithComparer(comparer).Add(item);
        }

        /// <summary>
        /// Creates a new immutable collection prefilled with the specified items.
        /// </summary>
        /// <typeparam name="T">The type of items stored by the collection.</typeparam>
        /// <param name="items">The items to prepopulate.</param>
        /// <returns>The new immutable collection.</returns>
        [Pure]
        public static ImmutableSortedSet<T> CreateRange<T>(IEnumerable<T> items)
        {
            return ImmutableSortedSet<T>.Empty.Union(items);
        }

        /// <summary>
        /// Creates a new immutable collection prefilled with the specified items.
        /// </summary>
        /// <typeparam name="T">The type of items stored by the collection.</typeparam>
        /// <param name="comparer">The comparer.</param>
        /// <param name="items">The items to prepopulate.</param>
        /// <returns>The new immutable collection.</returns>
        [Pure]
        public static ImmutableSortedSet<T> CreateRange<T>(IComparer<T> comparer, IEnumerable<T> items)
        {
            return ImmutableSortedSet<T>.Empty.WithComparer(comparer).Union(items);
        }

        /// <summary>
        /// Creates a new immutable collection prefilled with the specified items.
        /// </summary>
        /// <typeparam name="T">The type of items stored by the collection.</typeparam>
        /// <param name="items">The items to prepopulate.</param>
        /// <returns>The new immutable collection.</returns>
        [Pure]
        public static ImmutableSortedSet<T> Create<T>(params T[] items)
        {
            return ImmutableSortedSet<T>.Empty.Union(items);
        }

        /// <summary>
        /// Creates a new immutable collection prefilled with the specified items.
        /// </summary>
        /// <typeparam name="T">The type of items stored by the collection.</typeparam>
        /// <param name="comparer">The comparer.</param>
        /// <param name="items">The items to prepopulate.</param>
        /// <returns>The new immutable collection.</returns>
        [Pure]
        public static ImmutableSortedSet<T> Create<T>(IComparer<T> comparer, params T[] items)
        {
            return ImmutableSortedSet<T>.Empty.WithComparer(comparer).Union(items);
        }

        /// <summary>
        /// Returns an empty collection.
        /// </summary>
        /// <typeparam name="T">The type of items stored by the collection.</typeparam>
        /// <returns>The immutable collection.</returns>
        [Pure]
        public static ImmutableSortedSet<T>.Builder CreateBuilder<T>()
        {
            return Create<T>().ToBuilder();
        }

        /// <summary>
        /// Returns an empty collection.
        /// </summary>
        /// <typeparam name="T">The type of items stored by the collection.</typeparam>
        /// <param name="comparer">The comparer.</param>
        /// <returns>
        /// The immutable collection.
        /// </returns>
        [Pure]
        public static ImmutableSortedSet<T>.Builder CreateBuilder<T>(IComparer<T> comparer)
        {
            return Create<T>(comparer).ToBuilder();
        }

        /// <summary>
        /// Enumerates a sequence exactly once and produces an immutable set of its contents.
        /// </summary>
        /// <typeparam name="TSource">The type of element in the sequence.</typeparam>
        /// <param name="source">The sequence to enumerate.</param>
        /// <param name="comparer">The comparer to use for initializing and adding members to the sorted set.</param>
        /// <returns>An immutable set.</returns>
        [Pure]
        public static ImmutableSortedSet<TSource> ToImmutableSortedSet<TSource>(this IEnumerable<TSource> source, IComparer<TSource> comparer)
        {
            var existingSet = source as ImmutableSortedSet<TSource>;
            if (existingSet != null)
            {
                return existingSet.WithComparer(comparer);
            }

            return ImmutableSortedSet<TSource>.Empty.WithComparer(comparer).Union(source);
        }

        /// <summary>
        /// Enumerates a sequence exactly once and produces an immutable set of its contents.
        /// </summary>
        /// <typeparam name="TSource">The type of element in the sequence.</typeparam>
        /// <param name="source">The sequence to enumerate.</param>
        /// <returns>An immutable set.</returns>
        [Pure]
        public static ImmutableSortedSet<TSource> ToImmutableSortedSet<TSource>(this IEnumerable<TSource> source)
        {
            return ToImmutableSortedSet(source, null);
        }
    }
}

#endif
