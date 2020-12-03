using System;
using UnityEditor;

namespace DinomiteStudios.SpaceMouseUnity.Editor
{
    [Serializable]
    public class SpaceNavigatorWindow : EditorWindow, IDisposable
    {
        /// <summary>
        /// Initializes the window.
        /// </summary>
        [MenuItem("Window/SpaceNavigator")]
        public static void Init()
        {
            SpaceNavigatorWindow window = GetWindow(typeof(SpaceNavigatorWindow)) as SpaceNavigatorWindow;

            if (window)
            {
                window.Show();
            }
        }

        public static void OnDisable()
        {
            // Write settings to PlayerPrefs when EditorWindow is closed.
            Settings.Settings.Write();
        }

        public static void OnDestroy()
        {
            // Write settings to PlayerPrefs when EditorWindow is closed.
            Settings.Settings.Write();
        }

        // This does not get called, unfortunately...
        public void OnApplicationQuit()
        {
            ViewportController.OnApplicationQuit();
        }

        public void OnSelectionChange()
        {
            ViewportController.StoreSelectionTransforms();
        }

        public void OnGUI()
        {
            Settings.Settings.OnGUI();
        }

        public void Dispose()
        {
            // Write settings to PlayerPrefs when EditorWindow is closed.
            Settings.Settings.Write();
        }
    }
}