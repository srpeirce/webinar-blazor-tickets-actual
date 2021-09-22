using System;

namespace P4.Tickets.WebApi.Contract
{
    public record ShowSummaryModel(
        string ShowId, 
        string PromotionId, 
        string Name, 
        string PromotionName,
        decimal Price,
        DateTime StartDate,
        string Location, 
        string LocationId,
        string TicketStatus,
        string ImageUri);
    
    /*
     * Example to speed up writing unit tests :-)
     *
     * ShowSummaryModel show = new("saved-by-the-ring-bell", 
            "superstar-pro-wrestling", 
            "Saved By The Ring Bell", 
            "Superstar Pro Wrestling",
            12,
            new DateTime(2021, 8, 7, 12, 0, 0),
            "1 Musland Road, Kirby, Liverpool, L32 6QW",
            "liverpool-kirby",
            TicketStatus.Available,
            "https://p4-itops-images-cdn-prd.azureedge.net/content/superstar-pro-wrestling/saved-by-the-ring-bell/2021915-saved-by-the-ring-bell-637672958708266224.jpg/jpeg?width=346&height=480&quality=30"
        );
     */
}