using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Audio : MonoBehaviour {

    private AudioSource audioSource;
    public AudioMixerGroup mixerGroupMicrophone;
    public Transform[] audioSpectrumObjects;
    [Range(1, 350)] public float heightMultiplier = 350;
    private int speedMultiplier;
    [Range(64, 8192)] public int numberOfSamples = 64; //step by 2
    public FFTWindow fftWindow;
    public float lerpTime = 0.5f;

    private ParticleSystem ps;
    /*
	 * The intensity of the frequencies found between 0 and 44100 will be
	 * grouped into 1024 elements. So each element will contain a range of about 43.06 Hz.
	 * The average human voice spans from about 60 hz to 9k Hz
	 * we need a way to assign a range to each object that gets animated. that would be the best way to control and modify animatoins.
	*/

    void Start()
    {

        heightMultiplier = 350;
        speedMultiplier = 10;
        //ps = this.GetComponentInChildren<ParticleSystem>();

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(null, true, 1, 4400);
        audioSource.loop = true;
        audioSource.outputAudioMixerGroup = mixerGroupMicrophone;
        while (!(Microphone.GetPosition(null) > 0)) { }
        audioSource.Play();
        
    }

    void Update()
    {

        // initialize our float array
        float[] spectrum = new float[numberOfSamples];

        // populate array with fequency spectrum data
        //audioSource.GetSpectrumData(spectrum, 0, fftWindow);
        audioSource.GetSpectrumData(spectrum, 0, fftWindow);

        // loop over audioSpectrumObjects and modify according to fequency spectrum data
        // this loop matches the Array element to an object on a One-to-One basis.
        for (int i = 0; i < audioSpectrumObjects.Length; i++)
        {

            // apply height multiplier to intensity
            float intensity = spectrum[i] * heightMultiplier;

            // calculate object's scale
            //float lerpY = Mathf.Lerp(audioSpectrumObjects[i].localScale.y, intensity, lerpTime);
            //float lerpX = Mathf.Lerp(audioSpectrumObjects[i].localScale.x, intensity, lerpTime);
            Vector3 newScale = new Vector3(intensity, intensity, audioSpectrumObjects[i].localScale.z);


            // appply new scale to object
            audioSpectrumObjects[i].localScale = Vector3.Lerp(audioSpectrumObjects[i].localScale,newScale, lerpTime);//newScale;
            
            ps = audioSpectrumObjects[i].GetComponentInChildren<ParticleSystem>();
            var main = ps.main;
            main.startSpeed = Mathf.Clamp(intensity, 2, 25);
            main.startLifetime = Mathf.Clamp(intensity * 10, 0, 25);
            
            var emit = ps.emission;
            emit.rateOverTime = Mathf.Clamp(intensity, 2,100);

        }
    }

}
