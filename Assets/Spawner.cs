using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class Spawner : MonoBehaviour
{
    public GameObject[]  objects;
    public GameObject[]  clouds;
    public GameObject    yinyang;
    public List<Element> instances;
    public Camera        camera;
    public TMP_Text      scoreText;
    public Vector3       objectSpawnPoint;
    public Vector3       cloudSpawnPoint;
    public Vector3       yinYangSpawnPoint;
    public Player        player;

    public static bool dark = false;

    private float nextObjSpawn;
    private float nextCloudSpawn;
    private float nextYinYangSpawn;
    private bool  lastShort;


    private void Start()
    {
        if (dark) {
            dark = false;
            this.Switch();
        }
        this.nextCloudSpawn         = Time.time;
        this.nextObjSpawn           = this.nextCloudSpawn + 3;
        this.nextYinYangSpawn       = this.nextCloudSpawn + 2;
        PlayerPrefs.SetInt("currentScore", 0);
    }


    private void SpawnObj()
    {
        var element = this.objects[Random.Range(0, this.objects.Length)];
        element = Instantiate(element, this.objectSpawnPoint, Quaternion.identity);
        var e = element.GetComponent<Element>();
        e.player  = this.player;
        e.spawner = this;
        if (dark) e.Switch();
        this.instances.Add(e);
        if (!this.lastShort && Random.value < 0.2f) {
            this.nextObjSpawn += 0.5f;
            this.lastShort    =  true;
        }
        else {
            this.nextObjSpawn += Random.Range(2.5f, 6f);
            this.lastShort    =  false;
        }
    }


    private void SpawnCloud()
    {
        var element = this.clouds[Random.Range(0, this.clouds.Length)];
        element = Instantiate(element, this.cloudSpawnPoint, Quaternion.identity);
        element.transform.Translate(0, Random.Range(2f, -2f), 0);
        var e = element.GetComponent<Element>();
        e.player  = this.player;
        e.spawner = this;
        if (dark) e.Switch();
        this.instances.Add(e);
        this.nextCloudSpawn += Random.Range(1.5f, 4f);
    }


    private void SpawnYinYang()
    {
        var element = Instantiate(this.yinyang, this.yinYangSpawnPoint, Quaternion.identity);
        var e       = element.GetComponent<Element>();
        e.player  = this.player;
        e.spawner = this;
        if (dark) e.Switch();
        this.instances.Add(e);
        this.nextYinYangSpawn += 5;
    }


    public void Switch()
    {
        this.camera.backgroundColor = dark ? Color.black : Color.white;
        dark                        = !dark;
        this.scoreText.color        = dark ? Color.black : Color.white;
        this.instances              = this.instances.Where(x => x != null).ToList();
        foreach (var instance in this.instances) {
            instance.Switch();
        }
    }


    public void Point()
    {
        PlayerPrefs.SetInt("currentScore", PlayerPrefs.GetInt("currentScore") + 1);
        if (PlayerPrefs.GetInt("currentScore") > PlayerPrefs.GetInt("bestScore"))
            PlayerPrefs.SetInt("bestScore", PlayerPrefs.GetInt("currentScore"));
        this.scoreText.text = PlayerPrefs.GetInt("currentScore").ToString();
    }


    private void Update()
    {
        if (Time.time > this.nextObjSpawn) SpawnObj();
        if (Time.time > this.nextCloudSpawn) SpawnCloud();
        if (Time.time > this.nextYinYangSpawn) SpawnYinYang();
    }
}
