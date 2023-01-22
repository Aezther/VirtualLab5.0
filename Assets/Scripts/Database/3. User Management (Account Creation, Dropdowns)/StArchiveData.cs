using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StArchiveData : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] StudentArchiveData data;

    [Header("TMP")]
    [SerializeField] TextMeshProUGUI idTM;
    [SerializeField] TextMeshProUGUI usernameTM;
    [SerializeField] TextMeshProUGUI passwordTM;

    [SerializeField] TextMeshProUGUI firstnameTM;
    [SerializeField] TextMeshProUGUI middlenameTM;
    [SerializeField] TextMeshProUGUI lastnameTM;
    [SerializeField] TextMeshProUGUI sectionTM;



    public void UpdateValues()
    {
        data.id = idTM.text;
        data.username = usernameTM.text;
        data.password = passwordTM.text;
        data.firstname = firstnameTM.text;
        data.middlename = middlenameTM.text;
        data.lastname = lastnameTM.text;
        data.section = sectionTM.text;
    }
}
