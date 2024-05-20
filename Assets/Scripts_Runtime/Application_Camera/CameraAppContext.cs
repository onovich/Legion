using System;
using System.Threading.Tasks;
using MortiseFrame.Swing;
using TenonKit.Vista.Camera2D;
using UnityEngine;

namespace Legion {

    public class CameraAppContext {

        public TemplateInfraContext templateInfraContext;

        // CameraCore
        public Camera2DCore cameraCore;
        public int mainCameraID;

        public CameraAppContext(Vector2 screenSize) {
            cameraCore = new Camera2DCore(screenSize);
        }

    }

}