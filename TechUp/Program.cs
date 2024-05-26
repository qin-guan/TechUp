using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Playwright;
using ZiggyCreatures.Caching.Fusion;

var builder = WebApplication.CreateSlimBuilder(args);

builder.Services.AddFusionCache();

var app = builder.Build();

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
});

app.Run();