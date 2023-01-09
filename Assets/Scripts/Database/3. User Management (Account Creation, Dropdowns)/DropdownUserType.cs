using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using TMPro;
using UnityEngine.UI;
using System;

public class DropdownUserType : MonoBehaviour
{
    public string SelectedUserType;
    public int index;

    void Start() {
        DisplayUserTypeInDropdown();

    }
    public void DisplayUserTypeInDropdown() { //----------------------------------------USERTYPE;
                                              //get dropdown component from transform

        var dropdown = transform.GetComponent<TMP_Dropdown>();
        //clear the options if there are any
        dropdown.options.Clear();
        //create list of strings that contains sample items from dropdown.
        List<string> items = new List<string>();
        items.Add("Student");
        items.Add("Teacher");
        //add items in the options, loop in a for each loop and 
        foreach (var item in items) {
            dropdown.options.Add(new TMP_Dropdown.OptionData() { text = item });
        }
        //Call method in the start method, so that it will display when the game starts
        DropdownItemSelected(dropdown);
        //value change listener for dropdown which is dropdownitemselected
        dropdown.onValueChanged.AddListener(delegate { DropdownItemSelected(dropdown); });


    }
    public void DropdownItemSelected(TMP_Dropdown dropdown) {//---------------USERTYPE;
        index = dropdown.value;

        //TextBox.text = dropdown.options[index].text;
        SelectedUserType = dropdown.options[index].text;
        //Debug.Log(SelectedUserType + index);
        //Debug.Log(SelectedUserType);
        //Debug.Log("Selected BELOW :"+dropdown.options[index].text);
    }


}
