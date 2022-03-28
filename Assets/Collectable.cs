using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CollectableType {
    Cabbage = 0,
    Carrot = 1,
    Tomato = 2
}

public class Collectable : MonoBehaviour
{
    public CollectableType collType;

    public int amount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickUp() {
        Destroy(gameObject);
    }
}


