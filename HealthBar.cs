using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    private HealthSystem healthSystem;

    // Start is called before the first frame update
    public void SetUp(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Find("Bar").localScale = new Vector3(healthSystem.getHealthPercent(), 1);
    }
}
