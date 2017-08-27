using MKKA;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private const string settings = "Settings";
        private const string dan = "DanRankings";
        private const string db = "Karate.db";
        private SQLiteConnection getConn()
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(db);
                return conn;
            }
            catch (SQLiteException ex)
            {
                return null;
            }
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
            var kataMoves = conn.Query<KataMove>("SELECT * from " + moves + " where KataID = ?", kataID);
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
        public List<int> GetKataGroups()
        {

            var ret = new List<int>();
            var conn = getConn();
            var groupList = conn.Query<KataGroup>("SELECT distinct GROUPID from " + groups);
            foreach (var group in groupList)
            {
                ret.Add(group.GroupID);
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
            var conn = getConn();
            var group = conn.Query<Setting>("SELECT * from " + settings);
            foreach (var member in group)
            {
                ret.Add(member);
            }
            return ret;
        }
    }
}
