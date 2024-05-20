using System;
using UnityEngine;

namespace Legion {

    [CreateAssetMenu(fileName = "SO_Role", menuName = "Legion/RoleTM")]
    public class RoleTM : ScriptableObject {

        public int typeID;
        public AllyStatus allyStatus;
        public AIType aiType;

        public float moveSpeed;

        public int hp;

        public Sprite mesh;
        public GameObject deadVFX;
        public float deadVFXDuration;

#if UNITY_EDITOR

        [ContextMenu("Set AA")]
        public void SetAA() {
            AddressableHelper.SetAddressable(this, "TM_Role", "TM_Role", true);
        }
#endif

    }

}