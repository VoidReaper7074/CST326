using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint LazerTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missle selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLazerTurret()
    {
        Debug.Log("LazerTurret selected");
        buildManager.SelectTurretToBuild(LazerTurret);
    }
}
