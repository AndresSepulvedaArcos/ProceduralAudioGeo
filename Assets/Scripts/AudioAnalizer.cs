using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioAnalizer : MonoBehaviour
{
    private AudioSource audioSource;
    public float[] samples=new float[512];
    public float[] frequencyBand=new float[8];
    public float[] bandBuffer=new float[8];
    private float[] bufferDrecrease=new float[8];


    public GameObject audioCubePrefab;
    List<GameObject> audioCubes=new List<GameObject>();
    List<GameObject> audioCubeBuffer = new List<GameObject>();

    Vector3 cubeScale =Vector3.one;
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
        for (int i = 0; i < bandBuffer.Length; i++)
        {
            audioCubeBuffer.Add(Instantiate(audioCubePrefab, transform.position+Vector3.forward*-4 + Vector3.right * i, Quaternion.identity));

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
        BandBuffer();


        DisplayAudioCubes();
        DisplayBandBuffer();

    }

    void DisplayAudioCubes()
    {
        for (int i = 0; i < audioCubes.Count; i++)
        {
            cubeScale.y=frequencyBand[i];
            audioCubes[i].transform.localScale= cubeScale;
        }
    }

    void DisplayBandBuffer()
    {
        for (int i = 0; i < audioCubeBuffer.Count; i++)
        {
            cubeScale.y = bandBuffer[i];
            audioCubeBuffer[i].transform.localScale = cubeScale;
        }
    }

    void BandBuffer()
    {
        for (int g = 0; g < frequencyBand.Length; g++)
        {
            if(frequencyBand[g]>bandBuffer[g])
            {
                bandBuffer[g]=frequencyBand[g];
                bufferDrecrease[g]=0.005f;

            }

            if (frequencyBand[g] < bandBuffer[g])
            {
                bandBuffer[g] -= bufferDrecrease[g];
                bufferDrecrease[g] *=1.2f;

            }
        }
        

    }
}
