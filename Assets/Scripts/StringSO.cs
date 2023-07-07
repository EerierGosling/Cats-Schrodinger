using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class StringSO : ScriptableObject
{
    [SerializeField]
    private string _value;

    public string Value {
        get { return _value; }
        set { _value = value; }
    }
}