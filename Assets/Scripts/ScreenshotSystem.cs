using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core.GamePaths;
using System.IO;
using System;
using Random = UnityEngine.Random;
namespace Game.Core.ScreenshotSystem
{
    public class ScreenshotSystem : MonoBehaviour
    {
        [Header("Visual")]
        [SerializeField] private KeyCode _ScreenShotKey = KeyCode.Print;

        private void Awake()
        {
            GamePaths.GamePaths.SetScreenShotPath($"C:/Users/{Environment.UserName}/Documents/{Application.productName}/ScreenShots");
        }

        private void Update()
        {
            if(Input.GetKeyDown(_ScreenShotKey))
                StartCoroutine(ScreenShot());
        }

        private IEnumerator ScreenShot()
        {
            var path = GamePaths.GamePaths._screenShotPath;
            var dateTime = $"{DateTime.Now.Day}-{DateTime.Now.Month}-{DateTime.Now.Year}";
            var screenShotName = $"ScreenShot{Application.productName}({dateTime})({Random.Range(0, 10*99)}).png";
            var fullPath = Path.Combine(path, screenShotName);
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            ScreenCapture.CaptureScreenshot(fullPath);
            print($"Capture: {fullPath}");
            yield return null;
        }
    }
}