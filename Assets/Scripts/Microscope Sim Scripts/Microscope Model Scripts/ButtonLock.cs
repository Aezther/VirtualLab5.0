using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLock : MonoBehaviour
{

    [SerializeField] GameObject eyePiece;
    [SerializeField] GameObject bodyTube;
    [SerializeField] GameObject armBtn;
    [SerializeField] GameObject baseBtn;
    [SerializeField] GameObject stageBtn;
    [SerializeField] GameObject stageClips;
    [SerializeField] GameObject mirrorBtn;
    [SerializeField] GameObject resolvingNP;
    [SerializeField] GameObject fadjKnob;
    [SerializeField] GameObject cadjKnob;
    [SerializeField] GameObject objectiveBtn;
    [SerializeField] GameObject incJoint;
    [SerializeField] GameObject diaBtn;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void unlockAll()
    {
        eyePiece.GetComponent<Button>().interactable = true;
        bodyTube.GetComponent<Button>().interactable = true;
        armBtn.GetComponent<Button>().interactable = true;
        baseBtn.GetComponent<Button>().interactable = true;
        stageClips.GetComponent<Button>().interactable = true;
        stageBtn.GetComponent<Button>().interactable = true;
        mirrorBtn.GetComponent<Button>().interactable = true;
        resolvingNP.GetComponent<Button>().interactable = true;
        fadjKnob.GetComponent<Button>().interactable = true;
        cadjKnob.GetComponent<Button>().interactable = true;
        objectiveBtn.GetComponent<Button>().interactable = true;
        incJoint.GetComponent<Button>().interactable = true;
        diaBtn.GetComponent<Button>().interactable = true;
    }

    public void eyePieceAct()
    {
        // eyePiece.GetComponent<Button>().interactable = false;
        bodyTube.GetComponent<Button>().interactable = false;
        armBtn.GetComponent<Button>().interactable = false;
        baseBtn.GetComponent<Button>().interactable = false;
        stageBtn.GetComponent<Button>().interactable = false;
        stageClips.GetComponent<Button>().interactable = false;
        mirrorBtn.GetComponent<Button>().interactable = false;
        resolvingNP.GetComponent<Button>().interactable = false;
        fadjKnob.GetComponent<Button>().interactable = false;
        cadjKnob.GetComponent<Button>().interactable = false;
        objectiveBtn.GetComponent<Button>().interactable = false;
        incJoint.GetComponent<Button>().interactable = false;
        diaBtn.GetComponent<Button>().interactable = false;
    }

    public void bodyTubeAct()
    {
        eyePiece.GetComponent<Button>().interactable = false;
        // bodyTube.GetComponent<Button>().interactable = false;
        armBtn.GetComponent<Button>().interactable = false;
        baseBtn.GetComponent<Button>().interactable = false;
        stageBtn.GetComponent<Button>().interactable = false;
        stageClips.GetComponent<Button>().interactable = false;
        mirrorBtn.GetComponent<Button>().interactable = false;
        resolvingNP.GetComponent<Button>().interactable = false;
        fadjKnob.GetComponent<Button>().interactable = false;
        cadjKnob.GetComponent<Button>().interactable = false;
        objectiveBtn.GetComponent<Button>().interactable = false;
        incJoint.GetComponent<Button>().interactable = false;
        diaBtn.GetComponent<Button>().interactable = false;
    }

    public void armBtnAct()
    {
        eyePiece.GetComponent<Button>().interactable = false;
        bodyTube.GetComponent<Button>().interactable = false;
        // armBtn.GetComponent<Button>().interactable = false;
        baseBtn.GetComponent<Button>().interactable = false;
        stageBtn.GetComponent<Button>().interactable = false;
        stageClips.GetComponent<Button>().interactable = false;
        mirrorBtn.GetComponent<Button>().interactable = false;
        resolvingNP.GetComponent<Button>().interactable = false;
        fadjKnob.GetComponent<Button>().interactable = false;
        cadjKnob.GetComponent<Button>().interactable = false;
        objectiveBtn.GetComponent<Button>().interactable = false;
        incJoint.GetComponent<Button>().interactable = false;
        diaBtn.GetComponent<Button>().interactable = false;
    }

    public void baseBtnAct()
    {  
        eyePiece.GetComponent<Button>().interactable = false;
        bodyTube.GetComponent<Button>().interactable = false;
        armBtn.GetComponent<Button>().interactable = false;
        // baseBtn.GetComponent<Button>().interactable = false;
        stageBtn.GetComponent<Button>().interactable = false;
        stageClips.GetComponent<Button>().interactable = false;
        mirrorBtn.GetComponent<Button>().interactable = false;
        resolvingNP.GetComponent<Button>().interactable = false;
        fadjKnob.GetComponent<Button>().interactable = false;
        cadjKnob.GetComponent<Button>().interactable = false;
        objectiveBtn.GetComponent<Button>().interactable = false;
        incJoint.GetComponent<Button>().interactable = false;
        diaBtn.GetComponent<Button>().interactable = false;
    }

    public void stageBtnAct()
    {
        eyePiece.GetComponent<Button>().interactable = false;
        bodyTube.GetComponent<Button>().interactable = false;
        armBtn.GetComponent<Button>().interactable = false;
        baseBtn.GetComponent<Button>().interactable = false;
        // stageBtn.GetComponent<Button>().interactable = false;
        stageClips.GetComponent<Button>().interactable = false;
        mirrorBtn.GetComponent<Button>().interactable = false;
        resolvingNP.GetComponent<Button>().interactable = false;
        fadjKnob.GetComponent<Button>().interactable = false;
        cadjKnob.GetComponent<Button>().interactable = false;
        objectiveBtn.GetComponent<Button>().interactable = false;
        incJoint.GetComponent<Button>().interactable = false;
        diaBtn.GetComponent<Button>().interactable = false;
    }

    public void stageClipsAct()
    {
        eyePiece.GetComponent<Button>().interactable = false;
        bodyTube.GetComponent<Button>().interactable = false;
        armBtn.GetComponent<Button>().interactable = false;
        baseBtn.GetComponent<Button>().interactable = false;
        stageBtn.GetComponent<Button>().interactable = false;
        // stageClips.GetComponent<Button>().interactable = false;
        mirrorBtn.GetComponent<Button>().interactable = false;
        resolvingNP.GetComponent<Button>().interactable = false;
        fadjKnob.GetComponent<Button>().interactable = false;
        cadjKnob.GetComponent<Button>().interactable = false;
        objectiveBtn.GetComponent<Button>().interactable = false;
        incJoint.GetComponent<Button>().interactable = false;
        diaBtn.GetComponent<Button>().interactable = false;
    }

    public void mirrorBtnAct()
    {
        eyePiece.GetComponent<Button>().interactable = false;
        bodyTube.GetComponent<Button>().interactable = false;
        armBtn.GetComponent<Button>().interactable = false;
        baseBtn.GetComponent<Button>().interactable = false;
        stageBtn.GetComponent<Button>().interactable = false;
        stageClips.GetComponent<Button>().interactable = false;
        // mirrorBtn.GetComponent<Button>().interactable = false;
        resolvingNP.GetComponent<Button>().interactable = false;
        fadjKnob.GetComponent<Button>().interactable = false;
        cadjKnob.GetComponent<Button>().interactable = false;
        objectiveBtn.GetComponent<Button>().interactable = false;
        incJoint.GetComponent<Button>().interactable = false;
        diaBtn.GetComponent<Button>().interactable = false;
    }

    public void resolvingNPAct()
    {
        eyePiece.GetComponent<Button>().interactable = false;
        bodyTube.GetComponent<Button>().interactable = false;
        armBtn.GetComponent<Button>().interactable = false;
        baseBtn.GetComponent<Button>().interactable = false;
        stageBtn.GetComponent<Button>().interactable = false;
        stageClips.GetComponent<Button>().interactable = false;
        mirrorBtn.GetComponent<Button>().interactable = false;
        // resolvingNP.GetComponent<Button>().interactable = false;
        fadjKnob.GetComponent<Button>().interactable = false;
        cadjKnob.GetComponent<Button>().interactable = false;
        objectiveBtn.GetComponent<Button>().interactable = false;
        incJoint.GetComponent<Button>().interactable = false;
        diaBtn.GetComponent<Button>().interactable = false;
    }

    public void fadjKnobAct()
    {
        eyePiece.GetComponent<Button>().interactable = false;
        bodyTube.GetComponent<Button>().interactable = false;
        armBtn.GetComponent<Button>().interactable = false;
        baseBtn.GetComponent<Button>().interactable = false;
        stageBtn.GetComponent<Button>().interactable = false;
        stageClips.GetComponent<Button>().interactable = false;
        mirrorBtn.GetComponent<Button>().interactable = false;
        resolvingNP.GetComponent<Button>().interactable = false;
        // fadjKnob.GetComponent<Button>().interactable = false;
        cadjKnob.GetComponent<Button>().interactable = false;
        objectiveBtn.GetComponent<Button>().interactable = false;
        incJoint.GetComponent<Button>().interactable = false;
        diaBtn.GetComponent<Button>().interactable = false;
    }

    public void cadjKnobAct()
    {
        eyePiece.GetComponent<Button>().interactable = false;
        bodyTube.GetComponent<Button>().interactable = false;
        armBtn.GetComponent<Button>().interactable = false;
        baseBtn.GetComponent<Button>().interactable = false;
        stageBtn.GetComponent<Button>().interactable = false;
        stageClips.GetComponent<Button>().interactable = false;
        mirrorBtn.GetComponent<Button>().interactable = false;
        resolvingNP.GetComponent<Button>().interactable = false;
        fadjKnob.GetComponent<Button>().interactable = false;
        // cadjKnob.GetComponent<Button>().interactable = false;
        objectiveBtn.GetComponent<Button>().interactable = false;
        incJoint.GetComponent<Button>().interactable = false;
        diaBtn.GetComponent<Button>().interactable = false;
    }

    public void objectiveBtnAct()
    {
        eyePiece.GetComponent<Button>().interactable = false;
        bodyTube.GetComponent<Button>().interactable = false;
        armBtn.GetComponent<Button>().interactable = false;
        baseBtn.GetComponent<Button>().interactable = false;
        stageBtn.GetComponent<Button>().interactable = false;
        stageClips.GetComponent<Button>().interactable = false;
        mirrorBtn.GetComponent<Button>().interactable = false;
        resolvingNP.GetComponent<Button>().interactable = false;
        fadjKnob.GetComponent<Button>().interactable = false;
        cadjKnob.GetComponent<Button>().interactable = false;
        // objectiveBtn.GetComponent<Button>().interactable = false;
        incJoint.GetComponent<Button>().interactable = false;
        diaBtn.GetComponent<Button>().interactable = false;
    }

    public void incJointAct()
    {
        eyePiece.GetComponent<Button>().interactable = false;
        bodyTube.GetComponent<Button>().interactable = false;
        armBtn.GetComponent<Button>().interactable = false;
        baseBtn.GetComponent<Button>().interactable = false;
        stageBtn.GetComponent<Button>().interactable = false;
        stageClips.GetComponent<Button>().interactable = false;
        mirrorBtn.GetComponent<Button>().interactable = false;
        resolvingNP.GetComponent<Button>().interactable = false;
        fadjKnob.GetComponent<Button>().interactable = false;
        cadjKnob.GetComponent<Button>().interactable = false;
        objectiveBtn.GetComponent<Button>().interactable = false;
        // incJoint.GetComponent<Button>().interactable = false;
        diaBtn.GetComponent<Button>().interactable = false;
    }

    public void diaBtnAct()
    {
        eyePiece.GetComponent<Button>().interactable = false;
        bodyTube.GetComponent<Button>().interactable = false;
        armBtn.GetComponent<Button>().interactable = false;
        baseBtn.GetComponent<Button>().interactable = false;
        stageBtn.GetComponent<Button>().interactable = false;
        stageClips.GetComponent<Button>().interactable = false;
        mirrorBtn.GetComponent<Button>().interactable = false;
        resolvingNP.GetComponent<Button>().interactable = false;
        fadjKnob.GetComponent<Button>().interactable = false;
        cadjKnob.GetComponent<Button>().interactable = false;
        objectiveBtn.GetComponent<Button>().interactable = false;
        incJoint.GetComponent<Button>().interactable = false;
        // diaBtn.GetComponent<Button>().interactable = false;
    }

}
