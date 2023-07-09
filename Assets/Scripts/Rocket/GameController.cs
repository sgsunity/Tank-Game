using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GunService gunService;
    public AudioClip shotSound;
    private AudioSource tankAudio;

    private bool isRight = true;

     void Start()
    {
        tankAudio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isRight)
            {
                AirDefenseGun rGun = gunService.LoadGun<AirDefenseGun>();
                tankAudio.PlayOneShot(shotSound, 1.0f);
            } 
        }
    }

   
}
