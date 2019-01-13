using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line2_bad : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Score_Manager.score += 5;
            Combo_Manager.combo++;
            if (HP_Manager.HP < 100) HP_Manager.HP++;
            Destroy(other.gameObject);
        }
    }
}
