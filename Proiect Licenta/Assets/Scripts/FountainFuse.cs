using UnityEngine;

public class FountainFuse : MonoBehaviour
{

    public GameObject fuseA, fuseB, fuseC, fuseD;
    public ParticleSystem fountainparticles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fuseA.activeInHierarchy && fuseB.activeInHierarchy && fuseC.activeInHierarchy && fuseD.activeInHierarchy)
            fountainparticles.gameObject.SetActive(false);
    }
}
