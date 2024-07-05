using UnityEngine;

public class ButtonMoveSound : MonoBehaviour

{
    public AudioSource soundPlay;

    public void PlayThisSoundEffect()
    {
        soundPlay.Play();
    }

}