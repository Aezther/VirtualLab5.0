using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    public GameObject Bat,Eagle,Camel,Cheetah,Deer,ShadowBat,ShadowEagle,ShadowCamel,ShadowCheetah,ShadowDeer;
    public GameObject youWin;

    Vector2 BatInitialPos,EagleInitialPos,CamelInitialPos,CheetahInitialPos,DeerInitialPos;

    public AudioSource source;
    public AudioClip[] correct;
    public AudioClip incorrect;

    bool BatCorrect,EagleCorrect,CamelCorrect,CheetahCorrect,DeerCorrect;

    void Start()
    {
        BatInitialPos=Bat.transform.position;
        EagleInitialPos=Eagle.transform.position;
        CamelInitialPos=Camel.transform.position;
        CheetahInitialPos=Cheetah.transform.position;
        DeerInitialPos=Deer.transform.position;
    }
    public void DragCamel()
    {
        Camel.transform.position = Input.mousePosition;
    }

    public void DragBat()
    {
        Bat.transform.position = Input.mousePosition;
    }

    public void DragEagle()
    {
        Eagle.transform.position = Input.mousePosition;
    }

    public void DragCheetah()
    {
        Cheetah.transform.position = Input.mousePosition;
    }

    public void DragDeer()
    {
        Deer.transform.position = Input.mousePosition;
    }


    public void DropCamel()
    {
        float Distance=Vector3.Distance(Camel.transform.position,ShadowCamel.transform.position);
        if(Distance<50)
        {
            Camel.transform.position=ShadowCamel.transform.position;
            source.clip=correct[Random.Range(0,correct.Length)];
            source.Play();
            CamelCorrect = true;
        }
        else
        {
            Camel.transform.position=CamelInitialPos;
            source.clip=incorrect;
            source.Play();
        }
    }

        public void DropBat()
    {
        float Distance=Vector3.Distance(Bat.transform.position,ShadowBat.transform.position);
        if(Distance<50)
        {
            Bat.transform.position=ShadowBat.transform.position;
            source.clip=correct[Random.Range(0,correct.Length)];
            source.Play();
            BatCorrect = true;
        }
        else
        {
            Bat.transform.position=BatInitialPos;
            source.clip=incorrect;
            source.Play();
        }
    }

        public void DropEagle()
    {
        float Distance=Vector3.Distance(Eagle.transform.position,ShadowEagle.transform.position);
        if(Distance<50)
        {
            Eagle.transform.position=ShadowEagle.transform.position;
            source.clip=correct[Random.Range(0,correct.Length)];
            source.Play();
            EagleCorrect = true;
        }
        else
        {
            Eagle.transform.position=EagleInitialPos;
            source.clip=incorrect;
            source.Play();
        }
    }

        public void DropCheetah()
    {
        float Distance=Vector3.Distance(Cheetah.transform.position,ShadowCheetah.transform.position);
        if(Distance<50)
        {
            Cheetah.transform.position=ShadowCheetah.transform.position;
            source.clip=correct[Random.Range(0,correct.Length)];
            source.Play();
            CheetahCorrect = true;
        }
        else
        {
            Cheetah.transform.position=CheetahInitialPos;
            source.clip=incorrect;
            source.Play();
        }
    }
    
        public void DropDeer()
    {
        float Distance=Vector3.Distance(Deer.transform.position,ShadowDeer.transform.position);
        if(Distance<50)
        {
            Deer.transform.position=ShadowDeer.transform.position;
            source.clip=correct[Random.Range(0,correct.Length)];
            source.Play();
            DeerCorrect = true;
        }
        else
        {
            Deer.transform.position=DeerInitialPos;
            source.clip=incorrect;
            source.Play();
        }
    }

    void Update()
    {
        if(BatCorrect && EagleCorrect && CamelCorrect && CheetahCorrect && DeerCorrect)
        {
            youWin.SetActive(true);
        }
    }

}

