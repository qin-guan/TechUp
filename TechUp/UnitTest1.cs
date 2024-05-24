using Microsoft.Playwright;

namespace TechUp;

[Parallelizable(ParallelScope.Children)]
[TestFixture]
public class Tests : BrowserTest
{
    [Test, TestCaseSource(nameof(Websites))]
    public async Task GenerateScreenshots(Uri site)
    {
        try
        {
            var page = await Browser.NewPageAsync();
            await page.GotoAsync(site.ToString());
            await page.ScreenshotAsync(new PageScreenshotOptions()
            {
                Path = $"./output/{site.Host}.jpeg",
                Quality = 100
            });
        }
        catch
        {
            Console.WriteLine($"Failed to load {site}");
        }
    }

    public static List<Uri> Websites()
    {
        return new List<string>
        {
            "https://brainstogether.one", "https://cannot.app/", "https://icebreakerdowhat.com/",
            "https://snso-tools.space", "https://stepsgowhere.net", "https://www.joel-tan.com/", "https://rekki.xyz",
            "https://backtobp.one", "https://www.digitraining.pro", "https://seasonparking.shop/",
            "https://www.singaporenursingroom.com/", "https://paychecked.info", "https://cafegowhere.co",
            "https://www.nekotoinu.cc/", "https://www.chairgpt.pro", "https://www.halalgowheresg.info/",
            "https://parkwhere.net", "http://taskprioritization.xyz/", "https://dylanwkw.com",
            "https://stayhere.dowhat.ohemgee.net", "https://introspeaction.com/", "https://pm-calculator.com",
            "https://pantrybooking.com", "https://grocerlisticated.site", "http://msw.tools/",
            "https://airqualitychecker.net", "https://www.keeporthrow.com", "https://www.examrevisionplanner.com",
            "https://learnmusicalnotes.com", "https://www.shoplistapp.com/", "https://chatwitus.com/",
            "https://digicareer.coach", "https://takestock.day", "https://leaveplanner.online/",
            "https://www.vicfindbook.net/", "https://brewbuddy.site/", "https://trades.arifshehab.com/",
            "https://findmentor.co/", "https://thefeelingjournal.com", "https://grocerytracker.online/",
            "https://isbonniehungry.com", "https://modernmulans.com/", "https://www.mindergap.com",
            "https://kidexpensetracker.com/", "https://checkthescam.com", "https://asimplelist.com",
            "https://whatsnack.click", "https://www.halaleats.asia/", "https://www.buyorbuynot.com/",
            "https://decideforme.today/", "https://omgjjbuiltawebsite.onrender.com", "https://www.jiojalan.com/",
            "https://zrhomework.com/", "https://www.snackandrun.com/", "http://virtual-usher.co",
            "https://bobaboard.co/bobaboard", "https://ngep-dashboard.abilashsivalingam.com",
            "https://naptrack.growingpancakes.com/", "https://hangry-go-where.com/", "https://govlinkchecker.com",
            "https://www.milesvscashbacksg.xyz", "https://savemyinvite.app/", "https://laujingpeng.com",
            "https://helpcomehere.com", "https://seccy.app/", "https://fussfreetour.onrender.com/",
            "https://ccrewards.pro", "https://lumnut.art", "https://whichfurnitureshoptogo.com",
            "https://ngrenae.github.io/take6/", "https://www.ratemylibrary.club/", "https://dashboardsg.augalice.com/"
        }.Select(e => new Uri(e)).ToList();
    }
}