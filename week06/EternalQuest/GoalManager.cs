using System.Text;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    private int _level;
    private readonly int _pointsPerLevel = 100; // Points needed to level up

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
        _level = 1;
    }

    private void UpdateLevel(int previousScore)
    {
        int oldLevel = previousScore / _pointsPerLevel + 1;
        int newLevel = _score / _pointsPerLevel + 1;
        
        if (newLevel > oldLevel)
        {
            _level = newLevel;
            Console.WriteLine($"\n🎉 LEVEL UP! 🎉");
            Console.WriteLine($"Congratulations! You've reached level {_level}!");
            Console.WriteLine($"Keep going! Next level at {_level * _pointsPerLevel} points.");
        }
    }

    public void Start()
    {

        string choice = "";

        while (choice != "6")
        {
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
            Console.Write("Select a choice from the menu: ");

            choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\n=== Player Status ===");
        Console.WriteLine($"Level: {_level}");
        Console.WriteLine($"Points: {_score}");
        Console.WriteLine($"Points needed for next level: {(_level * _pointsPerLevel) - _score}");
        Console.WriteLine($"==================");
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("\nThe goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine("\nThe types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();
        
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        
        Console.Write("What is the amount of points associated with this goal? ");
        string points = Console.ReadLine();

        Goal goal;
        switch (choice)
        {
            case "1":
                goal = new SimpleGoal(name, description, points);
                break;
            case "2":
                goal = new EternalGoal(name, description, points);
                break;
            case "3":
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                goal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid goal type.");
                return;
        }

        _goals.Add(goal);
    }

    public void RecordEvent()
    {
        Console.WriteLine("\nThe goals are:");
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
        {
            Goal goal = _goals[index - 1];
            int previousScore = _score;
            
            goal.RecordEvent();
            int points = goal.GetPoints();
            _score += points;
            
            Console.WriteLine($"\n⭐ Congratulations! You have earned {points} points!");
            
            if (goal is ChecklistGoal checklistGoal && checklistGoal.IsComplete())
            {
                int bonus = checklistGoal.GetBonus();
                _score += bonus;
                Console.WriteLine($"🎯 BONUS! You have earned an additional {bonus} points!");
            }
            
            UpdateLevel(previousScore);
            Console.WriteLine($"\nTotal points: {_score}");
        }
        else
        {
            Console.WriteLine("Invalid goal number.");
        }
    }

    public void SaveGoals()
    {
        Console.Write("\nWhat is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"{_score},{_level}");
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals()
    {
        Console.Write("\nWhat is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);

        if (lines.Length > 0)
        {
            string[] scoreAndLevel = lines[0].Split(',');
            _score = int.Parse(scoreAndLevel[0]);
            _level = scoreAndLevel.Length > 1 ? int.Parse(scoreAndLevel[1]) : _score / _pointsPerLevel + 1;

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                if (parts.Length != 2) continue;

                string goalType = parts[0];
                string[] goalData = parts[1].Split(',');

                Goal goal = null;
                switch (goalType)
                {
                    case "SimpleGoal":
                        if (goalData.Length >= 4)
                        {
                            goal = new SimpleGoal(goalData[0], goalData[1], goalData[2]);
                            if (bool.Parse(goalData[3]))
                                goal.RecordEvent();
                        }
                        break;

                    case "EternalGoal":
                        if (goalData.Length >= 3)
                        {
                            goal = new EternalGoal(goalData[0], goalData[1], goalData[2]);
                        }
                        break;

                    case "ChecklistGoal":
                        if (goalData.Length >= 6)
                        {
                            goal = new ChecklistGoal(goalData[0], goalData[1], goalData[2],
                                int.Parse(goalData[3]), int.Parse(goalData[4]));
                            
                            int completedCount = int.Parse(goalData[5]);
                            for (int j = 0; j < completedCount; j++)
                            {
                                goal.RecordEvent();
                            }
                        }
                        break;
                }

                if (goal != null)
                {
                    _goals.Add(goal);
                }
            }
        }
    }
} 