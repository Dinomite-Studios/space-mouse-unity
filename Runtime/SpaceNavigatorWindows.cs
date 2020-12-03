using System;
using System.Runtime.InteropServices;
using UnityEngine;
using DinomiteStudios.SpaceMouseUnity.Settings;

#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
using TDx.TDxInput;
#endif

namespace DinomiteStudios.SpaceMouseUnity
{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
    class SpaceNavigatorWindows : SpaceNavigator
    {
        private const float TransSensScale = 0.0001f, RotSensScale = 0.0008f;

        // Public API
        public override Vector3 GetTranslation()
        {
            float sensitivity = Application.isPlaying ? Settings.Settings.PlayTransSens : Settings.Settings.TransSens[Settings.Settings.CurrentGear];
            return (SubInstance._sensor == null ?
                        Vector3.zero :
                        new Vector3(
                            Settings.Settings.GetLock(DoF.Translation, Axis.X) ? 0 : (float)SubInstance._sensor.Translation.X,
                            Settings.Settings.GetLock(DoF.Translation, Axis.Y) ? 0 : (float)SubInstance._sensor.Translation.Y,
                            Settings.Settings.GetLock(DoF.Translation, Axis.Z) ? 0 : -(float)SubInstance._sensor.Translation.Z) *
                        sensitivity * TransSensScale);
        }
        public override Quaternion GetRotation()
        {
            float sensitivity = Application.isPlaying ? Settings.Settings.PlayRotSens : Settings.Settings.RotSens;
            return (SubInstance._sensor == null ?
                        Quaternion.identity :
                        Quaternion.AngleAxis(
                            (float)SubInstance._sensor.Rotation.Angle * sensitivity * RotSensScale,
                            new Vector3(
                                Settings.Settings.GetLock(DoF.Rotation, Axis.X) ? 0 : -(float)SubInstance._sensor.Rotation.X,
                                Settings.Settings.GetLock(DoF.Rotation, Axis.Y) ? 0 : -(float)SubInstance._sensor.Rotation.Y,
                                Settings.Settings.GetLock(DoF.Rotation, Axis.Z) ? 0 : (float)SubInstance._sensor.Rotation.Z)));
        }

        // Device variables
        private Sensor _sensor;
        private Device _device;
        //private Keyboard _keyboard;

        /// <summary>
        /// Private constructor, prevents a default instance of the <see cref="SpaceNavigatorWindows" /> class from being created.
        /// </summary>
        private SpaceNavigatorWindows()
        {
            try
            {
                if (_device == null)
                {
                    _device = new DeviceClass();
                    _sensor = _device.Sensor;
                    //_keyboard = _device.Keyboard;
                }
                if (!_device.IsConnected)
                    _device.Connect();
            }
            catch (COMException ex)
            {
                Debug.LogError(ex.ToString());
            }
        }

        public static SpaceNavigatorWindows SubInstance
        {
            get { return _subInstance ?? (_subInstance = new SpaceNavigatorWindows()); }
        }
        private static SpaceNavigatorWindows _subInstance;

        public override void Dispose()
        {
            try
            {
                if (_device != null && _device.IsConnected)
                {
                    _device.Disconnect();
                    _subInstance = null;
                    GC.Collect();
                }
            }
            catch (COMException ex)
            {
                Debug.LogError(ex.ToString());
            }
        }
    }
#endif    // UNITY_EDITOR_WIN || UNITY_STANDALONE_WIN
}