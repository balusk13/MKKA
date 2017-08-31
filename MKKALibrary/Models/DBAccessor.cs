
using MKKA;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MKKA
{
    internal class DBAccessor
    {
        public DBAccessor()
        {
        }
        private const string moves = "KataMoves";
        private const string groups = "KataGroups";
        private const string board = "BoardMembers";
        private const string settings = "Setting";
        private const string dan = "DanRankings";
        private const string db = "Karate.db";

        private const string settingdb = "Setting.db";
        SQLiteConnection conn;
        SQLiteConnection settingConn;
        string error;
        private SQLiteConnection getConn()
        {
            try
            {
                if (conn == null)
                {
                    string newPath = GetDatabasePath();
                    conn = new SQLiteConnection(newPath);
                    var info = conn.GetTableInfo(dan);
                    info.Clear();
                }
                return conn; 
                }
            catch(Exception e)
            {
                error = e.Message;   
            }
            return conn;
        }
        private SQLiteConnection getSettingConn()
        {
            try
            {
                if (settingConn == null)
                {
                    var dbConn = getConn();
                    string newPath = GetSettingsPath();
                    settingConn = new SQLiteConnection(newPath);
                    var info = settingConn.GetTableInfo(settings);
                    if (info.Count == 0)
                    {
                        InitializeSettings();
                    }
                }
                return settingConn;
            }
            catch (Exception e)
            {
                error = e.Message;
            }
            return settingConn;
        }

        private void InitializeSettings()
        {
            var newSettings = new List<Setting>();
            Setting tmp = new Setting();
            tmp.SettingKey = SettingKeyEnum.usingKataGroup1;
            tmp.SettingType = SettingTypeEnum.settingTypeBool;
            tmp.SettingValue = "1";
            newSettings.Add(tmp);

            tmp = new Setting();
            tmp.SettingKey = SettingKeyEnum.usingKataGroup2;
            tmp.SettingType = SettingTypeEnum.settingTypeBool;
            tmp.SettingValue = "1";
            newSettings.Add(tmp);

            tmp = new Setting();
            tmp.SettingKey = SettingKeyEnum.usingKataGroup3;
            tmp.SettingType = SettingTypeEnum.settingTypeBool;
            tmp.SettingValue = "1";
            newSettings.Add(tmp);

            tmp = new Setting();
            tmp.SettingKey = SettingKeyEnum.usingKataGroup4;
            tmp.SettingType = SettingTypeEnum.settingTypeBool;
            tmp.SettingValue = "1";
            newSettings.Add(tmp);

            tmp = new Setting();
            tmp.SettingKey = SettingKeyEnum.usingKataGroup5;
            tmp.SettingType = SettingTypeEnum.settingTypeBool;
            tmp.SettingValue = "1";
            newSettings.Add(tmp);

            tmp = new Setting();
            tmp.SettingKey = SettingKeyEnum.usingKataGroup6;
            tmp.SettingType = SettingTypeEnum.settingTypeBool;
            tmp.SettingValue = "1";
            newSettings.Add(tmp);

            tmp = new Setting();
            tmp.SettingKey = SettingKeyEnum.secondsBetweenCallouts;
            tmp.SettingType = SettingTypeEnum.settingTypeFloat;
            tmp.SettingValue = "5.0";
            newSettings.Add(tmp);

            tmp = new Setting();
            tmp.SettingKey = SettingKeyEnum.leftRightSwitch;
            tmp.SettingType = SettingTypeEnum.settingTypeBool;
            tmp.SettingValue = "1";
            newSettings.Add(tmp);

            tmp = new Setting();
            tmp.SettingKey = SettingKeyEnum.leftRightFrequency;
            tmp.SettingType = SettingTypeEnum.settingTypePercentage;
            tmp.SettingValue = "5";
            newSettings.Add(tmp);

            settingConn.CreateTable<Setting>();
            settingConn.InsertAll(newSettings);
            var info = settingConn.GetTableInfo(settings);
            info.Clear();
        }

        internal static string GetDatabasePath()
        {
            return DependencyService.Get<IFileHelper>().GetLocalFilePath(db);
        }
        internal static string GetSettingsPath()
        {
            return DependencyService.Get<IFileHelper>().GetLocalFilePath(settingdb);
        }

        public KataMove GetKataMove(string kataID, int orderNumber)
        {
            var conn = getConn();
            var km = conn.Query<KataMove>("SELECT * from " + moves + " where KataID = ? and OrderNumber = ?", kataID, orderNumber);
            return km.First(); 
        }
        public int GetKataSize(string kataID)
        {
            var conn = getConn();
            var kataMoves = conn.Query< List<KataMove>>("SELECT * from " + moves + " where KataID = ?", kataID);
            return kataMoves.Count();
        }

        public List<string> GetKataList()
        {
            
            var ret = new List<string>();
            var conn = getConn();
            var katas = conn.Query<KataGroup>("SELECT * from " + groups);
            foreach (var move in katas)
            {
                ret.Add(move.KataID);
            }
            return ret;
        }

        internal void SetSetting(SettingKeyEnum key, string value)
        {
            var conn = getSettingConn();
            conn.Execute("UPDATE Settings SET SettingValue = ? where SettingKey = ?", value, key);
        }

        public List<string> GetKataList(int groupID)
        {

            var ret = new List<string>();
            var conn = getConn();
            var katas = conn.Query<KataGroup>("SELECT * from " + groups +" WHERE GroupID = ?", groupID);
            foreach (var move in katas)
            {
                ret.Add(move.KataID);
            }
            return ret;
        }
        public List<KataGroup> GetKataGroups()
        {

            var ret = new List<KataGroup>();
            var conn = getConn();
            var groupList = conn.Query<KataGroup>("SELECT * from " + groups);
            foreach (var group in groupList)
            {
                ret.Add(group);
            }
            return ret;
        }
        public List<BoardMember> GetBoardMembers()
        {

            var ret = new List<BoardMember>();
            var conn = getConn();
            var group = conn.Query<BoardMember>("SELECT * from " + board);
            foreach (var member in group)
            {
                ret.Add(member);
            }
            return ret;
        }
        public List<DanRanking> GetDanRankings()
        {

            var ret = new List<DanRanking>();
            var conn = getConn();
            var group = conn.Query<DanRanking>("SELECT * from " + dan);
            foreach (var member in group)
            {
                ret.Add(member);
            }
            return ret;
        }
        public List<Setting> GetSettings()
        {

            var ret = new List<Setting>();
            var conn = getSettingConn();
            var group = conn.Query<Setting>("SELECT * from " + settings);
            foreach (var member in group)
            {
                ret.Add(member);
            }
            return ret;
        }
    }
}
