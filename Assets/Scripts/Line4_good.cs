using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line4_good : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Score_Manager.score += 10;
            Combo_Manager.combo++;
            if (HP_Manager.HP < 100) HP_Manager.HP++;
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Score_Manager.score += 10;
            Combo_Manager.combo++;
            if (HP_Manager.HP < 100) HP_Manager.HP++;
            Destroy(other.gameObject);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Score_Manager.score += 10;
            Combo_Manager.combo++;
            if (HP_Manager.HP < 100) HP_Manager.HP++;
            Destroy(other.gameObject);
        }
    }
}
