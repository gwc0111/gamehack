using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class PitureManager : MonoBehaviour
{
    [SerializeField] GameObject picture;
    [SerializeField] GameObject key;
    [SerializeField] bool enable;
    [SerializeField] UnityEvent OnKeyTaked;

    bool pictureHasTake = false;
    bool keyHasTake = false;

    // Start is called before the first frame update
    void Start()
    {
        //OnKeyTaked = new UnityEvent();
    }

    public void SetEnable(bool b)
    {
        enable = b;
    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.gameObject == picture && !pictureHasTake)
                {
                    picture.transform.DOMoveX(-1, 1);
                    picture.GetComponent<SpriteRenderer>().DOFade(0, 1);
                    pictureHasTake = true;

                    StartCoroutine(DelayDisablePicture());
                }
                else if(hit.collider.gameObject == key && !keyHasTake)
                {
                    key.transform.DOScale(2, 1);
                    key.GetComponent<SpriteRenderer>().DOFade(0, 1);
                    keyHasTake = true;

                    StartCoroutine(TakeKey());
                }

            }
        }
    }

    IEnumerator DelayDisablePicture()
    {
        yield return new WaitForSeconds(1);

        picture.SetActive(false);
    }

    IEnumerator TakeKey()
    {
        yield return new WaitForSeconds(1);
        OnKeyTaked.Invoke();
    }
}
