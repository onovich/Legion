namespace Legion {

    public class SkillEntity {

        public int entityID;
        public int typeID;
        public int level;
        public string name;
        public string desc;

        public float cd;
        public float cdMax;

        public SkillCastType castType;
        public float aimRange;

        // Stage
        public bool isAutoCast;
        public float preCastSecMax;
        public float castingMaintainSecMax;
        public float castingIntervalSecMax;
        public float endCastSecMax;

        // Bullet
        public bool hasCastBullet;
        public int castBulletTypeID;

        public bool hasDestroySelf;

        public SkillEntity() { }

        public void Reuse() {

        }

        public void Release() {
            
        }

        public void CD_ResetTimer() {
            cd = cdMax;
        }

    }

}