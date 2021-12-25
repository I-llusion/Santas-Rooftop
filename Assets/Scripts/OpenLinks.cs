using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLinks : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void YouTubeChannel()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCv4T2VUBOVuqDXfQ_gkQ1JA");
    }

    public void Discord()
    {
        Application.OpenURL(" https://discord.gg/3VvAvfzAHd");
    }

    public void Instagram()
    {
        Application.OpenURL("https://www.instagram.com/_illusionstudios_/");
    }
}
