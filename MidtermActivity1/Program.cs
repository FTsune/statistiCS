using System;
using System.Collections.Generic;
using System.Linq;
using ClassLibrary1;
using StatisticsLibrary;

namespace MidtermActivity1
{
	public class Program
	{
		public static void CentralTendencies(string term, IEnumerable<double> grades)
		{
			var stats = new StatisticsModel(grades);

			Console.WriteLine(term);
			Console.WriteLine("Mean: " + stats.CalculateMean());
			Console.WriteLine("Median: " + stats.CalculateMedian());
			Console.WriteLine("Mode: " + stats.CalculateMode());
			Console.WriteLine("Variance: " + stats.CalculateVariance());
			Console.WriteLine("Standard Deviation: " + stats.GetStandardDeviation());
			Console.WriteLine("Range: " + stats.CalculateRange());
			Console.WriteLine();
		}

		public static void Main()
		{
			List<Student> students = new List<Student>
		{
			new Student() {StudentName = "Student A", PrelimGrade = 78.88, MidtermGrade = 85.00, FinalGrade = 100.00} ,
			new Student() {StudentName = "Student B", PrelimGrade = 56.76, MidtermGrade = 98.00, FinalGrade = 100.00} ,
			new Student() {StudentName = "Student C", PrelimGrade = 98.00, MidtermGrade = 87.92, FinalGrade = 99.00} ,
			new Student() {StudentName = "Student D", PrelimGrade = 87.98, MidtermGrade = 85.00, FinalGrade = 98.00} ,
			new Student() {StudentName = "Student E", PrelimGrade = 89.00, MidtermGrade = 90.15, FinalGrade = 97.00} ,
			new Student() {StudentName = "Student F", PrelimGrade = 90.00, MidtermGrade = 90.11, FinalGrade = 89.90}
		};

			CentralTendencies("PRELIMS", students.Select(s => s.PrelimGrade));
			CentralTendencies("MIDTERMS", students.Select(s => s.MidtermGrade));
			CentralTendencies("FINALS", students.Select(s => s.FinalGrade));

			Console.WriteLine("STUDENT FINAL AVERAGES");
			var statistics = new StatisticsModel(null);
			foreach (var student in students)
			{
				var finalAverage = statistics.CalculateFinalAve(student);
				Console.WriteLine($"{student.StudentName}: {finalAverage}");
			}
		}
	}
}
