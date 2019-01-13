using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Miss : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("miss");
        Combo_Manager.combo = 0;
        HP_Manager.HP -= 10;
        Destroy(other.gameObject);
    }
}
