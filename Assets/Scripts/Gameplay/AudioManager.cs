using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager Instance { get; private set; }

    public AudioSource ads;

    private void Awake()
    {
        Instance = this;
    }

}
