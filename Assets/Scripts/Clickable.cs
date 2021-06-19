using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField] GameObject hoverEffectPrefab;
    GameObject hoverEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hoverEffect == null)
            {
                if (hit.collider.gameObject != gameObject)
                    return;

                hoverEffect = Instantiate(hoverEffectPrefab, gameObject.transform);

                Debug.Log("init effect");
            }
        }
        else
        {
            Destroy(hoverEffect);
        }
    }
}