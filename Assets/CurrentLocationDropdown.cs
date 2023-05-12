using UnityEngine;
using UnityEngine.UI;

public class CurrentLocationDropdown : MonoBehaviour
{
    public Dropdown dropdown;

    public static string selectedValue1;

    void Start()
    {
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });
    }

    void DropdownValueChanged(Dropdown dropdown)
    {
        selectedValue1 = dropdown.options[dropdown.value].text;
        Debug.Log("Selected value: " + selectedValue1);
    }
}