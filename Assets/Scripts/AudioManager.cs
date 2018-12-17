using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    
    public AudioClip cutWood;
    public AudioClip cleanUp;
    public AudioClip Generation;
    public AudioClip Plant;
    public AudioClip receiveWater;
    public AudioClip giveWater;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject House;

	public void Update(){

        if (Player2.GetComponent<PlayerEvent>().SoundCutWood){
            
            this.GetComponent<AudioSource>().PlayOneShot(cutWood);
            Player2.GetComponent<PlayerEvent>().SoundCutWood = false;

        }
        if (Player2.GetComponent<PlayerEvent>().SoundPlant){
            
            this.GetComponent<AudioSource>().PlayOneShot(Plant);
            Player2.GetComponent<PlayerEvent>().SoundPlant = false;

        }
        if (Player2.GetComponent<PlayerEvent>().SoundGeneration){

            this.GetComponent<AudioSource>().PlayOneShot(Generation);
            Player2.GetComponent<PlayerEvent>().SoundGeneration = false;

        }
        if(Player1.GetComponent<PlayerEvent>().SoundCleanUp){
            
            this.GetComponent<AudioSource>().PlayOneShot(cleanUp);
            Player1.GetComponent<PlayerEvent>().SoundCleanUp = false;

        }
        if(Player1.GetComponent<PlayerEvent>().SoundGiveWater){

            this.GetComponent<AudioSource>().PlayOneShot(giveWater);
            Player1.GetComponent<PlayerEvent>().SoundGiveWater= false;

        }
        if(Player1.GetComponent<PlayerEvent>().SoundReceiveWater){

            this.GetComponent<AudioSource>().PlayOneShot(receiveWater);
            Player1.GetComponent<PlayerEvent>().SoundReceiveWater = false;

        }
	}
}
