using System;
using UnityEngine;

namespace Legion {

    [CreateAssetMenu(fileName = "SO_Effector", menuName = "Legion/EffectorTM")]
    public class EffectorTM : ScriptableObject {

        public GameObject hitVFXPrefab;
        public float hitVFXDuration;
        public AudioClip hitSFX;

        public bool hasHitAttachBuff;
        public int hitAttachBuffTypeID;

        public bool hasImpact;
        public float impactRange;
        public int impactAtk;
        public GameObject impactRangeVFXPrefab;
        public float impactRangeVFXDuration;

        public bool hasImpactAttachBuff;
        public int impactAttachBuffTypeID;

    }

}