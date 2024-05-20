using System;
using System.Collections.Generic;
using UnityEngine;

namespace Legion {

    public class GameBusinessContext {

        // Entity
        public GameEntity gameEntity;
        public PlayerEntity playerEntity;
        public InputEntity inputEntity; // External
        public MapEntity currentMapEntity;

        public RoleRepository roleRepo;

        // App
        public UIAppContext uiContext;
        public VFXAppContext vfxContext;
        public CameraAppContext cameraContext;

        // Camera
        public Camera mainCamera;

        // Service
        public IDRecordService idRecordService;

        // Infra
        public TemplateInfraContext templateInfraContext;
        public AssetsInfraContext assetsInfraContext;

        // Timer
        public float fixedRestSec;

        // SpawnPoint
        public Vector2 ownerSpawnPoint;

        // TEMP
        public RaycastHit2D[] hitResults;

        public GameBusinessContext() {
            gameEntity = new GameEntity();
            playerEntity = new PlayerEntity();
            idRecordService = new IDRecordService();
            roleRepo = new RoleRepository();
            hitResults = new RaycastHit2D[100];
        }

        public void Reset() {
            idRecordService.Reset();
            roleRepo.Clear();
        }

        // Role
        public RoleEntity Role_GetOwner() {
            roleRepo.TryGetRole(playerEntity.ownerRoleEntityID, out var role);
            return role;
        }

    }

}