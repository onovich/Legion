using System;
using UnityEngine;

namespace Legion {

    [CreateAssetMenu(fileName = "SO_Buff", menuName = "Legion/BuffTM")]
    public class BuffTM : ScriptableObject {

        public int typeID;
        public int level;
        public string typeName;
        public string desc;

        public float lifeSec;

        public bool hasDot;
        public float dotIntervalSec;
        public int dotAtk;

#if UNITY_EDITOR

        [ContextMenu("Set AA")]
        public void SetAA() {
            AddressableHelper.SetAddressable(this, "TM_Buff", "TM_Buff", true);
        }
#endif

    }

}