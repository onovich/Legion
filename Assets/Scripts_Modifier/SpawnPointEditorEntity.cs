#if UNITY_EDITOR
using UnityEngine;

namespace Legion.Modifier {

    public class SpawnPointEditorEntity : MonoBehaviour {

        public void Rename() {
            this.gameObject.name = "Spawn Point";
        }

        public Vector2 GetPos() {
            return transform.position;
        }

    }

}
#endif