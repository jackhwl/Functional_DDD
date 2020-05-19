﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WL_DDD.Logic.Common
{
    public abstract class ValueObject<T> where T : ValueObject<T>
    {
        // protected abstract IEnumerable<object> GetEqualityComponents();

        public override bool Equals(object obj)
        {
            var valueObject = obj as T;

            if (ReferenceEquals(valueObject, null))
                return false;

            return EqualsCore(valueObject);
        }

        //private bool EqualsCore(ValueObject<T> other)
        //{
        //    return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        //}

        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return GetHashCodeCore();
            //return GetEqualityComponents()
            //    .Aggregate(1, (current, obj) => current * 23 + (obj?.GetHashCode() ?? 0));
        }

        protected abstract int GetHashCodeCore();
        public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
        {
            return !(a == b);
        }
    }
}
