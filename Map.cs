using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : LocationService
{
    //public Text text;
    private string map;
    private string url = "https://api.mapbox.com/styles/v1/vladbakharev/cj2dgkutw006h2rnq13kdh8m9/static/";
    public double lat;
    public double lon;
    public string scale = "15.00";
    public string angleRotation = "0.00";
    public string angleTilt = "60.00";
    public string size = "1024x768@2x";
    private string token = "access_token=pk.eyJ1IjoidmxhZGJha2hhcmV2IiwiYSI6ImNqMW1idXpoMDAwMWsycXBmbHdiNzE2ZXUifQ.8HLvB8rSuoLLOVVonj7xzg";
    //private string urll = "https://api.mapbox.com/styles/v1/vladbakharev/cj2dcov1800912rqnh8n6fq43/static/60.627601,56.834007,11.00,0.00,0.00/1024x768@2x?access_token=pk.eyJ1IjoidmxhZGJha2hhcmV2IiwiYSI6ImNqMW1idXpoMDAwMWsycXBmbHdiNzE2ZXUifQ.8HLvB8rSuoLLOVVonj7xzg";
    IEnumerator createMap()
    {
       
        map = url + Instace.longtitudeP + "," + Instace.lattitudeP + "," + scale + "," + angleRotation + "," + angleTilt + "/" + size + "?" + token;
        WWW www = new WWW(map);
        yield return www;
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = www.texture;
        
    }
    void Start()
    {
        
    }
    void Update()
    {
        //text.text = map;
        StartCoroutine(createMap());
    }
}