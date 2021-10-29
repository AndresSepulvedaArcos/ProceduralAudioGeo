using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalizer : MonoBehaviour
{
    private AudioSource audioSource;
    public float[] samples=new float[512];
    public float[] frequencyBand=new float[8];

    public GameObject audioCubePrefab;
    List<GameObject> audioCubes=new List<GameObject>();
    Vector3 cubeScale=Vector3.one;
    private void Awake()
    {
        audioSource=GetComponent<AudioSource>();

    }

   
    // Start is called before the first frame update
    void Start()
    {
       GenerateAudioCubes();
    }
    void GenerateAudioCubes()
    {
        for (int i = 0; i < frequencyBand.Length; i++)
        {
            audioCubes.Add(Instantiate(audioCubePrefab,transform.position+Vector3.right*i,Quaternion.identity));

        }
    }
    void GetAudioSamples()
    {
        audioSource.GetSpectrumData(samples,0,FFTWindow.Blackman);

    }

    void MakeFrequencyBands()
    {
        float average=0;
        int count=0;
        for (int i = 0; i < 8; i++)
        {
            int samepleCount= (int) Mathf.Pow(2,i)*2;

            if(i==7)
            {
                samepleCount+=2;
            }

            for (int j = 0; j < samepleCount; j++)
            {
                average+=samples[count]*(count+1);
                count++;
            }
            average/=count;
            frequencyBand[i]=average;

        }
    }
    // Update is called once per frame
    void Update()
    {
        GetAudioSamples();
        MakeFrequencyBands();

        DisplayAudioCubes();

    }

    void DisplayAudioCubes()
    {
        for (int i = 0; i < audioCubes.Count; i++)
        {
            cubeScale.y=frequencyBand[i];
            audioCubes[i].transform.localScale= cubeScale;
        }
    }
}
