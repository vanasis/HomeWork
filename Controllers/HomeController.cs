using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Sample.Models;

namespace Sample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    #region Data
    private List<Province> Data()
    {
        var provinces = new List<Province>();

        // Add Records
        provinces.Add(new Province()
        {
            Name = "تهران",
            Cities = new List<City>()
            {
                new City(){Name="دماوند", Streets = new List<Street>(){
                    new Street(){Name = "گوهردشت"},
                    new Street(){Name = "رجائی"},
                    new Street(){Name = "حسن آباد"},
                }},
                new City(){Name="پردیس", Streets = new List<Street>(){
                    new Street(){Name = "گلستان"},
                    new Street(){Name = "هنر"},
                }},
            }
        });

        provinces.Add(new Province()
        {
            Name = "اصفهان",
            Cities = new List<City>()
            {
                new City(){Name="کاشان", Streets = new List<Street>(){
                    new Street(){Name = "بهارستان"},
                    new Street(){Name = "مرادی"},
                    new Street(){Name = "بیست متری"},
                }},
                new City(){Name="نجف آباد", Streets = new List<Street>(){
                    new Street(){Name = "باهنر"},
                    new Street(){Name = "طالقانی"},
                }},
                new City(){Name="گلپایگان", Streets = new List<Street>(){
                    new Street(){Name = "مطهری"},
                    new Street(){Name = "طرشت"},
                    new Street(){Name = "صادقیه"},
                }},
            }
        });

        return provinces;
    }
    #endregion


    public IActionResult Province()
    {
        var province = Data();
        return View(model: province);
    }

    public IActionResult City(string provinceName)
    {
        var cities = Data()
                .FirstOrDefault(e => e.Name == provinceName)?
                .Cities;

        ViewBag.ProvinceName = provinceName;
        return View(model: cities);
    }

    public IActionResult Street(string provinceName, string cityName)
    {
        var streets = Data()
                .FirstOrDefault(e => e.Name == provinceName)?
                .Cities?
                .FirstOrDefault(e => e.Name == cityName)?
                .Streets;

        ViewBag.ProvinceName = provinceName;
        ViewBag.cityName = cityName;

        return View(model: streets);
    }
}
