﻿namespace MiniSpace.Services.Reports.Core.Entities
{
    public class Report : AggregateRoot
    {
        public Guid IssuerId { get; private set; }
        public Guid TargetId { get; private set; }
        public ContextType ContextType { get; private set; }
        public ReportCategory Category { get; private set; }
        public string Reason { get; private set; }
        public ReportStatus Status { get; private set; }
        public DateTime CreatedAt { get; private set; }
        
        public Report(Guid id, Guid issuerId, Guid targetId, ContextType contextType, ReportCategory category,
            string reason, ReportStatus status, DateTime createdAt)
        {
            Id = id;
            IssuerId = issuerId;
            TargetId = targetId;
            ContextType = contextType;
            Category = category;
            Reason = reason;
            Status = status;
            CreatedAt = createdAt;
        }
    }
}