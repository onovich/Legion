using System;
using System.Threading.Tasks;
using MortiseFrame.Swing;
using TenonKit.Prism;
using TenonKit.Vista.Camera2D;
using UnityEngine;

namespace Legion {

    public static class CameraApp {

        public static void Init(CameraAppContext ctx, Vector2 pos, float rot, float size, float aspect, Vector2 confinerWorldMax, Vector2 confinerWorldMin, Vector2 driverPos) {
            var cameraID = CreateMainCamera(ctx, pos, rot, size, aspect, confinerWorldMax, confinerWorldMin, driverPos);
            SetCurrentCamera(ctx, cameraID);
            var config = ctx.templateInfraContext.Config_Get();
            var deadZoneNormalizedSize = config.cameraDeadZoneNormalizedSize;

            SetDeadZone(ctx, deadZoneNormalizedSize);
            EnableDeadZone(ctx, true);
            SetMoveByDriver(ctx);
        }

        public static Vector2 LateTickPos(CameraAppContext ctx, float dt) {
            return ctx.cameraCore.Tick(dt);
        }

        public static void RecordDriverPos(CameraAppContext ctx, Vector2 driverPos) {
            ctx.cameraCore.RecordDriverPos(ctx.mainCameraID, driverPos);
        }

        public static void ShakeOnce(CameraAppContext ctx, int cameraID) {
            var config = ctx.templateInfraContext.Config_Get();
            var shakeFrequency = config.roleDeadShakeFrequency;
            var shakeAmplitude = config.roleDeadShakeAmplitude;
            var shakeDuration = config.roleDeadShakeDuration;
            var shakeEasingType = config.roleDeadShakeEasingType;
            var shakeEasingMode = config.roleDeadShakeEasingMode;
            ctx.cameraCore.ShakeOnce(cameraID, shakeFrequency, shakeAmplitude, shakeDuration, shakeEasingType, shakeEasingMode);
        }

        // Camera
        public static int CreateMainCamera(CameraAppContext ctx, Vector2 pos, float rot, float size, float aspect, Vector2 confinerWorldMax, Vector2 confinerWorldMin, Vector2 driverPos) {
            ctx.mainCameraID = ctx.cameraCore.CreateCamera2D(pos, rot, size, aspect, confinerWorldMax, confinerWorldMin, driverPos);
            return ctx.mainCameraID;
        }

        public static void SetCurrentCamera(CameraAppContext ctx, int cameraID) {
            ctx.cameraCore.SetCurrentCamera(cameraID);
        }

        // Move
        public static void SetMoveToTarget(CameraAppContext ctx, Vector2 target, float duration, EasingType easingType = EasingType.Linear, EasingMode easingMode = EasingMode.None, System.Action onComplete = null) {
            var mainCameraID = ctx.mainCameraID;
            ctx.cameraCore.SetMoveToTarget(mainCameraID, target, duration, easingType, easingMode, onComplete);
        }

        public static void SetMoveByDriver(CameraAppContext ctx) {
            var mainCameraID = ctx.mainCameraID;
            ctx.cameraCore.SetMoveByDriver(mainCameraID);
        }

        // DeadZone
        public static void SetDeadZone(CameraAppContext ctx, Vector2 normalizedSize) {
            var mainCameraID = ctx.mainCameraID;
            ctx.cameraCore.SetDeadZone(mainCameraID, normalizedSize, Vector2.zero);
        }

        public static void EnableDeadZone(CameraAppContext ctx, bool enable) {
            var mainCameraID = ctx.mainCameraID;
            ctx.cameraCore.EnableDeadZone(mainCameraID, enable);
        }

        // Gizmos
        public static void OnDrawGizmos(CameraAppContext ctx) {
            ctx.cameraCore.DrawGizmos();
        }

    }

}