using System;

namespace P4.Tickets.WebApi.Contract
{
    public record ShowDetailsModel(
        string ShowId, 
        string PromotionId, 
        string Name, 
        string PromotionName, 
        string Description, 
        decimal Price,
        DateTime StartDate,
        string Location, 
        string LocationId,
        string TicketStatus,
        string ImageUri,
        string HeroImageUri);
}