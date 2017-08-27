using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MKKA
{
    class MKKAEngine
    {
        List<DanRanking> rankings;
        List<Kata> katas;
        List<BoardMember> board;
        List<Setting> settings;
        DBAccessor db;
        QuestionGenerator gen;
        MKKAEngine()
        {
            db = new DBAccessor();
            gen = new QuestionGenerator();
            LoadDB();
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
