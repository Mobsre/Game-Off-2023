using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]

public class MenuSource {
    // Start is called before the first frame update

    public string name2;

    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pich;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
