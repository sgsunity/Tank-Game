using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunService : MonoBehaviour
{
    private const string VIEW_PATH = "Prefabs";
    [SerializeField] private Transform gunContainer;

    public T LoadGun<T>() where T : Gun
    {
        string gunName = typeof(T).Name;
        T gunPrefab = Resources.Load<T>($"{VIEW_PATH}/{gunName}");
        Debug.Log(gunPrefab);
        return Object.Instantiate(gunPrefab, gunContainer);
    }
}
