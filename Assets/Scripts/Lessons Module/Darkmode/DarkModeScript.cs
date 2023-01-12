using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class DarkModeScript : MonoBehaviour
{
    [Header("BACKGROUNDS")]
    public GameObject OuterBG;
    public GameObject ContentBG;
    public GameObject OuterBG2;
    public GameObject ContentBG2;
    public GameObject OuterBG3;
    public GameObject ContentBG3;
    public GameObject OuterBG4;
    public GameObject ContentBG4;
    public GameObject OuterBG5;
    public GameObject ContentBG5;
    public GameObject OuterBG6;
    public GameObject ContentBG6;
    public GameObject OuterBG7;
    public GameObject ContentBG7;
    public GameObject OuterBG8;
    public GameObject ContentBG8;
    public GameObject OuterBG9;
    public GameObject ContentBG9;

    [Header("CONTENT")]
    //panel 1
    public TextMeshProUGUI textContent;
    public TextMeshProUGUI textContentHeader;
    //panel 2
    [Header ("\tContent panel 2")]
    public TextMeshProUGUI textContent2;
    public TextMeshProUGUI textContentHeader2;
    public TextMeshProUGUI textContentMiniHeader2;

    [Header("\tContent panel 3")]
    public TextMeshProUGUI textContent3;
    public TextMeshProUGUI textContentHeader3;
    public TextMeshProUGUI textContentMiniHeader3;
    [Header("\tContent panel 4")]
    public TextMeshProUGUI textContent4;
    public TextMeshProUGUI textContentHeader4;
    public TextMeshProUGUI textContentMiniHeader4;
    public TextMeshProUGUI textContentSub4;
    [Header("\tContent panel 5")]
    public TextMeshProUGUI textContent5;
    public TextMeshProUGUI textContentHeader5;
    public TextMeshProUGUI textContentMiniHeader5;
    [Header("\tContent panel 6")]
    public TextMeshProUGUI textContent6;
    public TextMeshProUGUI textContentHeader6;
    public TextMeshProUGUI textContentMiniHeader6;
    public TextMeshProUGUI textContentSub6;
    [Header("\tContent panel 7")]
    public TextMeshProUGUI textContent7;
    public TextMeshProUGUI textContentHeader7;
    public TextMeshProUGUI textContentMiniHeader7;
    public TextMeshProUGUI textContentSub7;
    public TextMeshProUGUI textContentMiniSubHeader7;
    [Header("\tContent panel 8")]
    public TextMeshProUGUI textContent8;
    public TextMeshProUGUI textContentHeader8;
    public TextMeshProUGUI textContentMiniHeader8;
    public TextMeshProUGUI textContentSub8;
    public TextMeshProUGUI textContentMiniSubHeader8;
    [Header("\tContent panel 9")]
    public TextMeshProUGUI textContent9;
    public TextMeshProUGUI textContentHeader9;
    public TextMeshProUGUI textContentMiniHeader9;
    public TextMeshProUGUI textContentSub9;
    public TextMeshProUGUI textContentMiniSubHeader9;

    [Header("BUTTONS")]
    public GameObject Play;
    public GameObject Pause;
    public GameObject Restart;
    public GameObject Volume;
    public GameObject Unmute;
    

    public GameObject Play2;
    public GameObject Pause2;
    public GameObject Restart2;
    public GameObject Volume2;
    public GameObject Unmute2;

    public GameObject Play3;
    public GameObject Pause3;
    public GameObject Restart3;
    public GameObject Volume3;
    public GameObject Unmute3;

    public GameObject Play4;
    public GameObject Pause4;
    public GameObject Restart4;
    public GameObject Volume4;
    public GameObject Unmute4;

    public GameObject Play5;
    public GameObject Pause5;
    public GameObject Restart5;
    public GameObject Volume5;
    public GameObject Unmute5;

    public GameObject Play6;
    public GameObject Pause6;
    public GameObject Restart6;
    public GameObject Volume6;
    public GameObject Unmute6;

    public GameObject Play7;
    public GameObject Pause7;
    public GameObject Restart7;
    public GameObject Volume7;
    public GameObject Unmute7;

    public GameObject Play8;
    public GameObject Pause8;
    public GameObject Restart8;
    public GameObject Volume8;
    public GameObject Unmute8;

    public GameObject Play9;
    public GameObject Pause9;
    public GameObject Restart9;
    public GameObject Volume9;
    public GameObject Unmute9;

    [Header("BUTTONS TEXT")]
    public TextMeshProUGUI txtPlay;
    public TextMeshProUGUI txtPause;
    public TextMeshProUGUI txtRestart;
    public TextMeshProUGUI txtVolume;
    public TextMeshProUGUI txtUnmute;

    public TextMeshProUGUI txtPlay2;
    public TextMeshProUGUI txtPause2;
    public TextMeshProUGUI txtRestart2;
    public TextMeshProUGUI txtVolume2;
    public TextMeshProUGUI txtUnmute2;

    public TextMeshProUGUI txtPlay3;
    public TextMeshProUGUI txtPause3;
    public TextMeshProUGUI txtRestart3;
    public TextMeshProUGUI txtVolume3;
    public TextMeshProUGUI txtUnmute3;

    public TextMeshProUGUI txtPlay4;
    public TextMeshProUGUI txtPause4;
    public TextMeshProUGUI txtRestart4;
    public TextMeshProUGUI txtVolume4;
    public TextMeshProUGUI txtUnmute4;

    public TextMeshProUGUI txtPlay5;
    public TextMeshProUGUI txtPause5;
    public TextMeshProUGUI txtRestart5;
    public TextMeshProUGUI txtVolume5;
    public TextMeshProUGUI txtUnmute5;

    public TextMeshProUGUI txtPlay6;
    public TextMeshProUGUI txtPause6;
    public TextMeshProUGUI txtRestart6;
    public TextMeshProUGUI txtVolume6;
    public TextMeshProUGUI txtUnmute6;

    public TextMeshProUGUI txtPlay7;
    public TextMeshProUGUI txtPause7;
    public TextMeshProUGUI txtRestart7;
    public TextMeshProUGUI txtVolume7;
    public TextMeshProUGUI txtUnmute7;

    public TextMeshProUGUI txtPlay8;
    public TextMeshProUGUI txtPause8;
    public TextMeshProUGUI txtRestart8;
    public TextMeshProUGUI txtVolume8;
    public TextMeshProUGUI txtUnmute8;

    public TextMeshProUGUI txtPlay9;
    public TextMeshProUGUI txtPause9;
    public TextMeshProUGUI txtRestart9;
    public TextMeshProUGUI txtVolume9;
    public TextMeshProUGUI txtUnmute9;
    [Header("Buttons Previous | Next")]
    public TextMeshProUGUI txtPrevious;
    public TextMeshProUGUI txtNext;
    public TextMeshProUGUI txtPrevIcon;
    public TextMeshProUGUI txtNextIcon;
    public TextMeshProUGUI txtMiddle;

    public TextMeshProUGUI txtPrevious2;
    public TextMeshProUGUI txtNext2;
    public TextMeshProUGUI txtPrevIcon2;
    public TextMeshProUGUI txtNextIcon2;
    public TextMeshProUGUI txtMiddle2;

    public TextMeshProUGUI txtPrevious3;
    public TextMeshProUGUI txtNext3;
    public TextMeshProUGUI txtPrevIcon3;
    public TextMeshProUGUI txtNextIcon3;
    public TextMeshProUGUI txtMiddle3;

    public TextMeshProUGUI txtPrevious4;
    public TextMeshProUGUI txtNext4;
    public TextMeshProUGUI txtPrevIcon4;
    public TextMeshProUGUI txtNextIcon4;
    public TextMeshProUGUI txtMiddle4;

    public TextMeshProUGUI txtPrevious5;
    public TextMeshProUGUI txtNext5;
    public TextMeshProUGUI txtPrevIcon5;
    public TextMeshProUGUI txtNextIcon5;
    public TextMeshProUGUI txtMiddle5;

    public TextMeshProUGUI txtPrevious6;
    public TextMeshProUGUI txtNext6;
    public TextMeshProUGUI txtPrevIcon6;
    public TextMeshProUGUI txtNextIcon6;
    public TextMeshProUGUI txtMiddle6;

    public TextMeshProUGUI txtPrevious7;
    public TextMeshProUGUI txtNext7;
    public TextMeshProUGUI txtPrevIcon7;
    public TextMeshProUGUI txtNextIcon7;
    public TextMeshProUGUI txtMiddle7;

    public TextMeshProUGUI txtPrevious8;
    public TextMeshProUGUI txtNext8;
    public TextMeshProUGUI txtPrevIcon8;
    public TextMeshProUGUI txtNextIcon8;
    public TextMeshProUGUI txtMiddle8;

    public TextMeshProUGUI txtPrevious9;
    public TextMeshProUGUI txtNext9;
    public TextMeshProUGUI txtPrevIcon9;
    public TextMeshProUGUI txtNextIcon9;
    public TextMeshProUGUI txtMiddle9;

    public void DarkMode() {
        //Backgrounds
        OuterBG.GetComponent<Image>().color = new Color32(40,40,40,255);
        ContentBG.GetComponent<Image>().color = new Color32(80,80,80,255);
        OuterBG2.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
        ContentBG2.GetComponent<Image>().color = new Color32(80, 80, 80, 255);
        OuterBG3.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
        ContentBG3.GetComponent<Image>().color = new Color32(80, 80, 80, 255);
        OuterBG4.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
        ContentBG4.GetComponent<Image>().color = new Color32(80, 80, 80, 255);
        OuterBG5.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
        ContentBG5.GetComponent<Image>().color = new Color32(80, 80, 80, 255);
        OuterBG6.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
        ContentBG6.GetComponent<Image>().color = new Color32(80, 80, 80, 255);
        OuterBG7.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
        ContentBG7.GetComponent<Image>().color = new Color32(80, 80, 80, 255);
        OuterBG8.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
        ContentBG8.GetComponent<Image>().color = new Color32(80, 80, 80, 255);
        OuterBG9.GetComponent<Image>().color = new Color32(40, 40, 40, 255);
        ContentBG9.GetComponent<Image>().color = new Color32(80, 80, 80, 255);
        //Contents
        textContent.color = Color.white;
        textContentHeader.color = Color.white;
        //panel 2
        textContent2.color = Color.white; ;
        textContentHeader2.color = Color.white; ;
        textContentMiniHeader2.color = Color.white; ;
        //panel 3

        textContent3.color = Color.white; ;
        textContentHeader3.color = Color.white; ;
        textContentMiniHeader3.color = Color.white; ;
        //panel 4
        textContent4.color = Color.white; ;
        textContentHeader4.color = Color.white; ;
        textContentMiniHeader4.color = Color.white; ;
        textContentSub4.color = Color.white; ;
        //panel 5
        textContent5.color = Color.white; ;
        textContentHeader5.color = Color.white; ;
        textContentMiniHeader5.color = Color.white; ;

        //panel 6
        textContent6.color = Color.white; ;
        textContentHeader6.color = Color.white; ;
        textContentMiniHeader6.color = Color.white; ;
        textContentSub6.color = Color.white; ;

        //panel 7
        textContent7.color = Color.white; ;
        textContentHeader7.color = Color.white; ;
        textContentMiniHeader7.color = Color.white; ;
        textContentSub7.color = Color.white; ;
        textContentMiniSubHeader7.color = Color.white; ;
        //panel 8
        textContent8.color = Color.white; ;
        textContentHeader8.color = Color.white; ;
        textContentMiniHeader8.color = Color.white; ;
        textContentSub8.color = Color.white; ;
        textContentMiniSubHeader8.color = Color.white; ;
        //panel 9
        textContent9.color = Color.white; ;
        textContentHeader9.color = Color.white; ;
        textContentMiniHeader9.color = Color.white; ;
        textContentSub9.color = Color.white; ;
        textContentMiniSubHeader9.color = Color.white; ;


        //Buttons
        Play.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Pause.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Restart.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Volume.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Unmute.GetComponent<Image>().color = new Color32(128, 128, 128, 255);

        Play2.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Pause2.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Restart2.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Volume2.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Unmute2.GetComponent<Image>().color = new Color32(128, 128, 128, 255);

        Play3.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Pause3.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Restart3.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Volume3.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Unmute3.GetComponent<Image>().color = new Color32(128, 128, 128, 255);

        Play4.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Pause4.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Restart4.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Volume4.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Unmute4.GetComponent<Image>().color = new Color32(128, 128, 128, 255);

        Play5.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Pause5.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Restart5.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Volume5.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Unmute5.GetComponent<Image>().color = new Color32(128, 128, 128, 255);

        Play6.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Pause6.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Restart6.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Volume6.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Unmute6.GetComponent<Image>().color = new Color32(128, 128, 128, 255);

        Play7.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Pause7.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Restart7.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Volume7.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Unmute7.GetComponent<Image>().color = new Color32(128, 128, 128, 255);

        Play8.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Pause8.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Restart8.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Volume8.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Unmute8.GetComponent<Image>().color = new Color32(128, 128, 128, 255);

        Play9.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Pause9.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Restart9.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Volume9.GetComponent<Image>().color = new Color32(128, 128, 128, 255);
        Unmute9.GetComponent<Image>().color = new Color32(128, 128, 128, 255);

        //text adjust
        txtPlay.color = Color.white;
        txtPause.color = Color.white;
        txtRestart.color = Color.white;
        txtVolume.color = Color.white;
        txtUnmute.color = Color.white;

        txtPlay2.color = Color.white;
        txtPause2.color = Color.white;
        txtRestart2.color = Color.white;
        txtVolume2.color = Color.white;
        txtUnmute2.color = Color.white;

        txtPlay3.color = Color.white;
        txtPause3.color = Color.white;
        txtRestart3.color = Color.white;
        txtVolume3.color = Color.white;
        txtUnmute3.color = Color.white;

        txtPlay4.color = Color.white;
        txtPause4.color = Color.white;
        txtRestart4.color = Color.white;
        txtVolume4.color = Color.white;
        txtUnmute4.color = Color.white;

        txtPlay5.color = Color.white;
        txtPause5.color = Color.white;
        txtRestart5.color = Color.white;
        txtVolume5.color = Color.white;
        txtUnmute5.color = Color.white;

        txtPlay6.color = Color.white;
        txtPause6.color = Color.white;
        txtRestart6.color = Color.white;
        txtVolume6.color = Color.white;
        txtUnmute6.color = Color.white;

        txtPlay7.color = Color.white;
        txtPause7.color = Color.white;
        txtRestart7.color = Color.white;
        txtVolume7.color = Color.white;
        txtUnmute7.color = Color.white;

        txtPlay8.color = Color.white;
        txtPause8.color = Color.white;
        txtRestart8.color = Color.white;
        txtVolume8.color = Color.white;
        txtUnmute8.color = Color.white;

        txtPlay9.color = Color.white;
        txtPause9.color = Color.white;
        txtRestart9.color = Color.white;
        txtVolume9.color = Color.white;
        txtUnmute9.color = Color.white;

        //for previous, and next
        txtPrevious.color = Color.white;
        txtNext.color = Color.white;
        txtPrevIcon.color = Color.white;
        txtNextIcon.color = Color.white;
        txtMiddle.color = Color.white;

        txtPrevious2.color = Color.white;
        txtNext2.color = Color.white;
        txtPrevIcon2.color = Color.white;
        txtNextIcon2.color = Color.white;
        txtMiddle2.color = Color.white;

        txtPrevious3.color = Color.white;
        txtNext3.color = Color.white;
        txtPrevIcon3.color = Color.white;
        txtNextIcon3.color = Color.white;
        txtMiddle3.color = Color.white;

        txtPrevious4.color = Color.white;
        txtNext4.color = Color.white;
        txtPrevIcon4.color = Color.white;
        txtNextIcon4.color = Color.white;
        txtMiddle4.color = Color.white;

        txtPrevious5.color = Color.white;
        txtNext5.color = Color.white;
        txtPrevIcon5.color = Color.white;
        txtNextIcon5.color = Color.white;
        txtMiddle5.color = Color.white;

        txtPrevious6.color = Color.white;
        txtNext6.color = Color.white;
        txtPrevIcon6.color = Color.white;
        txtNextIcon6.color = Color.white;
        txtMiddle6.color = Color.white;

        txtPrevious7.color = Color.white;
        txtNext7.color = Color.white;
        txtPrevIcon7.color = Color.white;
        txtNextIcon7.color = Color.white;
        txtMiddle7.color = Color.white;

        txtPrevious8.color = Color.white;
        txtNext8.color = Color.white;
        txtPrevIcon8.color = Color.white;
        txtNextIcon8.color = Color.white;
        txtMiddle8.color = Color.white;

        txtPrevious9.color = Color.white;
        txtNext9.color = Color.white;
        txtPrevIcon9.color = Color.white;
        txtNextIcon9.color = Color.white;
        txtMiddle9.color = Color.white;


    }

    public void DayMode() {
        //backgrounds
        OuterBG.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        ContentBG.GetComponent<Image>().color = new Color32(233,233,233,255);
        OuterBG2.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        ContentBG2.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        OuterBG3.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        ContentBG3.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        OuterBG4.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        ContentBG4.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        OuterBG5.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        ContentBG5.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        OuterBG6.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        ContentBG6.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        OuterBG7.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        ContentBG7.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        OuterBG8.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        ContentBG8.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        OuterBG9.GetComponent<UnityEngine.UI.Image>().color = Color.white;
        ContentBG9.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        //contents
        textContent.color = Color.black;
        textContentHeader.color = Color.black;
        //panel 2
        textContent2.color = Color.black; ;
        textContentHeader2.color = Color.black; ;
        textContentMiniHeader2.color = Color.black; ;
        //panel 3

        textContent3.color = Color.black; ;
        textContentHeader3.color = Color.black; ;
        textContentMiniHeader3.color = Color.black; ;
        //panel 4
        textContent4.color = Color.black; ;
        textContentHeader4.color = Color.black; ;
        textContentMiniHeader4.color = Color.black; ;
        textContentSub4.color = Color.black; ;
        //panel 5
        textContent5.color = Color.black; ;
        textContentHeader5.color = Color.black; ;
        textContentMiniHeader5.color = Color.black; ;

        //panel 6
        textContent6.color = Color.black; ;
        textContentHeader6.color = Color.black; ;
        textContentMiniHeader6.color = Color.black; ;
        textContentSub6.color = Color.black; ;

        //panel 7
        textContent7.color = Color.black; ;
        textContentHeader7.color = Color.black; ;
        textContentMiniHeader7.color = Color.black; ;
        textContentSub7.color = Color.black; ;
        textContentMiniSubHeader7.color = Color.black; ;
        //panel 8
        textContent8.color = Color.black; ;
        textContentHeader8.color = Color.black; ;
        textContentMiniHeader8.color = Color.black; ;
        textContentSub8.color = Color.black; ;
        textContentMiniSubHeader8.color = Color.black; ;
        //panel 9
        textContent9.color = Color.black; ;
        textContentHeader9.color = Color.black; ;
        textContentMiniHeader9.color = Color.black; ;
        textContentSub9.color = Color.black; ;
        textContentMiniSubHeader9.color = Color.black; ;

        //buttons
        Play.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Pause.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Restart.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Volume.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Unmute.GetComponent<Image>().color = new Color32(233, 233, 233, 255);

        Play2.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Pause2.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Restart2.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Volume2.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Unmute2.GetComponent<Image>().color = new Color32(233, 233, 233, 255);

        Play3.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Pause3.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Restart3.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Volume3.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Unmute3.GetComponent<Image>().color = new Color32(233, 233, 233, 255);

        Play4.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Pause4.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Restart4.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Volume4.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Unmute4.GetComponent<Image>().color = new Color32(233, 233, 233, 255);

        Play5.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Pause5.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Restart5.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Volume5.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Unmute5.GetComponent<Image>().color = new Color32(233, 233, 233, 255);

        Play6.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Pause6.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Restart6.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Volume6.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Unmute6.GetComponent<Image>().color = new Color32(233, 233, 233, 255);

        Play7.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Pause7.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Restart7.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Volume7.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Unmute7.GetComponent<Image>().color = new Color32(233, 233, 233, 255);

        Play8.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Pause8.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Restart8.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Volume8.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Unmute8.GetComponent<Image>().color = new Color32(233, 233, 233, 255);

        Play9.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Pause9.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Restart9.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Volume9.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        Unmute9.GetComponent<Image>().color = new Color32(233, 233, 233, 255);
        //text adjust
        txtPlay.color = Color.black;
        txtPause.color = Color.black;
        txtRestart.color = Color.black;
        txtVolume.color = Color.black;
        txtUnmute.color = Color.black;

        txtPlay2.color = Color.black;
        txtPause2.color = Color.black;
        txtRestart2.color = Color.black;
        txtVolume2.color = Color.black;
        txtUnmute2.color = Color.black;

        txtPlay3.color = Color.black;
        txtPause3.color = Color.black;
        txtRestart3.color = Color.black;
        txtVolume3.color = Color.black;
        txtUnmute3.color = Color.black;

        txtPlay4.color = Color.black;
        txtPause4.color = Color.black;
        txtRestart4.color = Color.black;
        txtVolume4.color = Color.black;
        txtUnmute4.color = Color.black;

        txtPlay5.color = Color.black;
        txtPause5.color = Color.black;
        txtRestart5.color = Color.black;
        txtVolume5.color = Color.black;
        txtUnmute5.color = Color.black;

        txtPlay6.color = Color.black;
        txtPause6.color = Color.black;
        txtRestart6.color = Color.black;
        txtVolume6.color = Color.black;
        txtUnmute6.color = Color.black;

        txtPlay7.color = Color.black;
        txtPause7.color = Color.black;
        txtRestart7.color = Color.black;
        txtVolume7.color = Color.black;
        txtUnmute7.color = Color.black;

        txtPlay8.color = Color.black;
        txtPause8.color = Color.black;
        txtRestart8.color = Color.black;
        txtVolume8.color = Color.black;
        txtUnmute8.color = Color.black;

        txtPlay9.color = Color.black;
        txtPause9.color = Color.black;
        txtRestart9.color = Color.black;
        txtVolume9.color = Color.black;
        txtUnmute9.color = Color.black;

        //for previous, and next
        txtPrevious.color = Color.black;
        txtNext.color = Color.black;
        txtPrevIcon.color = Color.black;
        txtNextIcon.color = Color.black;
        txtMiddle.color = Color.black;

        txtPrevious2.color = Color.black;
        txtNext2.color = Color.black;
        txtPrevIcon2.color = Color.black;
        txtNextIcon2.color = Color.black;
        txtMiddle2.color = Color.black;

        txtPrevious3.color = Color.black;
        txtNext3.color = Color.black;
        txtPrevIcon3.color = Color.black;
        txtNextIcon3.color = Color.black;
        txtMiddle3.color = Color.black;

        txtPrevious4.color = Color.black;
        txtNext4.color = Color.black;
        txtPrevIcon4.color = Color.black;
        txtNextIcon4.color = Color.black;
        txtMiddle4.color = Color.black;

        txtPrevious5.color = Color.black;
        txtNext5.color = Color.black;
        txtPrevIcon5.color = Color.black;
        txtNextIcon5.color = Color.black;
        txtMiddle5.color = Color.black;

        txtPrevious6.color = Color.black;
        txtNext6.color = Color.black;
        txtPrevIcon6.color = Color.black;
        txtNextIcon6.color = Color.black;
        txtMiddle6.color = Color.black;

        txtPrevious7.color = Color.black;
        txtNext7.color = Color.black;
        txtPrevIcon7.color = Color.black;
        txtNextIcon7.color = Color.black;
        txtMiddle7.color = Color.black;

        txtPrevious8.color = Color.black;
        txtNext8.color = Color.black;
        txtPrevIcon8.color = Color.black;
        txtNextIcon8.color = Color.black;
        txtMiddle8.color = Color.black;

        txtPrevious9.color = Color.black;
        txtNext9.color = Color.black;
        txtPrevIcon9.color = Color.black;
        txtNextIcon9.color = Color.black;
        txtMiddle9.color = Color.black;

    }
}
