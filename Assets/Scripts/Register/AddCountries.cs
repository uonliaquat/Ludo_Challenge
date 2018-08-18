using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddCountries : MonoBehaviour {

    public Dropdown dropdown;
    public Sprite[] flags;

    private void Start()
    {
        dropdown.ClearOptions();
        List<Dropdown.OptionData> flagItems = new List<Dropdown.OptionData>();

        foreach(var flag in flags){
            var flagOption = new Dropdown.OptionData(flag.name, flag);
            flagItems.Add(flagOption);
        }

        dropdown.AddOptions(flagItems);
       
    }

}
