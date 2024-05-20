using System;
using UnityEngine;

namespace Legion {

    [CreateAssetMenu(fileName = "SO_Skill", menuName = "Legion/SkillTM")]
    public class SkillTM : ScriptableObject {

        public int typeID;
        public int level;
        public string typeName;
        public string desc;

        public float cdMax;

        public SkillCastType castType;

        public float preCastSec;
        public float castingMaintainSec;
        public float castingIntervalSec;
        public float endCastSec;

        public bool hasCastBullet;
        public int castBulletTypeID;

        public Sprite icon;

#if UNITY_EDITOR

        [ContextMenu("Set AA")]
        public void SetAA() {
            AddressableHelper.SetAddressable(this, "TM_Skill", "TM_Skill", true);
        }
#endif

    }

}