using UnityEngine;

public class MinimapCamera : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    public Vector3 offset = new Vector3(0, 9, 0);
    public GameObject minimap;
    public KeyCode mapKey = KeyCode.M;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);
        if (Input.GetKeyDown(mapKey))
        {
           minimap.SetActive(true);
        }

        // Disable when M is released
        if (Input.GetKeyUp(mapKey))
        {
            minimap.SetActive(false);
        }
    }

    }

