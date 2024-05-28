// See https://aka.ms/new-console-template for more information

using Microsoft.Playwright;

var sites = new List<string>
{
    "https://periodpal.cc",
    "https://muslimpraygowhere.com",
    "https://www.readyknot.co",
    "https://trackmyprotein.org",
    "https://familytime.work",
    "https://wheremymoney.work",
    "https://kokhing.org",
    "https://weekendgowhere.net",
    "https://sgnaturecalls.com",
    "https://coach-codi.org",
    "https://mindyourlanguage.cc",
    "https://ready-daddy.com",
    "https://singalore.app",
    "https://helpchecksg.com",
    "https://trilingotots.com",
    "https://what2cook.xyz",
    "https://my-family-recipes.com",
    "https://kaypohusefully.org",
    "https://lookmeup.org",
    "https://wealthup.cc",
    "https://tourgether.xyz",
    "https://estategiveaway.org",
    "https://acivilexchange.org",
    "https://sgeatwhere.com",
    "https://offthebeatentrack.app",
    "https://dunsaybojio.net",
    "https://govconnect.club",
    "https://shadesshare.com",
    "https://sipherbs.org",
    "https://huhwhatsthis.org",
    "https://aihubapp.com",
    "https://worthit.cc",
    "https://studybuddy.work",
    "https://caifancaloriecounter.com",
    "https://sayknowtoscams.com",
    "https://saynotopfas.com",
    "https://housemuch.app",
    "https://bestpricesg.org",
    "https://fixmyhdb.com",
    "https://hikelah.onrender.com",
    "https://reportyourissue.org",
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
    "https://simple-abbreviation-finder.com",
    "https://bulkyway.work",
    "https://pawfridge.com",
    "https://spellingbee.cc",
    "https://whatsdonewhatsnot.com/",
    "https://grantopia.work",
    "https://techup-proj.work",
    "https://project-elysium.com",
    "https://giftacheer.org",
    "https://chefrebel.org"
}.Select(e => new Uri(e)).ToList();

using var pw = await Playwright.CreateAsync();
var browser = await pw.Chromium.LaunchAsync();

var failed = "";

var tasks = sites.Select(async site =>
{
    try
    {
        Console.WriteLine($"Loading {site}");
        var page = await browser.NewPageAsync(new BrowserNewPageOptions
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
        Console.WriteLine($"Done loading {site}");
    }
    catch
    {
        Console.WriteLine($"Failed to load {site}");
        failed += $"Failed to load {site}\n";
    }
});

await Task.WhenAll(tasks);

Console.WriteLine(failed);