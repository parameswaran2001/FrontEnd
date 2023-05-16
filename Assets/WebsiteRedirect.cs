using UnityEngine;

public class WebsiteRedirect : MonoBehaviour
{
    public string websiteUrl;

    public void OpenWebsite()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSft6Av40MPA3mV1ndiWvf5APXOZ98v5sv5lILYVJn5T6KO11w/viewform?usp=sf_link");
    }
}