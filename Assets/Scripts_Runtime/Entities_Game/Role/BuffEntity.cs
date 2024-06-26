using UnityEngine;

namespace Legion {

    public class BuffEntity {

        public int entityID;
        public int typeID;
        public int level;

        public float lifeTimer;
        public float lifeSecMax;

        public bool hasDot;
        public float dotIntervalSec;
        public float dotIntervalTimer;
        public int dotAtk;

        public bool hasIce;
        public float iceSlowRate;
        public bool hasIceImpact;
        public int iceImpactNeecCount;
        public int iceImpactAtk;

        public bool IsDead => lifeTimer <= 0;

        public BuffEntity() { }

        public void Reuse() {

        }

        public void Release() {

        }

        public void TimeTick(float dt) {
            lifeTimer -= dt;
            if (lifeTimer < 0) {
                lifeTimer = 0;
            }

            if (hasDot) {
                dotIntervalTimer -= dt;
                if (dotIntervalTimer <= 0) {
                    dotIntervalTimer = 0;
                }
            }
        }

    }

}