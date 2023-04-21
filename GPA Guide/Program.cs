using System;

namespace test
{
    class Program
    {
        public static void Main(string[] args)
        {
            int TwoHoursSubjectsNum, ThreeHoursSubjectsNum, HoursDone;
            double CurrentTotalGpa;

            Console.Write("Number Of Registered 2 Hours Subjects: ");
            TwoHoursSubjectsNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Number Of Registered 3 Hours Subjects: ");
            ThreeHoursSubjectsNum = Convert.ToInt32(Console.ReadLine());
            Console.Write("Hours Done: ");
            HoursDone = Convert.ToInt32(Console.ReadLine());
            Console.Write("Current Total Gpa: ");
            CurrentTotalGpa = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine();
            

            int SubjectsNum = TwoHoursSubjectsNum + ThreeHoursSubjectsNum;
            int SemesterHours = (TwoHoursSubjectsNum * 2) + (ThreeHoursSubjectsNum * 3);
            int TotalHours = HoursDone + SemesterHours;
            double CurrentTotalPoints = CurrentTotalGpa * HoursDone;

            SemesterTargets("Excellent", 3.4, CurrentTotalGpa, TwoHoursSubjectsNum, ThreeHoursSubjectsNum, TotalHours, CurrentTotalPoints, SemesterHours);
            SemesterTargets("Very Good", 2.8, CurrentTotalGpa, TwoHoursSubjectsNum, ThreeHoursSubjectsNum, TotalHours, CurrentTotalPoints, SemesterHours);
            SemesterTargets("Good", 2.4, CurrentTotalGpa, TwoHoursSubjectsNum, ThreeHoursSubjectsNum, TotalHours, CurrentTotalPoints, SemesterHours);
            SemesterTargets("Pass", 2.0, CurrentTotalGpa, TwoHoursSubjectsNum, ThreeHoursSubjectsNum, TotalHours, CurrentTotalPoints, SemesterHours);
            SemesterTargets("Weak", 1.4, CurrentTotalGpa, TwoHoursSubjectsNum, ThreeHoursSubjectsNum, TotalHours, CurrentTotalPoints, SemesterHours);

            //to save your gpa
            
            string SaveGpa = SubjectGrade(SubjectPoints(SemesterPointsCalculator(TotalHours, CurrentTotalPoints, CurrentTotalGpa), TwoHoursSubjectsNum, ThreeHoursSubjectsNum));
            Console.Write("You have to get ");
            if (TwoHoursSubjectsNum != 0)
            {
                Console.Write("(A) minimum for 2 Hours subjects and ");

            }
            Console.WriteLine("({0}) minimum for 3 Hours subjects to save your gpa", SaveGpa);

            //Console.WriteLine("\nYou have to get (A) minimum for 2 Hours subjects and ({0}) for 3 Hours subjects to save your GPA\nAnd your total GPA will be: \nAnd the semester GPA will be:  ", SaveGpa);

        }
        public static void SemesterTargets(string TargetGpaGrade, double TargetGpa,double CurrentTotalGpa, int TwoHoursSubjectsNum,int ThreeHoursSubjectsNum, int TotalHours, double CurrentTotalPoints, int SemesterHours)
        {
            if (CurrentTotalGpa < TargetGpa)
            {
                

                if (MaxPointsTest(TwoHoursSubjectsNum, ThreeHoursSubjectsNum, SemesterPointsCalculator(TotalHours, CurrentTotalPoints, TargetGpa), SemesterHours) == 1)
                {

                    PrintSuccess(TargetGpaGrade, SubjectGrade(SubjectPoints(SemesterPointsCalculator(TotalHours, CurrentTotalPoints, TargetGpa), TwoHoursSubjectsNum, ThreeHoursSubjectsNum)), TwoHoursSubjectsNum);
                }
                else
                {
                    PrintFaild(TargetGpaGrade);
                }

            }
        }
        public static int MaxPointsTest(int TwoHoursSubjectsNum,int ThreeHoursSubjectsNum,double SemesterPoints,int SemesterHours)
        {
            double MaxSemesterPoints = ((TwoHoursSubjectsNum * (2 * 4)) + (ThreeHoursSubjectsNum * (3 * 4)));
            if (SemesterPoints <= MaxSemesterPoints)
            {
                return 1;
            }

            return 0;

        }
        public static double SemesterPointsCalculator(int TotalHours, double CurrentTotalPoints, double TargetGpa)
        {
            double SemesterPoints = (TargetGpa * TotalHours) -  CurrentTotalPoints ;  
            return SemesterPoints;


        }
        public static string SubjectGrade( double SubjectPoints)
        {

            if (SubjectPoints > 3.75 && SubjectPoints <= 4)
            {
                return "A+";
            }
            else if (SubjectPoints > 3.4 && SubjectPoints <= 3.75)
            {
                return "A";

            }
            else if (SubjectPoints > 3.1 && SubjectPoints <= 3.4)
            {
                return "B+";

            }
            else if (SubjectPoints > 2.8 && SubjectPoints <= 3.1)
            {
                return "B";

            }
            else if (SubjectPoints > 2.5 && SubjectPoints <= 2.8)
            {
                return "C+";

            }
            else if (SubjectPoints > 2.25 && SubjectPoints <= 2.5)
            {
                return "C";
            }
            else if (SubjectPoints > 2 && SubjectPoints <= 2.25)
            {
                return "D+";

            }
            else if (SubjectPoints > 0 && SubjectPoints <= 2)
            {
                return "D";

            }
            else
            {
                return "Error";
            }

        }
        public static double SubjectPoints(double SemesterPoints, int TwoHoursSubjectsNum, int ThreeHoursSubjectsNum)
        {
            double SubjectPoints = (SemesterPoints - (2 * 3.75 * TwoHoursSubjectsNum)) / (3 * ThreeHoursSubjectsNum);
            return SubjectPoints;

        }
        public static void PrintSuccess(string OverallGrade,string SubjectGrade,int TwoHoursSubjectsNum)
        {
            
            Console.Write("If You Want Get {0} this semester ", OverallGrade);
            if (TwoHoursSubjectsNum != 0)
            {
                Console.Write("(A) minimum for 2 Hours subjects and ");

            }
            Console.WriteLine("You have to get ({0}) minimum for 3 Hours subjects", SubjectGrade);
                
        }
        public static void PrintFaild(string Grade)
        {
            Console.WriteLine("You Can't reach {0} this semester", Grade);
        }
    }
}