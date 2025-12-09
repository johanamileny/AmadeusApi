namespace AmadeusApi.Contracts
{
    public class UserAnswerStatsDto
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public int TotalAnswers { get; set; }
        public DateTime LastActivityDate { get; set; }
        public DateTime FirstActivityDate { get; set; }
        public int CompletedSessions { get; set; }
        public List<QuestionAnswerDto> RecentAnswers { get; set; } = new();
    }

    public class QuestionAnswerDto
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public int SelectedOptionId { get; set; }
        public string SelectedOptionText { get; set; } = string.Empty;
        public DateTime AnsweredAt { get; set; }
        public string? UserAgent { get; set; }
        public string? IpAddress { get; set; }
    }

    public class OverallStatsDto
    {
        public int TotalUsers { get; set; }
        public int ActiveUsersLastWeek { get; set; }
        public int ActiveUsersLastMonth { get; set; }
        public int TotalAnswers { get; set; }
        public int TotalQuestions { get; set; }
        public double AverageAnswersPerUser { get; set; }
        public List<PopularDestinationDto> PopularDestinations { get; set; } = new();
        public List<QuestionStatsDto> QuestionStats { get; set; } = new();
        public List<DailyActivityDto> DailyActivity { get; set; } = new();
    }

    public class PopularDestinationDto
    {
        public int DestinationId { get; set; }
        public string DestinationName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public int TimesRecommended { get; set; }
        public double Percentage { get; set; }
    }

    public class QuestionStatsDto
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public int TotalAnswers { get; set; }
        public List<OptionStatsDto> OptionStats { get; set; } = new();
    }

    public class OptionStatsDto
    {
        public int OptionId { get; set; }
        public string OptionText { get; set; } = string.Empty;
        public int Count { get; set; }
        public double Percentage { get; set; }
    }

    public class DailyActivityDto
    {
        public DateTime Date { get; set; }
        public int NewUsers { get; set; }
        public int TotalAnswers { get; set; }
        public int ActiveUsers { get; set; }
    }
}