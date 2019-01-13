using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class BmsLoader : MonoBehaviour
{
    public string bmsFileName;
    public bool isFinishLoad = false;
    public Bms bms;
    public List<GameObject> objectList;
    public float W;

    // Start is called before the first frame update
    void Start()
    {
        BmsLoad();
    }

    private void BmsLoad()
    {
        Debug.Log("Bms load start");
        objectList = new List<GameObject>();
        bms = gameObject.AddComponent<Bms>();
        string[] lineData = File.ReadAllLines("Assets/BmsFiles/" + bmsFileName);
        foreach (string line in lineData)
        {
            //Debug.Log(line);
            if (line.StartsWith("#"))
            {
                string[] data = line.Split(' ');

                // exception
                if (data[0].IndexOf(":") == -1 && data.Length == 1)
                {
                    continue;
                }

                // header field
                if (data[0].Equals("#TITLE"))
                {
                    bms.setTitle(data[1]);
                }
                else if (data[0].Equals("#ARTIST"))
                {
                    bms.setArtist(data[1]);
                }
                else if (data[0].Equals("#BPM"))
                {
                    bms.setBpm(double.Parse(data[1]));
                }
                else if (data[0].Equals("#PLAYER"))
                {
                }
                else if (data[0].Equals("#GENRE"))
                {
                }
                else if (data[0].Equals("#PLAYLEVEL"))
                {
                }
                else if (data[0].Equals("#RANK"))
                {
                }
                else if (data[0].Equals("#TOTAL"))
                {
                }
                else if (data[0].Equals("#VOLWAV"))
                {
                }
                else if (data[0].Equals("#MIDIFILE"))
                {
                }
                else if (data[0].Equals("#WAV02"))
                {
                }//
                else if (data[0].Equals("#BMP01"))
                {
                }//
                else if (data[0].Equals("#STAGEFILE"))
                {
                }
                else if (data[0].Equals("#VIDEOFILE"))
                {
                }
                else if (data[0].Equals("#BGA"))
                {
                }
                else if (data[0].Equals("#STOP"))
                {
                }
                else if (data[0].Equals("#LNTYPE"))
                {
                    bms.setLnType(int.Parse(data[1]));
                }
                else if (data[0].Equals("#LNOBJ"))
                {
                }
                else
                {
                    // data field
                    int bar = 0; // node key
                    Int32.TryParse(data[0].Substring(1, 3), out bar);

                    int channel = 0; // node channel
                    Int32.TryParse(data[0].Substring(4, 2), out channel);

                    string noteStr = data[0].Substring(7);
                    List<int> noteData = getNoteDataOfStr(noteStr);

                    Note note = gameObject.AddComponent<Note>();
                    note.setBar(bar);
                    note.setChannel(channel);
                    note.setNoteData(noteData);
                    //note.debug();

                    bms.addNote(note);
                    isFinishLoad = true;
                }
            }
        }
        if (isFinishLoad)
        {
            GameObject test = GameObject.CreatePrimitive(PrimitiveType.Cube);
            test.transform.localScale += new Vector3(4, 1, 0);
            test.GetComponent<Renderer>().material.color = Color.red;
            test.transform.position = new Vector3(0,-15,5);
            foreach (Note note in bms.getNoteList())
            {

                switch (note.channel)
                {

                    case 11:
                        int cnt = 0;
                        switch (note.noteData.Count)
                        {
                            case 1:
                                GameObject r_1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                r_1.transform.localScale += new Vector3(4, 1, 0);
                               r_1.GetComponent<Renderer>().material.color = Color.red;
                                //  r_1.tag = "red";
                                r_1.transform.position = new Vector3(-10, -15, 30 + note.bar * W);
                                objectList.Add(r_1);
                                break;
                            case 2:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject r_2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        r_2.transform.localScale += new Vector3(4, 1, 0);
                                       r_2.GetComponent<Renderer>().material.color = Color.red;
                                        //  r_2.tag = "red";
                                        r_2.transform.position = new Vector3(-10, -15, 30 + (note.bar * W) + (W / 8 * cnt));
                                        objectList.Add(r_2);
                                    }
                                    cnt += 4;
                                }
                                break;
                            case 4:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject r_4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        r_4.transform.localScale += new Vector3(4, 1, 0);
                                       r_4.GetComponent<Renderer>().material.color = Color.red;
                                        // r_4.tag = "red";
                                        r_4.transform.position = new Vector3(-10, -15, 30 + (note.bar * W) + (W / 8 * cnt));
                                        objectList.Add(r_4);
                                    }
                                    cnt += 2;
                                }
                                break;
                            case 8:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject r_8 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        r_8.transform.localScale += new Vector3(4, 1, 0);
                                       r_8.GetComponent<Renderer>().material.color = Color.red;
                                        // r_8.tag = "red";
                                        r_8.transform.position = new Vector3(-10, -15, 30 + (note.bar * W) + (W / 8 * cnt));
                                        objectList.Add(r_8);
                                    }
                                    cnt += 1;
                                }
                                break;
                        }
                        break;

                    case 12:
                        int cnt2 = 0;
                        switch (note.noteData.Count)
                        {
                            case 1:
                                GameObject g_1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                g_1.transform.localScale += new Vector3(4, 1, 0);
                                g_1.GetComponent<Renderer>().material.color = Color.green;
                                // g_1.tag = "green";
                                g_1.transform.position = new Vector3(-5, -15, 30 + note.bar * W);
                                objectList.Add(g_1);
                                break;
                            case 2:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject g_2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        g_2.transform.localScale += new Vector3(4, 1, 0);
                                        g_2.GetComponent<Renderer>().material.color = Color.green;
                                        // g_2.tag = "green";
                                        g_2.transform.position = new Vector3(-5, -15, 30 + (note.bar * W) + (W / 8 * cnt2));
                                        objectList.Add(g_2);
                                    }
                                    cnt2 += 4;
                                }
                                break;
                            case 4:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject g_4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        g_4.transform.localScale += new Vector3(4, 1, 0);
                                        g_4.GetComponent<Renderer>().material.color = Color.green;
                                        // g_4.tag = "green";
                                        g_4.transform.position = new Vector3(-5, -15, 30 + (note.bar * W) + (W / 8 * cnt2));
                                        objectList.Add(g_4);
                                    }
                                    cnt2 += 2;
                                }
                                break;
                            case 8:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject g_8 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        g_8.transform.localScale += new Vector3(4, 1, 0);
                                        g_8.GetComponent<Renderer>().material.color = Color.green;
                                        //g_8.tag = "green";
                                        g_8.transform.position = new Vector3(-5, -15, 30 + (note.bar * W) + (W / 8 * cnt2));
                                        objectList.Add(g_8);
                                    }
                                    cnt2 += 1;
                                }
                                break;
                        }
                        break;
                    case 13:
                        int cnt3 = 0;
                        switch (note.noteData.Count)
                        {
                            case 1:
                                GameObject g_1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                g_1.transform.localScale += new Vector3(4, 1, 0);
                                g_1.GetComponent<Renderer>().material.color = Color.blue;
                                //  g_1.tag = "blue";
                                g_1.transform.position = new Vector3(0, -15, 30 + note.bar * W);
                                objectList.Add(g_1);
                                break;
                            case 2:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject g_2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        g_2.transform.localScale += new Vector3(4, 1, 0);
                                        g_2.GetComponent<Renderer>().material.color = Color.blue;
                                        //   g_2.tag = "blue";
                                        g_2.transform.position = new Vector3(0, -15, 30 + (note.bar * W) + (W / 8 * cnt3));
                                        objectList.Add(g_2);
                                    }
                                    cnt3 += 4;
                                }
                                break;
                            case 4:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject g_4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        g_4.transform.localScale += new Vector3(4, 1, 0);
                                        g_4.GetComponent<Renderer>().material.color = Color.blue;
                                        //  g_4.tag = "blue";
                                        g_4.transform.position = new Vector3(0, -15, 30 + (note.bar * W) + (W / 8 * cnt3));
                                        objectList.Add(g_4);
                                    }
                                    cnt3 += 2;
                                }
                                break;
                            case 8:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject g_8 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        g_8.transform.localScale += new Vector3(4, 1, 0);
                                        g_8.GetComponent<Renderer>().material.color = Color.blue;
                                        // g_8.tag = "blue";
                                        g_8.transform.position = new Vector3(0, -15, 30 + (note.bar * W) + (W / 8 * cnt3));
                                        objectList.Add(g_8);
                                    }
                                    cnt3 += 1;
                                }
                                break;
                        }
                        break;
                    case 14:
                        int cnt4 = 0;
                        switch (note.noteData.Count)
                        {
                            case 1:
                                GameObject g_1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                g_1.transform.localScale += new Vector3(4, 1, 0);
                                g_1.GetComponent<Renderer>().material.color = Color.black;
                                //g_1.tag = "black";
                                g_1.transform.position = new Vector3(5, -15, 30 + note.bar * W);
                                objectList.Add(g_1);
                                break;
                            case 2:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject g_2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        g_2.transform.localScale += new Vector3(4, 1, 0);
                                        g_2.GetComponent<Renderer>().material.color = Color.black;
                                        //  g_2.tag = "black";
                                        g_2.transform.position = new Vector3(5, -15, 30 + (note.bar * W) + (W / 8 * cnt4));
                                        objectList.Add(g_2);
                                    }
                                    cnt4 += 4;
                                }
                                break;
                            case 4:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject g_4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        g_4.transform.localScale += new Vector3(4, 1, 0);
                                        g_4.GetComponent<Renderer>().material.color = Color.black;
                                        //g_4.tag = "black";
                                        g_4.transform.position = new Vector3(5, -15, 30 + (note.bar * W) + (W / 8 * cnt4));
                                        objectList.Add(g_4);
                                    }
                                    cnt4 += 2;
                                }
                                break;
                            case 8:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject g_8 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        g_8.transform.localScale += new Vector3(4, 1, 0);
                                        g_8.GetComponent<Renderer>().material.color = Color.black;
                                        // g_8.tag = "black";
                                        g_8.transform.position = new Vector3(5, -15, 30 + (note.bar * W) + (W / 8 * cnt4));
                                        objectList.Add(g_8);
                                    }
                                    cnt4 += 1;
                                }
                                break;
                        }
                        break;
                    case 15:
                        int cnt5 = 0;
                        switch (note.noteData.Count)
                        {
                            case 1:
                                GameObject g_1 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                g_1.transform.localScale += new Vector3(4, 1, 0);
                                g_1.GetComponent<Renderer>().material.color = Color.yellow;
                                // g_1.tag = "yellow";
                                g_1.transform.position = new Vector3(10, -15, 30 + note.bar * W);
                                objectList.Add(g_1);
                                break;
                            case 2:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject g_2 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        g_2.transform.localScale += new Vector3(4, 1, 0);
                                        g_2.GetComponent<Renderer>().material.color = Color.yellow;
                                        // g_2.tag = "yellow";
                                        g_2.transform.position = new Vector3(10, -15, 30 + (note.bar * W) + (W / 8 * cnt5));
                                        objectList.Add(g_2);
                                    }
                                    cnt5 += 4;
                                }
                                break;
                            case 4:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject g_4 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        g_4.transform.localScale += new Vector3(4, 1, 0);
                                        g_4.GetComponent<Renderer>().material.color = Color.yellow;
                                        //    g_4.tag = "yellow";
                                        g_4.transform.position = new Vector3(10, -15, 30 + (note.bar * W) + (W / 8 * cnt5));
                                        objectList.Add(g_4);
                                    }
                                    cnt5 += 2;
                                }
                                break;
                            case 8:
                                foreach (int i in note.noteData)
                                {
                                    if (i == 1)
                                    {
                                        GameObject g_8 = GameObject.CreatePrimitive(PrimitiveType.Cube);
                                        g_8.transform.localScale += new Vector3(4, 1, 0);
                                        g_8.GetComponent<Renderer>().material.color = Color.yellow;
                                        //  g_8.tag = "yellow";
                                        g_8.transform.position = new Vector3(10, -15, 30 + (note.bar * W) + (W / 8 * cnt5));
                                        objectList.Add(g_8);
                                    }
                                    cnt5 += 1;
                                }
                                break;
                        }
                        break;
                }

            }
        }
    }
    private List<int> getNoteDataOfStr(string str)
    {
        string tempStr = str;
        List<int> noteList = new List<int>();

        while (true)
        {
            if (tempStr.Length > 2)
            {
                int data = 0;
                Int32.TryParse(tempStr.Substring(0, 2), out data);

                noteList.Add(data);
                tempStr = tempStr.Substring(2);
            }
            else
            {
                int data = 0;
                Int32.TryParse(tempStr, out data);
                noteList.Add(data);
                break;
            }

        }

        // 총노트수 증가
        foreach (int note in noteList)
        {
            if (note != 0)
            {
                bms.sumTotalNoteCount();
            }
        }

        return noteList;
    }

    void Update()
    {
        Double bpm = bms.getBpm();
        //  Debug.Log(HP_Manager.isGameEnd.ToString());
        foreach (GameObject o in objectList)
        {
            if (o != null) o.transform.position += new Vector3(0f, 0f, 20 * Time.deltaTime * (float)(-0.5) * (float)bpm / 60);
          /*  if (HP_Manager.isGameEnd)
            {
                Debug.Log("Hp 0 game end");
                Destroy(this);
            }*/
        }
    }
}
