#if UNITY_EDITOR
using UnityEngine;

namespace Legion.Modifier {

    public class RoleEditorEntity : MonoBehaviour {

        [SerializeField] public RoleTM roleTM;
        public int index;

        public void Rename() {
            this.gameObject.name = $"Role - {roleTM.typeID} - {index}";
        }

        public Vector2 GetPos() {
            return transform.position;
        }

    }

}
#endif