using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestL : MonoBehaviour
{
    public delegate void GiveGiftDelegate(string gift);

    // public delegate bool Predicate<in T>(T obj);
    

    public List<int> Arguments = new List<int>()
    {3, 4, 23, 4,
        5,
        6,
        234 - 45,
        56,
        77,
        -10
    };
    
    Predicate<int> isPositive = (int x) => x < 0;
    void Start()
    {
        LessThanZero();
    }

    public void GiveGift(string gift)
    {
        Debug.Log($"Gave {gift}");
    }

   

    private void LessThanZero()
    {
        // var i = Arguments.Find(c => c > 0);
        foreach (var VARIABLE in Arguments)
        {
            Debug.Log($" {VARIABLE } {this.isPositive(VARIABLE)}");
        }
    }
}
