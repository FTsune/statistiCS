using System;
using System.Linq;
using System.Collections.Generic;
using ClassLibrary1;

namespace StatisticsLibrary
{
    public class StatisticsModel
    {
        public IEnumerable<double> Grades { get; private set; }

        public StatisticsModel(IEnumerable<double> grades)
        {
            Grades = grades;
        }

        public double CalculateMean()
        {
            return Math.Round(Grades.Average(), 2);
        }

        public double CalculateMedian()
        {
            var sortedGrades = Grades.OrderBy(x => x).ToList();
            var middle1 = sortedGrades[(sortedGrades.Count - 1) / 2];
            var middle2 = sortedGrades[sortedGrades.Count / 2];
            return Math.Round((middle1 + middle2) / 2, 2);
        }

        public double CalculateMode()
        {
            var modeGroup = Grades
            .GroupBy(x => x)
            .OrderByDescending(group => group.Count())
            .FirstOrDefault();

            if (modeGroup == null || modeGroup.Count() == 1)
            {
                return double.NaN;
            }

            return modeGroup.Key;
        }

        public double CalculateVariance()
        {
            var mean = Grades.Average();
            var frequency = Grades.Count();

            var formula = Grades.Sum(x => Math.Pow(x - mean, 2));

            return Math.Round(formula / frequency, 2);
        }

        public double GetStandardDeviation()
        {
            var variance = CalculateVariance();

            return Math.Round(Math.Sqrt(variance), 2);
        }

        public double CalculateRange()
        {
            var upperLimit = Grades.Max();
            var lowerLimit = Grades.Min();

            return Math.Round(upperLimit - lowerLimit, 2);
        }

        public double CalculateFinalAve(Student student)
        {
            return Math.Round((student.PrelimGrade + student.MidtermGrade + student.FinalGrade) / 3, 0);
        }
    }
}
