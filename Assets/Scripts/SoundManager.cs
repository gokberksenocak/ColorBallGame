using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] sources;
    [SerializeField] private AudioClip[] clips;

    public void Completed()
    {
        sources[0].PlayOneShot(clips[0]);
    }
    public void GameOver()
    {
        sources[1].PlayOneShot(clips[1]);
    }
    public void EffSel()
    {
        sources[2].PlayOneShot(clips[2]);
    }
    public void Imp1()
    {
        sources[3].PlayOneShot(clips[4]);
    }
    public void Imp2()
    {
        sources[4].PlayOneShot(clips[5]);
    }
}