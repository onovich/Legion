#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using TriInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Legion.Modifier {

    public class MapEditorEntity : MonoBehaviour {

        [SerializeField] int typeID;
        [SerializeField] GameObject mapSize;
        [SerializeField] MapTM mapTM;
        [SerializeField] Transform roleGroup;
        [SerializeField] Transform spawnPointGroup;
        [SerializeField] Vector2 cameraConfinerWorldMax;
        [SerializeField] Vector2 cameraConfinerWorldMin;

        IndexService indexService;

        [Button("Bake")]
        void Bake() {
            indexService = new IndexService();
            indexService.ResetIndex();
            BakeMapInfo();
            BakeRole();
            BakeSpawnPoint();

            AddressableHelper.SetAddressable(this, "TM_Map", "TM_Map", true);
            EditorUtility.SetDirty(mapTM);
            AssetDatabase.SaveAssets();
            Debug.Log("Bake Sucess");
        }

        void BakeMapInfo() {
            mapTM.typeID = typeID;
            mapTM.mapSize = mapSize.transform.localScale.RoundToVector2Int();
            mapTM.mapPos = mapSize.transform.localPosition.RoundToVector2Int();
            mapSize.transform.localScale = mapTM.mapSize.ToVector3Int();
            mapSize.transform.localPosition = mapTM.mapPos.ToVector3Int();
        }

        void BakeRole() {
            List<RoleTM> roleTMList = new List<RoleTM>();
            List<Vector2> roleSpawnPosList = new List<Vector2>();
            var roleEditors = roleGroup.GetComponentsInChildren<RoleEditorEntity>();
            if (roleEditors == null) {
                Debug.Log("BlockEditors Not Found");
            }
            for (int i = 0; i < roleEditors.Length; i++) {
                var editor = roleEditors[i];

                var tm = editor.roleTM;
                roleTMList.Add(tm);

                var pos = editor.GetPos();
                roleSpawnPosList.Add(pos);

                var index = indexService.PickBlockIndex();
                editor.index = index;
                editor.Rename();
            }
            mapTM.npcRoles = roleTMList.ToArray();
            mapTM.npcSpawnPoints = roleSpawnPosList.ToArray();
        }

        void BakeSpawnPoint() {
            var editor = spawnPointGroup.GetComponent<SpawnPointEditorEntity>();
            if (editor == null) {
                Debug.Log("SpawnPointEditor Not Found");
            }
            editor.Rename();
            var pos = editor.GetPos();
            mapTM.SpawnPoint = pos;
        }

        void OnDrawGizmos() {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube((cameraConfinerWorldMax + cameraConfinerWorldMin) / 2, cameraConfinerWorldMax - cameraConfinerWorldMin);
        }

    }

}
#endif