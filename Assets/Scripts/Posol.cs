using UnityEngine;
public class Posol : MonoBehaviour
{
    Renderer m_Renderer;
    public bool used;
    // Use this for initialization
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!m_Renderer.isVisible && used)
        {
            used = false;
            this.gameObject.SetActive(false);
            //this.gameObject.SetActive(false);
            //print("InVisible");
        }
        //else print("Visible");
    }
}