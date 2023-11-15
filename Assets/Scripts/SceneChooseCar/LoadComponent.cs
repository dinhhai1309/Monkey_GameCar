using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadComponent : MonoBehaviour
{
    protected virtual void Reset()
    {
        this.LoadComponents();
    }

    protected virtual void Awake()
    {
        this.LoadComponents();// lỡ quên reset, nó sẽ tự gọi
    }
    protected virtual void Start()
    {
        // for override

    }
    protected virtual void LoadComponents()
    {
        // for override
    }
}
