using System;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

namespace Extensions
{
    public static class UnityExtensions
    {
        public static void CheckLink<T>(
            [CanBeNull] this T nullable,
            [CallerMemberName] string memberName = "")
            where T : MonoBehaviour
        {
            if (nullable == null)
            {
                throw new NullReferenceException($"Check {memberName}");
            }
        }
    }
}