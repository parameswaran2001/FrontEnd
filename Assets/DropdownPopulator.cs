using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class DropdownPopulator : MonoBehaviour
{
    public TextAsset optionsFile;
    public Dropdown dropdown;

    void Start()
    {
        // Read the text file and split its contents into an array of options
        string[] options = optionsFile.text.Split('\n');

        // Add each option to the dropdown
        foreach (string option in options)
        {
            dropdown.options.Add(new Dropdown.OptionData(option.Trim()));
        }

        // Set the value of the dropdown to the first option
        dropdown.value = 0;
    }
}
