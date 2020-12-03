using System;
using UnityEngine;

namespace DinomiteStudios.SpaceMouseUnity
{
    public abstract class SpaceNavigator : IDisposable
    {
        private static SpaceNavigator instance;

        public static SpaceNavigator Instance
        {
            get
            {
                if (instance == null)
                {
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
                    instance = SpaceNavigatorWindows.SubInstance;
#endif
#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
				instance = SpaceNavigatorMac.SubInstance;
#endif
                }
                return instance;
            }
            set { instance = value; }
        }

        public static Vector3 Translation { get { return Instance.GetTranslation(); } }

        public static Quaternion Rotation { get { return Instance.GetRotation(); } }

        public static Quaternion RotationInLocalCoordSys(Transform coordSys)
        {
            return coordSys.rotation * Rotation * Quaternion.Inverse(coordSys.rotation);
        }

        public static void SetTranslationSensitivity(float newPlayTransSens)
        {
            Settings.Settings.PlayTransSens = newPlayTransSens;
        }

        public static void SetRotationSensitivity(float newPlayRotSens)
        {
            Settings.Settings.PlayRotSens = newPlayRotSens;
        }

        public abstract Vector3 GetTranslation();

        public abstract Quaternion GetRotation();

        public abstract void Dispose();
    }
}