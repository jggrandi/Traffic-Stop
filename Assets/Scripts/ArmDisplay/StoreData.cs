using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreData<T> : MonoBehaviour
{
    public T data;
    protected AlertObject alertObjectRef;

    protected void InitialSetup()
    {
        alertObjectRef = GetComponent<AlertObject>();
    }
}
