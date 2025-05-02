using UnityEngine;
using UnityEngine.UI;

public class InteractScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Text txt;

    void Start()
    {
        txt.text = "Press E to Interact";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
