﻿using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ROP.CSharp")]

namespace SFX.ROP.CSharp
{
    /// <summary>
    /// Represents the result of an operation/invokation. It is not a full two track
    /// input representation, since it:
    /// 1) Insists that the error type is <see cref="Exception"/>
    /// 2) Enables default "fallback" to exception typed flow via an implicit cast
    /// operator, that throws the provided exception if one has been provided
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Result<T>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">The optional value</param>
        /// <param name="error">The optional <see cref="Exception"/></param>
        internal Result(T value, Exception error) =>
            (Value, Error) = (value, error);

        /// <summary>
        /// The result of the operation if success full
        /// </summary>
        public T Value { get; }
        /// <summary>
        /// The error of the operation if successfull
        /// </summary>
        public Exception Error { get; }

        /// <summary>
        /// Deconstructor
        /// </summary>
        /// <param name="success">Flag telling whether the operation was successfull</param>
        /// <param name="error">The <see cref="Exception"/> if present</param>
        /// <param name="value">The result - of successfull</param>
        public void Deconstruct(out bool success, out Exception error, out T value) =>
            (success, error, value) = (Error is null, Error, Value);

        /// <summary>
        /// Implicit cast to the value if the operation was successfull
        /// </summary>
        /// <param name="x">The <see cref="Result{T}"/> to cast</param>
        public static implicit operator T(Result<T> x)
        {
            if (!(x.Error is null))
                throw x.Error;
            else return x.Value;
        }
    }
}
