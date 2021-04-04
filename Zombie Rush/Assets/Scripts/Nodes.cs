using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodes : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    private GameObject turret;

    private Renderer ren;
    private Color startColor;

    private void Start()
    {
        ren = GetComponent<Renderer>();
        startColor = ren.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Cant bulid there! - TODO: Display on screen");
            return;
        }

        GameObject turretToBuild = buildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
    }
    private void OnMouseEnter()
    {
        ren.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        ren.material.color = startColor;
    }
}
