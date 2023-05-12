using UnityEngine;
using UnityEngine.UI;

public class TargetDestinationDropdown : MonoBehaviour
{
    public Dropdown dropdown;

    public static string selectedValue;

    void Start()
    {
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });
    }

    void DropdownValueChanged(Dropdown dropdown)
    {
        selectedValue = dropdown.options[dropdown.value].text;
        Debug.Log("Selected value: " + selectedValue);
    }
}