using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKA
{
    public class MKKAEngine
    {
        private static MKKAEngine mkkaSingleton;
        public List<DanRanking> rankings;
        public List<Kata> katas;
        public List<BoardMember> board;
        List<Setting> settings;
        DBAccessor db;
        QuestionGenerator gen;
        public List<Kata> activeKatas;
        public List<KataGroup> groups;
        private MKKAEngine()
        {
            db = new DBAccessor();
            gen = new QuestionGenerator();
            LoadDB();
        }
        public static MKKAEngine getEngine()
        {
            if (mkkaSingleton == null)
            {
                mkkaSingleton = new MKKAEngine();
            }
            return mkkaSingleton;
        }

        public static string GetDatabasePath()
        {
            return DBAccessor.GetDatabasePath();
        }

        private void LoadDB()
        {
            LoadSettings();
            LoadBoardMembers();
            LoadDanRankings();
            LoadKataGroups();
            LoadKatas();
        }

        private void LoadKataGroups()
        {
            groups = db.GetKataGroups();
        }

        private void LoadSettings()
        {
            var tmp = db.GetSettings();
            settings = tmp;

        }
        public void ChangeSetting(SettingKeyEnum key, string value)
        {
            db.SetSetting(key, value);
            LoadActiveKatas();
        }

        private void LoadKatas()
        {
            katas = new List<Kata>();
            List<string> klist = db.GetKataList();
            foreach (var kataName in klist)
            {
                katas.Add(new Kata(kataName));
            }
            LoadActiveKatas();
        }

        private void LoadActiveKatas()
        {
            if (activeKatas == null)
                activeKatas = new List<Kata>();
            activeKatas.Clear();
            foreach (var kata in katas)
            {
                SettingKeyEnum kGroup = GetGroupEnum(kata);
                string groupUsed = GetSettingValue(kGroup);
                if(groupUsed == "1" )
                {
                    activeKatas.Add(kata);
                }
            }
        }

        public string GetSettingValue(SettingKeyEnum key)
        {
            foreach (var setting in settings)
            {
                if (setting.SettingKey == key)
                    return setting.SettingValue;
            }
            return "";
        }

        private SettingKeyEnum GetGroupEnum(Kata kata)
        {
            int groupID = 0;
            foreach (var group in groups)
            {
                if (group.KataID == kata.Name)
                {
                    groupID = group.GroupID;
                }
            }
            if (groupID == 0)
                return SettingKeyEnum.invalidSetting;
            switch (groupID)
            {
                case 1:
                    return SettingKeyEnum.usingKataGroup1;
                case 2:
                    return SettingKeyEnum.usingKataGroup2;
                case 3:
                    return SettingKeyEnum.usingKataGroup3;
                case 4:
                    return SettingKeyEnum.usingKataGroup4;
                case 5:
                    return SettingKeyEnum.usingKataGroup5;
                default:
                    return SettingKeyEnum.usingKataGroup6;
            }
        }

        private void LoadDanRankings()
        {
            rankings = db.GetDanRankings();
        }

        private void LoadBoardMembers()
        {
            board = db.GetBoardMembers();
        }
        public Trivia GetKataQuestion()
        {
            return gen.GenKataQuestion(this);
        }

        public string GetRandomActiveKata()
        {
            Random r = new Random();
            return activeKatas[r.Next() % activeKatas.Count].Name;
        }

        public Trivia GetBoardDanQuestion()
        {
            return gen.GenBoardDanQuestion(this);
        }

        public Trivia SpecialFunctionX()
        {
            return new Trivia("Go Speed Racer");
        }
    }
}
