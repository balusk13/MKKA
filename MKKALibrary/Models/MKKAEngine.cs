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
        List<DanRanking> rankings;
        List<Kata> katas;
        List<BoardMember> board;
        List<Setting> settings;
        DBAccessor db;
        QuestionGenerator gen;
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
        private void LoadDB()
        {
            LoadBoardMembers();
            LoadDanRankings();
            LoadKatas();
            LoadSettings();
        }

        private void LoadSettings()
        {
            settings = db.GetSettings();
        }

        private void LoadKatas()
        {
            List<string> klist = db.GetKataList();
            foreach (var kataName in klist)
            {
                katas.Add(new Kata(kataName));
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
            return gen.GenKataQuestion(ref katas, ref settings);
        }
        public Trivia GetBoardDanQuestion()
        {
            return gen.GenBoardDanQuestion(ref katas, ref settings);
        }

    }
}
