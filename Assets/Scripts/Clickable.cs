using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class Clickable : MonoBehaviour
{
    [SerializeField] GameObject hoverEffectPrefab;
    [SerializeField] string block;
    GameObject hoverEffect;

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
            if(hoverEffect)
                Destroy(hoverEffect);
        }

        if(hoverEffect && Input.GetMouseButtonDown(0) && block != "")
        {
            Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
            SceneController.instance.StartFocus();
            flowchart.ExecuteBlock(block);

            if (hoverEffect)
                Destroy(hoverEffect);

            this.enabled = false;
        }

    }
}