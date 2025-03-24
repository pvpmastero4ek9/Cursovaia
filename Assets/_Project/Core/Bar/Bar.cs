using System;
using UnityEngine;

namespace Core.Bars
{
    public abstract class Bar
    {
        private int _currentValue;
        public int MaxValue { get; protected set; }

        public int CurrentValue { get => _currentValue; protected set =>  Math.Clamp(value, 0, MaxValue); }
        public delegate void CurrentValueChanhedDelegate(int CurrentValue);
        public event CurrentValueChanhedDelegate CurrentValueChanhed;

        protected Bar(int maxValue, int initialValue)        
        {
            MaxValue = maxValue;
            CurrentValue = initialValue;
        }

        public void Increase(int amount)
        {
            CurrentValue += amount;
        }

        public void Decrease(int amount)
        {
            CurrentValue -= amount;
        }
    }
}
