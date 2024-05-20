using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Legion {

    public class MapEntity : MonoBehaviour {

        public int typeID;
        public Vector2Int mapSize;
        public Vector2Int mapOffset;

        public void Ctor() {
        }

        public void TearDown() {
            Destroy(gameObject);
        }

    }

}