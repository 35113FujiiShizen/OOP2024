namespace Section01 {
    internal class Employee {
        public string PrefecturalCapital { get; set; }
        public string Prefecture { get; set; }

        public Employee(string prefecture, string prefecturalCapital) {
            Prefecture = prefecture;
            PrefecturalCapital = prefecturalCapital;
        }
    }
}