using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Play : MonoBehaviour
{
    private AudioSource audio;
    bool isEnd;
    // Start is called before the first frame update
    void Start()
    {
        isEnd = false;
        audio = GetComponent<AudioSource>();
        Invoke("p", 1);
    }

    private void p()
    {
        audio.Play();
        isEnd = true;
    }

    // Update is called once per frame
    void Update()
    {
        if ((!audio.isPlaying && isEnd) || HP_Manager.isGameEnd)
        {
            Debug.Log("end");
            //점수창으로 가기
            Destroy(this);
        }
    }
}
