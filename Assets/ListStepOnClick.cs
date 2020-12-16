using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ListStepOnClick : MonoBehaviour
{
    [Header("Paneles o imagenes en secuencia")]
    public List<GameObject> goList;

    public int currIdx;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (currIdx > 0)
                goList[currIdx - 1].SetActive(false);

            currIdx++;

            if (currIdx >= goList.Count)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                goList[currIdx].SetActive(true);

            }
        }
    }
}
