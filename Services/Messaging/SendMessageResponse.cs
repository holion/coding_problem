namespace coding_problem.Services.Messaging;

public sealed record SendMessageResponse(bool IsSuccess, string? ErrorMessage);