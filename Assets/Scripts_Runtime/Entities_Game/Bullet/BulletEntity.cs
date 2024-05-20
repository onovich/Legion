using UnityEngine;

namespace Legion {

    public class BulletEntity : MonoBehaviour {

        public int entityID;
        public int typeID;
        public int level;
        public AllyStatus allyStatus;

        public bool hasTarget;
        public int casterEntityID;
        public int targetEntityID;

        public BulletFlyType flyType;
        public float flySpeed;
        public float radius;
        public int atk;
        public int crossTimes;
        public float lifeSec;
        public float searchRangeIfTrack;
        public float trackFlyPreSec;

        public Vector2 fromPos;
        public Vector2 pos;
        public Vector2 targetPos;
        public Vector2 dir;

        public EffectorModel hitEffector;

        public bool IsDead => crossTimes <= 0 || lifeSec <= 0;

        [SerializeField] SpriteRenderer sr;

        public void Ctor() {
            gameObject.SetActive(false);
        }

        public void Reuse() {
            gameObject.SetActive(true);
        }

        public void Release() {
            gameObject.SetActive(false);
        }

        public void TearDown() {
            Release();
            Destroy(gameObject);
        }

        public void Pos_UpdatePos() {
            transform.position = new Vector2(pos.x, pos.y);
            transform.right = dir;
        }

        public Vector2Int Pos_GetPosInt() {
            return new Vector2Int(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));
        }

        public void Pos_UpdateFace() {
            transform.right = dir;
        }

        public void Show() {
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }

        public void SR_SetSprite(Sprite sprite) {
            sr.sprite = sprite;
        }

#if UNITY_EDITOR

        [ContextMenu("Set AA")]
        public void SetAA() {
            AddressableHelper.SetAddressable(this, "Entity", "Entity", true);
        }
#endif

    }

}