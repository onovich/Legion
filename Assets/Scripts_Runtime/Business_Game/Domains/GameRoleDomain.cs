using UnityEngine;

namespace Legion {

    public static class GameRoleDomain {

        public static RoleEntity Spawn(GameBusinessContext ctx, int typeID, Vector2 pos) {
            var role = GameFactory.Role_Spawn(ctx.templateInfraContext,
                                              ctx.assetsInfraContext,
                                              ctx.idRecordService,
                                              typeID,
                                              pos);
            role.OnBodyTriggerEnterHandle += (RoleEntity role, Collider2D other) => {
                OnBodyTriggerEnter(ctx, role, other);
            };
            ctx.roleRepo.Add(role);
            return role;
        }

        public static void CheckAndUnSpawn(GameBusinessContext ctx, RoleEntity role) {
            if (role.needTearDown) {
                UnSpawn(ctx, role);
            }
        }

        public static void UnSpawn(GameBusinessContext ctx, RoleEntity role) {
            ctx.roleRepo.Remove(role);
            role.TearDown();
        }

        public static void BoxCastBullet(GameBusinessContext ctx, RoleEntity role) {
            var pos = role.Pos;
            var size = new Vector2(1.6f, 0.2f);
            var dir = Vector2.zero;
            LayerMask layer = 1 << LayConst.BULLET;

            var hitResults = ctx.hitResults;
            var hitCount = Physics2D.BoxCastNonAlloc(pos, size, 0, dir, hitResults, 0f, layer);
            Debug.DrawRay(pos + new Vector2(-0.8f, 0f), new Vector2(0.8f, 0f), Color.red);
            for (int i = 0; i < hitCount; i++) {
                var hit = hitResults[i];
                var hitGo = hit.collider.gameObject;
                if (hitGo.CompareTag(TagConst.BULLET)) {
                    OnBodyEnterBullet(ctx, role, hit.collider);
                }
            }
        }

        static void OnBodyEnterBullet(GameBusinessContext ctx, RoleEntity role, Collider2D other) {
        }

        static void OnBodyTriggerEnter(GameBusinessContext gameContext, RoleEntity role, Collider2D other) {
        }

        public static void ApplyMove(GameBusinessContext ctx, RoleEntity role, float dt) {
            role.Move_ApplyMove(dt);
        }

        public static void ApplyConstraint(GameBusinessContext ctx, RoleEntity role, float dt) {
            var map = ctx.currentMapEntity;
            var size = map.mapSize.ToVector3Int();
            var center = map.transform.position;
            var min = center - size / 2;
            var max = center + size / 2;
            var pos = role.Pos;
            if (pos.x < min.x || pos.x > max.x || pos.y < min.y || pos.y > max.y) {
                role.Attr_DeadlyHurt();
                Debug.Log($"Dead: pos = {pos}, min = {min}, max = {max}, center = {center}, size = {size}");
            }
        }

    }

}