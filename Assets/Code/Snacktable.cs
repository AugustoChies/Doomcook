using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snacktable : MonoBehaviour
{
    public List<GameObject> snackmodels;
    private int snackmodelCurrent = 0;
    private int placedSnacks;
    public int availableSnacks;
    public float snackeatingtime;
    // Start is called before the first frame update
    private void Awake()
    {
        Transform snackmaster = transform.Find("Snacks");
        snackmodels = new List<GameObject>();
        foreach (Transform child in snackmaster)
        {
            snackmodels.Add(child.gameObject);
        }
        placedSnacks = snackmodels.Count;
        availableSnacks = placedSnacks;
    }
    

    public void Eat()
    {
        placedSnacks--;
        snackmodels[snackmodelCurrent].SetActive(false);
        snackmodelCurrent++;
        if(placedSnacks <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
