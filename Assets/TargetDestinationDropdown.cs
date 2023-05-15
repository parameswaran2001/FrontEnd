using UnityEngine;
using UnityEngine.UI;

public class TargetDestinationDropdown : MonoBehaviour
{
    public Dropdown dropdown;

    public static string selectedValue2="A-101 Visitors Room";

    void Start()
    {
        dropdown.onValueChanged.AddListener(delegate {
            DropdownValueChanged(dropdown);
        });
    }

    void DropdownValueChanged(Dropdown dropdown)
    {
        selectedValue2 = dropdown.options[dropdown.value].text;
        Debug.Log("Selected value: " + selectedValue2);
    }
}