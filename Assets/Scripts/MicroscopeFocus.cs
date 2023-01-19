using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MicroscopeFocus : MonoBehaviour
{

    [SerializeField] public Slider coarseSlider;
    [SerializeField] public Slider fineSlider;
    [SerializeField] public Slider diaphragmSlider;
    [SerializeField] public Material coarseBlur;
    [SerializeField] public Material fineBlur;
    [SerializeField] public RawImage Dia;
    [SerializeField] public RawImage tenX;
    [SerializeField] public RawImage fortyX;
    [SerializeField] public RawImage hunX;


    // Start is called before the first frame update
    void Start()
    {
        int coarseRng = Random.Range(0,20);
        int fineRng = Random.Range(0,10);
        coarseBlur.SetFloat("_Size",coarseRng);
        fineBlur.SetFloat("_Size",fineRng);
        Color alph = Dia.color;

        if(coarseRng <= 10)
        {
            coarseSlider.direction = Slider.Direction.LeftToRight;
        }else
        {
            coarseSlider.direction = Slider.Direction.RightToLeft;
        }

        if(fineRng >= 5)
        {
            fineSlider.direction = Slider.Direction.RightToLeft;
        }else 
        {
            fineSlider.direction = Slider.Direction.LeftToRight;
        }

        coarseSlider.onValueChanged.AddListener((v) => {
           coarseBlur.SetFloat("_Size",v);
        });

        fineSlider.onValueChanged.AddListener((v) => {
           fineBlur.SetFloat("_Size",v);
        });

        diaphragmSlider.onValueChanged.AddListener((v) => {
            // Dia.canvasRenderer.SetAlpha(v);
            alph.a = v;
            Dia.color = alph;
            Debug.Log(alph);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void tenMag()
    {

        int coarseRng = Random.Range(0,20);
        int fineRng = Random.Range(0,10);
        coarseBlur.SetFloat("_Size",coarseRng);
        fineBlur.SetFloat("_Size",fineRng);

        if(fineRng >= 5)
        {
            fineSlider.direction = Slider.Direction.RightToLeft;
        }else 
        {
            fineSlider.direction = Slider.Direction.LeftToRight;
        }
        tenX.gameObject.SetActive(true);
        fortyX.gameObject.SetActive(false);
        hunX.gameObject.SetActive(false);

    }

    public void fortyMag()
    {   
        int fineRng = Random.Range(6,10);
        fineBlur.SetFloat("_Size",fineRng);
        fineSlider.value = 5;

        if(fineRng >= 8)
        {
            fineSlider.direction = Slider.Direction.RightToLeft;
        }else 
        {
            fineSlider.direction = Slider.Direction.LeftToRight;
        }

        tenX.gameObject.SetActive(false);
        fortyX.gameObject.SetActive(true);
        hunX.gameObject.SetActive(false);
    }

    public void hunMag()
    {
        int fineRng = Random.Range(4,10);
        fineBlur.SetFloat("_Size",fineRng);
        fineSlider.value = 5;

         if(fineRng >= 6)
        {
            fineSlider.direction = Slider.Direction.RightToLeft;
        }else 
        {
            fineSlider.direction = Slider.Direction.LeftToRight;
        }

        tenX.gameObject.SetActive(false);
        fortyX.gameObject.SetActive(false);
        hunX.gameObject.SetActive(true);    
    }
}
