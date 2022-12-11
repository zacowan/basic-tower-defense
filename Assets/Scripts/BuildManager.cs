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

    public void SetTurretToBuild(GameObject turret)
    {
        turretToBuild = turret;
    }

    void Awake()
    {
        if (instance)
        {
            throw new System.Exception("Multiple instances of BuildManger detected.");
        }

        instance = this;
    }
}
