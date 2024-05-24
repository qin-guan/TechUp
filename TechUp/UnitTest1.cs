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
            var page = await Browser.NewPageAsync(new BrowserNewPageOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1200,
                    Height = 800
                }
            });
            await page.GotoAsync(site.ToString());
            await page.ScreenshotAsync(new PageScreenshotOptions()
            {
                Path = $"./output/{site.Host}.png",
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
            "https://periodpal.cc",
            "https://muslimpraygowhere.com/",
            "https://www.readyknot.co/",
            "https://trackmyprotein/",
            "https://familytime.work/",
            "https://wheremymoney.work/",
            "https://kokhing.org",
            "https://weekendgowhere.net",
            "https://sgnaturecalls.com/",
            "https://coach-codi.org",
            "https://mindyourlanguage.cc",
            "https://singalore.app",
            "https://helpchecksg.com",
            "https://trilingotots.com",
            "https://What2Cook.xyz",
            "https://my-family-recipes.com",
            "https://kaypohusefully.org",
            "https://lookmeup.org",
            "https://wealthup.cc/",
            "https://tourgether.xyz/",
            "https://estategiveaway.org",
            "https://aCivilExchange.org",
            "https://sgeatwhere.com",
            "https://sgeatwhere.onrender.com/",
            "https://offthebeatentrack.app",
            "https://dunsaybojio.net/",
            "https://shadesshare.com/",
            "https://huhwhatsthis.org",
            "https://aihubapp.com/",
            "https://worthit.cc",
            "https://caifancaloriecounter.com",
            "https://sayknowtoscams.com",
            "https://saynotopfas.com",
            "https://housemuch.app",
            "https://bestpricesg.org",
            "https://fixmyhdb.com",
            "https://hikelah.onrender.com/",
            "https://reportyourissue.org/",
            "https://balancefithub.com",
            "https://brewview.app",
            "https://kidsgowhere.org",
            "https://pawright.org",
            "https://project-monitoring.org",
            "https://tilt-app.org",
            "https://sghospitalshuttle.com",
            "https://SpellBuddy.net",
            "https://caffeinewise.app",
            "https://lelong.cc",
            "https://tracktime.work",
            "https://bulkyway.work/",
            "https://pawfridge.com/",
            "https://SpellingBee.CC",
            "https://grantopia.work/",
            "https://techup-proj.work",
            "https://project-elysium.com",
            "https://giftacheer.org",
            "https://chefrebel.org"
        }.Select(e => new Uri(e)).ToList();
    }
}