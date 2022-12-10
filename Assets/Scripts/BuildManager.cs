using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public GameObject StandardTurretPrefab;
    public static BuildManager instance;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    void Awake()
    {
        if (instance)
        {
            throw new System.Exception("Multiple instances of BuildManger detected.");
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        turretToBuild = StandardTurretPrefab;
    }
}
