using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Playwright;
using ZiggyCreatures.Caching.Fusion;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddFusionCache();

builder.Services.AddRateLimiter(_ => _
    .AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit = 8;
        options.Window = TimeSpan.FromSeconds(10);
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        options.QueueLimit = 100;
    }));

builder.Services.AddHttpLogging(o => { });

var app = builder.Build();

app.UseRateLimiter();

using var pw = await Playwright.CreateAsync();
var browser = await pw.Chromium.LaunchAsync();

app.MapGet("/screenshot", async (
        IFusionCache fusionCache,
        [FromQuery] [Required] Uri uri,
        [FromQuery] int width = 1200,
        [FromQuery] int height = 800
    ) =>
    {
        var buffer = await fusionCache.GetOrSetAsync<byte[]>(
            $"screenshot:{uri}:{width}:{height}", async _ =>
            {
                var page = await browser.NewPageAsync(new BrowserNewPageOptions
                {
                    ViewportSize = new ViewportSize
                    {
                        Width = width,
                        Height = height
                    }
                });

                await page.GotoAsync(uri.ToString());

                return await page.ScreenshotAsync();
            },
            TimeSpan.FromMinutes(1)
        );

        return TypedResults.File(buffer, "image/png", $"{uri.Host}.png");
    })
    .RequireRateLimiting("fixed");

app.UseHttpLogging();

app.Run();