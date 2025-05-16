using System;
using UnityEngine;

namespace ListExtentions
{
    public class RandomChanceDrop : MonoBehaviour
    {
        private double _trueChance;
        private System.Random _random;

        public bool ChanceBoolean(double trueChancePercent)
        {
            if (trueChancePercent > 100 || trueChancePercent < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(trueChancePercent), "Значение должно быть от 0 до 100.");
            }

            _trueChance = trueChancePercent / 100;
            _random = new();

            return _random.NextDouble() < _trueChance;
        }
    }
}
