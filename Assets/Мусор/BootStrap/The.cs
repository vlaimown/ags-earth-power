using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The : MonoBehaviour
{
    // Start is called before the first frame update

    public static The Instance {  get; private set; }

    [SerializeField] private GameObject characterPrefab1;
    [SerializeField] private GameObject characterPrefab2;
    [SerializeField] private GameObject characterPrefab3;

    //public GameObject;

    private void Start()
    {
        Instance ??= this;

        if (Instance == null) 
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
