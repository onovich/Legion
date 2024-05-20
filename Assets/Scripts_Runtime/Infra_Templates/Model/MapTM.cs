using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Legion {

    [CreateAssetMenu(fileName = "SO_Map", menuName = "Legion/MapTM")]
    public class MapTM : ScriptableObject {

        public int typeID;

        public Vector2Int mapSize;
        public Vector2Int mapPos;

        // Player Role Spawn 
        public Vector2 SpawnPoint;

        // NPC Role Spawn
        public RoleTM[] npcRoles;
        public Vector2[] npcSpawnPoints;

        // Camera
        public Vector2 cameraConfinerWorldMax;
        public Vector2 cameraConfinerWorldMin;

    }

}