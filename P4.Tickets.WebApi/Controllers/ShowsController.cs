using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P4.Tickets.WebApi.Contract;

namespace P4.Tickets.WebApi.Controllers
{
    [ApiController]
    [Route("api/v1/shows")]
    public class ShowsController : ControllerBase
    {
        private readonly ILogger<ShowsController> _logger;
        private readonly ShowsRepository _showsRepository;

        public ShowsController(ILogger<ShowsController> logger, ShowsRepository showsRepository)
        {
            _logger = logger;
            _showsRepository = showsRepository;
        }

        [HttpGet]
        public async Task<ShowSummaryModel[]> GetAsync()
        {
            return await _showsRepository.GetAsync();
        }
        
        [HttpGet("{showId}")]
        public async Task<ActionResult<ShowDetailsModel>> GetAsync(string showId) 
            => await _showsRepository.GetAsync(showId) is ShowDetailsModel show ? Ok(show) : NotFound();
    }

    public class ShowsRepository
    {
        private readonly List<ShowDetailsModel> _shows = new()
        {
            new ShowDetailsModel("saved-by-the-ring-bell", 
                "superstar-pro-wrestling", 
                "Saved By The Ring Bell", 
                "Superstar Pro Wrestling",
                "Match Card: \n\nSingles Match\nEthan Kelly vs.Isaac North\n\nSingles Match\nHannah Taylor vs.Harley Hudson\n\nSingles Match\nConor Clyne vs.Tom Billington\n\nSingles Match\nAlfie Brooks vs.Jordan Black\n\nSingles Match\nBrian Aidenson vs.Mark Billington\n\nTag Team Match\nDean Allmark & James Reid vs.JJ Webb & Sam Bailey",
                12,
                new DateTime(2021, 8, 7, 12, 0, 0),
                "1 Musland Road, Kirby, Liverpool, L32 6QW",
                "liverpool-kirby",
                TicketStatus.Available,
                "https://p4-itops-images-cdn-prd.azureedge.net/content/superstar-pro-wrestling/saved-by-the-ring-bell/2021915-saved-by-the-ring-bell-637672958708266224.jpg/jpeg?width=346&height=480&quality=30",
                "https://p4-itops-images-cdn-prd.azureedge.net/content/superstar-pro-wrestling/saved-by-the-ring-bell/2021915-saved-by-the-ring-bell-637672958785046974.jpg/jpeg?width=2048&height=1072&quality=50"
            ),
            new ShowDetailsModel("set-sail", 
                "odyssey-pro-wrestling", 
                "Set Sail", 
                "Odyssey Pro Wrestling",
                "Match Card: \n\nSingles Match\nLance Revera vs. Rick Markus\n\nTag Team Match\nSinergy (Anderson Daniels & Troy Ryan) vs. Freakshow (Nightmare & Will Carter) (w/Isaiah Quinn)\n\nOpen Challenge Match\nSexy Kev vs. Tu Byt\n\nSingles Match\nGia Adams vs. Taonga\n\nSingles Match\nScotty Rawk vs. RP Davies\n\nSingles Match\nLucas Neon vs. Mark Meltzer\n\nTag Team Match\nChris Ridgeway & Ryan Hunter vs. Big Guns Joe & JJ Webb",
                12,
                new DateTime(2021, 8, 7, 18, 0, 0),
                "The Carleton, Marine Road, Morecambe, LA4 4EU",
                "carlton-morecambe",
                TicketStatus.Available,
                "https://p4-itops-images-cdn-prd.azureedge.net/content/odyssey-pro-wrestling/set-sail/202195-set-sail-637664378849171249.jpg/jpeg?width=346&height=480&quality=30",
                "https://p4-itops-images-cdn-prd.azureedge.net/content/odyssey-pro-wrestling/set-sail/202195-set-sail-637664378917026690.jpg/jpeg?width=2048&height=1072&quality=50"
            ),
            new ShowDetailsModel("outrage-2021", 
                "tnt-ignition", 
                "Outrage 2021", 
                "TNT Ignition",
                "Match Card:\n\nSingles Match\nMan Like Dereiss Vs Leyton Buzzard\n\nSingles Match\nNico Angelo Vs Chase Alexander\n\nSingles Match\nGene Munny Vs Scott Oberman\n\nTNT Igntion Championship Match\nSoner Dursun Vs Tom Thelwell\n\nIgnition Rumble",
                12,
                new DateTime(2021, 8, 7, 18, 0, 0),
                "Fusion Nightclub, Liverpool",
                "fusion-liverpool",
                TicketStatus.Available,
                "https://p4-itops-images-cdn-prd.azureedge.net/content/tnt-on-demand/outrage-2021/2021821-outrage-2021-637651442537659782.jpeg/jpeg?width=346&height=480&quality=30",
                "https://p4-itops-images-cdn-prd.azureedge.net/content/tnt-on-demand/outrage-2021/2021821-outrage-2021-637651442619254845.jpeg/jpeg?width=2048&height=1072&quality=50"
            ),
            
            new ShowDetailsModel("sirens-fury-2021", 
                "tnt-extreme-wrestling", 
                "Sirens Fury 2021", 
                "TNT Extreme Wrestling",
                "Match Card: \n\nSingles Match\nEmersyn Jayne vs. Angel Hayze\n\nSingles Match\nRaven Creed vs. Aurora Teves\n\nSingles Match\nLana Austin vs. Molly Spartan (w/Kasey)\n\nSingles Match\nSession Moth Martina vs. Heidi Katrina\n\nTag Team Match\nGia Adams & Taonga vs. Pretty Little Killers (Ivy & Ruby Radley)\n\nTNT Women's Title Falls Count Anywhere Match\nLizzy Evo (c) vs. Alexxis Falcon",
                12,
                new DateTime(2021, 7, 31, 20, 0, 0),
                "Fusion Nightclub, Liverpool",
                "fusion-liverpool",
                TicketStatus.SoldOut,
                "https://p4-itops-images-cdn-prd.azureedge.net/content/tnt-on-demand/sirens-fury-2021/2021819-sirens-fury-2021-637649983559926840.jpg/jpeg?width=346&height=480&quality=30",
                "https://p4-itops-images-cdn-prd.azureedge.net/content/tnt-on-demand/sirens-fury-2021/2021819-sirens-fury-2021-637649897618357659.jpg/jpeg?width=2048&height=1072&quality=50"
            ),
            new ShowDetailsModel("slamaganza", 
                "the-lwf", 
                "Slamaganza", 
                "The Lancashire Wrestling Federation",
                "Match Card:\n\nShining Wizard Perform \"Kickstart My Heart\" \n\nWomen’s Tag Team Match\nHelana Razor & Kelly Van Ness Vs Slay All Day \n\nCastle Cup Semi Final: \nBob Koston Vs Jack Roberts \n\nCastle Cup Semi Final: \nNick Kutter Vs Chris Stone \n\nSingles Match\nDavey Getski Vs Nathan Gunn \n\nTag Team Match\nShining Wizard Vs Sinergy \n\nThe Castle Cup Final \n\nLWF Championship Match (Brother in Law Vs Brother in Law) \nClassic Carl Clinch Vs Raynaldo",
                12,
                new DateTime(2021, 8, 7, 12, 0, 0),
                "Lancashire",
                "lancashire",
                TicketStatus.Available,
                "https://p4-itops-images-cdn-prd.azureedge.net/content/the-lwf/slamaganza/202191-slamaganza-637661079921246509.jpg/jpeg?width=346&height=480&quality=30",
                "https://p4-itops-images-cdn-prd.azureedge.net/content/the-lwf/slamaganza/202191-slamaganza-637661224306351429.jpg/jpeg?width=2048&height=1072&quality=50"
            ),
            new ShowDetailsModel("total-carnage-2021", 
                "tnt-extreme-wrestling", 
                "Total Carnage 2021", 
                "TNT Extreme Wrestling",
                "Match Card: \n\nTotal Carnage Tournament First Round Lego Death Match\nSession Moth Martina vs. Kira Chimera\n\nTotal Carnage Tournament First Round Drawing Pins Death Match\nKasey vs. Alexxis Falcon\n\nTotal Carnage Tournament First Round Carpet Strips Death Match\nEmersyn Jayne vs. Raven Creed\n\nTotal Carnage Tournament First Round Kendo Sticks Death Match\nMolly Spartan vs. Gia Adams\n\nTotal Carnage Tournament Semi Final Light Tubes and Tables Death Match\n??? vs. ???\n\nTotal Carnage Tournament Semi Final Barbed Wire Chairs Death Match\n??? vs. ???\n\nTotal Carnage Tournament Final Ultimate Death Match\n??? vs. ???",
                12,
                new DateTime(2021, 7, 30, 20, 0, 0),
                "Fusion Nightclub, Liverpool",
                "fusion-liverpool",
                TicketStatus.Available,
                "https://p4-itops-images-cdn-prd.azureedge.net/content/tnt-on-demand/total-carnage-2021/2021819-total-carnage-2021-637649983342610482.jpg/jpeg?width=346&height=480&quality=30",
                "https://p4-itops-images-cdn-prd.azureedge.net/content/tnt-on-demand/total-carnage-2021/2021816-total-carnage-2021-637647112471009940.jpg/jpeg?width=2048&height=1072&quality=50"
            ),
            new ShowDetailsModel("skys-the-limit-2021", 
                "tnt-ignition", 
                "Sky's The Limit 2021", 
                "TNT Ignition",
                "Match Card: \n\nSingles Match\nNico Angelo vs. Leyton Buzzard\n\nSingles Match\nSoner Dursun vs. Tom Thelwell\n\nTag Team Match\nCrashboat (Jack Bandicoot & Jake Silver) vs. Made To Last (Leon Grey & Ryan Thorn)\n\nSingles Match\nAlexxis Falcon vs. Aurora Tevas\n\nBriefcase On The Line Match\nKameron Solas vs. Scott Oberman",
                12,
                new DateTime(2021, 6, 27, 20, 0, 0),
                "Fusion Nightclub, Liverpool",
                "fusion-liverpool",
                TicketStatus.Available,
                "https://p4-itops-images-cdn-prd.azureedge.net/content/tnt-on-demand/skys-the-limit-2021/2021726-skys-the-limit-2021-637629269546788146.jpg/jpeg?width=346&height=480&quality=30",
                "https://p4-itops-images-cdn-prd.azureedge.net/content/tnt-on-demand/skys-the-limit-2021/2021726-skys-the-limit-2021-637629272757168049.jpg/jpeg?width=2048&height=1072&quality=50"
            ),
            new ShowDetailsModel("going-off-big-time-2021", 
                "tnt-extreme-wrestling", 
                "Going Off Big Time 2021", 
                "TNT Extreme Wrestling",
                "Match Card: \n\nTNT Tag Team Title Match\nKings Of The North (Bonesaw & Damien Corvin) (c) vs. The Young Guns (Ethan Allen & Luke Jacobs)\n\nSingles Match\nSoner Dursun vs. Dan Moloney\n\nTNT Women's Title Match\nLizzy Evo (c) vs. Alexxis Falcon\n\nTNT Ultra X Title Match\nKid Lykos II (c) vs. Leyton Buzzard\n\nTag Team Match\nMariah May & Zoe Lucas vs. She-Wolves (Kasey & Molly Spartan) (w/Lana Austin)\n\nTNT Extreme Division Title Four Way Match (vacant)\nJack Jester vs. Big Joe vs. BT Gunn vs. Clint Margera",
                12,
                new DateTime(2021, 7, 30, 20, 0, 0),
                "Fusion Nightclub, Liverpool",
                "fusion-liverpool",
                TicketStatus.SoldOut,
                "https://p4-itops-images-cdn-prd.azureedge.net/content/tnt-on-demand/going-off-big-time-2021/2021717-going-off-big-time-2021-637621224827325448.jpg/jpeg?width=346&height=480&quality=30",
                "https://p4-itops-images-cdn-prd.azureedge.net/content/tnt-on-demand/going-off-big-time-2021/2021717-going-off-big-time-2021-637621224992512014.jpg/jpeg?width=2048&height=1072&quality=50"
            ),
            new ShowDetailsModel("saturday-night-grapplemasters-2", 
                "chicagoland-championship-wrestling", 
                "Saturday Night Grapplemasters 2", 
                "Chicagoland Championship Wrestling",
                "Match Card: \n\nUHC Title Match:\nJay Kross vs The Ewok\n\nSingles Match \nNelson Edwin Robert Doolittle V Vs Garrisaon Creed\n\n6 Man Tag Match\nSin City Playboys Vs Gunner Brave & Country Air\n\nSingles Match\nMarshe Rockett vs Chris Moore\n\nTag Match\nNo Coast vs The Tribunal\n\n6 Man Tag Match\nThe ARC vs Braven Fett, Yoya and Janai Kai\n\nSingles Match\nChris Owens Vs Chip Walker\n\nNo. 1 Contendership Match for IWRG Tag Titles \nThe Outrunners Vs Youth Gone Wild\n\nChicagoland Heavyweight Championship Match\nSteve Michael Vs Chris L.O.G.A.N (c)",
                12,
                new DateTime(2021, 7, 30, 20, 0, 0),
                "Chicago",
                "chicago",
                TicketStatus.SoldOut,
                "https://p4-itops-images-cdn-prd.azureedge.net/content/chicagoland-championship-wrestling/saturday-night-grapplemasters-2/2021717-saturday-night-grapplemasters-2-637621180529635812.jpg/jpeg?width=346&height=480&quality=30",
                "https://p4-itops-images-cdn-prd.azureedge.net/content/chicagoland-championship-wrestling/saturday-night-grapplemasters-2/2021717-saturday-night-grapplemasters-2-637621183818134684.jpg/jpeg?width=2048&height=1072&quality=50"
            ),
            new ShowDetailsModel("who-are-ya", 
                "this-is-wrestling", 
                "Who Are Ya", 
                "This Is Wrestling",
                "Match Card: \n\nSingles Match\nSandy Beach Vs Matt Brooks\n\nTriple Threat Match \nKenny Killbaine Vs Rick Markus Vs Drill\n\nSingles Match\nSean Only Vs Jacob North\n\nLoser Leaves TIW  \nBig Joe Vs Seymour Gains\n\nSingles Match\nBabyface Pitbull Vs Rizzy Ash\n\nWomens Singles Match\nDominita Vs Rhio\n\nWinner Takes All Match \nJJ Webb Vs Ethan Allen\n\nSingles Match\nPhilip Michael Vs Soner Dursun",
                12,
                new DateTime(2021, 7, 30, 20, 0, 0),
                "Upholland Labour Club, Skelmersdale",
                "upholland-labour-club-skelmersdale",
                TicketStatus.Available,
                "https://p4-itops-images-cdn-prd.azureedge.net/content/this-is-wrestling/who-are-ya/2021728-who-are-ya-637631005151161790.jpg/jpeg?width=346&height=480&quality=30",
                "https://p4-itops-images-cdn-prd.azureedge.net/content/this-is-wrestling/who-are-ya/2021728-who-are-ya-637631007835709502.jpg/jpeg?width=2048&height=1072&quality=50"
            ),
            new ShowDetailsModel("pwa-10-year-anniversary", 
                "pro-wrestling-allstars", 
                "PWA 10 YEAR ANNIVERSARY", 
                "Pro Wrestling Alliance",
                "Match Card: \n\nSingles Match\nSandy Beach Vs Matt Brooks\n\nTriple Threat Match \nKenny Killbaine Vs Rick Markus Vs Drill\n\nSingles Match\nSean Only Vs Jacob North\n\nLoser Leaves TIW  \nBig Joe Vs Seymour Gains\n\nSingles Match\nBabyface Pitbull Vs Rizzy Ash\n\nWomens Singles Match\nDominita Vs Rhio\n\nWinner Takes All Match \nJJ Webb Vs Ethan Allen\n\nSingles Match\nPhilip Michael Vs Soner Dursun",
                12,
                new DateTime(2018, 3, 24, 20, 0, 0),
                "Zaal De Brug (Libertus), Mechelen",
                "zaal-de-brug",
                TicketStatus.SoldOut,
                "https://p4-itops-images-cdn-prd.azureedge.net/content/pro-wrestling-allstars/pwa-10-year-anniversary/2021811-pwa-10-year-anniversary-637643008181287685.jpg/jpeg?width=346&height=480&quality=30",
                "https://p4-itops-images-cdn-prd.azureedge.net/content/pro-wrestling-allstars/pwa-10-year-anniversary/2021811-pwa-10-year-anniversary-637643009865031431.jpg"
            ),
            new ShowDetailsModel("pwa-sole-survivor-ii", 
                "pro-wrestling-allstars", 
                "PWA SOLE SURVIVOR II", 
                "Pro Wrestling Alliance",
                "MATCH CARD:\n\nSingles Match\nNate Devlin vs. Mark Benjamin\n\nSix Man Tag Team Match\nJimmy Lightning, Keith Mercer & Scotty Valentine (w/Jessie Jones) vs. Danny Sparks, Joel Vox & Rami Romeo\n\nPWA DareDevil Title Steel Chain Match\nSteve Venom vs. Spike Bones (c)\n\nPWA Queen Of Diamonds Title Three Way Match\nKiller Kelly vs. Isla Dawn vs. Audrey Bride (c)\n\nPWA Tag Team Title / PWA European Allstar Title Match\nThe Warriors of the World (Rex Rage (c) & Rob Raw) vs. Nitro (c) & Johnny Evers\n\nPWA European Allstar Title 30 Man Sole Survivor Match\nRex Rage (c) vs. Steve Venom vs. Rob Raw vs. Boomer vs. Lloyd Pengel vs. Young Money Chong vs. Johnny Evers vs. Jimmy Lightning vs. Audrey Bride vs. TNK vs. Isla Dawn vs. Scotty Valentine vs. Nitro vs. Daniel Montanus vs. Danny Sparks vs. Keith Mercer vs. Nate Devlin vs. Rami Romeo vs. Timo Zimone vs. Killer Kelly vs. Joel Vox vs. Maverick Rennson vs. Mark Benjamin vs. Asriel Walker vs. Jay List vs. Johnny Truant vs. Kemo vs. Sam Bellamy vs. Sarah-Elisa Hayes",
                12,
                new DateTime(2018, 3, 24, 20, 0, 0),
                "Feestpaleis, Boom",
                "feestpaleis-boom",
                TicketStatus.SoldOut,
                "https://p4-itops-images-cdn-prd.azureedge.net/content/pro-wrestling-allstars/pwa-sole-survivor-ii/202184-pwa-sole-survivor-ii-637636905753856932.jpg/jpeg?width=346&height=480&quality=30",
                "https://p4-itops-images-cdn-prd.azureedge.net/content/pro-wrestling-allstars/pwa-sole-survivor-ii/202184-pwa-sole-survivor-ii-637636905839912382.jpg"
            )
        };

        public async Task<ShowSummaryModel[]> GetAsync() => 
            await Task.FromResult(_shows.Select(s 
                    => new ShowSummaryModel
                        (
                            s.ShowId,
                            s.PromotionId,
                            s.Name,
                            s.PromotionName,
                            s.Price,
                            s.StartDate,
                            s.Location,
                            s.LocationId,
                            s.TicketStatus,
                            s.ImageUri
                        )).ToArray());
        
        
        public async Task<ShowDetailsModel?> GetAsync(string showId) => 
            await Task.FromResult(_shows.SingleOrDefault(s => s.ShowId.Equals(showId, StringComparison.InvariantCultureIgnoreCase)));
    }
}