using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Collections.Generic;

public class LegacyDropdownGenerator : MonoBehaviour
{
    public Dropdown dropdown;
    public string filePath;
    public int dropdownLength;

    private List<string> optionsList = new List<string>();
    private List<string> displayedOptions = new List<string>();
    private int scrollPosition = 0;

    void Start()
    {
        LoadOptions();
        dropdown.ClearOptions();
        dropdown.AddOptions(displayedOptions);
    }

    void LoadOptions()
    {
        optionsList = new List<string>(File.ReadAllLines(filePath));
        optionsList.Sort();

        if (optionsList.Count > dropdownLength)
        {
            displayedOptions = optionsList.GetRange(0, dropdownLength);
        }
        else
        {
            displayedOptions = optionsList;
        }
    }

    public void OnScroll()
    {
        scrollPosition = dropdown.value;
        UpdateDisplayedOptions();
    }

    void UpdateDisplayedOptions()
    {
        int startIndex = scrollPosition;
        int endIndex = Mathf.Min(scrollPosition + dropdownLength, optionsList.Count);
        displayedOptions = optionsList.GetRange(startIndex, endIndex - startIndex);

        dropdown.ClearOptions();
        dropdown.AddOptions(displayedOptions);
        dropdown.value = scrollPosition;
    }
}
