using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class DialogManagerInstance : MonoBehaviour
{
    [SerializeField] DialogManager instance;
    static DialogManager staticInstance;

    void Awake()
    {
        staticInstance = instance;
    }

    public static DialogManager GetInstance()
    {
        return staticInstance;
    }
}
