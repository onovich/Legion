using System.Collections.Generic;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Legion {

    public class TemplateInfraContext {

        GameConfig config;
        public AsyncOperationHandle configHandle;

        Dictionary<int, MapTM> mapDict;
        public AsyncOperationHandle mapHandle;

        Dictionary<int, RoleTM> roleDict;
        public AsyncOperationHandle roleHandle;

        Dictionary<int, BulletTM> bulletDict;
        public AsyncOperationHandle bulletHandle;

        Dictionary<int, SkillTM> skillDict;
        public AsyncOperationHandle skillHandle;

        Dictionary<int, BuffTM> buffDict;
        public AsyncOperationHandle buffHandle;

        public TemplateInfraContext() {
            mapDict = new Dictionary<int, MapTM>();
            roleDict = new Dictionary<int, RoleTM>();
            bulletDict = new Dictionary<int, BulletTM>();
            skillDict = new Dictionary<int, SkillTM>();
            buffDict = new Dictionary<int, BuffTM>();
        }

        // Game
        public void Config_Set(GameConfig config) {
            this.config = config;
        }

        public GameConfig Config_Get() {
            return config;
        }

        // Map
        public void Map_Add(MapTM map) {
            mapDict.Add(map.typeID, map);
        }

        public bool Map_TryGet(int typeID, out MapTM map) {
            var has = mapDict.TryGetValue(typeID, out map);
            if (!has) {
                GLog.LogError($"Map {typeID} not found");
            }
            return has;
        }

        // Role
        public void Role_Add(RoleTM role) {
            roleDict.Add(role.typeID, role);
        }

        public bool Role_TryGet(int typeID, out RoleTM role) {
            var has = roleDict.TryGetValue(typeID, out role);
            if (!has) {
                GLog.LogError($"Role {typeID} not found");
            }
            return has;
        }

        // Bullet
        public void Bullet_Add(BulletTM bullet) {
            bulletDict.Add(bullet.typeID, bullet);
        }

        public bool Bullet_TryGet(int typeID, out BulletTM bullet) {
            var has = bulletDict.TryGetValue(typeID, out bullet);
            if (!has) {
                GLog.LogError($"Bullet {typeID} not found");
            }
            return has;
        }

        // Skill
        public void Skill_Add(SkillTM skill) {
            skillDict.Add(skill.typeID, skill);
        }

        public bool Skill_TryGet(int typeID, out SkillTM skill) {
            var has = skillDict.TryGetValue(typeID, out skill);
            if (!has) {
                GLog.LogError($"Skill {typeID} not found");
            }
            return has;
        }

        // Buff
        public void Buff_Add(BuffTM buff) {
            buffDict.Add(buff.typeID, buff);
        }

        public bool Buff_TryGet(int typeID, out BuffTM buff) {
            var has = buffDict.TryGetValue(typeID, out buff);
            if (!has) {
                GLog.LogError($"Buff {typeID} not found");
            }
            return has;
        }

        // Clear
        public void Clear() {
            mapDict.Clear();
            roleDict.Clear();
            bulletDict.Clear();
            skillDict.Clear();
            buffDict.Clear();
        }

    }

}