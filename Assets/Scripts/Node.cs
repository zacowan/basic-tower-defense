using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color HoverColor;

    private GameObject turret;
    private Renderer rendererReference;
    private Color defaultColor;

    private BuildManager buildManager;

    void Start()
    {
        rendererReference = GetComponent<Renderer>();
        defaultColor = rendererReference.material.color;
        buildManager = BuildManager.instance;
    }

    void OnMouseDown()
    {
        if (!buildManager.GetTurretToBuild() || turret) return;

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        Vector3 buildPosition = transform.position + turretToBuild.transform.position;
        turret = (GameObject)Instantiate(turretToBuild, buildPosition, transform.rotation);

        buildManager.SetTurretToBuild(null);
    }

    // Called every time the mouse hovers over the GameObject
    void OnMouseEnter()
    {
        if (!buildManager.GetTurretToBuild() || turret) return;

        rendererReference.material.color = HoverColor;
    }

    void OnMouseExit()
    {
        rendererReference.material.color = defaultColor;
    }
}
