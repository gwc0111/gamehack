using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Clickable : MonoBehaviour
{
    [SerializeField] GameObject hoverEffectPrefab;
    [SerializeField] bool focusToBlock = true;
    [SerializeField] string block;
    [SerializeField] bool enable = true;
    [SerializeField] UnityEvent OnClicked;
    GameObject hoverEffect;

    private void Start()
    {
        OnClicked = new UnityEvent();
    }

    public void SetEnable(bool enable_)
    {
        enable = enable_;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enable)
            return;

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

        if(hoverEffect && Input.GetMouseButtonDown(0))
        {
            if (block != "")
            {
                Flowchart flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
                if (focusToBlock)
                    SceneController.instance.StartFocus();
                flowchart.ExecuteBlock(block);
            }

            if (hoverEffect)
                Destroy(hoverEffect);

            this.enabled = false;

            OnClicked.Invoke();
        }

    }
}