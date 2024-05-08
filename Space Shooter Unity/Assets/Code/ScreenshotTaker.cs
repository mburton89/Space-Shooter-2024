using UnityEngine;

public class ScreenshotTaker : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            TakeScreenshot();
        }
    }

    void TakeScreenshot()
    {
        // Define the file name with a timestamp
        string fileName = "Screenshot_" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".png";

        // Capture the screenshot
        ScreenCapture.CaptureScreenshot(fileName);

        Debug.Log("Screenshot saved as: " + fileName);
    }
}