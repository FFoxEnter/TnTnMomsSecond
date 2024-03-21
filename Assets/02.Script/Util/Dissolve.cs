using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dissolve : MonoBehaviour
{
    //[SerializeField] RawImage _ri;
    float changeSpeed = 2f;
    //[SerializeField] BellyZone bellyZone;

    public GameObject[] gameObjects;
    public Image[] images;
    public GameObject imgObj01;
    public GameObject imgObj02;
    public GameObject imgObj03;
    public Image img01;
    public Image img02;
    public Image img03;


    // Start is called before the first frame update
    void Start()
    {
        //bellyZone = FindObjectOfType<BellyZone>();
        //_ri = GetComponent<RawImage>();
        //_ri.texture = bellyZone.ScreenTexture;

        //if (_ri.texture == null)
        //    gameObject.SetActive(false);

        //_ri.color = Color.white;

        StartCoroutine(ImageDissolveCo());
    }

    IEnumerator ImageDissolveCo()
    {
        int i = 0;
        
        while (true)
        {
            if (gameObjects[i].activeSelf == false)
                gameObjects[i].SetActive(true);
            if (images[i].color != new Color(1,1,1,0))
            {
                images[i].color = Color.Lerp(Color.white, new Color(1, 1, 1, 0), 100f * Time.deltaTime);
                yield return null;
            }
            gameObjects[i].SetActive(false);
            i++;
            images[i - 1].color = Color.white;
            if (i == gameObjects.Length)
                i = 0;
            
        }

        

    }

    // Update is called once per frame
    void Update()
    {
        //_ri.color = Color.Lerp(_ri.color, new Color(1,1,1,0), changeSpeed * Time.deltaTime);
        //if (_ri.color.a <= 0.01f)
        //    gameObject.SetActive(false);
    }
}
