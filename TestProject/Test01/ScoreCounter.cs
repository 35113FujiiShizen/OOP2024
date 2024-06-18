using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test01 {
    class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }


        //メソッドの概要：StudentScoreを読み込み、Studentオブジェクトのリストを返す
        private static IEnumerable<Student> ReadScore(string filePath) {
            var Scores = new List<Student>();
            var lines = File.ReadAllLines(filePath);

            foreach (String line in lines) {
                var items = line.Split(',');
                var student = new Student {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2])
                };
                Scores.Add(student);
            }
            return Scores;
        }

        //メソッドの概要：生徒別の点数を求める
        public IDictionary<string, int> GetPerStudentScore() {

            var dict = new Dictionary<string, int>();
            foreach (Student student in _score) {
                if (dict.ContainsKey(student.Name))
                    dict[student.Name] += student.Score;
                else
                    dict[student.Name] = student.Score;
            }
            return dict;
        }
    }
}
