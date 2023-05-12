using UnityEngine;
using UnityEngine.UI;

public class TargetDestinationDropdown : MonoBehaviour
{
    public Dropdown dropdown;
    public static string selectedOption2="A-101 Visitors Room";

    void Start()
    {
        if (dropdown.options.Count > 0)
        {
        selectedOption2 = dropdown.options[0].text;
        }
    }

    public void onValueChanged()
    {
        // Get the text content of the selected option and save it to the static variable
        selectedOption2 = dropdown.options[dropdown.value].text;

        // Log the selected option to the console
        print(selectedOption2);
    }
}
