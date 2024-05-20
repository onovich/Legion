using System;
using UnityEngine;

namespace Legion {

    [CreateAssetMenu(fileName = "SO_Bullet", menuName = "Legion/BulletTM")]
    public class BulletTM : ScriptableObject {

        public int typeID;
        public int level;

        public BulletFlyType flyType;
        public float searchRangeIfTrack;
        public float flySpeed;
        public float radius;

        public int atk;

        public int crossTimes;
        public float lifeSec;

        public Sprite spr;

        public EffectorTM hitEffector;

#if UNITY_EDITOR

        [ContextMenu("Set AA")]
        public void SetAA() {
            AddressableHelper.SetAddressable(this, "TM_Bullet", "TM_Bullet", true);
        }
#endif

    }

}