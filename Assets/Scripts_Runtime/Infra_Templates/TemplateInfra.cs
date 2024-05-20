using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Legion {

    public static class TemplateInfra {

        public static async Task LoadAssets(TemplateInfraContext ctx) {

            {
                var handle = Addressables.LoadAssetAsync<GameConfig>("TM_Config");
                var cotmfig = await handle.Task;
                ctx.Config_Set(cotmfig);
                ctx.configHandle = handle;
            }

            {
                var handle = Addressables.LoadAssetsAsync<MapTM>("TM_Map", null);
                var mapList = await handle.Task;
                foreach (var tm in mapList) {
                    ctx.Map_Add(tm);
                }
                ctx.mapHandle = handle;
            }

            {
                var handle = Addressables.LoadAssetsAsync<RoleTM>("TM_Role", null);
                var roleList = await handle.Task;
                foreach (var tm in roleList) {
                    ctx.Role_Add(tm);
                }
                ctx.roleHandle = handle;
            }

            {
                var handle = Addressables.LoadAssetsAsync<BulletTM>("TM_Bullet", null);
                var bulletList = await handle.Task;
                foreach (var tm in bulletList) {
                    ctx.Bullet_Add(tm);
                }
                ctx.bulletHandle = handle;
            }

            {
                var handle = Addressables.LoadAssetsAsync<SkillTM>("TM_Skill", null);
                var skillList = await handle.Task;
                foreach (var tm in skillList) {
                    ctx.Skill_Add(tm);
                }
                ctx.skillHandle = handle;
            }

            {
                var handle = Addressables.LoadAssetsAsync<BuffTM>("TM_Buff", null);
                var buffList = await handle.Task;
                foreach (var tm in buffList) {
                    ctx.Buff_Add(tm);
                }
                ctx.buffHandle = handle;
            }

        }

        public static void Release(TemplateInfraContext ctx) {
            if (ctx.configHandle.IsValid()) {
                Addressables.Release(ctx.configHandle);
            }
            if (ctx.mapHandle.IsValid()) {
                Addressables.Release(ctx.mapHandle);
            }
            if (ctx.roleHandle.IsValid()) {
                Addressables.Release(ctx.roleHandle);
            }
            if (ctx.bulletHandle.IsValid()) {
                Addressables.Release(ctx.bulletHandle);
            }
            if (ctx.skillHandle.IsValid()) {
                Addressables.Release(ctx.skillHandle);
            }
            if (ctx.buffHandle.IsValid()) {
                Addressables.Release(ctx.buffHandle);
            }
        }

    }

}